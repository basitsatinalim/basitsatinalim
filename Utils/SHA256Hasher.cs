using basitsatinalimuyg.Utils.Abstraction;
using System.Security.Cryptography;
using System.Text;

namespace basitsatinalimuyg.Utils
{
	public class SHA256Hasher : IHasher
	{
		public string Hash(string clearText)
		{
			var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(clearText));
			return Convert.ToBase64String(hashedBytes);
		}

		public bool Verify(string clearText, string hashText)
		{
			var hashedProvidedText = Hash(clearText);
			return hashText == hashedProvidedText;
		}
	}
}
