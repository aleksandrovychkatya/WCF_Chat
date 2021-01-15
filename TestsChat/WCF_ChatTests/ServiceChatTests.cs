using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WCF_Chat;
using System.ServiceModel;


namespace TestsChat.WCF_ChatTests
{
    public class ServiceChatTests
    {
        //List<ServerUser> users = new List<ServerUser>();
        //ServiceChat schat = new ServiceChat();
       
        [Fact]
        public void Connect_CreateUserAndConnect_SuccessfullyTest()
        {
            ServiceChat schat = new ServiceChat();
            string UserName = "Petro";
            //int ID = schat.Connect(UserName);
            Assert.True(schat.Connect(UserName)!= 0);

        }

    }
}
