using Xunit;
using ClientApi.Models;


public class ClientServiceTests
{
	[Fact]
	public void GetFullName_ReturnsCorrectValue()
	{
	
		
		var client = new Client { Nom = "Dupont", Prenom = "Jean" };


        var result = client.GetFullName();
       
        Assert.Equal("Jean Dupont", result);
	}
}
