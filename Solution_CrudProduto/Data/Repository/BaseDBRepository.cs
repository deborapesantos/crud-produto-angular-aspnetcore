using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solution_CrudProduto.Data.Repository
{
    public class BaseDBRepository<TEntity> : IDisposable where TEntity : class
    {
        private BaseContext _entity;

        protected BaseContext entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
            }
        }
        bool disposed = false;

        public BaseDBRepository(BaseContext mySqlContext)
        {
            _entity = mySqlContext;
        }

        #region Conection
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                if (entity != null)
                    entity.Dispose();

            disposed = true;
        }
        #endregion

        #region List

        /// <summary>
        /// Retorna um Querable da lista do objeto "TEntry" informado.
        /// </summary>
        /// <param name="predicateWhere">Lambda dos filros para busca na base.</param>
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicateWhere = null)
        {
            return GetAll<TEntity>(predicateWhere);
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicateWhere) where T : class
        {
            return (predicateWhere != null)
                 ? entity.Set<T>().Where(predicateWhere).AsQueryable()
                 : entity.Set<T>().AsQueryable();
        }
        /// <summary>
        /// Busca o objeto pela chave.
        /// </summary>
        /// <param name="key">Array de parametros</param>
        public TEntity FindByKey(params object[] key)
        {
            return FindByKey<TEntity>(key);
        }

        public T FindByKey<T>(params object[] key) where T : class
        {
            return entity.Set<T>().Find(key);
        }
        #endregion

        #region Create 
        /// <summary>
        /// Inclui um novo objeto no contexto
        /// </summary>
        /// <param name="obj"></param>
        public void Add(TEntity obj)
        {
            Add<TEntity>(obj);
        }

        public void Add<T>(T obj) where T : class
        {
            entity.Set<T>().Add(obj);
        }

        #endregion

        #region Update
        /// <summary>
        /// Atualiza o objeto do contexto
        /// </summary>
        /// <param name="obj"></param>
        public void Update(TEntity obj)
        {
            Update<TEntity>(obj);
        }

        public void Update<T>(T obj) where T : class
        {
            entity.Entry(obj).State = EntityState.Modified;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Exclui o objeto do contexto
        /// </summary>
        /// <param name="predicate"></param>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Delete<TEntity>(predicate);
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            entity.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => entity.Set<T>().Remove(del));
        }
        #endregion

        #region Others

        /// <summary>
        /// Efetiva as alterações na base.
        /// </summary>
        public void Save()
        {
            try
            {
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



    }
}
