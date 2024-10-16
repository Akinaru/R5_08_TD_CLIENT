using TD1Client.Models;

namespace TD1Client.Services
{
    public interface IService<TEntity>
    {

        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllByNameAsync(string name);
        Task<TEntity?> GetByIdAsync(int id);
        Task PostAsync(TEntity produit);
        Task PutAsync(int id, TEntity produit);
        Task DeleteAsync(int id);

    }
}
