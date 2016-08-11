using HotelApi_.Entities;

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

        public HotelModel()
        {
            
        }

        public HotelModel(HotelEntity hotelEntity)
        {
            Id = hotelEntity.Id;
            City = hotelEntity.Location.City;
            Description = hotelEntity.Description;
            Name = hotelEntity.Name;
            Rating = (short) hotelEntity.Rating;
            RoomsCount = hotelEntity.Rooms.Count;
        }
    }

}