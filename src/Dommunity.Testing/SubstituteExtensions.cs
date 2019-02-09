using System.Linq;
using NSubstitute;
using NSubstitute.Exceptions;

namespace Dommunity.Testing
{
    /// <summary>
    /// Contains help methods for NSubstitute.
    /// </summary>
    public static class SubstituteExtensions
    {
        /// <summary>
        /// Check this substitute has received the dispose pattern calls.
        /// </summary>
        public static void ReceivedDisposePattern<T>(this T substitute) where T : class
        {
            // Get number of calls into protected dispose.
            var called = substitute.ReceivedCalls().Count(call =>
            {
                var methodInfo = call.GetMethodInfo();

                // Check method name.
                if (methodInfo.Name != "Dispose")
                {
                    return false;
                }

                // Check return type.
                if (methodInfo.ReturnType != typeof(void))
                {
                    return false;
                }

                // Check parameter.
                var paramsInfo = methodInfo.GetParameters();

                if (paramsInfo.Length != 1 || paramsInfo[0].ParameterType != typeof(bool))
                {
                    return false;
                }

                // Check value of parameter.
                if (!(bool)call.GetArguments()[0])
                {
                    throw new ReceivedCallsException(
                        "Expected a call into protected dispose with true argument, got false."
                    );
                }

                return true;
            });

            if (called != 1)
            {
                throw new ReceivedCallsException($"Expected a call into protected dispose, got {called}.");
            }
        }
    }
}
