using System.ComponentModel.DataAnnotations;

namespace TARge21House.Core.Domain
{
    public class House
    {
        [Key]
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public int Country { get; set; }

        // database only

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
