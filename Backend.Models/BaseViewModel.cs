namespace Backend.Models;

public delegate void NotifyWithValidationMessages(Dictionary<string, string?> validationDictionary);

public class BaseViewModel : ObservableValidator
{
    public event NotifyWithValidationMessages? ValidationCompleted;

    public virtual ICommand ValidateCommand => new RelayCommand(() =>
    {
        ClearErrors();

        ValidateAllProperties();

        var validationMessages = this.GetErrors()
                                     .ToDictionary(k => k.MemberNames.First().ToLower(), v => v.ErrorMessage);

        ValidationCompleted?.Invoke(validationMessages);
    });


    [IndexerName("ErrorDictionary")]
    public ValidationStatus this[string propertyName]
    {
        get
        {
            var errors = this.GetErrors()
                             .ToDictionary(k => k.MemberNames.First(), v => v.ErrorMessage) ?? new Dictionary<string, string?>();

            var hasErrors = errors.TryGetValue(propertyName, out var error);
            return new ValidationStatus(hasErrors, error ?? string.Empty);
        }
    }

    public BaseViewModel() : base()
    {}
}

public class ValidationStatus : ObservableObject
{
    private bool hasError;
    private string error;

    public bool HasError
    {
        get => this.hasError;
        set => SetProperty(ref this.hasError, value);
    }

    public string Error
    {
        get => this.error;
        set => SetProperty(ref this.error, value);
    }

    public ValidationStatus()
    {
    }

    public ValidationStatus(bool hasError, string error)
    {
        this.hasError = hasError;
        this.error = error;
    }
}
