using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenFridge.Services.DTOs
{
    public class UpdateProductDTO : CreateProductDTO
    {
        public int Id { get; set; }
    }
}
