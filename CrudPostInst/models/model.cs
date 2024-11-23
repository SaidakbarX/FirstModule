namespace CrudPostInst.modul;

public class model
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime PostedTime { get; set; }
    public int QuentyLikes { get; set; }
    public List<string> Comments { get; set; } = new List<string>();
    public List<string> ViewerName { get; set; } = new List<string>();
}
