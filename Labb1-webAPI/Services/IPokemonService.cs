using System.Collections.Generic;
using System.Threading.Tasks;
using Labb1_MVC.Models;

namespace Labb1_MVC.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllAsync();
        Task<Pokemon?> GetByNameAsync(string name);
    }
}
