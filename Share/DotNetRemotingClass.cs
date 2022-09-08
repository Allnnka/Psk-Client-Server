using System;

namespace Share
{
    public class DotNetRemotingClass : MarshalByRefObject
    {
        public delegate string CommandD(string command);
        private CommandD onCommand;

        public DotNetRemotingClass(CommandD onCommand)
        {
            this.onCommand = onCommand;
        }

        public DotNetRemotingClass() { }
        public string Command(string command)
        {
            if (command != String.Empty)
            {
                return onCommand(command);
            }
            return "Something gone wrong";
        }
    }
}
