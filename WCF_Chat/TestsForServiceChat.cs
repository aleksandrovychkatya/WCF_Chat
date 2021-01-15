using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.ServiceModel;

namespace WCF_Chat
{
    public class TestsForServiceChat
    {

        [Fact]
        public void Connect_CreateUserAndConnect_SuccessfullyTest()
        {
            ServiceChat sChat = new ServiceChat();
            string userName = "Petro";

            sChat.Connect(userName);

            Assert.Equal(userName, sChat.users.FirstOrDefault(i => i.Name == userName).Name);
        }

        [Fact]
        public void Disconnect_CreateUserAddUserToListOfUsersAndDisconnect_UserDisconnected()
        {
            ServiceChat sChat = new ServiceChat();
            ServerUser userPetro = new ServerUser()
            {
                ID = 3,
                Name = "Petro",
                operationContext = OperationContext.Current
            };
            sChat.users.Add(userPetro);
            sChat.Disconnect(userPetro.ID);

            Assert.Equal(default, sChat.users.FirstOrDefault(i => i.ID == userPetro.ID));

        }

    }
}
