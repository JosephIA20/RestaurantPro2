namespace RestaurantPro2.wep.Models.Results
{
    public class BaseResult <Tmodel>
    {

        public string message { get; set; }
        public bool success { get; set; }


        public Tmodel? Result { get; set; }
    }
}
