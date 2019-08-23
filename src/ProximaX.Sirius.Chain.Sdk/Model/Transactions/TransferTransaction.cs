﻿// Copyright 2019 ProximaX
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using FlatBuffers;
using ProximaX.Sirius.Chain.Sdk.Buffers;
using ProximaX.Sirius.Chain.Sdk.Buffers.Schema;
using ProximaX.Sirius.Chain.Sdk.Model.Accounts;
using ProximaX.Sirius.Chain.Sdk.Model.Blockchain;
using ProximaX.Sirius.Chain.Sdk.Model.Mosaics;
using ProximaX.Sirius.Chain.Sdk.Model.Namespaces;
using ProximaX.Sirius.Chain.Sdk.Model.Transactions.Messages;
using ProximaX.Sirius.Chain.Sdk.Utils;

namespace ProximaX.Sirius.Chain.Sdk.Model.Transactions
{
    public class TransferTransaction : Transaction
    {
        public TransferTransaction(NetworkType networkType, int version, Deadline deadline, ulong? maxFee,
            Address recipient, List<Mosaic> mosaics, IMessage message, string signature = null,
            PublicAccount signer = null, TransactionInfo transactionInfo = null)
            : base(networkType, version, TransactionType.TRANSFER, deadline, maxFee, signature, signer, transactionInfo)
        {
            Address = recipient ?? throw new ArgumentNullException(nameof(recipient));
            Message = message ?? EmptyMessage.Create();
            Mosaics = mosaics;
        }

        public TransferTransaction(NetworkType networkType, int version, Deadline deadline, ulong? maxFee,
            NamespaceId recipient, List<Mosaic> mosaics, IMessage message, string signature = null,
            PublicAccount signer = null, TransactionInfo transactionInfo = null)
            : base(networkType, version, TransactionType.TRANSFER, deadline, maxFee, signature, signer, transactionInfo)
        {
            NamespaceId = recipient ?? throw new ArgumentNullException(nameof(recipient));
            Message = message ?? EmptyMessage.Create();
            Mosaics = mosaics;
        }

        public TransferTransaction(NetworkType networkType, int version, Deadline deadline, ulong? maxFee,
          Recipient recipient, List<Mosaic> mosaics, IMessage message, string signature = null,
          PublicAccount signer = null, TransactionInfo transactionInfo = null)
          : base(networkType, version, TransactionType.TRANSFER, deadline, maxFee, signature, signer, transactionInfo)
        {
            Recipient = recipient;
            Message = message ?? EmptyMessage.Create();
            Mosaics = mosaics;
        }

        public Recipient Recipient { get; }

        /// <summary>
        ///     Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; }

