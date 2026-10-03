namespace RecipeApp.Domain.Services;

public interface ITimerService
{
    public TimeSpan Remaining { get; }
    public bool IsRunning { get; }

    public void Start(TimeSpan duration);

    public void Pause();

    public void Resume();

    public void Reset();

}