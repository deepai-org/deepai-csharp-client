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
using System.Reflection;


namespace DeepAI
{
    /// <summary>
    /// Represents the status and configuration for a single Realtime video stream.
    /// </summary>
    public class RealtimeStream
    {
        public int id { get; set; }
        /// <summary>
        /// One of PENDING, RUNNING, STOPPED, FAILED
        /// </summary>
        public string status { get; set; }
        public string model { get; set; }
        public string input_type { get; set; }
        public string output_type { get; set; }
        /// <summary>
        /// URL at which you should send your input. This URL is compatible with ffmpeg and tools based upon it.
        /// </summary>
        public string input_url { get; set; }

        /// <summary>
        /// URL at which the results can be streamed back. This URL is compatible with ffmpeg and tools based upon it, like Ventuz.
        /// </summary>
        public string output_url { get; set; }
        public DateTime? finished_at { get; set; }
        public DateTime? started_at { get; set; }
        public float fps { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int output_bitrate_kbps { get; set; }

        /// <summary>
        /// The description of the reason for the change in status if it is known. For example, if transitioned to STOPPED due to inactivity, or FAILED due to DeepAI internal error.
        /// </summary>
        public string state_change_reason { get; set; }

        /// <summary>
        /// Currently active model options of the stream.
        /// </summary>
        public Dictionary<string, object> model_options { get; set; }
    }

    class RealtimeStreamList
    {
        public IList<RealtimeStream> streams { get; set; }
    }

    public class AvailableModelOptions : Dictionary<string, ModelOptionPossibleValues>
    {
    }

    public class ModelOptionPossibleValues
    {
        public string type { get; set; }
        public IList<string> choices { get; set; }
    }

    /// <summary>
    /// Basic information about a DeepAI account
    /// </summary>
    public class DeepAIAccountInfo
    {
        public string email { get; set; }
    }

    public class DeepAIError : Exception
    {
        public DeepAIError(String s) : base(s)
        {
            
        }
    } 
    
    /// <summary>
    /// Main API Client class - create an instance of the api by calling: DeepAI_API api = new DeepAI_API(apiKey: "...");
    /// </summary>

    public class DeepAI_API
    {
        private String apiKey;
        /// <summary>
        /// Object with helper utilities for sending input to and playing back a realtime stream.
        /// </summary>
        public RealtimeStreamUtilities realtimeStreamUtilities;

        private static JsonSerializerSettings deserializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };

        /// <summary>
        /// Call this to create a new DeepAI_API instance. 
        /// </summary>
        /// <param name="apiKey">Your DeepAI key as found in your DeepAI dashboard.</param>
        public DeepAI_API(String apiKey)
        {
            this.apiKey = apiKey;
            this.realtimeStreamUtilities = new RealtimeStreamUtilities();
        }


