namespace FarmasiCase.Dtos
{
    public class UrunlerDto
    {
        public IFormFile image { get; set; }
        public string UrunAdi { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
    }
}
