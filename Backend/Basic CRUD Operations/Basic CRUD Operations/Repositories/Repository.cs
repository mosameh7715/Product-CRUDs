using Basic_CRUD_Operations.DataContexts;
using Basic_CRUD_Operations.Helpers.DateTimeHelper;
using Basic_CRUD_Operations.Models;
using System.Linq.Expressions;

namespace Basic_CRUD_Operations.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Get
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, int pageNumber = 1, int pageSize = 9)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            query = query.Where(x => x.IsDeleted == false).Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            return query;
        }

        public TEntity? GetById(int id)
        {
            return _dbContext.Set<TEntity>().Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
        }

        #endregion

        #region Add
        public void Add(TEntity entity)
        {
            entity.CreatedOn = DateTimeHelper.GetCurrentDateTime();
            _dbContext.Add(entity);
        }
        #endregion

        #region Update
        public void Update(TEntity entity)
        {
            entity.UpdatedOn = DateTimeHelper.GetCurrentDateTime();
            _dbContext.Update(entity);
        }
        #endregion

        #region Delete
        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTimeHelper.GetCurrentDateTime();
            _dbContext.Update(entity);
        }
        #endregion

        #region Count 
        public long Count(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            query = query.Where(x => x.IsDeleted == false);
            return query.Count();
        }
        #endregion 

        #region Save 
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
