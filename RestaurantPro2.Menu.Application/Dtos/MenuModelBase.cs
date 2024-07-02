using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPro2.Menu.Application.Dtos
{
    public abstract class MenuModelBase
    {
        [Key]
        public int? IdPlato { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public Decimal? Precio { get; set; }
        public string Categoria { get; set; }

    }
}
