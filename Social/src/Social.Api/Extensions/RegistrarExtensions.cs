﻿using Social.Api.Registrars;

namespace Social.Api.Extensions
{
    public static class RegistrarExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
        {
            var registrars = GetRegisters<IWebApplicationBuilderRegistrar>(scanningType);
            foreach (var registrar in registrars) 
            {
                registrar.RegisterServices(builder);
            }
        }

        public static void RegisterPipelineComponents(this WebApplication app, Type scanningType)
        {
            var registrars = GetRegisters<IWebApplicationRegistrar>(scanningType);
            foreach(var registrar in registrars)
            {
                registrar.RegisterPipelineComponents(app);
            }

        }

        private static IEnumerable<T> GetRegisters<T>(Type scanningType) where T : IRegistrar 
        {
            return scanningType.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<T>();
        }
    }
}
