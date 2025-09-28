using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.Data;
using SimpleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SimpleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) { _db = db; }

        [HttpGet]
        public IActionResult Get() => Ok(_db.Products.ToList());

        [HttpPost]
        public IActionResult Post(Product p)
        {
            _db.Products.Add(p);
            _db.SaveChanges();
            return Ok(p);
        }
    }
}
