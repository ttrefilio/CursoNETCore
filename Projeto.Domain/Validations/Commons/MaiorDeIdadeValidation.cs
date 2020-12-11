using System;

namespace Projeto.Domain.Validations.Commons
{
    public class MaiorDeIdadeValidation
    {
        public static bool IsValid(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;

            if(DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }

            return idade >= 18;
        }
    }
}