        /// <summary>
        ///  Get the namespace id
        /// </summary>
        public NamespaceId NamespaceId { get; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public IMessage Message { get; private set; }

        /// <summary>
        ///     Gets the mosaics.
        /// </summary>
        /// <value>The mosaics.</value>
        public List<Mosaic> Mosaics { get; }


        public static TransferTransaction Create(Deadline deadline, Address recipient, List<Mosaic> mosaics,
            IMessage message, NetworkType networkType, ulong? maxFee = 0)
        {
            return new TransferTransaction(networkType, TransactionVersion.TRANSFER.GetValue(), deadline, maxFee,
                recipient, mosaics, message);
        }

        public static TransferTransaction Create(Deadline deadline, NamespaceId recipient, List<Mosaic> mosaics,
            IMessage message, NetworkType networkType, ulong? maxFee = 0)
        {
            return new TransferTransaction(networkType, TransactionVersion.TRANSFER.GetValue(), deadline, maxFee,
                recipient, mosaics, message);
        }

        internal override byte[] GenerateBytes()
        {
            var builder = new FlatBufferBuilder(1);

            // create vectors
            var signatureVector = TransferTransactionBuffer.CreateSignatureVector(builder, new byte[64]);
            var signerVector = TransferTransactionBuffer.CreateSignerVector(builder, GetSigner());

            var feeVector = TransferTransactionBuffer.CreateMaxFeeVector(builder, MaxFee?.ToUInt8Array());
            var deadlineVector = TransferTransactionBuffer.CreateDeadlineVector(builder, Deadline.Ticks.ToUInt8Array());

            byte[] recipientBytes = Recipient.GetBytes();

            /*
            if (NamespaceId != null)
            {
                recipientBytes = NamespaceId.AliasToRecipient();
            }

            if (Address != null)
            {
                recipientBytes = Address.Plain.FromBase32String();
            }*/

            var recipientVector =
                TransferTransactionBuffer.CreateRecipientVector(builder, recipientBytes);
            var version = ushort.Parse(NetworkType.GetValueInByte().ToString("X") + "0" + Version.ToString("X"),
                NumberStyles.HexNumber);

            if (Message == null) Message = EmptyMessage.Create();

            // create message vector
            var bytePayload = Message.GetPayload();
            var payload = MessageBuffer.CreatePayloadVector(builder, bytePayload);
            MessageBuffer.StartMessageBuffer(builder);
            if (bytePayload != null) MessageBuffer.AddType(builder, Message.GetMessageType());
            MessageBuffer.AddPayload(builder, payload);
            var message = MessageBuffer.EndMessageBuffer(builder);

            // create mosaics vector
            var mosaics = new Offset<MosaicBuffer>[Mosaics.Count];
            for (var index = 0; index < Mosaics.Count; index++)
            {
                var mosaic = Mosaics[index];
                var idPayload = MosaicBuffer.CreateIdVector(builder, mosaic.Id.ToUInt8Array());
                var amountVector = MosaicBuffer.CreateAmountVector(builder, mosaic.Amount.ToUInt8Array());
                MosaicBuffer.StartMosaicBuffer(builder);
                MosaicBuffer.AddId(builder, idPayload);
                MosaicBuffer.AddAmount(builder, amountVector);

                mosaics[index] = MosaicBuffer.EndMosaicBuffer(builder);
            }

            var fixedSize = HEADER_SIZE 
                + 25 // recipient
                + 2 // message size
                + 1 // message type
                + 1 // no of mosaics
                + (16 * Mosaics.Count) //each mosaic has id(8bytes) and amount(8bytes)
                + bytePayload.Length; // number of message bytes

            var mosaicsVector = TransferTransactionBuffer.CreateMosaicsVector(builder, mosaics);
            // add vectors
            TransferTransactionBuffer.StartTransferTransactionBuffer(builder);
            TransferTransactionBuffer.AddSize(builder, (uint) fixedSize);
            TransferTransactionBuffer.AddSignature(builder, signatureVector);
            TransferTransactionBuffer.AddSigner(builder, signerVector);
            TransferTransactionBuffer.AddVersion(builder, version);
            TransferTransactionBuffer.AddType(builder, TransactionType.TRANSFER.GetValue());
            TransferTransactionBuffer.AddMaxFee(builder, feeVector);
            TransferTransactionBuffer.AddDeadline(builder, deadlineVector);
            TransferTransactionBuffer.AddRecipient(builder, recipientVector);
            TransferTransactionBuffer.AddNumMosaics(builder, (byte) Mosaics.Count);
            TransferTransactionBuffer.AddMessageSize(builder, (ushort)(bytePayload.Length + 1));
            TransferTransactionBuffer.AddMessage(builder, message);
            TransferTransactionBuffer.AddMosaics(builder, mosaicsVector);
           
            // end build
            var codedTransfer = TransferTransactionBuffer.EndTransferTransactionBuffer(builder);
            builder.Finish(codedTransfer.Value);

            // validate size
            var output = new TransferTransactionSchema().Serialize(builder.SizedByteArray());

            if (output.Length != fixedSize) throw new SerializationException("Serialized form has incorrect length");

            return output;
        }
    }
}