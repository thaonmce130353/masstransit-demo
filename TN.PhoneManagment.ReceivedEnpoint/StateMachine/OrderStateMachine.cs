using MassTransit;
using TN.PhoneManagment.Contact.Interfaces;
using TN.PhoneManagment.Contact.Interfaces.Saga;
using TN.PhoneManagment.Api.Models;

namespace TN.PhoneManagment.ReceivedEndpoint.StateMachine
{
    public class OrderStateMachine : MassTransitStateMachine<Order>
    {
        public OrderStateMachine()
        {
            RegisterStates();
            RegisterEvents();
            DefineStateMachine();
        }

        protected void DefineStateMachine()
        {
            Initially(
            When(SubmitOrder)
                .TransitionTo(Submitted));

            During(Submitted,
                When(InTransitOrder)
                    .TransitionTo(InTransit));

            During(InTransit,
                When(OrderDelivered)
                    .TransitionTo(InTransit));
        }

        protected void RegisterStates()
        {
            InstanceState(x => x.Status);
            State(() => Submitted);
            State(() => InTransit);
            State(() => Delivered);
        }

        protected void RegisterEvents()
        {
            Event(() => SubmitOrder, cfg => cfg.CorrelateById(dtocontext => dtocontext.Message.OrderId));
            Event(() => InTransitOrder, cfg => cfg.CorrelateById(dtocontext => dtocontext.Message.OrderId));
            Event(() => OrderDelivered, cfg => cfg.CorrelateById(dtocontext => dtocontext.Message.OrderId));
        }

        public State Submitted { get; private set; }
        public State InTransit { get; private set; }
        public State Delivered { get; private set; }

        public Event<ISubmitOrder> SubmitOrder { get; private set; }
        public Event<ISagaInTransitOrder> InTransitOrder { get; private set; }
        public Event<ISagaOrderDelivered> OrderDelivered { get; private set; }
    }
}
