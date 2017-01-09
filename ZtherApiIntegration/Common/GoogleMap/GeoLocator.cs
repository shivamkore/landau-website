using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

using Newtonsoft.Json;
using ZtherApiIntegration.Common.GoogleMap.Entities;

namespace ZtherApiIntegration.Common.GoogleMap
{
    public class GeoLocator
    {
        private string _Address = string.Empty;

        public GeoLocator(string address)
        {
            this._Address = address;
        }

        public string City { get; private set; }
        public string State { get; private set; }

        public async Task Locate()
        {
            string request_url = this.GetRequestUrl(this._Address);

            var client = new RestClient();

            var response = await client.GetJsonAsync(request_url);

            if (!string.IsNullOrEmpty(response))
            {
                var entity = JsonConvert.DeserializeObject<GeocodingEntity>(response);

                if (entity.Status.Equals("OK"))
                {
                    if (entity.Results.First().Formatted_Address.Contains("USA"))
                    {
                        this.City = entity.Results.First().Addresses.Where(x => x.Types.Contains("locality")).FirstOrDefault().Short_Name;
                        this.State = entity.Results.First().Addresses.Where(x => x.Types.Contains("administrative_area_level_1")).FirstOrDefault().Short_Name;
                    }
                }
            }
        }

        private string GetRequestUrl(string parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters))
                return string.Empty;

            return String.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=AIzaSyAozf7qwNc4qMHgJdUmx_DzhffWr47b5pE", parameters);
        }
    }
}