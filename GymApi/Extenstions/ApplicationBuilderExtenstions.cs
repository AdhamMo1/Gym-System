using GymApi.CustomMiddleware;
using System.Runtime.CompilerServices;

namespace GymApi.Extenstions
{
    public static class ApplicationBuilderExtenstions
    {
        //configure middleware
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder) => 
            applicationBuilder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}
