namespace Backend.Models;

[PropertyChanged.AddINotifyPropertyChangedInterface]
public abstract class BaseModel : IDataErrorInfo
{
    // check for general model error
    public string Error { get { return null; } }

    // check for property errors
    public string this[string columnName]
    {
        get
        {
            var validationResults = new List<ValidationResult>();

            if (Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this),
                    new ValidationContext(this)
                    {
                        MemberName = columnName
                    },
                    validationResults))
                return null;

            return validationResults.First().ErrorMessage;
        }
    }
}
