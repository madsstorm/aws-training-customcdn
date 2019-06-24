using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Input
{
    public class InputFunction
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            dynamic body = JsonConvert.DeserializeObject(input.Body);

            string email = body.email;

            IEnumerable<dynamic> images = body.images;
            foreach(dynamic image in images)
            {
            }

            return new APIGatewayProxyResponse { StatusCode = 200, Body = $"OK" };
        }
    }
}
