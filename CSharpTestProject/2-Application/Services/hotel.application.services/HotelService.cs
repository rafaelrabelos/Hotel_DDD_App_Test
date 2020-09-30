using System;
using System.Linq;
using hotel.domain.interfaces;
using hotel.domain.entities;
using hotel.domain.valueobj.enums;
using hotel.application.services.dtos;

namespace hotel.application.services
{
    using interfaces;

    public class HotelService : IHotelService
    {

        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public HotelEntity GetLowestPriceHotel(RequestLowestPriceDto request)
        {
            var hotels = _hotelRepository.GetHotels();
            HotelEntity lowestHotel =null;

            if (request == null 
                || !request.IsValide())
                return null;

            var weekDays = request.Dates.Where(x => !IsWeekEnd(x)).Count();
            var weekendDays = request.Dates.Where(x => IsWeekEnd(x)).Count();

            foreach (var hotel in hotels)
            {
                if(lowestHotel == null)
                {
                    lowestHotel = hotel;
                    continue;
                }

                var actualHotelDaily = hotel.DailyValue(weekDays, weekendDays, request.ClientType);
                var lowestHotelDaily = lowestHotel.DailyValue(weekDays, weekendDays, request.ClientType);

                if (actualHotelDaily == lowestHotelDaily)
                    lowestHotel = lowestHotel.Rating > hotel.Rating ? lowestHotel : hotel;

                if (actualHotelDaily < lowestHotelDaily)
                    lowestHotel = hotel;
            }

            return lowestHotel;
        }

        #region private methods
        private bool IsWeekEnd(DateTime date) => (date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday);
        #endregion
    }
}
