using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Input
{
    public class OutputFunction
    {
        public string FunctionHandler(SQSEvent input, ILambdaContext context)
        {
            List<SQSEvent.SQSMessage> messages = input.Records;

            context.Logger.Log(string.Join(",", messages.Select(x => x.Body)));

            return "OK!!";
        }
    }
}
