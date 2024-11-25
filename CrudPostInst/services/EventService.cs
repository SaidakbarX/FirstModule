using CrudPostInst.models;
namespace CrudPostInst.service;

public class EventService
{
    private List<EventModel> _events;
    public EventService()
    {
        _events = new List<EventModel>();
    }
    public bool AddNewEvent(EventModel model)
    {
        try
        {
            model.ID = Guid.NewGuid();
            _events.Add(model);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public EventModel GetById(Guid id)
    {
        foreach (var model in _events)
        {
            if (model.ID == id)
            {
                return model;
            }

        }
        return null;
    }
    public bool UpdateEvent(EventModel model)
    {
        var eventId = GetById(model.ID);
        if (eventId is null)
        {
            return false;
        }
        var index = _events.IndexOf(eventId);
        _events[index]= model;
        return true;
    }
    public bool DeleteEvent(Guid id)
    { var eventDelete = GetById(id);
        if (eventDelete is null) 
            {
                return false;
            }
            _events.Remove(eventDelete);
            return true;
    }
    public List<EventModel> GetEvents()
    {
        return _events;
    }
    public void DisplayInfo(EventModel events)
    {
        Console.WriteLine($"ID: {events.ID}");
        Console.WriteLine($"Title: {events.Title}");
        Console.WriteLine($"Location: {events.Location}");
        Console.WriteLine($"Date: {events.Date}");
        Console.WriteLine($"Description: {events.Description}");
        Console.WriteLine("Attendees: ");
        foreach (var name in events.Attendees)
        {
            Console.WriteLine($" - {name}");
        }
        Console.WriteLine("Tags: ");
        foreach (var tag in events.Tags)
        {
            Console.WriteLine($" - {tag}");
        }
    }
    public bool AddPersonToEvent(Guid eventId, string person)
    {
        var eventFromDB = GetById(eventId);
        if (eventFromDB == null)
        {
            return false; 
        }

        eventFromDB.Attendees.Add(person); 
        return true;
    }

    
    public List<EventModel> GetEventsByLocation(string location)
    {
        var eventsByLocation = new List<EventModel>();
        foreach (var events in _events)
        {
            if (events.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
            {
                eventsByLocation.Add(events);
            }
        }
        return eventsByLocation;
    }

    
    public EventModel GetPopularEvent()
    {
        EventModel popularEvent = null;
        int maxAttendees = 0;

        foreach (var events in _events)
        {
            if (events.Attendees.Count > maxAttendees)
            {
                popularEvent = events;
                maxAttendees = events.Attendees.Count;
            }
        }

        return popularEvent;
    }
} 




