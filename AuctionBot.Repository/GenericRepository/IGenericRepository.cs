using System.Linq.Expressions;
using AuctionBot.Repository.Interfaces;

namespace AuctionBot.Repository.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : IEntity
{
    void Insert(TEntity entity);
    void Remove(object? id);
    void Remove(TEntity entity);
    void RemoveFromDb(TEntity entity);
    void RemoveFromDb(object? id);
    TEntity? GetEntity(object? id);
    TEntity? GetEntity(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
    IEnumerable<TEntity> GetEntities(params Expression<Func<TEntity, object>>[] includes);
    bool All(Expression<Func<TEntity, bool>> predicate);
    bool Any(Expression<Func<TEntity, bool>> predicate);
    void Save();
}
