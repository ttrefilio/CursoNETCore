using FluentValidation.Results;
using Projeto.Services.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Services.Api.Adapters
{
    public static class ValidationAdapter
    {
        /// <summary>
        /// Metodo para conversao de ValidationFailure em ValidationErrorModel
        /// </summary>
        /// <param name="errors">Lista de erros do FluentValidation</param>
        /// <returns>Lista de erros da classe modelo do projeto API</returns>
        public static List<ValidationErrorModel> Parse(IEnumerable<ValidationFailure> errors)
        {
            List<ValidationErrorModel> result = errors.Select
                (er => new { er.PropertyName, Errors = er.ErrorMessage })
                .GroupBy(g => g.PropertyName).ToList()
                .Select(s => new ValidationErrorModel 
                { 
                    PropertyName = s.Key, 
                    Errors = s.Select(m => m.Errors).ToList() 
                }).ToList();

            return result;
        }
    }
}
