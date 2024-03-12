using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ApplicationCore.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ValidarCpfAttribute : ValidationAttribute
    {
        private const int TotalDeDigitos = 11;

        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return true;
            }

            var cpf = value.ToString();
            
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != TotalDeDigitos)
            {
                return false; 
            }
            
            if (cpf.All(digito => digito == cpf[0]))
            {
                return false;
            }
            
            int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var soma = multiplicadoresPrimeiroDigito.Select((t, i) => int.Parse(cpf[i].ToString()) * t).Sum();

            var resto = soma % TotalDeDigitos;
            var primeiroDigito = (resto < 2) ? 0 : TotalDeDigitos - resto;

            if (int.Parse(cpf[9].ToString()) != primeiroDigito)
            {
                return false;
            }

            soma = multiplicadoresSegundoDigito.Select((t, i) => int.Parse(cpf[i].ToString()) * t).Sum();

            resto = soma % TotalDeDigitos;
            var segundoDigito = (resto < 2) ? 0 : TotalDeDigitos - resto;

            return int.Parse(cpf[10].ToString()) == segundoDigito;
        }
    }
}