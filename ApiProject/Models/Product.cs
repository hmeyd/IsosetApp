namespace ApiProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Reference { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public string? Categorie { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
    }
}
