using System.Linq.Expressions;
using AuctionBot.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AuctionBot.Repository.GenericRepository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase, new()
{
    protected readonly DbContext Context;
    
    private DbSet<TEntity> DbSet => Context.Set<TEntity>();

    protected GenericRepository(DbContext context) => Context = context ?? throw new ArgumentNullException(nameof(context));

    public virtual void Insert(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var entityExists = DbSet.Any(q => q.Id == entity.Id);

        if (entityExists)
        {
            entity.UpdateDt = DateTime.UtcNow;
            DbSet.Update(entity);
        }
        else
        {
            entity.CreateDt = entity.UpdateDt = DateTime.UtcNow;
            DbSet.Add(entity);
        }
    }

    public virtual void Remove(TEntity entity)
    {
        entity.UpdateDt = DateTime.UtcNow;
        entity.IsDeleted = true;
        DbSet.Update(entity);
    }

    public void RemoveFromDb(TEntity entity) => DbSet.Remove(entity);
    public void RemoveFromDb(object? id)
    {
        var entity = DbSet.Find(id);
        if (entity == null) return;
        DbSet.Remove(entity);
    }

    public virtual void Remove(object? id)
    {
        var entity = DbSet.Find(id);
        if (entity == null) return;

        entity.UpdateDt = DateTime.UtcNow;
        entity.IsDeleted = true;
        DbSet.Update(entity);
    }

    public virtual IEnumerable<TEntity?> GetEntities() => DbSet.ToList();

    public IEnumerable<TEntity> GetEntities(params Expression<Func<TEntity, object>>[] includes)
        => includes.Aggregate(DbSet.Where(q => true), (current, includeProperty) => current.Include(includeProperty!));

    public TEntity? GetEntity(object? id) => DbSet.Find(id);

    public TEntity? GetEntity(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        => includes.Aggregate(DbSet.Where(predicate!), (current, includeProperty) => current.Include(includeProperty!))
            .FirstOrDefault();
        

    public bool All(Expression<Func<TEntity, bool>> predicate) => DbSet.All(predicate);

    public bool Any(Expression<Func<TEntity, bool>> predicate) => DbSet.Any(predicate);

    public void Save() => Context.SaveChanges();
}