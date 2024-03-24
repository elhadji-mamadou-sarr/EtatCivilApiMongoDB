using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EtatCivilApiMongoDB.Models
{
    public class Birth
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Matricule { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime date { get; set; }

        public string FatherFirstName { get; set; }
        public string FatherLastName { get; set; }

        public string MotherFirstName { get; set; }
        public string MotherLastName { get; set; }

        public string Addresse { get; set; }
        public string Region { get; set; }
        public string Contry { get; set; }
        public string Hospital { get; set; }
    }
}
