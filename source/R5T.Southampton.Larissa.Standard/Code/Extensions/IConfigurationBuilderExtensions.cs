using System;

using Microsoft.Extensions.Configuration;

using R5T.Larissa.Standard;


namespace R5T.Southampton.Larissa.Standard
{
    public static class IConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddSvnSourceControlOperatorConfiguration(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder
                .AddSvnConfiguration(configurationServiceProvider)
                ;

            return configurationBuilder;
        }
    }
}
