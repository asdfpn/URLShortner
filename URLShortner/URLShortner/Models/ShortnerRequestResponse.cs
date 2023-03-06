using System;
namespace URLShortner.Models
{
    public class ShortnerRequestResponse
    {
        public string hash { get; set; }
        public string long_url { get; set; }
        public string short_url { get; set; }
    }
}

