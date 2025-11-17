using CryptoKeyToolbox.Domain.Entities;

namespace CryptoKeyToolbox.Domain.Interfaces
{
	public enum AlgoritmType
	{
		AES,
		Chacha20,
		TwoFish,
		RSA,
		Blowfish
	}

	public enum FormatType
	{
		Hex,
		Base64,
		Binary,
		PEM
	}

	public interface IEncryptionKey
	{
		Task<List<EncryptionKey>> GenerateKeys(AlgoritmType algorithm, FormatType format, int keySize, int count);
	}
}
