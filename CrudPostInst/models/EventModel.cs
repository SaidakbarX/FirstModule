namespace CrudPostInst.models;

public class EventModel
{
   
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<string> Attendees { get; set; }
        public List<string> Tags { get; set; }

        public EventModel()
        {
            Attendees = new List<string>();
            Tags = new List<string>();
        }
    

}
