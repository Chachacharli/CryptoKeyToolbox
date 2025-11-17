using CryptoKeyToolbox.Domain.Interfaces;

namespace CryptoKeyToolbox.Domain.Entities
{
	public class EncryptionKey
	{
		string Key { get; set; }
		AlgoritmType Algorithm { get; set; }
		FormatType Format { get; set; }
		int KeySize { get; set; }
		int Count { get; set; }

	}
}
