using System;
using hotel.application.services.dtos;
using hotel.domain.entities;

namespace hotel.application.services.interfaces
{
    public interface IHotelService
    {
        public HotelEntity GetLowestPriceHotel(RequestLowestPriceDto request);
    }
}
