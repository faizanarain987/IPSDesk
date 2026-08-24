namespace IPSDesk.Services;

public enum ToastLevel
{
    Success,
    Error,
    Info,
    Warning
}

public class ToastMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Message { get; set; } = string.Empty;
    public ToastLevel Level { get; set; }
}

public class ToastService
{
    public event Action<ToastMessage>? OnShow;
    
    public void ShowSuccess(string message)
    {
        OnShow?.Invoke(new ToastMessage { Message = message, Level = ToastLevel.Success });
    }
    
    public void ShowError(string message)
    {
        OnShow?.Invoke(new ToastMessage { Message = message, Level = ToastLevel.Error });
    }

    public void ShowInfo(string message)
    {
        OnShow?.Invoke(new ToastMessage { Message = message, Level = ToastLevel.Info });
    }
}
