using eProjectDemoApplication.Catalog.Dto;
using eProjectDemoData.EF;
using eProjectDemoData.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProjectDemoApplication.Catalog
{
    public class ProductServer : IProductServer
    {
        private readonly ProjectDemoContext _db;

        public ProductServer (ProjectDemoContext db)
        {
            _db = db;
        }
        public async Task<int> Create(ProductCreateModel request)
        {
            var product = new Products()
            {
                Name = request.Name,
                Description = request.Description,
                DateCreated = DateTime.Now,
            };
            _db.Products.Add(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _db.Products.FindAsync(productId);
            _db.Products.Remove(product);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var product = await _db.Products.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                DateCreated = x.DateCreated

            }).ToListAsync();
            return product;
        }

        public async Task<ProductViewModel> GetById(int productId)
        {
            var product = await _db.Products.FindAsync(productId);
            var productview = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                DateCreated = product.DateCreated
            };
            return productview;
        }

        public async Task<int> Update(ProductEditModel request)
        {
            var product = new Products()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                DateCreated = DateTime.Now
            };
            _db.Products.Update(product);
            return await _db.SaveChangesAsync();
        }
    }
}
