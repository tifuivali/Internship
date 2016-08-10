namespace HotelApi_.Models
{
    public class HotelModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public int RoomsCount { get; set; }

        public short Rating { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(HotelModel))
                return false;
            HotelModel hotelModel = (HotelModel)obj;
            return hotelModel.Id == Id;
        }
    }

}