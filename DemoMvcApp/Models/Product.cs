namespace DemoMvcApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Reference { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public string? Categorie {  get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateModification { get; set; }
    }
}
