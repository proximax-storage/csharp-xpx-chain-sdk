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

namespace ProximaX.Sirius.Chain.Sdk.Crypto.Core.Chaso.NaCl.Internal.Ed25519ref10
{
    internal static partial class GroupOperations
    {
        /*
		r = p
		*/
        internal static void ge_p3_to_cached(out GroupElementCached r, ref GroupElementP3 p)
        {
            FieldOperations.fe_add(out r.YplusX, ref p.Y, ref p.X);
            FieldOperations.fe_sub(out r.YminusX, ref p.Y, ref p.X);
            r.Z = p.Z;
            FieldOperations.fe_mul(out r.T2d, ref p.T, ref LookupTables.d2);
        }
    }
}