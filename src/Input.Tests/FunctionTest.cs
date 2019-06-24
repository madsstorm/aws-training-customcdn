using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using Input;

namespace Input.Tests
{
    public class InputFunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new InputFunction();
            var context = new TestLambdaContext();
            var response = function.FunctionHandler(new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest { Body = "hello world" }, context);

            Assert.Equal("HELLO WORLD", response.Body);
        }
    }
}
