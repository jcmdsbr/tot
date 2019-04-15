using System;

namespace Tot.Command
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}