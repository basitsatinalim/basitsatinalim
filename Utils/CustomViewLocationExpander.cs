
using Microsoft.AspNetCore.Mvc.Razor;

namespace basitsatinalimuyg.Utils
{
  public class CustomViewLocationExpander : IViewLocationExpander
  {
    public void PopulateValues(ViewLocationExpanderContext context)
    {
      // Do nothing - not required
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
      return new[]
      {
            "/Views/{1}/{0}.cshtml",
            "/Views/Shared/{0}.cshtml",
            "/Views/Admin/{0}.cshtml",
      };
    }
  }
}