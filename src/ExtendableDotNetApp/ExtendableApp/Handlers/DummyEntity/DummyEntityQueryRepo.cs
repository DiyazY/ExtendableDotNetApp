using System;
using System.Collections.Generic;

namespace ExtendableApp.Handlers.DummyEntity
{
    public class DummyEntityQueryRepo
    {
        public List<BusinessRule> GetDummyEntityPreActionBusinessRules(int id)
        {
            // here we should containerize business rules, make them comprehensive and executable
            var passedCondition = new Condition();
            passedCondition.Result = true;//for test
            
            var notPassedCondition = new Condition();
            notPassedCondition.Result = false;//for test 
            return new List<BusinessRule>
            {
                new BusinessRule(passedCondition, new List<Action>()
                {
                    new Action(){Name = "pre-HE HE"},
                    new Action(){Name = "pre-NO NO"}
                }),
                
                new BusinessRule(notPassedCondition, new List<Action>()
                {
                    new Action(){Name = "pre-qwe qwe"},
                    new Action(){Name = "pre-ewq ewq"}
                })
            };
        }
        
        public List<BusinessRule> GetDummyEntityPostActionBusinessRules(int id)
        {
            // here we should containerize business rules, make them comprehensive and executable
            var passedCondition = new Condition();
            passedCondition.Result = true;//for test
            
            var notPassedCondition = new Condition();
            notPassedCondition.Result = false;//for test 
            return new List<BusinessRule>
            {
                new BusinessRule(passedCondition, new List<Action>()
                {
                    new Action(){Name = "post-HE HE"},
                    new Action(){Name = "post-NO NO"}
                }),
                
                new BusinessRule(notPassedCondition, new List<Action>()
                {
                    new Action(){Name = "post-qwe qwe"},
                    new Action(){Name = "post-ewq ewq"}
                })
            };
        }
    }
}