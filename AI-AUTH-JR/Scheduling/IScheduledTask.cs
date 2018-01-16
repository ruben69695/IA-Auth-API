using System.Threading;
using System.Threading.Tasks;

namespace AI_AUTH_JR.Scheduling
{
    public interface IScheduledTask
    {
        string Schedule { get; }
    }
}