namespace EtatCivilApi.Models
{
    public class Death
    {

        public int Id { get; set; }
        public string Matricule { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Hospital { get; set; }

    }

}
