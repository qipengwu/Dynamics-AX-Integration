using AuthenticationUtility;
using Microsoft.OData.Client;
using ODataUtility.Microsoft.Dynamics.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ODataConsoleApplication
{
    class Program
    {
        public static string ODataEntityPath = ClientConfiguration.Default.UriString + "data";

        static void Main(string[] args)
        {
            Uri oDataUri = new Uri(ODataEntityPath, UriKind.Absolute);
            var context = new AXODataContext(oDataUri);

            context.SendingRequest2 += new EventHandler<SendingRequest2EventArgs>(delegate(object sender, SendingRequest2EventArgs e)
            {
                var authenticationHeader = OAuthHelper.GetAuthenticationHeader();
                e.RequestMessage.SetHeader(OAuthHelper.OAuthHeader, authenticationHeader);
            });

            SalesOrderHeader soh = context.CreateTrackedEntityInstance<SalesOrderHeader>();
            soh.DataAreaId = "USMF";
            soh.SalesOrderNumber = "000901";
            soh.OrderingCustomerAccountNumber = "US-022";

            SalesOrderLine sol = context.CreateTrackedEntityInstance<SalesOrderLine>();
            sol.DataAreaId = "USMF";
            sol.ItemNumber = "D0001";
            sol.SalesOrderNumber = soh.SalesOrderNumber;

            //SaveChangesOptions.PostOnlySetProperties | SaveChangesOptions.BatchWithSingleChangeset
            context.SaveChanges();

            Console.ReadLine();
        }
    }
}
