using System;
using SQLite;

namespace URLShortner.Models
{
	public class URL
	{
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string hash { get; set; }

        public string long_url { get; set; }

        public string short_url { get; set; }
    }
}

