using Client.ServiceReference1;
using Server;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //To add ServerServiceClient use
            //svcutil.exe http://localhost:8000/ServerService?wsdl
            //OR easier way 
            //To add new right click on project "Add Service Reference"
            //Update right click on "Service References->ServiceReference1" then "Update Service Reference"
            ServerServiceClient client = new ServerServiceClient("BasicHttpBinding_IServerService", "http://localhost:8000/ServerService");

            var reminders = client.GetReminders();

            foreach (var reminder in reminders.Reminders)
            {
                if (reminder is AppoinmentSmsSend)
                {
                    var appointmentSmsSend = reminder as AppoinmentSmsSend;

                    Console.WriteLine(appointmentSmsSend.Phonenumber);
                    Console.WriteLine(appointmentSmsSend.ReminderAction.ToString());
                }
            }

            Console.ReadLine();
            client.Close();
        }
    }
}
