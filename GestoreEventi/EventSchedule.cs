﻿using System;
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

    public List<Event> GetEventsDate(DateTime date)
    {
        List<Event> list = new List<Event>();
        foreach (Event @event in events)
        {
            if (@event.Date == date)
            {
                list.Add(@event);
            }
        }
        return list;
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

    public void EventCount()
    {
        Console.WriteLine(events.Count());
    }

    public void ClearEvents()
    {
        events.Clear();
    }

    public override string ToString()
    {
        string str = title + $"{Environment.NewLine}";

        foreach (Event evento in events)
        {
            str += evento.Date.ToString("dd/MM/yyyy") + "-" + evento.Title + $"{Environment.NewLine}";
        }

        return str;
    }
}
