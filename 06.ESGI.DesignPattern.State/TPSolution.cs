using System;

namespace _06.ESGI.DesignPattern.State
{
    public interface ITaskState
    {
        string Start(Task task);
        string Close(Task task);
    }

    public class Task
    {
        public Task()
        {
            State = new TodoState();
        }

        public ITaskState State { get; set; }

        public string Start()
        {
            return State.Start(this);
        }
        public string Close()
        {
            return State.Close(this);
        }
    }

    public class TodoState : ITaskState
    {
        public string Start(Task task)
        {
            task.State = new InProgressState();
            return "TODO -> IN PROGRESS";
        }

        public string Close(Task task)
        {
            return "INVALID TRANSITION";
        }
    }

    public class InProgressState : ITaskState
    {
        public string Start(Task task)
        {
            return "INVALID TRANSITION";
        }

        public string Close(Task task)
        {
            task.State = new ClosedState();
            return "IN PROGRESS -> CLOSED";
        }
    }

    public class ClosedState : ITaskState
    {
        public string Start(Task task)
        {
            return "INVALID TRANSITION";
        }

        public string Close(Task task)
        {
            return "INVALID TRANSITION";
        }
    }
}
