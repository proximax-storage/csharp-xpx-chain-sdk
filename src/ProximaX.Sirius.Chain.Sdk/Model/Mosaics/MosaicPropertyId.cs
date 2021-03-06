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

using ProximaX.Sirius.Chain.Sdk.Utils;
using System;


namespace ProximaX.Sirius.Chain.Sdk.Model.Mosaics
{
    public enum MosaicPropertyId
    {
        FLAGS = 0,
        DIVISIBILITY = 1,
        DURATION = 2
    }

    public static class MosaicPropertyIdExtension
    {
        /// <summary>
        ///     GetRawValue
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>MosaicPropertyId</returns>
        public static MosaicPropertyId GetRawValue(int? value)
        {
            return value.HasValue
                ? EnumExtensions.GetEnumValue<MosaicPropertyId>(value.Value)
                : throw new ArgumentOutOfRangeException("Unsupported MosaicPropertyId");
        }

        /// <summary>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte GetValueInByte(this MosaicPropertyId type)
        {
            return (byte)type;
        }
    }
}
