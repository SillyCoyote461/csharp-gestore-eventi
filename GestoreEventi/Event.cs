using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Event
{
    public string title;
    public DateTime date;
    public int capacity;
    public int booked;
    public int seatsLeft;

    //constructor
    public Event(string title, DateTime date, int capacity)
    {
        this.title = TitleCheck(title);
        this.date = DateCheck(date);

        if (capacity < 0) throw new ArgumentOutOfRangeException();
        else this.capacity = capacity;

        booked = 0;
        seatsLeft = capacity;
    }

    //getters and setters
    public string Title {
        get { return Title; }
        set 
        {
            Title = TitleCheck(value);
        }
    }
    public DateTime Date {
        get { return date; }
        set
        {
            Date = DateCheck(value);
        }
    }
    public int Capacity {
        get { return capacity; }
    }
    public int Booked {
        get { return booked; }
    }
    public int SeatsLeft {
        get { return seatsLeft; } 
    }

    //methods
    private DateTime DateCheck(DateTime date)
    {
        if (date.Date < DateTime.Now) throw new Exception();
        else return date;
    }

    private string TitleCheck(string title)
    {
        string noSpaces = title.Replace(" ", "");

        if (title is null || noSpaces.Length is 0) throw new ArgumentNullException("Il titolo non puó essere nullo o vuoto.", title);
        else return title;
    }

    public void BookSeat(int seats)
    {
        if (seatsLeft - seats < 0) throw new ArgumentOutOfRangeException("Non ci sono abbastanza posti.");
        else
        {
            booked += seats;
            seatsLeft -= seats;
        }
    }

    public void CancelSeat(int seats)
    {
        if (booked - seats < 0) throw new ArgumentOutOfRangeException("Impossibile disdire piú posti di quelli prenotati.");
        else
        {
            booked -= seats;
            seatsLeft += seats;
        } 
    }

    public override string ToString()
    {
        return $"----------------------- {Environment.NewLine}" +
            $"Titolo: {title} {Environment.NewLine}" +
            $"Data: {date} {Environment.NewLine}" +
            $"Posti massimi: {capacity} {Environment.NewLine}" +
            $"Posti prenotati: {booked}{Environment.NewLine}" +
            $"Posti disponibili: {seatsLeft}{Environment.NewLine}" +
            $"----------------------- {Environment.NewLine}";
    }

}

