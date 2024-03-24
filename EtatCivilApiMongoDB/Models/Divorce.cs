namespace EtatCivilApi.Models
{
    public class Divorce
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string HusbanFirstName { get; set; }
        public string HusbanListName { get; set; }
        public string WifeFirstName { get; set; }
        public string WifeLastName { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }

    }
}
