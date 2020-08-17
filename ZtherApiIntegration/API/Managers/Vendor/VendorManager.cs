using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models;

namespace ZtherApiIntegration.API.Managers.Vendor
{
    public class VendorManager
    {
        public VendorProductPageModel VendorProductPageModel { get; set; }

        public VendorManager(string brand, string productCode)
        {
            GetVendorProductPagesAsync(productCode).GetAwaiter().GetResult();

            var ScrubsOnCallPage = GetScrubsOnCallPageAsync(brand, productCode).GetAwaiter().GetResult();

            VendorProductPageModel.AddProductPage(ScrubsOnCallPage);
        }

        public async Task GetVendorProductPagesAsync(string productCode)
        {
            var model = new VendorProductPageModel();
            var endpoint = System.Configuration.ConfigurationManager.AppSettings["API-Endpoint"];
            
            if (!string.IsNullOrEmpty(productCode))
            {
                try
                {
                    var requestUrl = String.Format("{0}/vendors/products/{1}", endpoint, productCode);

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(requestUrl));

                    HttpResponseMessage response = await HttpClientHelper.SendAsync(request)
                                                            .ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync()
                                                .ConfigureAwait(false);

                        var models = JsonConvert.DeserializeObject<List<ProductPageModel>>(content);

                        model = new VendorProductPageModel(models);
                    }
                }
                catch
                {

                }
            }

            this.VendorProductPageModel = model;
        }

        public async Task<ProductPageModel> GetScrubsOnCallPageAsync(string brand, string productCode)
        {
            ProductPageModel model = null;

            if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(productCode))
            {
                if (brand.Equals("LN", StringComparison.OrdinalIgnoreCase))
                    brand = "LAN";
                else if (brand.Equals("UR", StringComparison.OrdinalIgnoreCase))
                    brand = "UBN";
                else if (brand.Equals("SN", StringComparison.OrdinalIgnoreCase))
                    brand = "SMT";

                var requestUrl = String.Format("https://eagle-pos.com/scrubsOnCall/include/php/detail.php?item={0}&vendor={1}", productCode, brand);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(requestUrl));

                HttpResponseMessage response = await HttpClientHelper.SendAsync(request)
                                                           .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync()
                                            .ConfigureAwait(false);

                    var startPosition = (content.IndexOf("<title>") + "<title>".Length);
                    var endPosition = (content.IndexOf("</title>") - startPosition);
                    var titleContent = content.Substring(startPosition, endPosition);
                    
                    if (titleContent.IndexOf(productCode) > 0)
                    {
                        model = new ProductPageModel
                        {
                            VendorId = 3,
                            ProductCode = productCode,
                            ProductUrl = requestUrl,
                            ColorCode = null
                        };
                    }
                }
            }

            return model;
        }
    }
}