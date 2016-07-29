namespace HotelApi_.Models
{
    public class Hotel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public uint RoomsCount { get; set; }

        public short Rating { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Hotel))
                return false;
            Hotel hotel = (Hotel)obj;
            return hotel.Id == Id;
        }
    }

}