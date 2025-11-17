using System.Security.Cryptography;
using CryptoKeyToolbox.Domain.Entities;
using CryptoKeyToolbox.Domain.Interfaces;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace CryptoKeyToolbox.App.Services
{

    public class SSHKeyService : ISSHKeyService
    {
        public Task<List<SSHKeyPair>> GenerateKeys(
            int bits = 2048,
            int count = 1,
            SshKeyType type = SshKeyType.RSA)
        {
            return Task.Run(() =>
            {
                var keyPairs = new List<SSHKeyPair>();

                for (int i = 0; i < count; i++)
                {
                    switch (type)
                    {
                        case SshKeyType.RSA:
                            keyPairs.Add(GenerateRsaKey(bits));
                            break;

                        case SshKeyType.ED25519:
                            keyPairs.Add(GenerateEd25519());
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(type), "Tipo de clave no soportado.");
                    }
                }

                return keyPairs;
            });
        }


        private SSHKeyPair GenerateRsaKey(int bits)
        {
            using var rsa = RSA.Create(bits);

            var privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());
            var publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());

            return new SSHKeyPair
            {
                PrivateKey = privateKey,
                PublicKey = publicKey
            };
        }

        public SSHKeyPair GenerateEd25519()
        {
            var generator = new Ed25519KeyPairGenerator();
            generator.Init(new Ed25519KeyGenerationParameters(new SecureRandom()));

            var keyPair = generator.GenerateKeyPair();

            var privateParams = (Ed25519PrivateKeyParameters)keyPair.Private;
            var publicParams = (Ed25519PublicKeyParameters)keyPair.Public;

            return new SSHKeyPair
            {
                PrivateKey = Convert.ToBase64String(privateParams.GetEncoded()),
                PublicKey = Convert.ToBase64String(publicParams.GetEncoded())
            };
        }


        public SSHKeyPair[] GenerateKey(int bits = 2048, int count = 1)
        {
            throw new NotImplementedException();
        }
    }
}
