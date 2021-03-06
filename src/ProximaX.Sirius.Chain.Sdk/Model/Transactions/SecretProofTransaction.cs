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
using System.Globalization;
using System.Runtime.Serialization;
using FlatBuffers;
using GuardNet;
using ProximaX.Sirius.Chain.Sdk.Buffers;
using ProximaX.Sirius.Chain.Sdk.Buffers.Schema;
using ProximaX.Sirius.Chain.Sdk.Model.Accounts;
using ProximaX.Sirius.Chain.Sdk.Model.Blockchain;
using ProximaX.Sirius.Chain.Sdk.Utils;

namespace ProximaX.Sirius.Chain.Sdk.Model.Transactions
{
    public class SecretProofTransaction : Transaction
    {
        public SecretProofTransaction(NetworkType networkType, int version, Deadline deadline, ulong? maxFee,
            HashType hashType,Recipient recipient, string secret, string proof, string signature = null, PublicAccount signer = null,
            TransactionInfo transactionInfo = null)
            : base(networkType, version, EntityType.SECRET_PROOF, deadline, maxFee, signature, signer,
                transactionInfo)
        {
            Guard.NotNullOrEmpty(secret, "Secret must not be null");
            Guard.NotNullOrEmpty(proof, "Proof must not be null");
            Guard.NotNull(recipient, "Recipient must not be null");
            if (!hashType.Validate(secret))
                throw new ArgumentOutOfRangeException(
                    "HashType and Secret have incompatible length or not hexadecimal string");

            HashType = hashType;
            Proof = proof;
            Secret = secret;
            Recipient = recipient;
        }

        /// <summary>
        ///     The secret string in hex
        /// </summary>
        public string Secret { get; }


        /// <summary>
        ///     The Proof string in hex
        /// </summary>
        public string Proof { get; }

        /// <summary>
        ///     The Recipient
        /// </summary>
        public Recipient Recipient { get; }

        /// <summary>
        ///     Gets or sets the hash type.
        /// </summary>
        /// <value>The hash type.</value>
        public HashType HashType { get; }

        /// <summary>
        ///     Creates SecretProofTransaction
        /// </summary>
        /// <param name="deadline"></param>
        /// <param name="hashType"></param>
        /// <param name="secret"></param>
        /// <param name="proof"></param>
        /// <param name="networkType"></param>
        /// <returns></returns>
        public static SecretProofTransaction Create(Deadline deadline, HashType hashType,Recipient recipient, string secret, string proof,
            NetworkType networkType)
        {
            return new SecretProofTransaction(networkType, EntityVersion.SECRET_PROOF.GetValue(),
                deadline, 0, hashType, recipient, secret, proof);
        }

        public static int CalculatePayloadSize(Recipient recipient, string proof)
        {
            return +35 // recipient
              + recipient.GetBytes().Length // proof length
              + proof.DecodeHexString().Length;
        }

        protected override int GetPayloadSerializedSize()
        {
            return CalculatePayloadSize(Recipient, Proof);
        }

        internal override byte[] GenerateBytes()
        {
            var builder = new FlatBufferBuilder(1);


            // create vectors
            var signatureVector = SecretProofTransactionBuffer.CreateSignatureVector(builder, new byte[64]);
            var signerVector = SecretProofTransactionBuffer.CreateSignerVector(builder, GetSigner());
            var feeVector = SecretProofTransactionBuffer.CreateMaxFeeVector(builder, MaxFee?.ToUInt8Array());
            var deadlineVector =
                SecretProofTransactionBuffer.CreateDeadlineVector(builder, Deadline.Ticks.ToUInt8Array());
            var secretVector = SecretLockTransactionBuffer.CreateSecretVector(builder, Secret.DecodeHexString());
            var proofVector = SecretProofTransactionBuffer.CreateProofVector(builder, Proof.DecodeHexString());
            var version = int.Parse(NetworkType.GetValueInByte().ToString("X") + "0" + Version.ToString("X"),
                NumberStyles.HexNumber);
            var recipientVector = SecretProofTransactionBuffer.CreateRecipientVector(builder, Recipient.GetBytes());

            int totalSize = GetSerializedSize();
     

            SecretProofTransactionBuffer.StartSecretProofTransactionBuffer(builder);
            SecretProofTransactionBuffer.AddSize(builder, (uint)totalSize);
            SecretProofTransactionBuffer.AddSignature(builder, signatureVector);
            SecretProofTransactionBuffer.AddSigner(builder, signerVector);
            SecretProofTransactionBuffer.AddVersion(builder, (uint)version);
            SecretProofTransactionBuffer.AddType(builder, TransactionType.GetValue());
            SecretProofTransactionBuffer.AddMaxFee(builder, feeVector);
            SecretProofTransactionBuffer.AddDeadline(builder, deadlineVector);
            SecretProofTransactionBuffer.AddHashAlgorithm(builder, HashType.GetValueInByte());
            SecretProofTransactionBuffer.AddRecipient(builder, recipientVector);
            SecretProofTransactionBuffer.AddSecret(builder, secretVector);
            SecretProofTransactionBuffer.AddProofSize(builder, Convert.ToUInt16(Proof.DecodeHexString().Length));
            SecretProofTransactionBuffer.AddProof(builder, proofVector);

            var codedSecretProof = SecretProofTransactionBuffer.EndSecretProofTransactionBuffer(builder);
            builder.Finish(codedSecretProof.Value);

            var output = new SecretProofTransactionSchema().Serialize(builder.SizedByteArray());

            if (output.Length != totalSize) throw new SerializationException("Serialized form has incorrect length");

            return output;

          
        }
    }
}