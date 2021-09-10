using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoApplication.Catalog.Dto
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
