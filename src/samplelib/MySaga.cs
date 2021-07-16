using System;
using System.Threading.Tasks;
using NServiceBus;

namespace samplelib
{

    public class MyMessage
    {
        public Guid OrderId { get; set; }
    }

    public class MySagaData : ContainSagaData
    {
        public Guid OrderId { get; set; }
    }

    public class MySaga :
        Saga<MySagaData>,
        IAmStartedByMessages<MyMessage>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MySagaData> mapper)
        {
            mapper.ConfigureMapping<MyMessage>(message => message.OrderId)
                .ToSaga(sagaData => sagaData.OrderId);
        }        

        public Task Handle(MyMessage message, IMessageHandlerContext context)
        {
            MarkAsComplete();
            return Task.CompletedTask;
        }
    }
}
