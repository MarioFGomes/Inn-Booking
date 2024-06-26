﻿using Domain.Enums;
using Action = Domain.Enums.Action;

namespace Domain.Entities; 
public class Booking 
{
    public int Id { get; set; }
    public DateTime PlacedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    private Status Satus { get; set; }
    public Guest Guest { get; set; }
    public Room Room { get; set; }
    public Status CurrentStatus 
    {
        get 
        {
            return this.Satus;
        }
    }

    public void ChangeState(Action action) 
    {
        this.Satus = (this.Satus, action) switch 
       {
            (Status.Created,   Action.Pay) => Status.Paid,
            (Status.Created,   Action.Cancel) => Status.Canceled,
            (Status.Paid,      Action.Finish) => Status.Finished,
            (Status.Paid,      Action.Refound) => Status.Refounded,
            (Status.Canceled,  Action.Reopen) => Status.Created,
            _ => this.Satus
        };
    }
    public Booking() // Reservas
    {
        this.Satus=Status.Created;
    }
}
