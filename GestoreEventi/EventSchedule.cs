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

    public List <Event> Events
    {
        get { return events; }
    }

    public void EventToList(Event @event)
    {
        events.Add(@event);
    }

    public List<Event> GetEventsDate(DateTime date, List<EventSchedule> listSchedule)
    {
        for(int i = 0; i < listSchedule.Count; i++)
        {
            foreach(EventSchedule list in listSchedule)
            {

            }
        }

    }
}
