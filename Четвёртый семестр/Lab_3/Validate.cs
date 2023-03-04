using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class Validate : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is string ID)
            {
                if(Regex.Match(ID, @"[1-9]{1}\d+").Success)
                {
                    return true;
                }
            }
            return false;   
        }
    }
}
