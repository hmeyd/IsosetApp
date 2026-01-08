select sum(PrixUnitaire * QuantiteEnStock) as CA, CategorieId
from Produit
group by CategorieId
