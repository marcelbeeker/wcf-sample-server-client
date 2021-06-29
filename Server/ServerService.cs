using System.Collections.Generic;

namespace Server
{
    public class ServerService : IServerService
    {
        public PatientReminder GetReminders()
        {
            var reminders = new PatientReminder()
            {
                Id = "1",
                Reminders = new List<ReminderBase>()
                {
                    new AppoinmentSmsSend()
                    {
                        Phonenumber = "123456789",
                        ReminderAction = ReminderActionType.AppointmentSmsSend
                    },
                    new AppointmentEmailSend()
                    {
                        Email = "test@test.nl",
                        ReminderAction = ReminderActionType.AppointmentEmailSend,
                    }
                }
            };

            return reminders;
        }
    }
}
