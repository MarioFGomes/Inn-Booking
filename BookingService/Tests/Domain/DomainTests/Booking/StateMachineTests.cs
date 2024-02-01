
using Domain.Enums;
using Xunit;
using Action = Domain.Enums.Action;

namespace DomainTests.Booking; 
public class StateMachineTests 
{
    [Fact]
    public void ShouldAlwaysStartWithCreateStatus() 
    {
        var booking=new Domain.Entities.Booking();

        Assert.Equal(Status.Created, booking.CurrentStatus);
    }

    [Fact]
    public void ShouldBeAbleToPaySameBooking() 
    {
        var booking = new Domain.Entities.Booking();

        booking.ChangeState(Action.Pay);

        Assert.Equal(Status.Paid, booking.CurrentStatus);
    }

    [Fact]
    public void ShouldBeAbleToCancelSameBooking() 
    {
        var booking = new Domain.Entities.Booking();

        booking.ChangeState(Action.Cancel);

        Assert.Equal(Status.Canceled, booking.CurrentStatus);
    }

    [Fact]
    public void ShouldBeAbleToFinishSameBooking() 
    {

        var booking = new Domain.Entities.Booking();

        booking.ChangeState(Action.Pay);

        booking.ChangeState(Action.Finish);

        Assert.Equal(Status.Finished, booking.CurrentStatus);
    }

    [Fact]
    public void ShouldBeAbleToRefoundSameBooking() 
    {

        var booking = new Domain.Entities.Booking();

        booking.ChangeState(Action.Pay);

        booking.ChangeState(Action.Refound);

        Assert.Equal(Status.Refounded, booking.CurrentStatus);
    }

    [Fact]
    public void ShouldBeAbleToReopenSameBooking() {

        var booking = new Domain.Entities.Booking();

        booking.ChangeState(Action.Cancel);

        booking.ChangeState(Action.Reopen);

        Assert.Equal(Status.Created, booking.CurrentStatus);
    }
}
