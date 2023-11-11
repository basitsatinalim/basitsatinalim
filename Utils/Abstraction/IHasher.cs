namespace basitsatinalimuyg.Utils.Abstraction
{
    public interface IHasher
    {
		string Hash(string clearText);
		bool Verify(string clearText, string hashText);
	}
}
