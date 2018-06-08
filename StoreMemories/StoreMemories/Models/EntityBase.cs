using System.ComponentModel.DataAnnotations;

namespace StoreMemories.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
