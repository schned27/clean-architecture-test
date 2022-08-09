using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MUIManagement.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static readonly string AssemblyNamespace = "MUIManagement";

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var modules = assemblies.Where(x => x.ManifestModule.Name.StartsWith(AssemblyNamespace)).ToArray();

            services
                .AddMediatR(modules)
                .AddAutoMapper(modules);

            return services;
        }
    }
}
