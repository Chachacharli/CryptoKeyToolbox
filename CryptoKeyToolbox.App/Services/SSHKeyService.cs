using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CryptoKeyToolbox.Domain.Entities;
using CryptoKeyToolbox.Domain.Interfaces;

namespace CryptoKeyToolbox.App.Services
{
	public class SSHKeyService : ISSHKeyService
	{
		public Task<List<SSHKeyPair>> GenerateKeys(int bits = 2048, int count = 1)
		{
			return Task.Run(() =>
			{
				var keyPairs = new List<SSHKeyPair>();

				for (int i = 0; i < count; i++)
				{
					using var rsa = RSA.Create(bits);

					var privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());
					var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
					var publicKey = Convert.ToBase64String(publicKeyBytes);

					keyPairs.Add(new SSHKeyPair
					{
						PrivateKey = privateKey,
						PublicKey = publicKey,
					});
				}

				return keyPairs;
			});
		}

		public SSHKeyPair[] GenerateKey(int bits = 2048, int count = 1)
		{
			throw new NotImplementedException();
		}
	}
}