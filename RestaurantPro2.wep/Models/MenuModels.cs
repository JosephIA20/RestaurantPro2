namespace RestaurantPro2.wep.Models
{
    public class MenuModels
    {
        public int? IdPlato { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public Decimal? Precio { get; set; }
        public string Categoria { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
