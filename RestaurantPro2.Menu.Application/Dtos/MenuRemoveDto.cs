

namespace RestaurantPro2.Menu.Application.Dtos
{
    public class MenuRemoveDto : MenuModelBase
    {
        public int deleted_user { get; set; }
        public DateTime? deleted_date { get; set; }

        public bool? deleted { get; set; }
    }


}

