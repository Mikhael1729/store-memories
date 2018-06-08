using StoreMemories.Data;
using StoreMemories.Repositories;
using StoreMemories.Models;

namespace StoreMemories.DataServices
{
    public class MemoryService : BaseRepository<Memory>, IMemoryService
    {
        public MemoryService(ApplicationDbContext context) : base(context)
        { }
    }
}
