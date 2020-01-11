using System;
using System.Text.RegularExpressions;

namespace Clean.Core.ValueTypes
{
    public class SocialSecurityNumber
    {
        private readonly string _socialSecurityNumber = string.Empty;
        
        public SocialSecurityNumber() { }

        public SocialSecurityNumber(string socialSecurityNumber)
        {
            var cleanValue = socialSecurityNumber.Replace("-", string.Empty);
            var isMatch = Regex.IsMatch(cleanValue, "/d");

            if (!isMatch)
            {
                //This is a bit heavy handed for validation error, ideally there would be a more graceful way to
                //communicate errors to the API consumer.
                throw new Exception("Invalid Social Security Number");
            }
            
            _socialSecurityNumber = cleanValue;
        }

        /// <summary>
        /// Retrieve the formatted Social Security Number
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
            => string.IsNullOrEmpty(_socialSecurityNumber) 
                ? string.Empty 
                : _socialSecurityNumber.Insert(5, "-").Insert(3, "-");
    }
}