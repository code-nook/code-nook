namespace ThePowerAndVersatilityOfDelegates;

public class TaskManager
{
    public event EventHandler? TaskAdded;
    public event EventHandler? TaskRemoved;

    private List<Task> Tasks { get; }
    private Func<Task, bool> SendEmailOnAdd { get; }
    private Func<Task, bool> SendEmailOnRemove { get; }
    private Action<string> Logging { get; }

    public TaskManager(Func<Task, bool> sendEmailOnAddFunc,
                       Func<Task, bool> sendEmailOnRemoveFunc,
                       Action<string> logging)
    {
        Tasks = new();
        SendEmailOnAdd = sendEmailOnAddFunc;
        SendEmailOnRemove = sendEmailOnRemoveFunc;
        Logging = logging;
    }

    public void AddTask(Task newTask)
    {
        Tasks.Add(newTask);
        OnTaskAdded();

        Logging?.Invoke("New task added");

        // Check if the email sending on task addition was successful
        bool emailSent = SendEmailOnAdd?.Invoke(newTask) ?? false;
        if (emailSent)
        {
            Logging?.Invoke("Email for new task sent successfully.");
        }
        else
        {
            Logging?.Invoke("Error sending email for new task.");
        }
    }

    public void RemoveTask(Task task)
    {
        Tasks.Remove(task);
        OnTaskRemoved();

        Logging?.Invoke("Deleted task.");

        // Check if the email sending on task removal was successful
        bool emailSent = SendEmailOnRemove?.Invoke(task) ?? false;
        if (emailSent)
        {
            Logging?.Invoke("Email for task removal sent successfully.");
        }
        else
        {
            Logging?.Invoke("Error sending email for task removal.");
        }
    }

    public List<Task> FilterTasks(Func<Task, bool> filter) 
    {
        ArgumentNullException.ThrowIfNull(filter);

        return Tasks.Where(filter).ToList();
    }

    private void OnTaskAdded()
    {
        TaskAdded?.Invoke(this, EventArgs.Empty);
    }

    private void OnTaskRemoved()
    {
        TaskRemoved?.Invoke(this, EventArgs.Empty);
    }
}