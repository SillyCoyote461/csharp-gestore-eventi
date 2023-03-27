using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


public class Event
{
    public string title;
    public DateTime date;
    public int capacity;
    public int booked;

    //public Event(string title, DateTime date, int capacity)
    //{
    //    this.title = title;
    //    this.date = date;
    //    this.capacity = capacity;
    //    booked = 0;
        
    //}

    //constructor

    //getters and setters
    public string Title
    {
        get { return title; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Il titolo non può essere vuoto o nullo");
            }
            title = value;
        }
    }
    public DateTime Date {
        get { return date; }
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentException("Deve essere la data di un futuro evento.");
            date = value;
        }
    }
    public int Capacity {
        get { return capacity; }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentOutOfRangeException("I posti a sedere non possono essere minori o uguali a 0");
            }
            else capacity = value;
        }
    }
    public int Booked {
       get { return booked; }
    }

    public string V { get; }
    public object Value { get; }

    //methods
    public void BookSeat(int seats)
    {
        if (capacity - (seats + booked) < 0) throw new ArgumentOutOfRangeException("Non ci sono abbastanza posti.");
        else
        {
            booked += seats;
        }
    }

    public void CancelSeat(int seats)
    {
        if (booked - (booked - seats) < 0) throw new ArgumentOutOfRangeException("Impossibile disdire piú posti di quelli prenotati.");
        else
        {
            booked -= seats;
        } 
    }

    public override string ToString()
    {
        return $"----------------------- {Environment.NewLine}" +
            $"Titolo: {title} {Environment.NewLine}" +
            $"Data: {date} {Environment.NewLine}" +
            $"Posti massimi: {capacity} {Environment.NewLine}" +
            $"Posti prenotati: {booked}{Environment.NewLine}" +
            $"Posti disponibili: {capacity - booked}{Environment.NewLine}" +
            $"----------------------- {Environment.NewLine}";
    }

}

