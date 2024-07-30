
using RestaurantPro2.menu.Application.Core;

namespace RestaurantPro2.menu.Application.Dtos
{
    public class MenuSaveDto : MenuModelBase
    {
        public int creation_user { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }
    }
}
