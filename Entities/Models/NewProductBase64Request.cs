using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class NewProductBase64Request
    {
        public Base64FileModel Base64FileModel { get; set; }
        public ProductEntity Product { get; set; }
    }
}
