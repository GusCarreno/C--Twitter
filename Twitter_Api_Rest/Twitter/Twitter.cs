using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace Twitter
{
    public class Twitter
    {
 


       // public SqlConnection connection = new SqlConnection("");

        public async Task<string> GetAccessToken()
        {

            string OAuthConsumerSecret = "put you key from a twitter app here";
            string OAuthConsumerKey = "put your secret Key from a twitter app here";
                  
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token");
            var customerInfo = Convert.ToBase64String(new UTF8Encoding().GetBytes(OAuthConsumerKey + ":" + OAuthConsumerSecret));
            request.Headers.Add("Authorization", "Basic " + customerInfo);
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            dynamic item = serializer.Deserialize<object>(json);
            return  item["access_token"];            
        }
        public async Task<bool> GetTwitLine(string accessToken = null)
        {

            
            if (accessToken == null)
            {
                accessToken = await GetAccessToken();
            }


            
                try
                {

                
                    var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count=20&tweet_mode=extended&screen_name=prensagrafica&trim_user=1"));
                    requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
                    var httpClient = new HttpClient();
                    HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);

                    JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();            
                    List<TwitClass>  ListaTwitt = (List<TwitClass>) JavaScriptSerializer.Deserialize(await responseUserTimeLine.Content.ReadAsStringAsync(),typeof(List<TwitClass>));

              
                    string FechaCreacion;
                    string TwitId;
                    string full_text;

        


                    foreach (var ListadoDeTwits in ListaTwitt)
                    {                                                          
                        FechaCreacion = ListadoDeTwits.created_at.ToString();
                        TwitId = ListadoDeTwits.id_str.ToString();
                        full_text = ListadoDeTwits.full_text.ToString();
                        Console.WriteLine(TwitId.ToString());
                    }

                    
                }

                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                    
            return true;
        }

    }
}