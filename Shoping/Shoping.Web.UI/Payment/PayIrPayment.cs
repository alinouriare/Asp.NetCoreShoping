using Newtonsoft.Json;
using Shoping.Domain.Contract.Payments;
using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Shoping.Web.UI.Payment
{
    public class PayIrPayment : IPayment
    {
        private string gatewaySend = "https://pay.ir/payment/send";
        private string gatewayResult = "https://pay.ir/payment/verify";

        private string api = "test";
        private string redirect = "https://localhost:44339/payment/verify";
        public PaymentResult pay(String amount)
        {
            string result = "";
            String post_string = "";
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", api);
            post_values.Add("amount", amount.ToString());

            post_values.Add("redirect", redirect);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(gatewaySend);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
         
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return JsonConvert.DeserializeObject<PaymentResult>(result);
        }

        public VerifyResponse Verify(String transID)
        {
            string result = "";
            String post_string = "";
            Dictionary<string, string> post_values = new Dictionary<string, string>();
            post_values.Add("api", api);
            post_values.Add("transId", transID);

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(gatewayResult);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }
            return JsonConvert.DeserializeObject<VerifyResponse>(result);

        }
    }
}
