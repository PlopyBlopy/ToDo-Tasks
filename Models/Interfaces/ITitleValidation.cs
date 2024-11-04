namespace ToDoTask.Models.Interfaces
{
    public interface ITitleValidation<T>
    {
        public bool IsValid(string parameter);

        public Task<bool> HasNoCollision(string parameter);
    }
}