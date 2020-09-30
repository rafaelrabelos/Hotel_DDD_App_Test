using System;
using System.Linq;
using System.Collections.Generic;
using hotel.domain.valueobj.enums;

namespace hotel.application.services.dtos
{
    public class RequestLowestPriceDto
    {
        public RequestLowestPriceDto(int clientType, List<DateTime> dates)
        {
            ClientType = (ClientTypeEnum)clientType;
            Dates = dates;
        }

        public ClientTypeEnum ClientType { get; set; }
        public List<DateTime> Dates { get; set; }

        public bool IsValide()
        {
            if(default(ClientTypeEnum) == ClientType
                || Dates == null
                || Dates.Count() < 1)
                return false;
            return true;
        }
    }
}
