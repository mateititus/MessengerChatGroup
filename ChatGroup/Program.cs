using System;

namespace MessengerChatApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var chatServer = new ChatServer();

            var person1 = new ChatUser("Mihai", chatServer);
            var person2 = new ChatUser("Ghita", chatServer);

            var observer1 = new ChatObserver("Ilie");
            var observer2 = new ChatObserver("Florin");



            chatServer.RegisterUser(person1);
            chatServer.RegisterUser(person2);
            chatServer.RegisterObserver(observer1);

            chatServer.UnregisterUser(person1);

            chatServer.UnregisterObserver(observer1);


            person1.SendMessage("Mihai" ,"Secret Message");
            person2.SendMessage("Ghita", "Secret Message");


            Console.ReadLine();
        }
    }
}
