using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Api.Domain
{
    public interface IValidator<in T>
    {
        DomainResult Validate(T param);
    }

    public class UsersValidator : IValidator<UsersContext>
    {
        public DomainResult Validate(UsersContext param)
        {
            var result = Validate(param.Name);
            return result;
        }

        private DomainResult Validate(string name)
        {
            List<DomainError> results = new List<DomainError>();

            if (name == null || name.Length > 500 || string.IsNullOrEmpty(name))
            {
                results.Add(new DomainError($"{nameof(name)} can not be null, empty or more than 500 chars"));
            }

            return !results.Any() ? DomainResult.Success() : DomainResult.Error(results);
        }
    }
}
