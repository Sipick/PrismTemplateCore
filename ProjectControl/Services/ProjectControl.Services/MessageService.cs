using ProjectControl.Services.Interfaces;

namespace ProjectControl.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
