using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace basitsatinalimuyg.Utils
{
	public static class HtmlHelperExtension
	{

		public static IHtmlContent RenderAsJson(this IHtmlHelper helper, object model)
		{
			return helper.Raw(JsonSerializer.Serialize(model));
		}
	}
}
