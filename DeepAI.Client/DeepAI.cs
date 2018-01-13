using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DeepAI
{

    public class DeepAI_API
    {
        private String apiKey;

        public DeepAI_API(String apiKey)
        {
            this.apiKey = apiKey;
        }

        private Object apiCall(String url_path, String method = "GET", Object postData = null)
        {
            // Use TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // uncomment to ignore ssl errors
            // ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.deepai.org/"+url_path);
            httpWebRequest.Headers["Api-Key"] = this.apiKey;

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;

            if (postData != null) { 
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(postData);

                    streamWriter.Write(json);
                }
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return new JavaScriptSerializer().DeserializeObject(result);
                }
            }
            catch (System.Net.WebException e)
            {
                String errMsg = new StreamReader(e.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                try
                {
                    // DeepAI returns errors as JSON so try to parse it
                    return new JavaScriptSerializer().DeserializeObject(errMsg);
                }
                catch
                {
                    // JSON parsing failed, return the message anyways...
                    if (errMsg != null && errMsg.Length > 0)
                    {
                        return new Dictionary<string, object> { {"error", errMsg} };
                    }
                    else
                    {
                        // No string returned at all...
                        return new Dictionary<string, object> { {"error", e.ToString()} };
                    }
                }

            }


        }

        public Dictionary<String, Object> getRealtimeStreams()
        {
            return (Dictionary<String, Object>)apiCall(url_path: "realtime-video");
        }

        public Dictionary<String, Object> getRealtimeStream(int id)
        {
            return (Dictionary<String, Object>)apiCall(url_path: "realtime-video/" + id);
        }

        public Dictionary<String, Object> stopRealtimeStream(int id)
        {
            return (Dictionary<String, Object>)apiCall(url_path: "realtime-video/" + id + "/stop", method: "POST");
        }

        public Dictionary<String, Object> startRealtimeStream(
            String model,
            String input_type,
            String output_type,
            float fps,
            int width,
            int height
            )
        {
            return (Dictionary<String, Object>)apiCall(url_path: "realtime-video/start", method: "POST", postData: new
            {
                model=model,
                input_type = input_type,
                output_type = output_type,
                fps=fps,
                width=width,
                height=height
            });
        }

        /* //example async wrapper
        public async Task<Dictionary<String, Object>> stopRealtimeStreamAsync(int id)
        {
            return await Task.Run(() => stopRealtimeStream(id)); 
        }

         */

        public String objectAsJsonString(Object a){
            return JsonUtility.NormalizeJsonString(JsonConvert.SerializeObject(a));
        }


    }

}

