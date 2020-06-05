using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

using R5T.Caledonia;
using R5T.Dacia;
using R5T.Larissa;
using R5T.Larissa.Configuration;
using R5T.Larissa.Default;
using R5T.Larissa.Standard;
using R5T.Lombardy;


namespace R5T.Southampton.Larissa.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static 
            (
            IServiceAction<ISourceControlOperator> sourceControlOperatorAction,
            (
            IServiceAction<ICommandLineInvocationOperator> commandLineInvocationOperatorAction,
            IServiceAction<IOptions<SvnConfiguration>> svnConfigurationOptions,
            IServiceAction<ISvnOperator> svnOperatorAction,
            IServiceAction<ISvnExecutableFilePathProvider> svnExecutableFilePathProviderAction
            ) addSvnOperatorAction,
            (
            IServiceAction<ISvnversionExecutableFilePathProvider> svnversionExecutableFilePathProviderAction,
            IServiceAction<ISvnversionOperator> svnversionOperatorAction
            ) addSvnvesionOperatorAction
            )
        AddSvnSourceControlOperatorAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<ILogger> loggerAction)
        {
#pragma warning disable IDE0042 // Deconstruct variable declaration
            var addSvnOperatorAction = services.AddSvnOperatorAction(stringlyTypedPathOperatorAction, loggerAction);
            var addSvnversionOperatorAction = services.AddSvnversionOperatorAction(loggerAction);
#pragma warning restore IDE0042 // Deconstruct variable declaration

            IServiceAction<ISourceControlOperator> sourceControlOperatorAction = ServiceAction<ISourceControlOperator>.New(() => services.AddSvnSourceControlOperatorAction(
                addSvnOperatorAction.svnOperatorAction,
                addSvnversionOperatorAction.svnversionOperatorAction,
                loggerAction));

            return (sourceControlOperatorAction, addSvnOperatorAction, addSvnversionOperatorAction);
        }

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
