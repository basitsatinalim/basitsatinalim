namespace basitsatinalimuyg.Utils
{
	public static class EnumExtension
	{
		public static string? GetName(this Enum enm) 
		{
			return enm.GetType().GetEnumName(enm);
		}
	}
}
