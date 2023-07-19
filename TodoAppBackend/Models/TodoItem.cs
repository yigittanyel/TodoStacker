namespace TodoAppBackend.Models;

public sealed class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool? IsCompleted { get; set; } = false;

    public TodoItem(int id,string title,bool? isCompleted)
    {
        Id=id;
        Title=title;
        IsCompleted=isCompleted;
    }

    public TodoItem( string title, bool? isCompleted)
    {
        Title=title;
        IsCompleted=isCompleted;
    }

    public TodoItem()
    {
        
    }
}
