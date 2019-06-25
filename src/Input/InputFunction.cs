using Amazon;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            dynamic body = JsonConvert.DeserializeObject(input.Body);

            string email = body.email;

            IAmazonSQS amazonSQS = new AmazonSQSClient(RegionEndpoint.EUCentral1);

            IEnumerable<dynamic> images = body.images;
            foreach (var image in images)
            {
                SendMessageRequest sendMessageRequest = new SendMessageRequest { QueueUrl = "https://sqs.eu-central-1.amazonaws.com/265904212570/ImageQueue" };
                sendMessageRequest.MessageBody = image.url;
                SendMessageResponse sendMessageResponse = await amazonSQS.SendMessageAsync(sendMessageRequest);
            }

            return new APIGatewayProxyResponse { StatusCode = 200, Body = $"OK" };
        }
    }
}
