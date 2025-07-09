using WebAPI.Utilities.Formatters;

namespace WebAPI.Extensions
{
    public static class IMvcBuilderExtensions
    {
        /// <summary>
        /// Adds a custom CSV formatter to the MVC builder.
        /// </summary>
        /// <param name="builder">The MVC builder.</param>
        /// <returns>The updated MVC builder.</returns>
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder)
        {
            builder.AddMvcOptions(config =>
            {
                config.OutputFormatters
                    .Add(new CsvOutputFormatter());
            });
            return builder;
        }
    }
}
