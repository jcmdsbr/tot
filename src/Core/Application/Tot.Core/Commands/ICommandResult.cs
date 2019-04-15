using System;

namespace Tot.Shared.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}