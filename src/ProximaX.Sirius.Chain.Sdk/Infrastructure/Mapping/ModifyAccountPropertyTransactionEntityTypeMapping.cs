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
using ProximaX.Sirius.Chain.Sdk.Infrastructure.DTO;
using ProximaX.Sirius.Chain.Sdk.Model.Accounts;
using ProximaX.Sirius.Chain.Sdk.Model.Blockchain;
using ProximaX.Sirius.Chain.Sdk.Model.Transactions;
using ProximaX.Sirius.Chain.Sdk.Utils;

namespace ProximaX.Sirius.Chain.Sdk.Infrastructure.Mapping
{
    /// <summary>
    ///     Class ModifyAccountPropertyTransactionEntityTypeMapping
    /// </summary>
    public class ModifyAccountPropertyTransactionEntityTypeMapping : TransactionMapping
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModifyAccountPropertyTransaction&lt;Address&gt;" /> class.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public new ModifyAccountPropertyTransaction<EntityType> Apply(JObject input)
        {
            return ToModifyAccountPropertyTransaction(input, TransactionMappingHelper.CreateTransactionInfo(input));
        }

        /// <summary>
        ///     ToModifyAccountPropertyTransaction
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="txInfo"></param>
        /// <returns></returns>
        private static ModifyAccountPropertyTransaction<EntityType> ToModifyAccountPropertyTransaction(JObject tx,
            TransactionInfo txInfo)
        {
            var transaction = tx["transaction"].ToObject<JObject>();
            var version = transaction["version"];


            //Bug - It seems the dotnetcore does not 
            //understand the Integer.
            //The workaround it to double cast the version
            int versionValue;
            try
            {
                versionValue = (int)((uint)version);
            }
            catch (Exception)
            {
                versionValue = (int)version;
            }

            var network = TransactionMappingUtils.ExtractNetworkType(versionValue);
            var txVersion = TransactionMappingUtils.ExtractTransactionVersion(versionValue);
            var deadline = new Deadline(transaction["deadline"].ToObject<UInt64DTO>().ToUInt64());
            var maxFee = transaction["maxFee"]?.ToObject<UInt64DTO>().ToUInt64();
            var signature = transaction["signature"].ToObject<string>();
            var signer = new PublicAccount(transaction["signer"].ToObject<string>(), network);
            var type = EntityTypeExtension.GetRawValue(transaction["type"].ToObject<int>());
            var propertyType = PropertyTypeExtension.GetRawValue(transaction["propertyType"].ToObject<int>());

            var modifications = transaction["modifications"];
            var modificationList = modifications == null
                ? new List<AccountPropertyModification<EntityType>>()
                : modifications.Select(e =>
                {
                    var mt = e["modificationType"] ?? e["type"];
                    var modificationType =
                        PropertyModificationTypeExtension.GetRawValue(mt.ToObject<int>());
                    var value = EntityTypeExtension.GetRawValue(e["value"].ToObject<int>());
                    var modification = new AccountPropertyModification<EntityType>(modificationType,
                        value);
                    return modification;
                }).ToList();

            if (type == EntityType.MODIFY_ACCOUNT_PROPERTY_ENTITY_TYPE)
                return new EntityTypeModification(
                    network,
                    txVersion,
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