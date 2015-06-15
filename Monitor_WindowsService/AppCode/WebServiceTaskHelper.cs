using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using ApplicationCommon;
namespace Monitor_WindowsService.AppCode
{
    class WebServiceTaskHelper
    {
        private volatile object result;
        private volatile bool isRuning = true;
        private  DateTime endDateTime;
        public object Result
        {
            get { return result; }
            set { result = value; }
        }
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
        private WebServicePool webServicePool = new WebServicePool();
        private Dictionary<string, Dictionary<string, MethodInfo>> urlMethods = new Dictionary<string, Dictionary<string, MethodInfo>>();
        public void Init(IEnumerable<string> urls)
        {
            foreach (var item in urls)
            {
                string assemblyName = MD5Helper.GetMD5(item) + ".dll";
                string assemblyFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName);
                webServicePool.GenerateWebSeviceAssembly(item, assemblyFullName);
                
            }
        }

        public void Invoke(string url, string methodName, object[] paras)
        {
            isRuning = true;
            MethodInfo method = GetWebServiceMethod(url, methodName);
            Type type = method.DeclaringType;
            Object service = Activator.CreateInstance(type);

            Func<object> func = new Func<object>(()=> {return  method.Invoke(service, paras);});
            func.BeginInvoke(o => { result = func.EndInvoke(o); isRuning = false; EndDateTime = DateTime.Now; }, null);
        }

        private MethodInfo GetWebServiceMethod(string url, string methodName)
        {

            Dictionary<string, MethodInfo> methods = null;
            MethodInfo method = null;
            Assembly assem = null;

            
            if(!urlMethods.ContainsKey(url))
            {
                urlMethods[url] = new Dictionary<string, MethodInfo>();
                methods = urlMethods[url];

                assem = webServicePool[url];
                if (assem == null)
                {
                    string assemblyName = MD5Helper.GetMD5(url) + ".dll";
                    string assemblyFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName);
                    webServicePool.GenerateWebSeviceAssembly(url, assemblyFullName);
                }
                assem = webServicePool[url];
                if (assem == null)
                {
                    throw new Exception(url+"所对应的WebService中没有找到其实现!");
                }
                method = GetWebServiceMethod(assem,url, methodName);

                methods[methodName] = method;
                return method;
            }
            if (methods.ContainsKey(methodName))
            {
                return methods[methodName];
            }
            
            
            method = GetWebServiceMethod(assem, url, methodName);
            methods[methodName] = method;
            return method;
        }

        public MethodInfo GetWebServiceMethod(Assembly assem,string url,string methodName)
        {
            List<Type> webServices = assem.GetTypes().Where<Type>(o => o.BaseType == typeof(System.Web.Services.Protocols.SoapHttpClientProtocol)).ToList();
            if (webServices == null || webServices.Count == 0)
            {
                throw new Exception(url +"所对应的WebService中,没有找到对应实现WebService的类型");
            }
            MethodInfo method = null;
            
            foreach (var item in webServices)
            {
                
                method = item.GetMethod(methodName);
                if (method != null)
                {
                    return method;
                }
            }
            throw new Exception(url+"所对应的WebService中没有找到对应方法"+methodName);
        }
    }
}
