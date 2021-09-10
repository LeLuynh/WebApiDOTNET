
using eProjectDemoApplication.Catalog;
using eProjectDemoApplication.Catalog.Dto;
using eProjectDemoData.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductApiController : ControllerBase
    {
        
        private readonly ProjectDemoContext _db;
        private readonly IProductServer _productServer;
        
        public ProductApiController( ProjectDemoContext db, IProductServer productServer)
        {
            _db = db;
            _productServer = productServer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Products.ToListAsync());
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _db.Products.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateModel request)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productServer.Create(request);
            if (productId == 0)
                return BadRequest();
            return Ok(new JsonResult("create success"));
  
        }

        [HttpDelete("{productId}")]
         public async Task<IActionResult> Delete(int productId)
        {
            var affectResult = await _productServer.Delete(productId);
            if (affectResult == 0)
                return BadRequest();
            return Ok(new JsonResult("Delete success"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm]ProductEditModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _productServer.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok(new JsonResult("Update success"));
        }

    }
}
