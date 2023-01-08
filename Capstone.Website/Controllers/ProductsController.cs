using Capstone.Website.Models;
using Capstone.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Capstone.Website.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        //[HttpPatch] Incase I need to update database ["FromBody"]
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductId, int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
                return Ok();
        }
    }

}
