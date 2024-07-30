using Microsoft.EntityFrameworkCore;


namespace RestaurantPro2.menu.Persistence.Context
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }

        #region"Db set"
        public DbSet<Domain.Entities.Menu> Menu { get; set; }

        #endregion
    }
}
