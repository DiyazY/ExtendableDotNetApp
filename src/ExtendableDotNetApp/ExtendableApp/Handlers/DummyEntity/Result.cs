using System;

namespace ExtendableApp.Handlers.DummyEntity
{
    
    /*
     *          var resultOfExecution = rule.Execute();
                var result = resultOfExecution.Match(
                    success:(bool success) => // success scenario
                    {
                        Console.WriteLine("did it!");
                        return true;
                    },
                    failure:(exception => // failure scenario
                    {
                        Console.WriteLine(exception.Message);
                        return rule.Compensate().Value;
                    }));
     */
    // Note: team may not understand FP
    // Deprecated. High risk of not supporting it!
    public class Result<TSuccess, TFailure>
    {
        private readonly TSuccess _success;
        private readonly TFailure _failure;
        private readonly bool _isSuccess;

        public Result(TSuccess success)
        {
            _success = success;
            _isSuccess = true;
        }

        public Result(TFailure failure)
        {
            _failure = failure;
        }

        public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
        {
            return _isSuccess ? success(_success) : failure(_failure);
        }

        public TSuccess Value => _isSuccess ? _success : default;
    }
}