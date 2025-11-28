using CryptoKeyToolbox.Domain.Interfaces;

namespace CryptoKeyToolbox.Domain.Entities
{
	public class EncryptionKey
	{
		public string Key { get; set; }
		public AlgoritmType Algorithm { get; set; }
		public FormatType Format { get; set; }
		public int KeySize { get; set; }
		public int Count { get; set; }

	}
}
