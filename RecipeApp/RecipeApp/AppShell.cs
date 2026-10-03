namespace RecipeApp;

public class AppShell : Shell
{
    public AppShell()
    {
        ShellContent shellContent = new ShellContent();
        shellContent.Title = "Recipe App";
        shellContent.Route = "main";
        shellContent.ContentTemplate = new DataTemplate(typeof(MainPage)); 
        Items.Add(shellContent);
        FlyoutBehavior = FlyoutBehavior.Disabled;
        
        // TODO: register push routes (cooking page, etc.)
    }
}