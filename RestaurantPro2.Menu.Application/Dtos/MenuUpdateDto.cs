

using RestaurantPro2.menu.Application.Core;

namespace RestaurantPro2.menu.Application.Dtos
{
    public class MenuUpdateDto : MenuModelBase
    {
        public DateTime? ModifyDate { get; set; }
        public DateTime? creation_date { get; set; }
     
    
    }
}
