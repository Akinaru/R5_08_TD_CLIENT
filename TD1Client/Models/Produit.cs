using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TD1Client.Models
{
    public class Produit
    {
        public int IdProduit { get; set; }
        public string? NomProduit { get; set; }
        public string? Description { get; set; }
        public string? NomPhoto { get; set; }
        public string? UriPhoto { get; set; }
        public int IdTypeProduit { get; set; }
        public int IdMarque { get; set; }
        public int StockReel { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }

        public override string ToString()
        {
            return $"{NomProduit} (ID: {IdProduit}) - {Description}\n" +
                   $"Marque ID: {IdMarque}, Type ID: {IdTypeProduit}\n" +
                   $"Stock: {StockReel} (Min: {StockMin}, Max: {StockMax})\n" +
                   $"Photo: {NomPhoto} ({UriPhoto})";
        }

    }
}
