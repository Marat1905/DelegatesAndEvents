namespace DelegatesAndEvents.Events;
public class FileEventArgs : EventArgs
{
    public string Name { get; set; }

    public FileEventArgs(string name)
    {
        Name = name;
    }
}

