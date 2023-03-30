using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Entities.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {
        }
        public int Id { get; set; }
        public int IdPhotoFile { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public decimal Units { get; set; }
        public string Description { get; set; }
    }
}

