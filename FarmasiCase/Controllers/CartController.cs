using FarmasiCase.Dtos;
using FarmasiCase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FarmasiCase.Controllers
{
    public class CartController : Controller
    {
        private object db;
        private readonly IWebHostEnvironment env;
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
        private object urunler;

        public object Session { get; private set; }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult AddToCart(int Id)
        {
           

            return View();
        }
        
    }
}
