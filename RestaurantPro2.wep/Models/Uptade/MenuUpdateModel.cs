namespace RestaurantPro2.wep.Models.Uptade
{
    public class MenuUpdateModel
    {

        public int? IdPlato { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public Decimal? Precio { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
