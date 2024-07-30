namespace RestaurantPro2.wep.Models.Save
{
    public class MenuSaveModel :MenuSaveResult
    {

        public int? IdPlato { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int creation_user { get; set; }
        public DateTime creation_date { get; set; }
        public bool IsValid { get; internal set; }
    }
}
