namespace basitsatinalimuyg.Middlewares
{
	public class ExceptionMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch
			{

				context.Response.StatusCode = 500;
				context.Response.Redirect("/Home/Error");
			}
		}
	}
}
