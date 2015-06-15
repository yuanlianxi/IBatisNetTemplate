using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Monitor_WindowsService.AppCode
{
    public class HttpLinkTaskHelper
    {
        private volatile bool isRuning = true;
        private HttpWebRequest webRequest;
        public volatile object Result;
        private Exception exception;
        private  DateTime endDateTime;

        
        public bool IsRuning
        {
            get { return isRuning; }
            set { isRuning = value; }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        public void GetString(string url, int timeout)
        {

            webRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.Timeout = timeout;
            
            webRequest.BeginGetResponse((IAsyncResult o) =>
            {
                HttpWebResponse response = webRequest.EndGetResponse(o) as HttpWebResponse;
                String contentType = response.ContentType;
                Stream stream = response.GetResponseStream();
                if (response.StatusCode!=HttpStatusCode.OK )
                {
                    exception = new Exception(response.StatusDescription);
                    return;
                }
                int bufferLen = 1024 * 1024;
                byte[] bytes = new byte[bufferLen];
                stream.Read(bytes, 0, bufferLen);
                if (IsUTF8(contentType))
                {

                    Result = Encoding.UTF8.GetString(bytes);
                }
                else
                {
                    Result = Encoding.Default.GetString(bytes);
                }
                isRuning = false;
                EndDateTime = DateTime.Now;
            }, null);
            
            
        }
        public void Cancel()
        {
            if (webRequest!= null)
            {
                webRequest.Abort();
            }
        }
        private bool IsUTF8(string contentType)
        {
            return contentType.ToLower().Contains("utf-8");
        }
    }
}
