namespace Social.Api.Registrars
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        void RegisterPipelineComponents(WebApplication app);
    }
}
