namespace TD1Client.Models
{
    public class TypeProduit
    {

        public int IdTypeProduit{ get; set; }
        public string? NomTypeProduit { get; set; }

        public override string ToString()
        {
            return $"{NomTypeProduit} (ID: {IdTypeProduit})";
        }

    }
}
