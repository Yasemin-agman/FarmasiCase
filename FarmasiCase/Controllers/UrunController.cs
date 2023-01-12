using FarmasiCase.Dtos;
using FarmasiCase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FarmasiCase.Controllers
{
    public class UrunController : Controller
    {
        private readonly IWebHostEnvironment env;
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
        public UrunController(IWebHostEnvironment env)
        {
            this.env = env;
        }
        // GET: UrunController
        public ActionResult Index()
        {
            var database = mongoClient.GetDatabase("Farmasi");
            var collection = database.GetCollection<Urunler>("urunler");
            var urunResults = collection.Find<Urunler>(a => true).ToList();
            return View(urunResults);
        }
        // GET: UrunController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UrunController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrunController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UrunlerDto urunler)
        {
            if (urunler == null)
            {
                return BadRequest();
            }

            string FilePath = "/images/";
            string FileName = string.Empty;
            if (urunler.image != null || urunler.image.Length > 0)
            {
                if (urunler.image.ContentType == "image/jpeg" || urunler.image.ContentType == "image/png" || urunler.image.ContentType == "image/jpg")
                {
                    string extension = Path.GetExtension(urunler.image.FileName);
                    FileName = $"{Guid.NewGuid()}{extension}";

                    using (var fileStream = new FileStream(Path.Combine(this.env.WebRootPath+FilePath, FileName), FileMode.Create))
                    {
                        urunler.image.CopyTo(fileStream);
                    }
                }
            }

            var model = new Urunler
            {
                Fiyat = urunler.Fiyat,
                Renk = urunler.Renk,
                UrunAdi = urunler.UrunAdi,
                Gorsel = FilePath + FileName,
            };
            try
            {
                var database = mongoClient.GetDatabase("Farmasi");
                var collection = database.GetCollection<Urunler>("urunler");
                collection.InsertOne(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }

        // GET: UrunController/Edit/5



    }
}
