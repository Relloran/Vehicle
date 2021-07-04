using RestSharp;
using System;

namespace Proxy
{
    public static class Client
    {
        public static ReturnHistoryModel GetCarHistoryImageByVinCode(string vinCode)
        {
            var client = new RestClient($"https://epicvin.com/check-vin-number-and-get-the-vehicle-history-report/checkout/{vinCode}?abt=6");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", "epicvin_session=eyJpdiI6ImdoZ1dlZ2owWTJLM3FBcElLY2FNZEE9PSIsInZhbHVlIjoiZUFFSDAyOU9yV3lkV1BjREJUQWZINE52bTJ2cXFuM29LNGFGTTZoMmJ1NCtaUEt5RnhaVXMxNmhFT3haeU82V2ZIaUJHZDlqNVpTNmZENUpydkcyeTQ5Uy9HZ2k3cDR2T0JTazh6UGdUSUZMMTA5UmFZM0lhQ2x5V2hoMm4vdjciLCJtYWMiOiIzOWQ1YzQ3Y2M1NzM2YTVkMzA1OGFiN2FlNDFkOTIwZWVkODk1OTZlZTNlY2JkZmRkMmUyNjFkZWU1ZDU5MDc4In0%3D; lost_basket=eyJpdiI6IjJDenZkdWFBSDFRVlh3TjdjRy90L2c9PSIsInZhbHVlIjoiWVZOTXhxSjhCTEFIeXlHMU9MVFhOYWRvUVNjMDVYZUVxZHVYMHpCZnRxSVhDakl3cVBMZllML1ZRaDBQUE5LSTg3c0cxUm9zY1lZS29SSFVqV3RNM0toVGd1SnhDSitsOGhramZrZjJvMy9SU3NNN2NQSHVqbjBYYnR0S2xwaTFzUlNsYjc5VmF6U1NZUVlKWlBxRjVodmUzdUg1aGNKRk01c1VTVFVpNUVIUk5iVk5RRzFrQWlUMEhUcWlxMWlVV0JwMFl5d3NLQzJjWFRSa2M4VGRXM2VseWtmbW0zTlJFQWIvdGxhdlhzUDlHcVc1R20yenI3bEZVK25uQlJ3Qnk4VGpZcVlOcThVWHREMzJvOGYwdkJrMkJBZHZDSi8vUWFsaUwvSWZlRGtacm1aOXdnUHVJZzBjNEZ3cFR2ck52V2g4aTI5QjNob0lrVVIwU0hOdnBSWFhKcFZIOFlKVFNKR2UyNk4rMTh0cmQwemNQV1gveGNxbmtKeHlNWGdrWGVkTlpKWVFoc0FuTEZqbHVadXFYUWpkak9TdXF0bEZucXdyTG9Nbkc3MFM5cURZS1Z1NzE4ODRyeVZlVGNsNiIsIm1hYyI6IjgyNGUwNDViMDFiYmE0YjI0YjgzODQ1OTE4OTBiNzliMWExMzM5NzI4MGQyZTczM2Q2N2I1ZGE1Yzc0YmE0NGQifQ%3D%3D");
            IRestResponse response = client.Execute(request);
            var res = response.Content;
            var bla = string.Concat(res.Substring(response.Content.IndexOf("window.curUrl") + 16,
                res.LastIndexOf(vinCode) - res.LastIndexOf("window.curUrl")),
                vinCode);

            var blu = res.Substring(res.IndexOf("/speed.svg"), res.IndexOf("/price.svg") - res.IndexOf("/speed.svg"));
            var imagePath = blu.Substring(blu.IndexOf("h5"), blu.IndexOf("h5") - blu.IndexOf("/h5"));
            var lastOdoMeter = blu.Substring(blu.IndexOf("mt-0") + 6, blu.LastIndexOf("</h5") - blu.LastIndexOf("mt-0") - 6);
            return
                new ReturnHistoryModel
                {
                    ImagePath = imagePath,
                    LastOdoMeter = lastOdoMeter,
                    //HadAccident = "" m
                };

        }
    }
}
