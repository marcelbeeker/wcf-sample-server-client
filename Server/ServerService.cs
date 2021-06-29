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
                Reminders = new List<AppoinmentSmsSend>()
                {
                    new AppoinmentSmsSend()
                    {
                        Phonenumber = "123456789",
                        ReminderAction = ReminderActionType.AppointmentSmsSend
                    }
                }
            };

            return reminders;
        }
    }
}
