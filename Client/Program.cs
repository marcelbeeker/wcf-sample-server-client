using Client.ServiceReference1;
using Server;
using System;
using System.Linq;

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

            var smsReminders = reminders.Reminders.Where(p => p.ReminderAction == ReminderActionType.AppointmentSmsSend);

            foreach (var smsReminder in smsReminders)
            {
                var appointmentSmsSend = smsReminder as AppoinmentSmsSend;

                Console.WriteLine($"SmsReminder {appointmentSmsSend.Phonenumber}");
                Console.WriteLine($"SmsReminder {appointmentSmsSend.ReminderAction.ToString()}");
            }

            var emailReminders = reminders.Reminders.Where(p => p.ReminderAction == ReminderActionType.AppointmentEmailSend);

            foreach (var emailReminder in emailReminders)
            {
                var appointmentEmailSend = emailReminder as AppointmentEmailSend;

                Console.WriteLine($"EmailReminder {appointmentEmailSend.Email}");
                Console.WriteLine($"EmailReminder {appointmentEmailSend.ReminderAction.ToString()}");
            }

            Console.ReadLine();
            client.Close();
        }
    }
}
