using System;

namespace MessengerChatApp
{
    public class ChatUser:IUser
    {
        private IChatServer _chatServer;

        public int getId { get; }
        public string getName { get; }
        public bool getOffline { get; }

        public ChatUser(string name, IChatServer chatServer)
        {
            getId = new Random().Next();
            getName = name;
            _chatServer = chatServer;
        }


        public void SendMessage(string sender, string message) => _chatServer.SendMessage(sender, message);

        public void ReceiveMessage(string personName, string reciever, string message)
        {
            Console.WriteLine($"Received message from {personName}: {message}");
        }


    }
}
