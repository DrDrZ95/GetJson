using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Speech
{
    class Program
    {
        public static string requestUri = "https://westus.stt.speech.microsoft.com/speech/recognition/conversation/cognitiveservices/v1?language=en-US"; //speech/recognition/conversation/cognitiveservices/v1

        public static string audioFile = @"C:\Users\zhu\Desktop\人工智能（语音识别）-教学\whatstheweatherlike.wav";

        public static string subscriptionKey = "8185f795483545288123abcc1f0ba65c";

        static void Main(string[] args)
        {
            //通过HttpWebRequest或者(httpClient 和 HttpWebRequest) 提交获取JSON 【等同于Postman的操作】
            
            var web = HttpWebRequestJson();

            //将以下JSON获取到 显示在WriteLine()里；
            //{
            //    "RecognitionStatus": "Success",
            //    "DisplayText": "What's the weather like?",
            //    "Offset": 400000,
            //    "Duration": 13400000
            //}
            Console.WriteLine("【web】\n" + web);
            Console.ReadLine();
        }
        
        public static string HttpWebRequestJson()
        {
            string requestUrl = requestUri;
            System.Net.HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            request.SendChunked = true;
            request.Accept = @"application/json;text/xml";
            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;
            request.ContentType = @"audio/wav;codec=audio/pcm;samplerate=16000";
            request.Headers["Ocp-Apim-Subscription-Key"] = subscriptionKey;
            using (FileStream fs = new FileStream(audioFile, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = null;
                int bytesRead = 0;
                using (Stream requestStream = request.GetRequestStream())
                {
                    buffer = new Byte[checked((uint)Math.Min(1024, (int)fs.Length))];
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }

                    requestStream.Flush();
                }
            }
            string re = null;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    re = sr.ReadToEnd();
                }
            }
            return re;
        }
    }
}
