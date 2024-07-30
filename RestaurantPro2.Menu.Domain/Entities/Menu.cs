

using RestaurantPro2.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantPro2.menu.Domain.Entities
{
    public class Menu :AuditEntity<int>
    {
        [Column("IdPlato")]
        public override int IdPlato { get; set ; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public string Categoria { get; set; }



    }
}
