﻿
using FluentAssertions;
using ProximaX.Sirius.Chain.Sdk.Crypto.Core.Chaso.NaCl;
using ProximaX.Sirius.Chain.Sdk.Model.Accounts;
using ProximaX.Sirius.Chain.Sdk.Model.Blockchain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProximaX.Sirius.Chain.Sdk.Tests.Models
{
    public class KeyPairTests
    {
        [Fact]
        public void Should_Create_KeyPair_From_Private_Key()
        {
            var pk = "A574ECE8F79DE11A39C6BADF0EF87C2C88730A5EA4CF2C0BD7E27103390BC4F4";
            var pubKey = "2B0FF0CADE0D945A23D1AF7AF266A0BAB7E07B163756F5F16CC75F24A4EEF23B";
            var keyPair = KeyPair.CreateFromPrivateKey(pk);

            keyPair.PublicKeyString.Should().Be(pubKey);
        
        }

        [Fact]
        public void Should_Sign_Data_And_Verify_Signature()
        {
            var pk = "A574ECE8F79DE11A39C6BADF0EF87C2C88730A5EA4CF2C0BD7E27103390BC4F4";
            var pubKey = "2B0FF0CADE0D945A23D1AF7AF266A0BAB7E07B163756F5F16CC75F24A4EEF23B";
            var keyPair = KeyPair.CreateFromPrivateKey(pk);
            var message = "This is a test data";
            var data = Encoding.ASCII.GetBytes(message);

            var signature = keyPair.Sign(data);

            var publicAccount = PublicAccount.CreateFromPublicKey(pubKey, NetworkType.MIJIN_TEST);
            
            var isValid = publicAccount.VerifySignature(data, signature);
            
            isValid.Should().BeTrue();

        }
    }
}
