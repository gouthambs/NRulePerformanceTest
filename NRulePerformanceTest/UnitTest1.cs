using NRules;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace NRulePerformanceTest
{
    public class Tests
    {
        RuleEngine _engine;
        ISessionFactory _factory;
        Stopwatch _watch;

        [SetUp]
        public void Setup()
        {
            _watch = Stopwatch.StartNew();
            _engine = new RuleEngine();
            _factory = _engine.InitializeEngine();

            _watch.Stop();
            Console.WriteLine($"Engine initialized in {_watch.ElapsedMilliseconds} milliseconds");
        }

        [Test]
        public void Test1()
        {
            var session = _factory.CreateSession();
            _engine.load(session, 1000);

            _watch = Stopwatch.StartNew();
            Console.WriteLine($"Firing rules at {DateTime.Now}");
            var result = session.Fire();
            _watch.Stop();
            Console.WriteLine($"Rules completed in {_watch.ElapsedMilliseconds} milliseconds");
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            _watch = Stopwatch.StartNew();
            Console.WriteLine($"Firing rules in batches at {DateTime.Now}");
            for(int i = 1; i<= 1000; i++)
            {
                var session = _factory.CreateSession();
                _engine.load(session, 10);
                session.Fire();
            }
            
            _watch.Stop();
            Console.WriteLine($"Rules completed in {_watch.ElapsedMilliseconds} milliseconds");
            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            _watch = Stopwatch.StartNew();
            Console.WriteLine($"Firing rules on single leads at {DateTime.Now}");
            for (int i = 1; i <= 100000; i++)
            {
                var session = _factory.CreateSession();
                _engine.load(session, 1);
                session.Fire();
            }

            _watch.Stop();
            Console.WriteLine($"Rules completed in {_watch.ElapsedMilliseconds} milliseconds");
            Assert.Pass();
        }
    }
}