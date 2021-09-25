using LibraryTracer;

namespace SPP_1LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new Tracer();
            Foo foo = new Foo(tracer);

            foo.Method1();
            foo.Method2();
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
