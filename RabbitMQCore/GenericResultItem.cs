using System;

namespace RabbitMQCore
{
    public class GenericResultItem<T>
    {
        public StateEnum State { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public Exception Ex { get; set; }

        public GenericResultItem(StateEnum state = StateEnum.Success)
        {
            State = state;
        }
    }
}
