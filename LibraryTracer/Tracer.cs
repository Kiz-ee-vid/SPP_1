using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LibraryTracer
{
    public class Tracer : ITracer
    {
        private readonly List<ITracer> _threadTracers = new();
        private readonly ReaderWriterLockSlim _lock = new();

        private ITracer GetThreadTracer(int id)
        {
            
        }

        private void AddThreadTracer(ITracer threadTracer)
        {
           
        }

        public void StartTrace()
        {
           
        }

        public void StopTrace()
        {
           
        }

        public ITraceResult GetTraceResult()
        {
           
        }

    }
}
