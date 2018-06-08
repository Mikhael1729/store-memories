using StoreMemories.Repositories;
using StoreMemories.Models;

namespace StoreMemories.DataServices
{
    public interface IMemoryService : IRepository<Memory>
    { }
}
