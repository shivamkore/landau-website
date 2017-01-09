using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Common.GoogleMap.Entities
{
    public class GeocodingEntity
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }
    }
}