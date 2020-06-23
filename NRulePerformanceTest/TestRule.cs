using NRulePerformanceTest.Models;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRulePerformanceTest
{    
    public class TestRule : Rule
    {
        public override void Define()
        {
            ConsumerLead consumerLead = null;

            When()
                .Or(o => o
                    .Match<ConsumerLead>(c => c.LoanPurpose == "Purchase" && c.LeadSource == "Digital")                    
                    .And(a => a
                        .Match<ConsumerLead>(c => c.FICO > 660 && c.LoanAmount > 120000 && c.LoanAmount < 420000 && c.LoanPurpose != "Purchase")
                        .Match<ConsumerLead>(c => c.LeadSource == "LendingTree2" || c.LeadSource == "LendingTree")
                    )
                );

            Then()
                .Do(_ => Noop());
        }

        private void Noop() { }
    }

    //public class NewRule : Rule
    //{
    //    public override void Define()
    //    {
    //        When()
    //            .
    //    }
    //}
}
