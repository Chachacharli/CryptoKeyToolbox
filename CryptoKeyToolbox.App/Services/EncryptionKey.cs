using CryptoKeyToolbox.Domain.Interfaces;
using CryptoKeyToolbox.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoKeyToolbox.App.Services
{
	public class EncryptionKeyService : IEncryptionKey
	{
		public Task<List<EncryptionKey>> GenerateKeys(AlgoritmType algorithm, FormatType format, int keySize, int count)
		{
			throw new NotImplementedException();
		}
	}
}