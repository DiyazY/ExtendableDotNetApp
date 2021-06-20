namespace ExtendableApp.Handlers.DummyEntity
{
    public class Condition : IExecutable // ValueObject
    {
        // condition should be compiled and set to some class's internal field
        // Note: there are some libs and methods how to compile code from metadata at a compile time (Expressions, AST, Roslyn)
        public bool Result { get; set; } // better to make it {private set;}

        public void Execute()
        {
            //here compiled condition might executed and set the result of its execution
            //Result = true;
        }
    }
}