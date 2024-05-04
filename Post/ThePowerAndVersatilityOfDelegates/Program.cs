using ThePowerAndVersatilityOfDelegates;

// Create an instance of TaskManager and subscribe to the events
TaskManager manager = new(SendEmailOnAdd, SendEmailOnRemove, Logging);
manager.TaskAdded += TaskAddedHandler;
manager.TaskRemoved += TaskRemovedHandler;

// Create a new task and add it to the manager
ThePowerAndVersatilityOfDelegates.Task newTask =
  new ThePowerAndVersatilityOfDelegates.Task
  {
      Description = "Write report",
      Priority = 3,
      DueDate = DateTime.Now.AddDays(7)
  };
manager.AddTask(newTask);

// Create a second task and add it to the manager
ThePowerAndVersatilityOfDelegates.Task newTask2 =
  new ThePowerAndVersatilityOfDelegates.Task
  {
      Description = "Call supplier",
      Priority = 2,
      DueDate = DateTime.Now.AddDays(2)
  };
manager.AddTask(newTask2);

// Create a third task and add it to the manager
ThePowerAndVersatilityOfDelegates.Task newTask3 =
  new ThePowerAndVersatilityOfDelegates.Task
  {
      Description = "Call client",
      Priority = 2,
      DueDate = DateTime.Now.AddDays(2)
  };
manager.AddTask(newTask3);

// Filter tasks by priority
List<ThePowerAndVersatilityOfDelegates.Task> filteredTasks = manager.FilterTasks(t => t.Priority == 2);

Logging("Tasks filtered by priority:");

foreach (var task in filteredTasks)
{
    Logging($"- {task.Description} (Priority: {task.Priority})");
}

// Remove the newly created task from the manager
manager.RemoveTask(newTask);

Console.ReadLine();

// Function to send email when adding a task
bool SendEmailOnAdd(ThePowerAndVersatilityOfDelegates.Task task)
{
    string emailMessage = $"Task added: {task.Description}";

    Logging($"Sending email:\n{emailMessage}");
    // Simulated email sending (real email sending code could go here)
    bool emailSent = SimulateEmailSending();

    return emailSent;
}

// Function to send email when removing a task
bool SendEmailOnRemove(ThePowerAndVersatilityOfDelegates.Task task)
{
    string emailMessage =
      $"Task removed: {task.Description}";

    Logging($"Sending email:\n{emailMessage}");

    // Simulated email sending (real email sending code could go here)
    bool emailSent = SimulateEmailSending();

    return emailSent;
}

// Method to simulate email sending
bool SimulateEmailSending()
{
    // Simulated email sending (real email sending code could go here)
    // Return true if sending was successful, false if it failed
    return true; // Simulated successful sending
}

void Logging(string message)
{
    Console.WriteLine(message);
}

// Function to handle TaskAdded event
void TaskAddedHandler(object? sender, EventArgs e)
{
    Logging("A new task has been added.");
}

// Function to handle TaskRemoved event
void TaskRemovedHandler(object? sender, EventArgs e)
{
    Logging("A task has been removed.");
}
