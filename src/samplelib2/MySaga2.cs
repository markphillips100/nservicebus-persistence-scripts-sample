using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace samplelib
{

    public class MyMessage2
    {
        public Guid OrderId { get; set; }
    }

    public class MySaga2Data : ContainSagaData
    {
        public Guid OrderId { get; set; }
    }

    public class MySaga2 :
        Saga<MySaga2Data>,
        IAmStartedByMessages<MyMessage2>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MySaga2Data> mapper)
        {
            mapper.ConfigureMapping<MyMessage2>(message => message.OrderId)
                .ToSaga(sagaData => sagaData.OrderId);
        }        

        public Task Handle(MyMessage2 message, IMessageHandlerContext context)
        {
            MarkAsComplete();
            return Task.CompletedTask;
        }
    }
}
