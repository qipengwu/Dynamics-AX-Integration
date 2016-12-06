﻿using Microsoft.IdentityModel.Clients.ActiveDirectory;
//using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUtility
{
    public class OAuthHelper
    {
        /// <summary>
        /// The header to use for OAuth.
        /// </summary>
        public const string OAuthHeader = "Authorization";

        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public async static Task<string> GetAuthenticationHeader()
        {
            string aadTenant = ClientConfiguration.Default.ActiveDirectoryTenant;
            string aadClientAppId = ClientConfiguration.Default.ActiveDirectoryClientAppId;
            string aadResource = ClientConfiguration.Default.ActiveDirectoryResource;
            string aadClientSecret = ClientConfiguration.Default.ActiveDirectoryClientSecret;

            AuthenticationContext authenticationContext = new AuthenticationContext(aadTenant);

            // OAuth through username and password.
            string username = ClientConfiguration.Default.UserName;
            string password = ClientConfiguration.Default.Password;

            // Get token object
            //AuthenticationResult authenticationResult = authenticationContext.AcquireToken(aadResource, aadClientAppId, new UserCredential(username, password));
            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(aadResource, new ClientCredential(aadClientAppId, aadClientSecret));

            // Create and get JWT token
            return authenticationResult.CreateAuthorizationHeader();
        }


    }
}
