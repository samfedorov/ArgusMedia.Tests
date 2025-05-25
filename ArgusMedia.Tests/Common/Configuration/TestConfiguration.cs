using Microsoft.Extensions.Configuration;

namespace ArgusMedia.Tests.Common.Configuration
{
    public static class TestConfiguration
    {
        /// <summary>
        /// Can be move to Environmental Variations as improvements.
        /// </summary>
        private static string _envName = "local";

        static TestConfiguration()
        {
            var path = Directory.GetCurrentDirectory();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile($"config.{_envName.ToLower()}.json")
                .Build();

            BaseUrl = configuration["BaseUrl"];
        }

        public static string BaseUrl { get; private set; }
    }
}
