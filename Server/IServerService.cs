using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    interface IServerService
    {
        [OperationContract]
        PatientReminder GetReminders();
    }
}
