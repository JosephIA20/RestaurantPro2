

using RestaurantPro2.Menu.Domain.interfaces;
using RestaurantPro2.Menu.Persistence.Context;
using System.Linq.Expressions;

namespace RestaurantPro2.Menu.Persistence.Repositorys;

public class MenuRepository : IMenuRepository
{
    private readonly RestauranteContext context;
    private readonly MenuRepository _MenuRepositories;
    public bool Exists(Expression<Func<Domain.Entities.Menu, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Domain.Entities.Menu> GetALL()
    {
        throw new NotImplementedException();
    }

    public Domain.Entities.Menu GetEntityBy(int IdPlato)
    {
        throw new NotImplementedException();
    }

    public List<Domain.Entities.Menu> GetMenus(int menuId)
    {
        throw new NotImplementedException();
    }

    public void Remove(Domain.Entities.Menu entity)
    {
        throw new NotImplementedException();
    }

    public void Save(Domain.Entities.Menu entity)
    {
        throw new NotImplementedException();
    }

    public void Uptade(Domain.Entities.Menu entity)
    {
        throw new NotImplementedException();
    }
}
