﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ChatClient.Annotations;
using Model;
using RestSharp;

namespace ChatClient
{
    public class WebserviceAPI
    {
        private static readonly string BASE_URL = "http://127.0.0.1/webservice/api/";

        [CanBeNull] public static UserAccount LoggedInUserAccount;

        public static void Registrate(string firstname, string lastname, string username, string password, string statusMessage, byte[] userIcon = null)
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("useraccount/registration", Method.POST);
            request.AddParameter("firstname", firstname);
            request.AddParameter("lastname", lastname);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("statusMessage", statusMessage);

            var registrationResponse = (RestResponse<UserAccount>)client.Execute<UserAccount>(request);

            if (registrationResponse.StatusCode == HttpStatusCode.OK && registrationResponse.Data != null)
            {
                LoggedInUserAccount = registrationResponse.Data;
            }
            else
            {
                throw new Exception(registrationResponse.ErrorMessage);
            }
        }

        public static void Login(string userName, string password)
        {
            var client = new RestClient(BASE_URL);
            var request = new RestRequest("useraccount/login", Method.POST);
            request.AddParameter("username", userName);
            request.AddParameter("password", password);
            var loginResponse = (RestResponse<UserAccount>)client.Execute<UserAccount>(request);
            if (loginResponse.StatusCode == HttpStatusCode.OK && loginResponse.Data != null)
            {
                LoggedInUserAccount = loginResponse.Data;
            }
            else
            {
                throw new Exception(loginResponse.ErrorMessage);
            }
        }

        public static void Logout()
        {
            if (LoggedInUserAccount != null)
            {
                var client = new RestClient(BASE_URL);
                var request = new RestRequest("useraccount/logout", Method.POST);
                request.AddParameter("username", LoggedInUserAccount.UserName);
                request.AddParameter("password", LoggedInUserAccount.Password);
                var loginResponse = client.Execute(request);
                if (loginResponse.StatusCode == HttpStatusCode.OK)
                {
                    LoggedInUserAccount = null;
                }
                else
                {
                    throw new Exception(loginResponse.ErrorMessage);
                }
            }
        }

        public static IEnumerable<Model.Chat> LoadChatList()
        {
            if (LoggedInUserAccount != null)
            {
                var client = new RestClient(BASE_URL);
                var request = new RestRequest("chat/chats", Method.POST);
                request.AddParameter("username", LoggedInUserAccount.UserName);
                request.AddParameter("password", LoggedInUserAccount.Password);

                var chatResponse = (RestResponse<List<Model.Chat>>)client.Execute<List<Model.Chat>>(request);

                if (chatResponse.StatusCode == HttpStatusCode.OK)
                {
                    return (List<Model.Chat>)chatResponse.Data;

                }
                throw new Exception(chatResponse.ErrorMessage.ToString());
            }
            return null;
        }

        public static IEnumerable<UserAccount> LoadContactList()
        {
            if (LoggedInUserAccount != null)
            {
                var client = new RestClient(BASE_URL);
                var request = new RestRequest("useraccount/contacts", Method.POST);
                request.AddParameter("username", LoggedInUserAccount.UserName);
                request.AddParameter("password", LoggedInUserAccount.Password);

                var userAccountResponse = (RestResponse<List<UserAccount>>)client.Execute<List<UserAccount>>(request);

                if (userAccountResponse.StatusCode == HttpStatusCode.OK)
                {
                    return userAccountResponse.Data;
                }
                throw new Exception(userAccountResponse.ErrorMessage.ToString());
            }
            return null;
        }
    }
}
