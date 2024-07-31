namespace UTEC.Salud.Clases
{
    public class Proxy
    {
        private readonly IConfiguration _configuration;

        public Proxy()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
    }
}
