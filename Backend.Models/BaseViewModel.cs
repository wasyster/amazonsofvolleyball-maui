namespace Backend.Models;

/// <summary>
/// Action pointer that points on event when validation occours
/// </summary>
/// <param name="validationDictionary">Dictionary that holds the key(property name) and the  value(validation message)</param>
public delegate void NotifyWithValidationMessages(Dictionary<string, string?> validationDictionary);

public class BaseViewModel : ObservableValidator
{
    public event NotifyWithValidationMessages? ValidationCompleted;

    public virtual IRelayCommand<object> ValidateCommand => new RelayCommand<object>((commandParameter) =>
    {
        ClearErrors();

        var propertyName = commandParameter?.ToString();

        if (!string.IsNullOrWhiteSpace(propertyName))
        {
            ValidateProperty(propertyName);
        }
        else
            ValidateAllProperties();
        
        var validationMessages = this.GetErrors()
                                     .ToDictionary(k => k.MemberNames.First().ToLower(), v => v.ErrorMessage);
    
        ValidationCompleted?.Invoke(validationMessages);
    });

    public BaseViewModel() : base()
    {}
}
