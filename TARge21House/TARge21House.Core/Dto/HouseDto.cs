using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARge21House.Core.Dto
{
    public class HouseDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public int Rooms { get; set; }

        // database only

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
