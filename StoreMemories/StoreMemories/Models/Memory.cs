using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreMemories.Models
{
    public class Memory : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PhotoId { get; set; }

        [NotMapped]
        public Photo Photo { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
