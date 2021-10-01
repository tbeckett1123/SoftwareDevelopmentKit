using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTools.CustomValidators
{
    public class DateTimeValidator<T> : PropertyValidator
    {
        protected override string GetDefaultMessageTemplate() => "The value provided is not a valid date";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return true;

            if (context.PropertyValue as DateTime? != null)
                return ((context.PropertyValue as DateTime?).Value != DateTime.MinValue);

            DateTime buffer;
            return DateTime.TryParse(context.PropertyValue as string, out buffer);
        }
    }

    public static class StaticDateTimeValidator
    {
        public static IRuleBuilderOptions<T, TProperty> IsValidDateTime<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new DateTimeValidator<TProperty>());
        }
    }
}

/* Copyright 2021 Timothy Beckett
 * * * * * * * * * * * * * * * * */

