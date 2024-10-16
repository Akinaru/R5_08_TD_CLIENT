namespace TD1Client.Models
{
    public class Marque
    {

        public int IdMarque { get; set; }
        public string? NomMarque { get; set; }

        public override string ToString()
        {
            return $"{NomMarque} (ID: {IdMarque})";
        }
    }
}
