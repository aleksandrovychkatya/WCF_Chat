﻿
using System.Windows;
using System.Windows.Input;
using ChatClient.ServiceChat;

namespace ChatClient
{
    public partial class MainWindow : Window, IServiceChatCallback
    {
        public bool isConnected = false;
        ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                bConnDiscon.Content = "Disconnect";
                isConnected = true;
            }
        }
        public void DisconnectUser() {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                tbUserName.IsEnabled = true;
                bConnDiscon.Content = "Connect";
                isConnected = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else ConnectUser();

        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
        }

   

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }
    

  

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    if(tbMessage.Text != "" || tbMessage.Text != " ")
                    {
                        client.SendMsg(tbMessage.Text, ID);
                        tbMessage.Text = string.Empty;
                    }
                    
                }

            }
        }

    }
}
