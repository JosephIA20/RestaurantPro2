
using Microsoft.Extensions.DependencyInjection;
using RestaurantPro2.Menu.Application.Interfaces;
using RestaurantPro2.Menu.Domain.interfaces;
using RestaurantPro2.Menu.Persistence.Repositorys;
using System.Runtime.Intrinsics.X86;

namespace RestaurantPro2.Course.IOC.Dependency
{
    public static class MenuDependency
    {
        public static void AddMenuDependency(this ServiceCollection service)
        {
            service.AddScoped<IMenuRepository, MenuRepository>();

            #region"Service"
            service.AddTransient<IMenuService, MenuService>();
            #endregion
        }
    }
}
