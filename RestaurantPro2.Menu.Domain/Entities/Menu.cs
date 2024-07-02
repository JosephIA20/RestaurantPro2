

using RestaurantPro2.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantPro2.Menu.Domain.Entities
{
    public class Menu :AuditEntity<int>
    {
        [Column("IdPlato")]
        public override int IdPlato { get; set ; }


    }
}
