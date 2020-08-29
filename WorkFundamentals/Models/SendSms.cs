using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace WorkFundamentals.Models
{
    public class SendSms
    {
        [Key]
        public int SmsId { get; set; }

        [DisplayName("Message: ")]
        public string _yourMessage { get; set; }

        public string Send()
        {
            String message = HttpUtility.UrlEncode(_yourMessage);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "nBAM9wpcDNA-n5QsRWkSnwnmtzgQXDhB1h54jUCBTj"},
                {"numbers" , "2533258414"},
                {"message" , message},
                {"sender" , "Jims Autos"},
                {"test", "true"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }
}
