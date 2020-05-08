using System;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace GameNight.NotificationService
{
	public class RabbitNotificationService : INotifyService
	{
		private ConnectionFactory factory;
		private String QueueName;

		public RabbitNotificationService()
		{
			factory = new ConnectionFactory() { HostName = "localhost" };
			QueueName = "werewolfqueue";
		}

		public void SendMessage(MessageModel message)
		{
			using(var connection = factory.CreateConnection())
			using(var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: QueueName, true, false, false, null);
				var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

				channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
			}
		}
	}
}
