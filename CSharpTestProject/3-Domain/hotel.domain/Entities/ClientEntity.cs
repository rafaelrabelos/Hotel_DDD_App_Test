using System;

namespace hotel.domain.entities
{
    using valueobj.enums;

    public class ClientEntity
    {
        public ClientEntity(ClientTypeEnum clientType)
        {
            ClientType = clientType;
        }

        public ClientTypeEnum ClientType { get; set; }
    }
}
