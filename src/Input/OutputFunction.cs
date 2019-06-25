using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace Input
{
    public class OutputFunction
    {
        public async Task<string> FunctionHandler(SQSEvent input, ILambdaContext context)
        {
            List<SQSEvent.SQSMessage> messages = input.Records;

            messages.ForEach(m => context.Logger.Log($"Message {m.MessageId}"));

            HttpClient client = new HttpClient();

            foreach(SQSEvent.SQSMessage message in messages)
            {
                var content = client.GetAsync(message.Body).Result.Content;
                Stream contentStream = await content.ReadAsStreamAsync();

                context.Logger.Log(message.MessageId);
            }

            return "OK!!";
        }
    }
}
