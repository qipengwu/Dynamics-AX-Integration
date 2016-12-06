using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUtility
{
    public partial class ClientConfiguration
    {
        public static ClientConfiguration Default { get { return ClientConfiguration.OneBox; } }

        public static ClientConfiguration OneBox = new ClientConfiguration()
        {
            UriString = "https://pwupdate3aos.cloudax.dynamics.com/",
            UserName = "qipengwu@pwax7.onmicrosoft.com  ",
            Password = "Pass!Word",
            ActiveDirectoryResource = "https://pwupdate3aos.cloudax.dynamics.com",
            ActiveDirectoryTenant = "https://login.windows.net/pwax7.onmicrosoft.com",
            /*ActiveDirectoryClientAppId = "f00ced34-2591-41f4-b22d-5005000f05be"     
              
            UriString = "https://ax71-demo002aos.cloudax.dynamics.com/",
            UserName = "ccrmdeva@microsoft.com",
            Password = "C!oudcrmACC0unt",
            ActiveDirectoryResource = "https://ax71-demo002aos.cloudax.dynamics.com",
            ActiveDirectoryTenant = "https://login.windows.net/microsoft.com",
            //ActiveDirectoryClientAppId = "9d1e285e-33a3-4a68-9382-185ee3bd3391"  
            //ActiveDirectoryClientAppId = "1a756409-e87e-42dc-b706-0514f8f04767",
*/
            ActiveDirectoryClientAppId = "eb4b16ca-1635-407b-9888-e71a9361d0aa",
            ActiveDirectoryClientSecret = "dYSH6sCssLWZ+C7YB6M2jiJM8gxBB7ad1hzkSZJH+tI="
            
 
        };

        public string UriString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ActiveDirectoryResource { get; set; }
        public String ActiveDirectoryTenant { get; set; }
        public String ActiveDirectoryClientAppId { get; set; }
        public String ActiveDirectoryClientSecret { get; set; }
    }
}
