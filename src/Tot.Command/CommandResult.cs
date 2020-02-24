using System;
using Tot.Shared.Commands;

namespace Tot.Command
{
    public abstract class CommandResult : ICommandResult
    {
        protected CommandResult()
        {
            Executed = DateTime.Now;
        }

        public bool Success { get; protected set; }

        public DateTime Executed { get; }
    }
}