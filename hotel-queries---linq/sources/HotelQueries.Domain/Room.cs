using System;

namespace iQuest.HotelQueries.Domain
{
    public class Room
    {
        public int Number { get; set; }
        
        public int MaxPersonCount { get; set; }
        
        public bool IsDisabledFriendly { get; set; }
        
        public bool HasBalcony { get; set; }
        
        public bool HasAirConditioner { get; set; }
        
        public double Surface { get; set; }
        
        public bool OffersSameConditionsOrBetterThen(Room room)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));

            return MaxPersonCount >= room.MaxPersonCount &&
                   HasAirConditioner == room.HasAirConditioner &&
                   IsDisabledFriendly == room.IsDisabledFriendly &&
                   HasBalcony == room.HasBalcony;
        }

        public bool Equals(Room other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Number == other.Number &&
                   MaxPersonCount == other.MaxPersonCount &&
                   IsDisabledFriendly == other.IsDisabledFriendly &&
                   HasBalcony == other.HasBalcony &&
                   HasAirConditioner == other.HasAirConditioner &&
                   Equals(Surface, other.Surface);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Room)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Number;
                hashCode = (hashCode * 397) ^ MaxPersonCount;
                hashCode = (hashCode * 397) ^ IsDisabledFriendly.GetHashCode();
                hashCode = (hashCode * 397) ^ HasBalcony.GetHashCode();
                hashCode = (hashCode * 397) ^ HasAirConditioner.GetHashCode();
                hashCode = (hashCode * 397) ^ Surface.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{Number} ({MaxPersonCount} pers; {Surface} m2)";
        }
    }
}