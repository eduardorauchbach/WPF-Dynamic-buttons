using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static FromZero.Desktop.Domain.Models.Theme;

namespace FromZero.Desktop.Domain.Helpers
{
    public static class FormHelpers
    {
        private static readonly Style StyleTextDefault = App.Current.FindResource("StyleTextDefault") as Style;
        private static readonly Style StyleTextError = App.Current.FindResource("StyleTextError") as Style;

        private static readonly Style StyleComboDefault = App.Current.FindResource("StyleComboDefault") as Style;
        private static readonly Style StyleComboError = App.Current.FindResource("StyleComboError") as Style;

        public static bool IsRequiredValidation(this Control control, string? message = null)
        {
            bool result = true;

            if (control is TextBox)
            {
                TextBox box = control as TextBox;
                result = !string.IsNullOrWhiteSpace(box.Text);

                box.Style = result ? StyleTextDefault : StyleTextError;
                box.ToolTip = result ? null : message;
            }

            if (control is ComboBox)
            {
                ComboBox cmb = control as ComboBox;
                result = cmb.SelectedIndex > -1;

                cmb.Style = result ? StyleComboDefault : StyleComboError;
                cmb.ToolTip = result ? null : message;
            }

            return result;
        }
    }

    public class IsRequiredValidation : ValidationRule
    {
        public string ValidationMessage { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, ValidationMessage);

            return new ValidationResult(true, null);
        }
    }

    public class NumericValidationRule : ValidationRule
    {
        public Type ValidationType { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value cannot be coverted to string.");
            bool canConvert = false;
            switch (ValidationType.Name)
            {

                case "Boolean":
                    bool boolVal = false;
                    canConvert = bool.TryParse(strValue, out boolVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of boolean");
                case "Int32":
                    int intVal = 0;
                    canConvert = int.TryParse(strValue, out intVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Int32");
                case "Double":
                    double doubleVal = 0;
                    canConvert = double.TryParse(strValue, out doubleVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Double");
                case "Int64":
                    long longVal = 0;
                    canConvert = long.TryParse(strValue, out longVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Int64");
                default:
                    throw new InvalidCastException($"{ValidationType.Name} is not supported");
            }
        }
    }
}
