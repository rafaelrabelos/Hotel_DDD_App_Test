using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using hotel.application.services.interfaces;
using hotel.domain.interfaces;
using hotel.domain.entities;

namespace CSharpTestProject
{
    public partial class HotelTest
    {
        private readonly AutoMocker _mocker;
        private readonly Mock<IHotelService> _hotelService;
        private readonly Mock<IHotelRepository> _hotelRepository;

        public HotelTest()
        {
            _mocker = new AutoMocker();

            _hotelService = this._mocker.GetMock<IHotelService>();
            _hotelRepository = this._mocker.GetMock<IHotelRepository>();
        }

        private List<HotelEntity> SelectAllFromHotel() => new List<HotelEntity>(new HotelEntity[]
        {
            new HotelEntity("Parque das flores", 3, 110, 80, 90, 80),
            new HotelEntity("Jardim Botânico", 4, 160, 110, 60, 50),
            new HotelEntity("Mar Atlântico", 5, 220, 100, 150, 40)
        });

    }
}
