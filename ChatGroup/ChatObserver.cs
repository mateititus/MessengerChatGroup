using System;


namespace MessengerChatApp
{
    class ChatObserver : IObserver
    {

        public int getId { get; }
        public string getName { get; }
        public bool getOffline { get; }

        public ChatObserver(string name)
        {
            getId = new Random().Next();
            getName = name;
        }

        public void ReceiveMessage(string personName, string reciever, string message)
        {
            Console.WriteLine($"Received message from {personName}: {message}");
        }

    }
}
