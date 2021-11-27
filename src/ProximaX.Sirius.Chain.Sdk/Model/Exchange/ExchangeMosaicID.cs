﻿// Copyright 2021 ProximaX
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
using ProximaX.Sirius.Chain.Sdk.Model.Mosaics;
using ProximaX.Sirius.Chain.Sdk.Model.Transactions;
using ProximaX.Sirius.Chain.Sdk.Utils;

namespace ProximaX.Sirius.Chain.Sdk.Model.Exchange
{
    /// <summary>
    /// Class of ExchangeMosaicID
    /// </summary>
    public class ExchangeMosaicID
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="mosaics"></param>
        public ExchangeMosaicID(string mosaics)
        {
            Mosaicid = mosaics;
        }

        /// <summary>
        ///     The mosaic id.
        /// </summary>
        /// <value>The identifier.</value>
        public string Mosaicid { get; }

        /// <summary>
        ///     ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{nameof(Mosaicid)}: {Mosaicid}";
        }
    }
}