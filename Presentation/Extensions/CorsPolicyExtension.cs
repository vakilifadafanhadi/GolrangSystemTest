namespace Presentation.Extensions
{
    public static class CorsPolicyExtension
    {
        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(option =>
            option.AddDefaultPolicy(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                ));
        }
    }
}
