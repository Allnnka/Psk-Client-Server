using Share;

namespace Server.service
{
    class PingPongService : IServiceModule
    {
        public string AnswerCommand(string command)
        {
            return PingClass.Pong(command);
        }
    }
}
