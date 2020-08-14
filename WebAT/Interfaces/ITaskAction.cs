namespace WebAT.Interfaces
{
    public interface ITaskAction {
        string action { get; set; }
        string findBy { get; set; }
        string value { get; set; }
        string keys { get; set;}
    }
}