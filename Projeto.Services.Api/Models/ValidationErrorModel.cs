using System.Collections.Generic;

namespace Projeto.Services.Api.Models
{
    public class ValidationErrorModel
    {
        public string PropertyName { get; set; }
        public List<string> Errors { get; set; }
    }
}
