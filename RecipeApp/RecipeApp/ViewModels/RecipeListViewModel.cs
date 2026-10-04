using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeApp.Domain.Models;
using RecipeApp.Domain.Services;

namespace RecipeApp.ViewModels;

/// <summary>
/// Start screen: shows the available recipes and opens one for cooking.
/// </summary>
public partial class RecipeListViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    // The list the page displays.
    public IReadOnlyList<Recipe> Recipes { get; }

    // Both dependencies are supplied by the DI container.
    public RecipeListViewModel(IRecipeRepository repository, INavigationService navigation)
    {
        _navigation = navigation;
        Recipes = repository.GetAll();
    }

    // [RelayCommand] generates OpenRecipeCommand, which the page calls when a recipe is tapped.
    [RelayCommand]
    private async Task OpenRecipe(Recipe recipe)
    {
        await _navigation.ShowCookingAsync(recipe);
    }
}