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
using System.Linq;
using Newtonsoft.Json.Linq;
using ProximaX.Sirius.Sdk.Infrastructure.DTO;
using ProximaX.Sirius.Sdk.Model.Accounts;
using ProximaX.Sirius.Sdk.Model.Blockchain;
using ProximaX.Sirius.Sdk.Model.Transactions;
using ProximaX.Sirius.Sdk.Utils;

namespace ProximaX.Sirius.Sdk.Infrastructure.Mapping
{
    /// <summary>
    ///     Class ModifyAccountPropertyTransactionAddressMapping
    /// </summary>
    public class ModifyAccountPropertyTransactionAddressMapping : TransactionMapping
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModifyAccountPropertyTransaction&lt;Address&gt;" /> class.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public new ModifyAccountPropertyTransaction<Address> Apply(JObject input)
        {
            return ToModifyAccountPropertyTransaction(input, TransactionMappingHelper.CreateTransactionInfo(input));
        }

        /// <summary>
        ///     ToModifyAccountPropertyTransaction
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="txInfo"></param>
        /// <returns></returns>
        private static ModifyAccountPropertyTransaction<Address> ToModifyAccountPropertyTransaction(JObject tx,
            TransactionInfo txInfo)
        {
            var transaction = tx["transaction"].ToObject<JObject>();
            var version = transaction["version"].ToObject<int>();
            var network = version.ExtractNetworkType();
            var deadline = new Deadline(transaction["deadline"].ToObject<UInt64DTO>().ToUInt64());
            var maxFee = transaction["maxFee"]?.ToObject<UInt64DTO>().ToUInt64();
            var signature = transaction["signature"].ToObject<string>();
            var signer = new PublicAccount(transaction["signer"].ToObject<string>(), network);
            var type = TransactionTypeExtension.GetRawValue(transaction["type"].ToObject<int>());
            var propertyType = PropertyTypeExtension.GetRawValue(transaction["propertyType"].ToObject<int>());

            var modifications = transaction["modifications"];
            var modificationList = modifications == null
                ? new List<AccountPropertyModification<Address>>()
                : modifications.Select(e =>
                {
                    var modificationType =
                        PropertyModificationTypeExtension.GetRawValue(e["modificationType"].ToObject<int>());
                    var value = Address.CreateFromHex(e["value"].ToObject<string>());
                    var modification = new AccountPropertyModification<Address>(modificationType,
                        value);
                    return modification;
                }).ToList();

            if (type == TransactionType.MODIFY_ACCOUNT_PROPERTY_ADDRESS)
                return new AddressModification(
                    network,
                    version,
                    deadline,
                    propertyType,
                    modificationList,
                    maxFee,
                    signature,
                    signer,
                    txInfo
                );

            throw new Exception("Unsupported transaction type");
        }
    }
}