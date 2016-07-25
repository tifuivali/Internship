using System;
using ExercicesPart3;

namespace ExercisePart3
{
    public class Room
    {
        private string description;
        private int places;
        private int number;
        private int floor;
        private RoomType type;


        public bool HasAirConditioning { get; set; }

        public bool HasFlatTv { get; set; }

        public RoomType Type
        {
            get
            {
                return type;
            }

            set
            {
                switch (value)
                {
                    case RoomType.Single:
                        if (Places != 1)
                        {
                            throw new ValidationException($"Room type cannot be {value} because places is {places}");
                        }
                        break;
                    case RoomType.Double:
                        if (places > 2)
                        {
                            throw new ValidationException($"Room type cannot be {value} because places is {places}");
                        }
                        break;
                    case RoomType.Twin:
                        if (places > 2)
                        {
                            throw new ValidationException($"Room type cannot be {value} because places is {places}");
                        }
                        break;
                    case RoomType.Duplex:
                        if (places < 2 || places > 6)
                        {
                            throw new ValidationException($"Room type cannot be {value} because places is {places}");
                        }
                        break;
                    case RoomType.KingBedroom:
                        if (places < 2 || places > 4)
                        {
                            throw new ValidationException($"Room type cannot be {value} because places is {places}");
                        }
                        break;
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value.Length > 500)
                    throw new Exception($"Maxim length of description must be 500! Curent:{value.Length}");

                description = value;
            }
        }

        public int Places
        {
            get
            {
                return places;
            }

            set
            {
                switch (type)
                {
                    case RoomType.Single:
                        if (value != 1)
                            throw new Exception($"Single Room Type must have 1 place! Current value is:{value}");
                        break;
                    case RoomType.Double:
                        if (value > 2)
                            throw new Exception($"Double Room Type must have maximum 2 places! Current value is:{value}");
                        break;
                    case RoomType.KingBedroom:
                        if (value < 2 || value > 4)
                            throw new Exception(
                                $"KingBedroom Type must have between 2 and 4 places! Current value is:{value}");
                        break;
                    case RoomType.Duplex:
                        if (value < 2 || value > 6)
                            throw new Exception(
                                $"Duplex Room Type must have between 2 and 6 places! Current value is:{value}");
                        break;
                }
                places = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (number < 0 || number > 10000)
                    throw new Exception($"Number canot be negative and must be under 10 000! Curent value is:{value}");
                number = value;
            }
        }

        public int Floor
        {
            get
            {
                return floor;
            }

            set
            {
                if (floor < 0 || floor > 1000)
                    throw new Exception($"Floor canot be negative and must be under 1000! Curent value is:{value}");
                floor = value;
            }
        }

        public Room()
        {
        }

        public Room(string description, int places, int number, int floor, RoomType type)
        {
            Type = type;
            Number = number;
            Description = description;
            Floor = floor;
            Places = places;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\tRoom " + Number);
            Console.WriteLine("\tDescription: " + Description);
            Console.WriteLine("\tFloor:" + Floor);
            Console.WriteLine("\tPlaces:" + Places);
            Console.WriteLine("\tRoom Type:" + Type);
        }
    }
}
