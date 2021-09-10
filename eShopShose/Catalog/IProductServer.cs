using eProjectDemoApplication.Catalog.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eProjectDemoApplication.Catalog
{
    public interface IProductServer
    {
        Task<List<ProductViewModel>> GetAll();
        Task<int> Create(ProductCreateModel request);
        Task<int> Update(ProductEditModel request);
        Task<int> Delete(int productId);
        Task<ProductViewModel> GetById(int productId);

    }
}