        private Object jsonApiCall(String url_path, String method = "GET", Object dataObjectForJson = null)
        {
            // Use TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // uncomment to ignore ssl errors
            // ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.deepai.org/"+url_path);
            httpWebRequest.Headers["Api-Key"] = this.apiKey;

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;

            if (dataObjectForJson != null) { 
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(dataObjectForJson);

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


        private string stringApiCall(String url_path, String method = "GET", Object dataObjectForJson = null)
        {
            // Use TLS 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // uncomment to ignore ssl errors
            // ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.deepai.org/" + url_path);
            httpWebRequest.Headers["Api-Key"] = this.apiKey;

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = method;

            if (dataObjectForJson != null)
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(dataObjectForJson);

                    streamWriter.Write(json);
                }
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (System.Net.WebException e)
            {
                String errMsg = new StreamReader(e.Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                if (errMsg != null && errMsg.Length > 0) { 
                    throw new DeepAIError("Web Error: "+errMsg);
                }
                else
                {
                    throw new DeepAIError("Web Error: "+e.Message);
                }
            }
        }

        /// <summary>
        /// Get basic infomation about the account associated with the API Key
        /// </summary>
        /// <returns>DeepAIAccountInfo object</returns>
        public DeepAIAccountInfo getAccountInfo()
        {
            return JsonConvert.DeserializeObject<DeepAIAccountInfo>(stringApiCall(url_path: "get_account_info"), deserializerSettings);
        }

        /// <summary>
        /// Get the full list of your active realtime streams, plus streams started or stopped in the last hour
        /// </summary>
        /// <returns>List of stream info objects</returns>
        public IList<RealtimeStream> getRealtimeStreams()
        {
            RealtimeStreamList list = JsonConvert.DeserializeObject<RealtimeStreamList>(stringApiCall(url_path: "realtime-video"), deserializerSettings);
            return list.streams;
        }


        /// <summary>
        /// Get the info for a single realtime stream. Useful for continuously polling the status of a stream.
        /// </summary>
        /// <param name="id">ID of the stream to get</param>
        /// <returns>Stream Info object</returns>
        public RealtimeStream getRealtimeStream(int id)
        {
            return JsonConvert.DeserializeObject<RealtimeStream>(stringApiCall(url_path: "realtime-video/" + id), deserializerSettings);
        }


        /// <summary>
        /// Abort a single realtime stream.
        /// </summary>
        /// <param name="id">ID of the stream to stop</param>
        /// <returns>RealtimeStream object</returns>
        public RealtimeStream stopRealtimeStream(int id)
        {
            return JsonConvert.DeserializeObject<RealtimeStream>(stringApiCall(url_path: "realtime-video/" + id + "/stop", method: "POST"), deserializerSettings);
        }

        /// <summary>
        /// Get the available model options for a given model name
        /// </summary>
        /// <param name="modelName">Name of the model to get options for</param>
        /// <returns>Object representing the possible choices of various fields</returns>
        public AvailableModelOptions getAvailableModelOptionsForModelName(string modelName)
        {
            return JsonConvert.DeserializeObject<AvailableModelOptions>(stringApiCall(url_path: "realtime-video/get-available-model-options/" + modelName), deserializerSettings);
        }

        /// <summary>
        /// Modify a single realtime stream.
        /// </summary>
        /// <param name="id">ID of the stream to modify</param>
        /// <param name="output_bitrate_kbps">If provided, set the output bitrate of the stream to this value.</param>
        /// <returns>RealtimeStream object</returns>
        public RealtimeStream modifyRealtimeStream(int id,
            int output_bitrate_kbps = -1,
            Dictionary<string, object> model_options = null
            )
        {
            var stream_options = new Dictionary<string, object>
            { 
            };

            if (output_bitrate_kbps > 0)
            {
                stream_options["output_bitrate_kbps"] = output_bitrate_kbps;
            }
            if (model_options != null)
            {
                stream_options["model_options"] = model_options;
            }

            return JsonConvert.DeserializeObject<RealtimeStream>(stringApiCall(url_path: "realtime-video/" + id + "/modify", method: "POST", dataObjectForJson: stream_options), deserializerSettings);
        }

        /// <summary>
        /// Creates a new real-time stream.
        /// The status field will initially be "PENDING" which will transition to "RUNNING" within 5 minutes.
        /// If the provided stream does not match the width and height values passed, it will be rescaled.
        /// </summary>
        /// <param name="model">Name of the model to process the video with, such as "deepdream" or "fast-style-transfer"</param>
        /// <param name="input_type">Stream descriptor of in the input video stream. Possible values are "tcp/mpegts" or "udp/mpegts".</param>
        /// <param name="output_type">Stream descriptor of in the output video stream. Possible values are "tcp/mpegts" or "udp/mpegts".</param>
        /// <param name="fps">Frames per second of the input video stream. The output stream will be the same frame rate.</param>
        /// <param name="width">width of the video to process in pixels</param>
        /// <param name="height">height of the video to process in pixels</param>
        /// <param name="output_bitrate_kbps">Bitrate of the output video stream in kbps. If not provided, the system default will be used.</param>
        /// <param name="model_options">Dictionary of options to send to the processing model. Possible values may be retrieved with api.getAvailableModelOptionsForModelName(...)</param>
        /// <returns>RealtimeStream object containing URLs which may be used to connect to the stream by sending input and receiving output.</returns>
        public RealtimeStream startRealtimeStream(
            String model,
            String input_type,
            String output_type,
            float fps,
            int width,
            int height,
            int output_bitrate_kbps=-1,
            Dictionary<string, object> model_options=null
            )
        {
            var stream_options = new Dictionary<string, object>
            { 
                { "model", model },
                { "input_type", input_type },
                { "output_type", output_type },
                { "fps", fps },
                { "width", width },
                { "height", height}
            };

            if (output_bitrate_kbps > 0)
            {
                stream_options["output_bitrate_kbps"] = output_bitrate_kbps;
            }
            if (model_options != null)
            {
                stream_options["model_options"] = model_options;
            }


            return JsonConvert.DeserializeObject<RealtimeStream>(stringApiCall(url_path: "realtime-video/start", method: "POST", dataObjectForJson: stream_options), deserializerSettings);

        }

        /// <summary>
        /// Simple helper method to pretty-print an object response of any API call for easier viewing.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public String objectAsJsonString(Object a){
            return JsonUtility.NormalizeJsonString(JsonConvert.SerializeObject(a));
        }


    }

}

