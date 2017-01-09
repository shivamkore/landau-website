using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Common.GoogleMap.Entities
{
    public class Result
    {
        [JsonProperty("formatted_address")]
        public string Formatted_Address { get; set; }

        [JsonProperty("address_components")]
        public IList<Address> Addresses { get; set; }


    }
}