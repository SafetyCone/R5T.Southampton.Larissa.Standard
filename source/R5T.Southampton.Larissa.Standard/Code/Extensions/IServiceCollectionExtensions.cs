using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Larissa.Standard;


namespace R5T.Southampton.Larissa.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSvnSourceControlOperator(this IServiceCollection services)
        {
            services
                .AddSingleton<ISourceControlOperator, SvnSourceControlOperator>()
                .AddSvnOperator()
                ;

            return services;
        }
    }
}
