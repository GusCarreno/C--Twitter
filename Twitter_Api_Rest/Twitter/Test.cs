using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{

    public class TwitClass
    {
        public string created_at { get; set; }
        public Int64 id { get; set; }
        public string id_str { get; set; }
        public string full_text { get; set; }
        public bool truncated { get; set; }
        public int[] display_text_range { get; set; }
        public Entities entities { get; set; }       
        public Users User { get; set; }
        public bool is_quote_status { get; set; }
        public int retweet_count { get; set; }
        public int favorite_count { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public bool possibly_sensitive { get; set; }
        public string lang { get; set; }
    }

    public class Users
    {
        public string id_str { get; set; }

    }


    public class Entities
    {
        public object[] hashtags { get; set; }
        public object[] symbols { get; set; }        
        public urls[] urls { get; set; }

        public media[] media { get; set; }

    }

    public class urls
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        

    }


    public class media
    {
        public string media_url { get; set; }
        public string expanded_url { get; set; }
        public string type { get; set; }

    }




    public class TwitSource
    {
        
        public Int64 id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public Int64 followers_count { get; set; }
        public Int64 friends_count { get; set; }
        public Int64 listed_count    { get; set; }
        public Int64 favourites_count { get; set; }
        public string time_zone { get; set; }
        public Int64 statuses_count { get; set; }
        public string lang { get; set; }
        public string profile_image_url { get; set; }

    }


    public class LocationWeather
    {
        public  currently currently { get; set; }
        public int offset { get; set; }
    }

    public class currently
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public float temperature { get; set; }        
    }


    public class LInkReader
    {
        public string title { get; set; }
    }


}
