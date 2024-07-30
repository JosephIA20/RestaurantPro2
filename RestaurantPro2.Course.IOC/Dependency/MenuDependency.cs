using Microsoft.Extensions.DependencyInjection;
using RestaurantPro2.menu.Application.Contracts;
using RestaurantPro2.menu.Application.Services;
using RestaurantPro2.menu.Domain.interfaces;
using RestaurantPro2.menu.Persistence.Repositores;

namespace RestaurantPro2.menu.IOC.Dependency
{
    public static class MenuDependency
    {
        public static void AddMenuDependency(this IServiceCollection service)
        {
            service.AddScoped<IMenuRepository, MenuRepositories>();
            service.AddHttpClient<MenuServiceWep>();
            #region"Service"
            service.AddTransient<IMenuService, MenuService>();
            #endregion
        }
    }
}
