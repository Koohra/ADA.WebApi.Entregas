using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Entregas.Filters
{
    public class FiltroExcessao : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.Result = new ObjectResult(new
            {
                ErrorMessage = "Ocorreu um erro, tente novamente mais tarde"
            })
            {
                StatusCode = 500
            };
            return Task.CompletedTask;
        }
    }
}
