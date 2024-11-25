using CrudPostInst.service;
using CrudPostInst.models;
namespace CrudPostInst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartFrontEnd();

        }
        public static void StartFrontEnd()
        {
            var eventService = new EventService();

            while (true)
            {
                Console.WriteLine("0. Stop");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. Update Event");
                Console.WriteLine("3. Delete Event");
                Console.WriteLine("4. Get All Events");
                Console.WriteLine("5. Get Event by ID");
                Console.Write("Select option: ");
                var option = Console.ReadLine();

                if (option == "0") break;
                else if (option == "1")
                {
                    var newEvent = new EventModel();
                    Console.Write("Enter Event Title: ");
                    newEvent.Title = Console.ReadLine();
                    Console.Write("Enter Event Location: ");
                    newEvent.Location = Console.ReadLine();
                    newEvent.Date = DateTime.Now;
                    Console.Write("Enter Event Description: ");
                    newEvent.Description = Console.ReadLine();

                    var result = eventService.AddNewEvent(newEvent);
                    if (result)
                        Console.WriteLine("Event Added Successfully!");
                    else
                        Console.WriteLine("Error Adding Event!");
                }
                else if (option == "2") 
                {
                    var updatedEvent = new EventModel();
                    Console.Write("Enter Event ID to Update: ");
                    updatedEvent.ID = Guid.Parse(Console.ReadLine());
                    Console.Write("Enter Updated Title: ");
                    updatedEvent.Title = Console.ReadLine();
                    Console.Write("Enter Updated Location: ");
                    updatedEvent.Location = Console.ReadLine();
                    updatedEvent.Date = DateTime.Now;
                    Console.Write("Enter Updated Description: ");
                    updatedEvent.Description = Console.ReadLine();

                    var result = eventService.UpdateEvent(updatedEvent);
                    if (result)
                        Console.WriteLine("Event Updated Successfully!");
                    else
                        Console.WriteLine("Event Not Found!");
                }
                else if (option == "3") 
                {
                    Console.Write("Enter Event ID to Delete: ");
                    var eventId = Guid.Parse(Console.ReadLine());
                    var result = eventService.DeleteEvent(eventId);
                    if (result)
                        Console.WriteLine("Event Deleted Successfully!");
                    else
                        Console.WriteLine("Event Not Found!");
                }
                else if (option == "4") 
                {
                    var events = eventService.GetEvents();
                    foreach (var _event in events)
                    {
                        eventService.DisplayInfo(_event);
                    }
                }
                else if (option == "5") 
                {
                    Console.Write("Enter Event ID: ");
                    var eventId = Guid.Parse(Console.ReadLine());
                    var _event = eventService.GetById(eventId);
                    if (_event is null)
                        eventService.DisplayInfo(_event);
                    else
                        Console.WriteLine("Event Not Found!");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}