using System;

namespace ExtendableApp.Handlers.DummyEntity
{
    public class Action: IExecutable // ValueObject
    {
        public string Name { get; set; } = "It may have a name!";
        // Option_1=> Like condition, action moght be compiled and set to some class's internal field
        // Option_2=> Each action implements IExecutable interface
        /* Example:
         * SendGreetingEmail:IExecutable{
         *      Name="Отправить приветсвенное письмо"
         *      Execute(){
         *          _mediatr.Send(new SendEmailCommand{
         *              email,
         *              "Hello!........"
         *          })
         *      }
         */

        public void Execute()
        {
            Console.WriteLine(Name);
            //here action body might executed
        }
    }
}