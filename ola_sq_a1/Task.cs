namespace ola_sq_a1;

public class Task
{
    public int Id { get; set; } // primary key
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsFinished { get; set; }
    
}