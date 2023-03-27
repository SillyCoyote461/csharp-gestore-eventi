using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EventSchedule
{
    public string title;
    public List<Event> events;

    public EventSchedule(string title)
    {
        this.title = title;
        events = new List<Event>();
    }

    public List<Event> Events
    {
        get { return events; }
    }

    public void EventToList(Event @event)
    {
        events.Add(@event);
    }

    public void GetEventsDate(DateTime date)
    {
        List<Event> list = new List<Event>();
        foreach (Event @event in events)
        {
            if (@event.Date == date)
            {
                list.Add(@event);
            }
        }
        if (list.Count > 0)
        {
            foreach (Event @event in list)
            {
                Console.WriteLine(@event);
            }
        }
        else
        {
            Console.WriteLine("Non sono stati trovati eventi in quella data.");
        }
    }

    public static string PrintEvents(List<Event> events)
    {
        string str = "";
        foreach (Event @event in events)
        {
            str += @event.Date.ToString("dd/MM/yyyy") + " - " + @event.Title + $"{Environment.NewLine}";
        }
        return str;
    }

    public int EventCount()
    {
        return events.Count();
    }

    public void ClearEvents()
    {
        events.Clear();
    }

    public override string ToString()
    {
        string str = title + $"{Environment.NewLine}";

        foreach (Event @event in events)
        {
            if (@event is Conference conference)
            {
                str += conference.Date.ToString("dd/MM/yyyy") + " - " + conference.Title + " - " + conference.Speaker + " - " + conference.Price + "€";

            }
        }

        return str;
    }
}
