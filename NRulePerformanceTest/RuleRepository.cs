using NRules.RuleModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRulePerformanceTest
{
    public class ContactStrategyRuleRepository : IRuleRepository
    {
        private readonly IRuleSet _ruleSet = new RuleSet("MyRuleSet");

        public IEnumerable<IRuleSet> GetRuleSets()
        {
            return new[] { _ruleSet };
        }

        public void LoadRules()
        {
            //Assuming there is only one rule in this example
            //var rule = BuildRule();
            //_ruleSet.Add(new[] { rule });
        }

        //private IRuleDefinition BuildRule()
        //{
        //    //...
        //}
    }
}
