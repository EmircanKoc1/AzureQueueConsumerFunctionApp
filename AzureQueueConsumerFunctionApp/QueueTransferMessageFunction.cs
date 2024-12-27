using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureQueueConsumerFunctionApp
{
    public class QueueTransferMessageFunction
    {
        private readonly ILogger<QueueTransferMessageFunction> _logger;

        public QueueTransferMessageFunction(ILogger<QueueTransferMessageFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(QueueTransferMessageFunction))]
        [QueueOutput("outputqueue", Connection = "MyAccount")]
        public string Run([QueueTrigger("queue1", Connection = "MyAccount")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");


            return $"Transfered message : {message.MessageText}";

        }
    }
}
