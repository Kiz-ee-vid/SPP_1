using LibraryTracer;
using System;
using System.IO;
using System.Threading;

namespace SPP_1LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new Tracer();
            Foo foo = new Foo(tracer);

            Thread thread1 = new Thread(foo.Method1);
            thread1.Start();

            Thread thread2 = new Thread(foo.Method2);
            thread2.Start();

            foo.Method1(); 
            foo.Method2();

            thread1.Join();
            thread2.Join();

            TraceResult result = tracer.GetTraceResult();

            /*
            * TODO: add serealisation
            */
        }
    }

    public class Foo
    {
        private readonly Bar _bar;
        private readonly ITracer _tracer;

        public Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(tracer);
        }

        public void Method1()
        {
            _tracer.StartTrace();
            Method2();
            _bar.InnerMethod1();
            _tracer.StopTrace();
        }

        public void Method2()
        {
            _tracer.StartTrace();
            _bar.InnerMethod1();
            _bar.InnerMethod2();
            _bar.InnerMethod3();
            _tracer.StopTrace();
        }

    }

    public class Bar
    {
        private readonly ITracer _tracer;

        public Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod1()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
        }

        public void InnerMethod2()
        {
            _tracer.StartTrace();
            InnerMethod3();
            _tracer.StopTrace();
        }

        public void InnerMethod3()
        {
            _tracer.StartTrace();
            InnerMethod1();
            _tracer.StopTrace();
        }

    }
}
