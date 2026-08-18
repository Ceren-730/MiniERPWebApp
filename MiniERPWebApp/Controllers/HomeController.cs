using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using MiniERPWebApp.Models;

namespace MiniERPWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString =
    "Server=(localdb)\\MSSQLLocalDB;Database=MiniERP;Trusted_Connection=True;TrustServerCertificate=True;";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Urunler()
        {
            List<Urun> urunler = new List<Urun>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        UrunID,
                        UrunAdi,
                        Kategori,
                        Fiyat,
                        StokMiktari
                    FROM Urunler";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        urunler.Add(new Urun
                        {
                            UrunID = Convert.ToInt32(reader["UrunID"]),
                            UrunAdi = reader["UrunAdi"]?.ToString() ?? "",
                            Kategori = reader["Kategori"]?.ToString() ?? "",
                            Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                            Stok = Convert.ToInt32(reader["StokMiktari"])
                        });
                    }
                }
            }

            return View(urunler);
        }
    }
}