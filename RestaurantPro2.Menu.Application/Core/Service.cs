
namespace RestaurantPro2.Menu.Application.Core
{
     public class Service
    {

            public Service()
            {
                this.Success = true;
            }
            public bool Success { get; set; }
            public string? Message { get; set; }
            public dynamic? Data { get; set; }
        }
}
