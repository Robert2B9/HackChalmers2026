using RecipeApp.Domain.Services;

public class CountdownTimerService : ITimerService
{
    public TimeSpan Remaining { get; }
    public TimeSpan Duration { get; }
    public bool IsRunning { get; }
    public void Start(TimeSpan duration)
    {
        throw new NotImplementedException();
    }

    public void Pause()
    {
        throw new NotImplementedException();
    }

    public void Resume()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public event EventHandler? Tick;
    public event EventHandler? Finished;
}