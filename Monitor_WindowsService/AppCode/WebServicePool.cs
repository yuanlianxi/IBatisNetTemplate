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
using System.Web.Services.Description;

namespace Monitor_WindowsService.AppCode
{
    class WebServicePool
    {
        private Dictionary<string, string> urlAssembly = new Dictionary<string, string>();
        
        public Assembly this[string url]
        {
            get
            {
                if (urlAssembly.ContainsKey(url))
                {
                    return Assembly.LoadFile(urlAssembly[url]);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool GenerateWebSeviceAssembly(string url,string assemblyName)
        {
            WebClient web = new WebClient();
            string wsdlUrl = url;
            if (url.ToUpper().Contains("?WSDL"))
            {
                wsdlUrl += "?WSDL";
            }
            Stream stream = web.OpenRead(wsdlUrl);

            // 2. 创建和格式化 WSDL 文档。
            ServiceDescription description = ServiceDescription.Read(stream);

            // 3. 创建客户端代理代理类。
            ServiceDescriptionImporter importer = new ServiceDescriptionImporter();

            importer.ProtocolName = "Soap"; // 指定访问协议。
            importer.Style = ServiceDescriptionImportStyle.Client; // 生成客户端代理。
            importer.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties | CodeGenerationOptions.GenerateNewAsync;

            importer.AddServiceDescription(description, null, null); // 添加 WSDL 文档。

            // 4. 使用 CodeDom 编译客户端代理类。
            CodeNamespace nmspace = new CodeNamespace(); // 为代理类添加命名空间，缺省为全局空间。
            CodeCompileUnit unit = new CodeCompileUnit();
            unit.Namespaces.Add(nmspace);

            ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit);
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            CompilerParameters parameter = new CompilerParameters();
            parameter.GenerateExecutable = false;
            parameter.GenerateInMemory = true;
            parameter.OutputAssembly = assemblyName + ".dll";
            parameter.ReferencedAssemblies.Add("System.dll");
            parameter.ReferencedAssemblies.Add("System.XML.dll");
            parameter.ReferencedAssemblies.Add("System.Web.Services.dll");
            parameter.ReferencedAssemblies.Add("System.Data.dll");

            CompilerResults result = provider.CompileAssemblyFromDom(parameter, unit);

            if (result.Errors.HasErrors)
            {
                return false;
            }
            else
            {
                urlAssembly[url] = assemblyName;
                return true;
            }
        }
        
    }
}
