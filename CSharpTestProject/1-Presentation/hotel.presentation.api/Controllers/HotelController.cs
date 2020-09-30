using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using hotel.application.services.interfaces;
using hotel.application.services.dtos;

namespace hotel.presentation.api.controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        [Route("lowestprice/{clientType}")]
        public IActionResult GetLowestHotelPrice(int clientType, [FromBody]List<DateTime> dates)
        {

            var result = _hotelService.GetLowestPriceHotel(new RequestLowestPriceDto(clientType, dates));

            return new OkObjectResult(new
            {
                success = result.HotelName != null,
                message = result.HotelName ?? "Nenhum hotel encontrado",
                data = result
            });
        }
    }
}
