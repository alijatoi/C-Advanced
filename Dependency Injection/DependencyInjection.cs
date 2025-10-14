using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    // Dependency Injection ka example,,, Program Main mein jao wahan se call karna hai..
    // Wahan per dekho kesa kam horaha hai...

    // Abhi yehen internal class DependencyInjection bana rahe hain.. jismein show kar rhy hen tight coupling kaise ho raha hai
    // uske baad neechay ham interface bana kar usko implement karenge aur dekhenge kesa loose coupling hota hai
    internal class WithoutDependencyInjection
    {
        // Idhar Ham Class Define kar rahe hain
        public class MessageSender
        {
            public void SendUpdate(string message)
            {
                Console.WriteLine("Sending message: " + message);
            }
        }

        public class EmailSender
        {
             public void SendUpdate(string message)
            {
                Console.WriteLine("Sending email: " + message);
            }
        }



        //idhar ham uper wali class use kar rahe hain

        //neechay example mein dekhen tight coupling kaise ho raha hai
        // NotificationService class ab dono class per depend kar raha hai
        public class NotificationService
        {
            private MessageSender _messageSender; // tight coupling.... Notification Service class ab IMessageSender class per depend kar raha hai
            private EmailSender _emailSender; // tight coupling.... Notification Service class ab EmailSender class per depend kar raha hai
            
            public NotificationService()
            {
                _messageSender = new MessageSender(); // yahan per instance bana rahe hain under constructor
                _emailSender = new EmailSender(); // same yahan bhi...
            }

            
            public void SendNotifications(string message)
            {
                _messageSender.SendUpdate(message);
                _emailSender.SendUpdate(message);
            }

        }
    }



internal class DependencyInjectionLooseCoupling
{
    // Abhi ham interface bana rahe hain jiska naam ham IUpdateSender rakh rahe hain
    public interface IUpdateSender
    {
        void SendUpdate(string message);
    }
    // Abhi ham MessageSender class ko implement kar rahe hain
    public class MessageSender : IUpdateSender
    {
        public void SendUpdate(string message)
        {
            Console.WriteLine("Sending message: " + message);
        }
    }
    // Abhi ham EmailSender class ko implement kar rahe hain
    public class EmailSender : IUpdateSender
    {
        public void SendUpdate(string message)
        {
            Console.WriteLine("Sending email: " + message);
        }
    }


    // Abhi ham NotificationService class bana rahe hain jo ab loose coupling ka example hai
    public class NotificationService
    {
        // yahan per ham IUpdateSender interface ka use kar rahe hain
        private IUpdateSender _updateSender;
        // Abhi ham constructor bana rahe hain jo IUpdateSender interface ko accept kar raha hai
        public NotificationService(IUpdateSender updateSender)
        {
            _updateSender = updateSender; // yahan per ham dependency inject kar rahe hain
        }
        public void SendNotification(string message)
        {
            _updateSender.SendUpdate(message); // yahan per ham SendUpdate method call kar rahe hain
        }

        // uper hamne constructor injection ka use kiya hai,,, 
        // ham ab MessageSender, ya EmailSender class ka instance bana kar bahir se
        // NotificationService class ko de sakte hain

        // Abhi ham method bana rahe hain jo example show karega kesa kam karta hai loose coupling

    }

}
