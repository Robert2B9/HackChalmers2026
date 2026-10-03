namespace RecipeApp.Domain.Services;
//Interface for different Timers
public interface ITimerService
{
    public TimeSpan Remaining { get; }
    public bool IsRunning { get; }
    //Should only be called when no other timer is running
    public void Start(TimeSpan duration);
    //Shouldn't be called if nothing is running
    public void Pause();

    public void Resume();

    public void Reset();

    public event EventHandler? Tick;
    public event EventHandler? Finished;
    

}