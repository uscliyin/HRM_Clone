namespace RecruitingWeb.Infra
{
    public class RecruitingMiddleware
    {
        private readonly RequestDelegate _next;

        public RecruitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // read information from Middleware
            var requestMethod = context.Request.Method;
            await _next(context);
        }


    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRecruitingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RecruitingMiddleware>();
        }
    }
}
