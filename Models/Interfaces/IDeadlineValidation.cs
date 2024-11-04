namespace ToDoTask.Models.Interfaces
{
    public interface IDeadlineValidation
    {
        public bool IsValid(DateTime parameter);
    }
}