using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using AuthenticationUtility;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CallContext callContext = new ServiceReference1.CallContext();
            ServiceReference1.WHSMobileDevicesServiceClient client = new ServiceReference1.WHSMobileDevicesServiceClient();
           
            var oauthHeader = OAuthHelper.GetAuthenticationHeader();


            using (OperationContextScope operationContextScope = new OperationContextScope(client.InnerChannel))
            {
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers[OAuthHelper.OAuthHeader] = oauthHeader;
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;

                string lid = string.Empty;
                client.getDefaultLanguage(callContext, out lid);
                
            }
        }
    }
}
