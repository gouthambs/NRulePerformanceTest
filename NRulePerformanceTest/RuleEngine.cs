using NRulePerformanceTest.Models;
using NRules;
using NRules.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NRulePerformanceTest
{
    public class RuleEngine
    {
        private readonly IEnumerable<ConsumerLead> _leads;
       
        public RuleEngine()
        {
            _leads = (from data in GetDataPerLines()
                          let splitFields = data.Split(",".ToCharArray())
                          select new ConsumerLead(splitFields)).ToList();
        }

        public ISessionFactory InitializeEngine()
        {            
            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(TestRule).Assembly));

            //Compile rules
            return repository.Compile();

            //Create a working session
            //return factory.CreateSession();
        }

        public void load(ISession session, long size = 100)
        {
            //var _query = from data in GetDataPerLines()
            //            let splitFields = data.Split(",".ToCharArray())
            //            select new ConsumerLead(splitFields);

            if (size == 1)
            {
                session.Insert(_leads.ElementAt(new Random().Next(1, 100000)));
            }
            else
            {
                long records = 0;
                bool first = true;
                foreach (var item in _leads)
                {
                    if (first)
                        first = false;
                    else
                    {
                        session.Insert(item);
                        records++;
                    }

                    if (records >= size)
                        break;
                }
            }
        }
        
        private static IEnumerable<String> GetDataPerLines()
        {
            FileStream aFile = new FileStream("MarketingAttributes.csv", FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
            sr.Close();
        }
    }
}
