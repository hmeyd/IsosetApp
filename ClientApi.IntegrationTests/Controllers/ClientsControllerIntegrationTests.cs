using System.Net.Http.Json;
using Xunit;
using ClientApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ClientApi.Data;

namespace ClientApi.IntegrationTests.Controllers
{
    public class ClientsControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public ClientsControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            // On customise le factory pour utiliser InMemoryDatabase
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Supprimer l'ancien DbContext si présent
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                    if (descriptor != null)
                        services.Remove(descriptor);

                    // Ajouter InMemoryDb pour les tests
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDb");
                    });
                });
            });

            _client = _factory.CreateClient();
        }

        private async Task SeedClientAsync(Client client)
        {
            using var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Clients.Add(client);
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetClients_ReturnsAllClients()
        {
            await SeedClientAsync(new Client { Nom = "Dupont", Prenom = "Jean", Email = "jean@ex.com", Adresse = "Rue A", DateCreation = DateTime.Now });
            await SeedClientAsync(new Client { Nom = "Martin", Prenom = "Claire", Email = "claire@ex.com", Adresse = "Rue B", DateCreation = DateTime.Now });

            var response = await _client.GetAsync("/api/Client");
            response.EnsureSuccessStatusCode();

            var clients = await response.Content.ReadFromJsonAsync<IEnumerable<Client>>();
            Assert.NotNull(clients);
            Assert.Collection(clients,
                c => Assert.Equal("Dupont", c.Nom),
                c => Assert.Equal("Martin", c.Nom));
        }

    }
}
