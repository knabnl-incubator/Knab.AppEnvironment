using System;
using System.Threading;

namespace Knab.AppEnvironment
{
    public class ApplicationEnvironment : IApplicationEnvironment
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }

        public DateTime DateTimeNow()
        {
            return DateTime.Now;
        }
        
        public int NewId(int from, int to)
        {
            return Random.Next(from, to);
        }

        protected static Random Random => 
            ThreadLocalRandom.Value;

        private static readonly ThreadLocal<Random> ThreadLocalRandom = new ThreadLocal<Random>(() =>
        {
            var seed = Guid.NewGuid().GetHashCode();

            return new Random(Interlocked.Increment(ref seed));
        });
    }

    public class ApplicationEnvironment<TConfiguration> : 
        ApplicationEnvironment, 
        IApplicationEnvironment<TConfiguration>
    {
        public ApplicationEnvironment(TConfiguration configuration)
        {
            Configuration = configuration;
        }

        public TConfiguration Configuration { get; }
    }
}
