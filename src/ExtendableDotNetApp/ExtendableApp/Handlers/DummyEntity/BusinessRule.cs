using System.Collections.Generic;

namespace ExtendableApp.Handlers.DummyEntity
{
    public class BusinessRule: IExecutable // ValueObject
    {
        // we may include domainEvent into a condition
        // for example: beforeCreatedItem && (other statements......)
        //              createdItem && (other statements......)
        //              createdItem && (other statements......)
        // It gives an ability to execute a collection of business rules without filtering them by "before" and "after" behavior.
        // Consequently, each business rule is sufficient, and it knows when it could be executed.
        // However, we may also mark BR "pre" and "post", or something like that
        public Condition Condition { get; private set; } 
        public IList<Action> Actions { get; private set;}

        public BusinessRule(Condition condition, IList<Action> actions)
        {
            Condition = condition;
            Actions = actions;
        }

        public void Execute()
        {
            Condition.Execute();// do the evaluation of a condition
            if (Condition.Result) // check the result of an executed condition
            {
                foreach (var action in Actions)
                {
                    action.Execute();
                }
            }
        }
    }
}