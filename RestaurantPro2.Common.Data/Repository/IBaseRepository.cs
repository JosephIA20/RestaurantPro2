

using System.Linq.Expressions;

namespace RestaurantPro2.Common.Data.Repository
{
    public interface IBaseRepository<TEntity,TType> where TEntity: class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Entidad con la que se va a trabajar</param>

        void Save(TEntity entity );
        void Uptade(TEntity entity );
        void Remove(TEntity entity );
        List<TEntity> GetALL();
        TEntity GetEntityBy(TType IdPlato);

        bool Exists(Expression<Func<TEntity, bool>> filter);
        List<RestaurantPro2.Menu.Domain.Entities.Menu> GetMenus(int menuId);
    }
}
