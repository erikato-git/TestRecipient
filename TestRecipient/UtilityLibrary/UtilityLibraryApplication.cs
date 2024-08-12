using Digst.DigitalPost.SSLClient.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Digst.DigitalPost.UtilityLibrary
{
    public class UtilityLibraryApplication
    {
        public static void Main(string[] args)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => { services.AddHttpClient<RestClient>(); })
                .Build();
        }
    }
}