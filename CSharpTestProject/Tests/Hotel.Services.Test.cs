using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using hotel.application.services;
using hotel.application.services.dtos;
using hotel.domain.valueobj.enums;
using hotel.presentation.console;

namespace CSharpTestProject
{
    public partial class HotelTest
    {
        #region console tests

        [Fact]
        public void Run_Console_Test()
        {
            // 16Mar2020(mon)

            // Arrange
            var expected = new DateTime(2020, 03, 16);

            // Act
            var result = Program.ParseinputDate("16Mar2020(mon)");

            // Assert
            Assert.Equal(expected, result);
        }

        #endregion

        #region Provided Example test
        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_3_Week_Days_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Regular,
                new List<DateTime>(new DateTime[] {
                new DateTime(2020, 03, 16),//Mon
                new DateTime(2020, 03, 17),//Tues
                new DateTime(2020, 03, 18)})//Wed
            );
            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_Wee_And_Weekend_Days_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Regular,
                new List<DateTime>(new DateTime[] {
                new DateTime(2020, 03, 20),//Fri
                new DateTime(2020, 03, 21),//Sat
                new DateTime(2020, 03, 22)})//Sun
            );
            var expected = "Jardim Botânico";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Fidelity_Client_Lowest_Hotel_Price_With_Wee_And_Weekend_Days_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Fidelity,
                new List<DateTime>(new DateTime[] {
                new DateTime(2020, 03, 26),//Thur
                new DateTime(2020, 03, 27),//Fri
                new DateTime(2020, 03, 28)})//Sat
            );
            var expected = "Mar Atlântico";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        #endregion

        #region week days test

        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_1_Day_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Regular,
                new List<DateTime>(new DateTime[] {
                new DateTime(2020, 03, 26),//Thur
                })
            );
            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Fidelity_Client_Lowest_Hotel_Price_With_1_Day_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Fidelity,
                new List<DateTime>(new DateTime[] {
                new DateTime(2020, 03, 26),//Thur
                })
            );
            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_2_Days_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Regular,
                new List<DateTime>(new DateTime[] {
                    new DateTime(2020, 03, 25),//Wed
                    new DateTime(2020, 03, 26),//Thur
                })
            );
            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Fidelity_Client_Lowest_Hotel_Price_With_2_Days_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Fidelity,
                new List<DateTime>(new DateTime[] {
                    new DateTime(2020, 03, 25),//Wed
                    new DateTime(2020, 03, 26),//Thur
                })
            );
            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_1_Week_Test()
        {
            // Arrange

            List<DateTime> days = new List<DateTime>();

            for (int a = 7; a < 11; a++)
                days.Add(new DateTime(2020, 09, a));
            
            var input = new RequestLowestPriceDto((int)ClientTypeEnum.Regular, days);

            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Fidelity_Client_Lowest_Hotel_Price_With_1_Week_Test()
        {
            // Arrange

            List<DateTime> days = new List<DateTime>();

            for (int a = 7; a < 11; a++)
                days.Add(new DateTime(2020, 09, a));

            var input = new RequestLowestPriceDto((int)ClientTypeEnum.Fidelity, days);

            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_Full_Week_Test()
        {
            // Arrange

            List<DateTime> days = new List<DateTime>();

            for (int a = 6; a <= 12; a++)
                days.Add(new DateTime(2020, 09, a));

            var input = new RequestLowestPriceDto((int)ClientTypeEnum.Regular, days);

            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Fidelity_Client_Lowest_Hotel_Price_With_Full_Week_Test()
        {
            // Arrange

            List<DateTime> days = new List<DateTime>();

            for (int a = 6; a <= 12; a++)
                days.Add(new DateTime(2020, 09, a));

            var input = new RequestLowestPriceDto((int)ClientTypeEnum.Fidelity, days);

            var expected = "Parque das flores";

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Equal(expected, result.HotelName);

            this._mocker.VerifyAll();
        }
        #endregion

        #region Invalid Values tesy
        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_Invalid_Request_Test()
        {
            // Arrange
            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(It.IsAny<RequestLowestPriceDto>());

            // Assert
            Assert.Null(result);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_Without_Dates_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                (int)ClientTypeEnum.Regular,
                null
            );

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Null(result);

            this._mocker.VerifyAll();
        }

        [Fact]
        public void Get_Regular_Client_Lowest_Hotel_Price_With_Invalid_ClientType_Test()
        {
            // Arrange
            var input = new RequestLowestPriceDto(
                0,
                new List<DateTime>(new DateTime[] {
                new DateTime(2020, 03, 16),
                new DateTime(2020, 03, 17),
                new DateTime(2020, 03, 18)})
            );

            this._hotelRepository
                .Setup(x => x.GetHotels())
                .Returns(SelectAllFromHotel());

            // Act
            var hotelTest = new HotelService(this._hotelRepository.Object);
            var result = hotelTest.GetLowestPriceHotel(input);

            // Assert
            Assert.Null(result);

            this._mocker.VerifyAll();
        }

        #endregion
    
    }
}
