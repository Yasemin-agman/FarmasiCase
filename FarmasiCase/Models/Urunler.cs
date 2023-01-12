using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarmasiCase.Models
{
    public class Urunler
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Gorsel { get; set; }
        public string UrunAdi { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
   

    }
}
