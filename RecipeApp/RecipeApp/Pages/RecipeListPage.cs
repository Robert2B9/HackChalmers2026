using CommunityToolkit.Maui.Markup;
using RecipeApp.Domain.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.Pages;

/// <summary>
/// Start screen: a scrolling list of recipes. Tapping one opens the cooking page.
/// </summary>
public class RecipeListPage : ContentPage
{
    public RecipeListPage(RecipeListViewModel viewModel)
    {
        BindingContext = viewModel;
        Title = "Recipes";

        CollectionView list = new CollectionView
            {
                SelectionMode = SelectionMode.Single,

                // How ONE recipe row looks. Inside this template the binding
                // context is a single Recipe, not the ViewModel.
                ItemTemplate = new DataTemplate(() =>
                    new Label { FontSize = 22, Padding = new Thickness(16, 14) }
                        .Bind(Label.TextProperty, static (Recipe recipe) => recipe.Title))
            }
            // The list of all recipes comes from the ViewModel.
            .Bind(ItemsView.ItemsSourceProperty, static (RecipeListViewModel vm) => vm.Recipes);

        // Forward taps to the ViewModel's command. No logic lives here.
        list.SelectionChanged += (_, e) =>
        {
            if (e.CurrentSelection.FirstOrDefault() is Recipe recipe)
            {
                viewModel.OpenRecipeCommand.Execute(recipe);
                list.SelectedItem = null; // clear the highlight so it can be tapped again later
            }
        };

        Content = list;
    }
}