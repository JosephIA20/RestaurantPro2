
using RestaurantPro2.Common.Data.Base;
using System.ComponentModel.DataAnnotations;

{
    public class Menu
    {
        [Key]
        public int? IdPlato { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public string Categoria { get; set; }

    }
}
