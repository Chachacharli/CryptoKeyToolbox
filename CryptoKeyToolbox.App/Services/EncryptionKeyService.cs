using CryptoKeyToolbox.Domain.Entities;
using CryptoKeyToolbox.Domain.Interfaces;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace CryptoKeyToolbox.App.Services
{
	public class EncryptionKeyService : IEncryptionKey
	{
		public Task<List<EncryptionKey>> GenerateKeys(AlgoritmType algorithm, FormatType format, int keySize, int count)
		{
			return Task.Run(() =>
			{
				var result = new List<EncryptionKey>();

				for (int i = 0; i < count; i++)
				{
					byte[] keyBytes = algorithm switch
					{
						AlgoritmType.AES => GenerateAesKey(keySize),
						AlgoritmType.Chacha20 => GenerateChaCha20Key(),
						AlgoritmType.TwoFish => GenerateTwofishKey(keySize),
						AlgoritmType.Blowfish => GenerateBlowfishKey(keySize),
						AlgoritmType.RSA => GenerateRsaPrivateKeyDer(keySize),
						_ => throw new ArgumentOutOfRangeException(nameof(algorithm))
					};

					string encoded = format switch
					{
						FormatType.Base64 => Convert.ToBase64String(keyBytes),
						FormatType.Hex => ConvertToHex(keyBytes),
						FormatType.DER => Convert.ToBase64String(keyBytes), // DER = raw bytes
						FormatType.PEM => ConvertToPem(algorithm, keyBytes),
						_ => Convert.ToBase64String(keyBytes)
					};

					result.Add(new EncryptionKey
					{
						Key = encoded,
						Algorithm = algorithm,
						Format = format,
						KeySize = keySize
					});
				}

				return result;
			});
		}

		// -------------------------------
		// AES
		// -------------------------------
		private byte[] GenerateAesKey(int keySize)
		{
			using var aes = Aes.Create();
			aes.KeySize = keySize;
			aes.GenerateKey();
			return aes.Key;
		}

		// -------------------------------
		// ChaCha20 (Key = 256 bits)
		// -------------------------------
		private byte[] GenerateChaCha20Key()
		{
			var key = new byte[32];
			RandomNumberGenerator.Fill(key);
			return key;
		}

		// -------------------------------
		// Twofish (BC required)
		// -------------------------------
		private byte[] GenerateTwofishKey(int keySize)
		{
			var key = new byte[keySize / 8];
			RandomNumberGenerator.Fill(key);
			return key;
		}

		// -------------------------------
		// Blowfish (BC required)
		// -------------------------------
		private byte[] GenerateBlowfishKey(int keySize)
		{
			var key = new byte[keySize / 8];
			RandomNumberGenerator.Fill(key);
			return key;
		}

		// -------------------------------
		// RSA
		// -------------------------------
		private byte[] GenerateRsaPrivateKeyDer(int keySize)
		{
			using var rsa = RSA.Create(keySize);
			return rsa.ExportPkcs8PrivateKey(); // DER
		}

		// -------------------------------
		// Encoding Helpers
		// -------------------------------
		private string ConvertToHex(byte[] data)
		{
			return BitConverter.ToString(data).Replace("-", "").ToLower();
		}

		private string ConvertToPem(AlgoritmType type, byte[] keyBytes)
		{
			string header = type == AlgoritmType.RSA ? "PRIVATE KEY" : "SYMMETRIC KEY";

			string base64 = Convert.ToBase64String(keyBytes, Base64FormattingOptions.InsertLineBreaks);

			return $"-----BEGIN {header}-----\n{base64}\n-----END {header}-----";
		}
	}
}
