using Microsoft.IdentityModel.Tokens;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models.Interfaces;

namespace ToDoTask.Models
{
    public class DescriptionValidation : IDescriptionValidation
    {
        public bool IsValid(string parameter)
        {
            if (!parameter.IsNullOrEmpty() && parameter.Length > InfoEntity.DescriptionLengthMax)
            {
                throw new ArgumentOutOfRangeException(parameter, $"The length of the task description exceeds the allowed limit. Maximum length: {InfoEntity.DescriptionLengthMax} characters.");
            }
            return true;
        }
    }
}