using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

/**
 * Codigo extraido de:
 * https://stackoverflow.com/questions/7247748/mvc3-validation-require-one-from-group
 */

namespace UruguayBusWeb.Models.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequireAtLeastOneOfGroupAttribute : ValidationAttribute, IClientValidatable
    {
        public RequireAtLeastOneOfGroupAttribute(string groupName)
        {
            ErrorMessage = string.Format("You must select at least one value from group \"{0}\"", groupName);
            GroupName = groupName;
        }

        public string GroupName { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            foreach (var property in GetGroupProperties(validationContext.ObjectType))
            {
                var propertyValue = (bool)property.GetValue(validationContext.ObjectInstance, null);
                if (propertyValue)
                {
                    // at least one property is true in this group => the model is valid
                    return null;
                }
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        private IEnumerable<PropertyInfo> GetGroupProperties(Type type)
        {
            return
                from property in type.GetProperties()
                where property.PropertyType == typeof(bool)
                let attributes = property.GetCustomAttributes(typeof(RequireAtLeastOneOfGroupAttribute), false).OfType<RequireAtLeastOneOfGroupAttribute>()
                where attributes.Count() > 0
                from attribute in attributes
                where attribute.GroupName == GroupName
                select property;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var groupProperties = GetGroupProperties(metadata.ContainerType).Select(p => p.Name);
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessage
            };
            rule.ValidationType = string.Format("group", GroupName.ToLower());
            rule.ValidationParameters["propertynames"] = string.Join(",", groupProperties);
            yield return rule;
        }
    }
}