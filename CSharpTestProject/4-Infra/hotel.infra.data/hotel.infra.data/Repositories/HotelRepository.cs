using System;
using hotel.domain.interfaces;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using hotel.domain.entities;
using hotel.domain.valueobj.enums;

namespace hotel.infra.data
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IDbConnection _dapperConnection;

        public HotelRepository(IDbConnection dapperCnn)
        {
            this._dapperConnection = dapperCnn;
        }

        public IEnumerable<HotelEntity> GetHotels()
        {
            using (var db = this._dapperConnection)
            {
                _dapperConnection.Open();
                return db.Query<HotelEntity>("SELECT * FROM Hotel");
            }
        }
    }
}
