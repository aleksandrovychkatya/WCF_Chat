using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCF_Chat;
using System.ServiceModel;
using System.Linq;

namespace WCF_Chat.Tests
{
    [TestClass]
    public class ServiceChatTests
    {
        [TestMethod]
        public void Connect_CreateUserAndConnect_SuccessfullyTest()
        {
            ServiceChat sChat = new ServiceChat();
            string userName = "Petro";

            sChat.Connect(userName);

            Assert.AreEqual(userName, sChat.users.FirstOrDefault(i => i.Name == userName).Name);
        }

        [TestMethod]
        public void Disconnect_CreateUserAddUserToListOfUsersAndDisconnect_UserDisconnectedAndDefault()
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

            Assert.AreEqual(default, sChat.users.FirstOrDefault(i => i.ID == userPetro.ID));

        }

    }
}