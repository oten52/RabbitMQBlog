using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQCore
{
    public class RabbitMQHelper : Singleton<RabbitMQHelper>
    {

        /// <summary>
        /// SendToQAsync - RabbitMQ ya bağlantı gerçekleştirir ve mesaj gönderir
        /// </summary>
        /// <param name="connectionUrl"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<GenericResultItem<bool>> SendToQAsync(Uri connectionUrl, string message, string routingKey, CancellationToken ct)
        {
            GenericResultItem<bool> ri = new GenericResultItem<bool>();

            try
            {
                #region Validation
                if (connectionUrl == null || !connectionUrl.IsAbsoluteUri)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "Url information is required. Please enter a valid url.";

                    return await Task.FromResult(ri);
                }

                if (string.IsNullOrEmpty(message))
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "Message information is required. Please enter a valid message.";

                    return await Task.FromResult(ri);
                }

                if (string.IsNullOrEmpty(routingKey))
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "RoutingKey information is required. Please enter a valid RoutingKey.";

                    return await Task.FromResult(ri);
                }
                #endregion

                // cancel isteğinde bulunulmuş mu
                if (ct.IsCancellationRequested)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = MessageConstants.CancellationToken;

                    return await Task.FromResult(ri);
                }

                var factory = new ConnectionFactory() { Uri = connectionUrl };

                using (var conn = factory.CreateConnection())
                {
                    var channel = conn.CreateModel();
                    channel.QueueDeclare(routingKey, true, false, false); // Açıkla ve que ismini al

                    // cancel isteğinde bulunulmuş mu
                    if (ct.IsCancellationRequested)
                    {
                        ri.State = StateEnum.Error;
                        ri.ErrorMessage = MessageConstants.CancellationToken;

                        return await Task.FromResult(ri);
                    }

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(string.Empty, routingKey, null, body);
                }
            }
            catch (Exception ex)
            {
                ri.State = StateEnum.Error;
                ri.Ex = ex;
                ri.ErrorMessage = ex.Message;
            }

            return await Task.FromResult(ri);
        }

        /// <summary>
        /// ListenAsync - RabbitMQ ya bağlantı gerçekleştirir ve kuyruktan veri çeker
        /// </summary>
        /// <param name="connectionUrl"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<GenericResultItem<EventingBasicConsumer>> ListenDirectAsync(Uri connectionUrl, string routingKey, RichTextBox rtbLog, CancellationToken ct)
        {
            GenericResultItem<EventingBasicConsumer> ri = new GenericResultItem<EventingBasicConsumer>();

            try
            {
                Action<object, BasicDeliverEventArgs> logMessage = (sender, args) =>
                {
                    if (rtbLog.InvokeRequired)
                    {
                        rtbLog.Invoke((MethodInvoker)delegate
                        {
                            var message = Encoding.UTF8.GetString(args.Body.ToArray());
                            rtbLog.AppendText($"{DateTime.Now} - Received Message: {message}\n");
                            rtbLog.Refresh();
                        });
                    }
                };

                // validation
                if (connectionUrl == null || !connectionUrl.IsAbsoluteUri)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "Url information is required. Please enter a valid url.";

                    return await Task.FromResult(ri);
                }

                // cancel isteğinde bulunulmuş mu
                if (ct.IsCancellationRequested)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = MessageConstants.CancellationToken;

                    return await Task.FromResult(ri);
                }

                var factory = new ConnectionFactory() { Uri = connectionUrl };

                var conn = factory.CreateConnection();


                var model = conn.CreateModel();

                // cancel isteğinde bulunulmuş mu
                if (ct.IsCancellationRequested)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = MessageConstants.CancellationToken;

                    return await Task.FromResult(ri);
                }

                ri.Data = new EventingBasicConsumer(model);

                ri.Data.Received += (ss, ee) => logMessage(ss, ee);

                model.BasicConsume(routingKey, true, ri.Data);

            }
            catch (Exception ex)
            {
                ri.State = StateEnum.Error;
                ri.Ex = ex;
                ri.ErrorMessage = ex.Message;
            }

            return await Task.FromResult(ri);
        }

        /// <summary>
        /// ListenTopicAsync - RabbitMQ ya bağlantı gerçekleştirir ve kuyruktan veri çeker
        /// </summary>
        /// <param name="connectionUrl"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<GenericResultItem<EventingBasicConsumer>> ListenTopicAsync(Uri connectionUrl, string routingKey, string exchangeName, RichTextBox rtbLog, CancellationToken ct)
        {
            GenericResultItem<EventingBasicConsumer> ri = new GenericResultItem<EventingBasicConsumer>();

            Action<object, BasicDeliverEventArgs> logMessage = (sender, args) =>
            {
                if (rtbLog.InvokeRequired)
                {
                    rtbLog.Invoke((MethodInvoker)delegate
                    {
                        var message = Encoding.UTF8.GetString(args.Body.ToArray());
                        rtbLog.AppendText($"{DateTime.Now} - Received Message: {message}\n");
                        rtbLog.Refresh();
                    });
                }
            };

            try
            {
                // validation
                if (connectionUrl == null || !connectionUrl.IsAbsoluteUri)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "Url information is required. Please enter a valid url.";

                }

                var factory = new ConnectionFactory() { Uri = connectionUrl };

                var conn = factory.CreateConnection();


                var channel = conn.CreateModel();
                channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic, true);
                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);

                ri.Data = new EventingBasicConsumer(channel);

                ri.Data.Received += (ss, ee) => logMessage(ss, ee);

                channel.BasicConsume(queueName, true, ri.Data);

            }
            catch (Exception ex)
            {
                ri.State = StateEnum.Error;
                ri.Ex = ex;
                ri.ErrorMessage = ex.Message;
            }

            return await Task.FromResult(ri);
        }

        /// <summary>
        /// SendToQAsync - RabbitMQ ya bağlantı gerçekleştirir ve mesaj gönderir
        /// </summary>
        /// <param name="connectionUrl"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<GenericResultItem<bool>> SendToQTopicAsync(Uri connectionUrl, string message, string routingKey, string exchangeName, CancellationToken ct)
        {
            GenericResultItem<bool> ri = new GenericResultItem<bool>();

            try
            {
                #region Validation
                if (connectionUrl == null || !connectionUrl.IsAbsoluteUri)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "Url information is required. Please enter a valid url.";

                    return await Task.FromResult(ri);
                }

                if (string.IsNullOrEmpty(message))
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "Message information is required. Please enter a valid message.";

                    return await Task.FromResult(ri);
                }

                if (string.IsNullOrEmpty(routingKey))
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "RoutingKey information is required. Please enter a valid RoutingKey.";

                    return await Task.FromResult(ri);
                }

                if (string.IsNullOrEmpty(exchangeName))
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = "ExchangeName information is required. Please enter a valid ExchangeName.";

                    return await Task.FromResult(ri);
                }
                #endregion

                // cancel isteğinde bulunulmuş mu
                if (ct.IsCancellationRequested)
                {
                    ri.State = StateEnum.Error;
                    ri.ErrorMessage = MessageConstants.CancellationToken;

                    return await Task.FromResult(ri);
                }

                var factory = new ConnectionFactory() { Uri = connectionUrl };

                using (var conn = factory.CreateConnection())
                {
                    var channel = conn.CreateModel();
                    channel.ExchangeDeclare(exchangeName, ExchangeType.Topic, true);

                    // cancel isteğinde bulunulmuş mu
                    if (ct.IsCancellationRequested)
                    {
                        ri.State = StateEnum.Error;
                        ri.ErrorMessage = MessageConstants.CancellationToken;

                        return await Task.FromResult(ri);
                    }

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchangeName, routingKey, null, body);
                }
            }
            catch (Exception ex)
            {
                ri.State = StateEnum.Error;
                ri.Ex = ex;
                ri.ErrorMessage = ex.Message;
            }

            return await Task.FromResult(ri);
        }
    }
}
