using System;
using hotel.domain.valueobj.enums;

namespace hotel.domain.entities
{
    public class HotelEntity
    {
        public HotelEntity(
            string hotelName,
            int rating,
            decimal regularWeekPrice,
            decimal fidelityWeekPrice,
            decimal regularWeekendPrice,
            decimal fidelityWeekendPrice)
        {
            HotelName = hotelName;
            Rating = rating;
            RegularWeekPrice = regularWeekPrice;
            RegularWeekendPrice = regularWeekendPrice;
            FidelityWeekPrice = fidelityWeekPrice;
            FidelityWeekendPrice = fidelityWeekendPrice;
        }

        public string HotelName { get; set; }
        public int Rating { get; set; }
        public decimal RegularWeekPrice { get; set; }
        public decimal RegularWeekendPrice { get; set; }
        public decimal FidelityWeekPrice { get; set; }
        public decimal FidelityWeekendPrice { get; set; }

        public bool IsValid()
        {
            if (HotelName == null
                || Rating <= 0
                || RegularWeekPrice <= 0
                || RegularWeekendPrice <= 0
                || FidelityWeekPrice <= 0
                || FidelityWeekendPrice <= 0)
                return false;
            return true;
        }

        public decimal DailyValue(int weekDaysCount, int weekendDaysCount, ClientTypeEnum ClientType)
        {
            var totalDays = weekDaysCount + weekendDaysCount;

            if (ClientType == ClientTypeEnum.Fidelity)
            {
                return ((weekDaysCount * FidelityWeekPrice) + (weekendDaysCount * FidelityWeekendPrice)) / totalDays;
            }
            return((weekDaysCount * RegularWeekPrice) + (weekendDaysCount * RegularWeekendPrice)) / totalDays;
        }
    }
}
