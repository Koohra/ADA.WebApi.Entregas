using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Entregas.Filters
{
    public class FiltroAutorizacao : Attribute, IAuthorizationFilter
    {
        private readonly ILogger<FiltroAutorizacao> _logger;

        public FiltroAutorizacao(ILogger<FiltroAutorizacao> logger)
        {
            _logger = logger;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Query.TryGetValue("usuarioLogado", out var value) && value == "true")
            {
                return;
            }

            _logger.LogWarning("Usuário sem permissão tentou acessar o endpoint");
            context.Result = new UnauthorizedObjectResult(new { Message = "Usuário não tem permissão" });
        }
    }
}
