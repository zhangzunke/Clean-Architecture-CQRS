using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Social.Api.Options
{
    public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider) 
        : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider = apiVersionDescriptionProvider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions) 
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Social",
                Version = description.ApiVersion.ToString()
            };

            if(description.IsDeprecated)
            {
                info.Description = "This API version has been deprecated";
            }

            return info;
        }
    }
}
