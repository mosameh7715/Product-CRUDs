using System.Linq.Expressions;

namespace Basic_CRUD_Operations.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Get
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter, int PageNumber, int PageSize);
        TEntity? GetById(int id);
        #endregion

        #region Add
        void Add(TEntity entity);
        #endregion

        #region Update
        void Update(TEntity entity);
        #endregion

        #region Delete
        void Delete(TEntity t);
        #endregion

        #region Count
        long Count(Expression<Func<TEntity, bool>>? filter);
        #endregion

        #region Save
        void SaveChanges();
        #endregion
    }
}
