using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Speech
{
    class Program
    {
        public static string requestUri = "https://westus.stt.speech.microsoft.com/"; //speech/recognition/conversation/cognitiveservices/v1

        public static string audioFile = null;

        public static string Key = "8185f795483545288123abcc1f0ba65c";

        static void Main(string[] args)
        {
            //通过httpClient 和 HttpContent 提交获取JSON 【等同于Postman的操作】





            //将以下JSON获取到 显示在WriteLine()里；
            //{
            //    "RecognitionStatus": "Success",
            //    "DisplayText": "What's the weather like?",
            //    "Offset": 400000,
            //    "Duration": 13400000
            //}
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
