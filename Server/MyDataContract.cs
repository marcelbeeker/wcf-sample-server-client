using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Server
{
    public enum ReminderActionType { None = 0, AppointmentSmsSend = 1, AppointmentEmailSend = 2 }

    [KnownType(typeof(AppoinmentSmsSend))]
    [KnownType(typeof(AppointmentEmailSend))]
    public class ReminderBase
    {
        public ReminderActionType ReminderAction { get; set; }
    }

    public class AppoinmentSmsSend : ReminderBase
    {
        public string Phonenumber { get; set; }
    }

    public class AppointmentEmailSend : ReminderBase
    {
        public string Email { get; set; }
    }

    public class PatientReminder
    {
        public string Id { get; set; }

        public IEnumerable<ReminderBase> Reminders { get; set; }
    }
}
