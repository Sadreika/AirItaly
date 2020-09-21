using System.Net;

namespace AirItaly
{
    public class AirItaly
    {
        private string mainPageUrl = "https://www.airitaly.com/en/";
        private string departureLocation;
        private string arrivalLocation;
        private string departureTime;
        private string arrivalTime;
        private string travelType;
        public AirItaly(string departureLocation, string arrivalLocation, string departureTime, string arrivalTime, string travelType)
        {
            this.departureLocation = departureLocation;
            this.arrivalLocation = arrivalLocation;
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
            this.travelType = travelType;
        }
        public CookieCollection gettingCookies()
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(mainPageUrl);
            webRequest.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 80.0) Gecko / 20100101 Firefox / 80.0";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            webRequest.Headers.Add("Accept-Language", "en-GB,en;q=0.5");
            var webRespone = (HttpWebResponse)webRequest.GetResponse();
            CookieCollection cookieCollection = new CookieCollection();
            cookieCollection = webRespone.Cookies;
            return cookieCollection;
        }

        public void collectingData()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("UserAgent", "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 80.0) Gecko / 20100101 Firefox / 80.0");
            webClient.Headers.Add("Accept", "text / html, application / xhtml + xml, application / xml; q = 0.9,image / webp,*/*;q=0.8");
            webClient.Headers.Add("Accept-Language", "en-GB,en;q=0.5");
           /* 
            CookieCollection cookieCollection = gettingCookies();
            foreach (Cookie cookie in cookieCollection)
            {
                webClient.Headers.Add(HttpRequestHeader.Cookie, cookie.Name + "=" + cookie.Value);
            }
           */
            string data = webClient.DownloadString(creatingNewUrl());
        }

        public string creatingNewUrl()
        {
            string newUrl = mainPageUrl + "travel-plan/book/booking-search-result?adt=1&chd=0&inf=0&dep=" + departureLocation +
                "&dep_dt=" + departureTime +
                "&rt=" + arrivalLocation +
                "&rt_dt=" + arrivalTime +
                "&ow=" + travelType + "&cls=Y&ct=false";
            return newUrl;
        }
    }
}
