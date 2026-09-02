namespace Labb1_MVC.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                // Pokémon hittades inte / vanlig 404
                if (context.Response.StatusCode == 404)
                {
                    context.Items["Message"] = "Pokémonen kunde inte hittas.";
                    context.Request.Path = "/Home/Error";
                    await _next(context);
                }
            }
            catch (HttpRequestException)
            {
                // PokéAPI är inte tillgängligt
                context.Items["Message"] = "PokéAPI är inte tillgängligt just nu. Försök igen senare.";
                context.Request.Path = "/Home/Error";
                await _next(context);
            }
        }
    }
}
