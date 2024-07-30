

namespace RestaurantPro2.menu.Application.Dtos
{
    public class MenuRemoveDto : MenuModelBase
    {
        public int deleted_user { get; set; }
        public DateTime? deleted_date { get; set; }

        public bool? deleted { get; set; }
    }


}

