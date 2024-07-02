
namespace RestaurantPro2.Menu.Application.Dtos
{
    public class MenuSaveDto : MenuModelBase
    {
        public int creation_user { get; set; }
        public DateTime creation_date { get; set; }
    }
}
