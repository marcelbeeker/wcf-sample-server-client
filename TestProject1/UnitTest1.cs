using Newtonsoft.Json;
using Server;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var reminders = new ServerService().GetReminders();

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var json = JsonConvert.SerializeObject(reminders, settings);

            var deserializedReminders = JsonConvert.DeserializeObject<PatientReminder>(json, settings);

            foreach (var reminder in deserializedReminders.Reminders)
            {
                if (reminder is AppoinmentSmsSend)
                {
                    var appointmentSmsSendReminder = reminder as AppoinmentSmsSend;

                    Console.WriteLine(appointmentSmsSendReminder.Phonenumber);
                }
            }

            Assert.True(true);
        }
    }
}
