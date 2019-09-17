using System;

namespace Knab.AppEnvironment
{
    public interface IApplicationEnvironment
    {
        int NewId(int from, int to);

        Guid NewGuid();

        DateTime DateTimeNow();
    }

    public interface IApplicationEnvironment<out TConfiguration> 
        : IApplicationEnvironment
    {
        TConfiguration Configuration { get; }
    }
}
