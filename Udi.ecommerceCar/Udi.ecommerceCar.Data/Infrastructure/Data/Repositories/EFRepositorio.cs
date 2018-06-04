// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EFRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase base para los repositorios.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Tipo de entidad para nuestro repositorio
    /// </typeparam>
    public class EFRepositorio<TEntity> : IDisposable
        where TEntity : class, new()
    {
        /// <summary>
        /// The _db context.
        /// </summary>
        private DbContext _dbContext;

        /// <summary>
        /// The db set.
        /// </summary>
        private DbSet<TEntity> dbSet;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepositorio{TEntity}"/> class. 
        /// Constructor sin parámetros
        /// </summary>
        /// <summary>
        /// Crea una nueva instancia de Repositorio
        /// </summary>
        /// <param name="context">
        /// ObjectContext que implementa la interfaz IAuditableObjectContext
        /// </param>
        public EFRepositorio()
        {
            // Comprueba precondiciones

            // Establece los valores internos
            DbContext context = new DbContext("EcommercedbEntities");
            this._dbContext = context;
            this._dbContext.Configuration.ProxyCreationEnabled = false;
            this.dbSet = this._dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Devuelve el IQueryable de la entidad
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public virtual IQueryable<TEntity> BuildQuery()
        {
            return this._dbContext.Set<TEntity>().AsQueryable<TEntity>();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this._dbContext != null)
                    {
                        this._dbContext.Dispose();
                    }
                }
            }

            this.disposed = true;
        }

        #region Properties

        /// <summary>
        /// Devuelve el AuditableObjectContext 
        /// </summary>
        /// <summary>
        /// Guarda los cambios en el contexto
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public virtual int SaveChanges()
        {
            return this._dbContext.SaveChanges();
        }

        /// <summary>
        /// Añade un elemento dentro del repositorio
        /// </summary>
        /// <param name="item">
        /// Elemento a añadir al repositorio
        /// </param>
        public virtual void Add(TEntity item)
        {
            // check item
            if (item == null)
            {
                throw new ArgumentNullException("item", " Resources.MessagesImpl.EntityNull");
            }

            this.dbSet.Add(item);
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id">
        /// clave primaria
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity Get(object id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>
        /// Get entity
        /// </summary>
        /// <param name="element">
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity Get(TEntity element)
        {
            ObjectContext context = null;
            object foundEntity = null;
            context = ((IObjectContextAdapter)this._dbContext).ObjectContext;

            // var context = this.Context;
            var objSet = context.CreateObjectSet<TEntity>();
            var entityKey = context.CreateEntityKey(objSet.EntitySet.Name, element);
            var exists = context.TryGetObjectByKey(entityKey, out foundEntity);
            return (TEntity)foundEntity;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="element">
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity Update(TEntity element)
        {
            this._dbContext.Entry(element).State = EntityState.Modified;
            return element;
        }

        /// <summary>
        /// Marca el elemento para su borrado en el repositorio
        /// </summary>
        /// <param name="item">
        /// Elemento a borrar
        /// </param>
        public virtual void Remove(TEntity item)
        {
            // check item
            if (item == (TEntity)null)
            {
                throw new ArgumentNullException("item", "Resources.MessagesImpl.EntityNull");
            }

            if (this._dbContext.Entry(item).State == EntityState.Detached)
            {
                this.dbSet.Attach(item);
            }

            this.dbSet.Remove(item);
        }

        /// <summary>
        /// Obtiene todos los elementos del tipo {T} en repositorio
        /// </summary>
        /// <returns>Lista de elementos seleccionados</returns>
        public virtual List<TEntity> GetAll()
        {
            // Create IObjectSet and perform query 
            return this.BuildQuery().ToList<TEntity>();
        }

        /// <summary>
        /// Obtiene todos los elementos del tipo {TEntity} en repositorio
        /// </summary>
        /// <param name="specifications">
        /// Primero se debe obtener de la propiedad this.BuildQuery() y añadir los filtros requeridos
        /// </param>
        /// <returns>
        /// Lista de elementos seleccionados
        /// </returns>
        public virtual List<TEntity> GetBySpecifications(IQueryable<TEntity> specifications)
        {
            // Create IObjectSet and perform query 
            if (specifications == (IQueryable<TEntity>)null)
            {
                throw new ArgumentNullException("specifications", "esources.MessagesImpl.SpecificationsNull");
            }

            return specifications.ToList<TEntity>();
        }

        /// <summary>
        /// Obtiene todos los elementos del tipo {TEntity} en el repositorio
        /// </summary>
        /// <param name="startRowIndex">
        /// Número de índice donde empieza la página. Por ejemplo si queremos la página número 3 entonces startIndex = 3 *maxRows 
        /// </param>
        /// <param name="maximunRows">
        /// ´Número de elementos por página
        /// </param>
        /// <param name="orderByExpression">
        /// Orden por expression para la query. Es obligatorio
        /// </param>
        /// <param name="ascending">
        /// Especifica si el orden es ascendente
        /// </param>
        /// <param name="count">
        /// Devuelve el número de elementos encontrados
        /// </param>
        /// <returns>
        /// Lista de elementos seleccionados
        /// </returns>
        public virtual List<TEntity> GetPagedElements<S>(
            int startRowIndex, 
            int maximunRows, 
            Expression<Func<TEntity, S>> orderByExpression, 
            bool ascending, 
            out int count)
        {
            return this.GetPagedElements<S>(startRowIndex, maximunRows, orderByExpression, ascending, out count, null);
        }

        /// <summary>
        /// Obtiene todos los elementos del tipo {TEntity} en el repositorio
        /// </summary>
        /// <param name="startRowIndex">
        /// Número de índice donde empieza la página. Por ejemplo si queremos la página número 3 entonces startIndex = 3 *maxRows 
        /// </param>
        /// <param name="maximunRows">
        /// ´Número de elementos por página
        /// </param>
        /// <param name="orderByExpression">
        /// Orden por expression para la query. Es obligatorio
        /// </param>
        /// <param name="ascending">
        /// Especifica si el orden es ascendente
        /// </param>
        /// <param name="count">
        /// Devuelve el número de elementos encontrados
        /// </param>
        /// <param name="specifications">
        /// Primero se debe obtener de la propiedad this.BuildQuery() y añadir los filtros requeridos
        /// </param>
        /// <returns>
        /// Lista de elementos seleccionados
        /// </returns>
        public virtual List<TEntity> GetPagedElements<S>(
            int startRowIndex, 
            int maximunRows, 
            Expression<Func<TEntity, S>> orderByExpression, 
            bool ascending, 
            out int count, 
            IQueryable<TEntity> specifications)
        {
            // checking arguments for this query 
            if (startRowIndex < 0)
            {
                throw new ArgumentException("Resources.MessagesImpl.InvalidPageIndex", "startIndex");
            }

            if (maximunRows <= 0)
            {
                throw new ArgumentException("Resources.MessagesImpl.InvalidPageCount", "maxRows");
            }

            if (orderByExpression == (Expression<Func<TEntity, S>>)null)
            {
                throw new ArgumentNullException(
                    "orderByExpression", 
                    "Resources.MessagesImpl.OrderByExpressionCannotBeNull");
            }

            // Create associated IObjectSet and perform query
            IQueryable<TEntity> initialQuery = null;
            if (specifications == null)
            {
                initialQuery = this.BuildQuery();
            }
            else
            {
                initialQuery = specifications;
            }

            // return objectSet.Paginate<TEntity, S>(orderByExpression, pageIndex, pageCount, ascending);
            IQueryable<TEntity> pagedQuery;
            if (ascending)
            {
                pagedQuery = initialQuery.OrderBy(orderByExpression).Skip(startRowIndex).Take(maximunRows);
            }
            else
            {
                pagedQuery = initialQuery.OrderByDescending(orderByExpression).Skip(startRowIndex).Take(maximunRows);
            }

            var query = from ent in pagedQuery select new { entity = ent, count = initialQuery.Count() };
            var result = query.ToList();
            count = result.Count().Equals(0) ? 0 : result[0].count;
            return result.Select(z => z.entity).ToList();
        }

        #endregion
    }
}