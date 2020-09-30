using System;
using System.Collections.Generic;
using hotel.domain.entities;
using hotel.domain.valueobj.enums;

namespace hotel.domain.interfaces
{
    public interface IHotelRepository
    {
        public IEnumerable<HotelEntity> GetHotels();
    }
}
