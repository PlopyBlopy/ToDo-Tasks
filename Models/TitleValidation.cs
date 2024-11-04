using Microsoft.IdentityModel.Tokens;
using ToDoTask.DataBases.Entitys;
using ToDoTask.Models.Interfaces;

namespace ToDoTask.Models
{
    public class TitleValidation<T> : ITitleValidation<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public TitleValidation(IRepository<T> repository)
        {
            _repository = repository;
        }

        public bool IsValid(string parameter)
        {
            if (parameter.IsNullOrEmpty())
            {
                throw new ArgumentNullException(parameter, "Please fill in the header field.");
            }

            if (parameter.Length < InfoEntity.TitleLengthMin || parameter.Length > InfoEntity.TitleLengthMax)
            {
                throw new ArgumentOutOfRangeException(parameter,
                    $"The length of the task title exceeds the allowed limit. \nMinimum length: {InfoEntity.TitleLengthMin}, Maximum length: {InfoEntity.TitleLengthMax} characters.");
            }
            if (!HasNoCollision(parameter).GetAwaiter().GetResult())
            {
                throw new ArgumentException(parameter, "This title already exists. Enter another one.");
            }
            return true;
        }

        public async Task<bool> HasNoCollision(string parameter)
        {
            var collision = await _repository.GetByTitleAsync(parameter);
            if (collision != null)
                return false;
            return true;
        }
    }
}