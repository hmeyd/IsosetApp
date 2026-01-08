using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using ClientApi.Controllers;
using ClientApi.Services;
using ClientApi.Models;

namespace ClientApi.Tests.Controllers
{
    public class CommandeControllerTests
    {
        private readonly Mock<ICommandeService> _mockService;
        private readonly CommandeController _controller;

        public CommandeControllerTests()
        {
            _mockService = new Mock<ICommandeService>();
            _controller = new CommandeController(_mockService.Object);
        }

       
        [Fact]
        public void AfficherAll_ReturnsAllCommandes()
        {
           
            var commandes = new List<Commande>
            {
                new Commande { Id = 1, NumeroCommande = 1001, ClientId = 1 },
                new Commande { Id = 2, NumeroCommande = 1002, ClientId = 2 }
            };
            _mockService.Setup(s => s.GetAll()).Returns(commandes);

            
            var result = _controller.AfficherAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returned = Assert.IsAssignableFrom<IEnumerable<Commande>>(okResult.Value);

            Assert.Equal(2, returned.Count());
        }


        [Fact]
        public void Afficher_ReturnsCommande_WhenExists()
        {
          
            var commande = new Commande { Id = 1, NumeroCommande = 1001, ClientId = 1 };
            _mockService.Setup(s => s.GetById(1)).Returns(commande);

          
            var result = _controller.Afficher(1);

            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

           
            var returnedCommande = Assert.IsType<Commande>(okResult.Value);

          
            Assert.Equal(1001, returnedCommande.NumeroCommande);
        }



        [Fact]
        public void Afficher_ReturnsNotFound_WhenNotExists()
        {
           
            _mockService.Setup(s => s.GetById(999)).Returns((Commande)null);

            var result = _controller.Afficher(999);

         
            Assert.IsType<NotFoundResult>(result.Result);
        }

      
        [Fact]
        public void Create_ReturnsCreatedCommande()
        {
           
            var commande = new Commande { Id = 1, NumeroCommande = 1001 };
            _mockService.Setup(s => s.Create(commande)).Returns(commande);

          
            var result = _controller.Create(commande);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returned = Assert.IsType<Commande>(okResult.Value);

        
            Assert.Equal(1001, returned.NumeroCommande);
        }


        [Fact]
        public void Update_ReturnsUpdatedCommande()
        {
            // Arrange
            int id = 1;

            var dto = new CommandeUpdateDto
            {
                NumeroCommande = 2002,
                DateCommande = DateTime.Now,
                MontantTotal = 150.50m,
                Statut = "En cours",
                ClientId = 1
            };

            
            _mockService.Setup(s => s.Update(id, dto)).Returns(true);


            // Act
            var result = _controller.Update(id, dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returned = Assert.IsType<CommandeUpdateDto>(okResult.Value);

            Assert.Equal(2002, returned.NumeroCommande);
            Assert.Equal(new DateTime(2025, 12, 11).Date, returned.DateCommande.Date);

            Assert.Equal(150.50m, returned.MontantTotal);
            Assert.Equal("En cours", returned.Statut);
            Assert.Equal(1, returned.ClientId);
        }




      
        [Fact]
        public void Supprimer_ReturnsOk_WhenDeleted()
        {
          
            int id = 1;
            _mockService.Setup(s => s.Delete(id)).Returns(true);

          
            var result = _controller.Supprimer(id);
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public void Supprimer_ReturnsNotFound_WhenCommandeNotExists()
        {
           
            int id = 999;
            _mockService.Setup(s => s.Delete(id)).Returns(false);

            var result = _controller.Supprimer(id);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
