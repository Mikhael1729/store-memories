using StoreMemories.Data;
using StoreMemories.Models;
using StoreMemories.Repositories;
namespace StoreMemories.DataServices
{
    public class PhotoService : BaseRepository<Photo>, IPhotoService
    {
        public PhotoService(ApplicationDbContext context) : base(context)
        { }
    }
}
