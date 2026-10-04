using RecipeApp.Pages;

namespace RecipeApp;

public class AppShell : Shell
{
    public AppShell()
    {
        ShellContent shellContent = new ShellContent();
        shellContent.Title = "Recipe App";
        shellContent.Route = "main";
        shellContent.ContentTemplate = new DataTemplate(typeof(RecipeListPage));
        //shellContent.ContentTemplate = new DataTemplate(typeof(MainPage)); 
        Items.Add(shellContent);
        FlyoutBehavior = FlyoutBehavior.Disabled;
   
        
        Routing.RegisterRoute("cooking", typeof(CookingPage)); 
    }
}