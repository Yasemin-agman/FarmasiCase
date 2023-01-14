using FarmasiCase.Dtos;
using FarmasiCase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace FarmasiCase.Controllers
{
    public class CartController : Controller
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Cart> carttablo = null;
        private IMongoCollection<Urunler> uruntablo = null;
        
        public CartController()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = _mongoClient.GetDatabase("Farmasi");
            uruntablo = _database.GetCollection<Urunler>("urunler");
            carttablo = _database.GetCollection<Cart>("Cart");
        }

        public IActionResult Index()
        {                  
            var cartResults = carttablo.Find<Cart>(a => true).ToList();
            return View(cartResults);
        }


        public IActionResult AddToCart(string id)
        {

            var urun = uruntablo.Find(c => c.Id == id).FirstOrDefault();
            Cart newcart = new Cart();
            newcart.Adet = 1;
            newcart.Urunler = urun;        
            carttablo.InsertOne(newcart);
            return RedirectToAction("Index");
           //return View(urunResults);

        }
        public IActionResult Delete(string id)
        {
            var ara = Builders<Cart>.Filter.Eq(c => c._id, id);
            carttablo.DeleteOne(ara);
            return RedirectToAction("Index");
            //return View(urunResults);

        }


    }
}
