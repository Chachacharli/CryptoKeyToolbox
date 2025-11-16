using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CryptoKeyToolbox.Domain.Entities;
using CryptoKeyToolbox.Domain.Interfaces;

namespace CryptoKeyToolbox.App.Services
{
    public class SSHKeyService : ISSHKeyService
    {
        public SSHKeyPair GenerateKey(int bits = 2048)
        {
            using var rsa = RSA.Create(bits);

            var privateKey = Convert.ToBase64String(
                rsa.ExportPkcs8PrivateKey()
            );

            var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
            var publicKey = Convert.ToBase64String(publicKeyBytes);

            return new SSHKeyPair
            {
                PrivateKey = privateKey,
                PublicKey = publicKey
            };
        }
    }

}
