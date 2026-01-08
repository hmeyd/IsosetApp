public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Reference { get; set; }
    public decimal Prix { get; set; }
    public int Quantite { get; set; }
    public string Categorie { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }


    // Le constructeurs
    public Produit(string reference)
    {
        Reference = reference;
    }

    public Produit()
    {

    }

    public Produit(string nom, string reference, decimal prix, int quantite, string categorie)
    {
        Nom = nom;
        Reference = reference;
        Prix = prix;
        Quantite = quantite;
        Categorie = categorie;
    }

    public override string ToString()
    {
        return $"{Nom}|{Reference}|{Prix}|{Quantite}|{Categorie}";
    }

    public decimal ValeurStock()
    {
        return Prix * Quantite;
    }

    // get et set nom.
    public string nom
    {
        get { return Nom; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                Nom = value;
            else
                throw new Exception("Le nom doit être une chaîne non vide");
        }
    }

    public string reference
    {
        get { return Reference; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                Reference = value;
            else
                throw new Exception("La référence doit être une chaîne non vide");
        }
    }

    public string categorie
    {
        get { return Categorie; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                Categorie = value;
            else
                throw new Exception("La catégorie doit être une chaîne non vide");
        }
    }

    public decimal prix
    {
        get { return Prix; }
        set
        {
            if (value >= 0)
                Prix = value;
            else
                throw new Exception("Le prix ne doit pas être négatif");
        }
    }

    public int quantite
    {
        get { return Quantite; }
        set
        {
            if (value >= 0)
                Quantite = value;
            else
                throw new Exception("La quantité doit être un entier positif");
        }
    }
}
