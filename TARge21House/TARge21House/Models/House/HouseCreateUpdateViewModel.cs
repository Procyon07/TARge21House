﻿namespace TARge21House.Models.House
{
    public class HouseCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public int Rooms { get; set; }

        // database only

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
