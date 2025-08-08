using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnet_task_api.Filters
{
    public class FluentValidationActionFilter : IAsyncActionFilter
    {
        private readonly IServiceProvider _sp;
        public FluentValidationActionFilter(IServiceProvider sp) => _sp = sp;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var (name, arg) in context.ActionArguments)
            {
                if (arg is null) continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());

                if (_sp.GetService(validatorType) is not IValidator validator) continue;

                var validationContext = new ValidationContext<object>(arg);
                var result = await validator.ValidateAsync(validationContext);

                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                        context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                    context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState));
                    return;
                }
            }

            await next();
        }
    }
}
