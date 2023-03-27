using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Conference : Event
{
    public string? speaker;
    public double price;

    //public Conference(string speaker, double price, string title, DateTime date, int capacity) : base(title, date, capacity )
    //{
    //    this.speaker = speaker;
    //    this.price = price;
    //}

    public string Speaker
    {
        get { return speaker; }
        set { speaker = value; }
    }
    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()} - {speaker} - {price}€";
    }
}

