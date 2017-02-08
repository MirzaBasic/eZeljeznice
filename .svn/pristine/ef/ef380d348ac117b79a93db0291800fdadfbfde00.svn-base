using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eZeljeznice.Web.Areas.ModulAdministracija.Models
{
    public class Validator
    {
        public static ValidationResult ValidateDate(DateTime date)
        {

            if (date < DateTime.Parse("1/1/1900") || date > DateTime.Now)
            {
                return new ValidationResult("Mora biti izmedju " + DateTime.Now.AddYears(-100).ToShortDateString() + " i " + DateTime.Now.ToShortDateString());
            }

            return ValidationResult.Success;
        }
    }
}