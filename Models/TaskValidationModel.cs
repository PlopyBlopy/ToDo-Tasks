namespace ToDoTask.Models
{
    public class TaskValidationModel
    {
        public string TitleError { get; set; } = string.Empty;
        public string DescriptionError { get; set; } = string.Empty;
    }
}