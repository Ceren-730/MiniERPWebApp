namespace MiniERPWebApp.Models
{
    public class Urun
    {
        public int UrunID { get; set; }

        public string UrunAdi { get; set; } = "";

        public string Kategori { get; set; } = "";

        public decimal Fiyat { get; set; }

        public int Stok { get; set; }
    }
}