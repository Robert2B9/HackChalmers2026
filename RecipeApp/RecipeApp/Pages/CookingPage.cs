using CommunityToolkit.Maui.Markup;
using RecipeApp.ViewModels;

namespace RecipeApp.Pages;

/// <summary>
/// The cooking screen: one step at a time, with a timer when the step has one.
/// Layout and bindings only. All logic is in CookingViewModel.
/// </summary>
public class CookingPage : ContentPage
{
    private readonly CookingViewModel _viewModel;

    public CookingPage(CookingViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = viewModel;
        Title = "Cooking";

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Padding = new Thickness(20),
                Spacing = 16,
                Children =
                {
                    // Small ingredient summary at the top.
                    new Label { FontSize = 14 }
                        .Bind(Label.TextProperty, static (CookingViewModel vm) => vm.IngredientsText),

                    // "Step 2 of 5"
                    new Label { FontSize = 16, FontAttributes = FontAttributes.Bold }
                        .Bind(Label.TextProperty, static (CookingViewModel vm) => vm.ProgressText),

                    // The instruction itself, big enough to read with messy hands.
                    new Label { FontSize = 28 }
                        .Bind(Label.TextProperty, static (CookingViewModel vm) => vm.Instruction),

                    // Timer block, only shown when the current step has a timer.
                    new VerticalStackLayout
                    {
                        Spacing = 8,
                        Children =
                        {
                            new Label { FontSize = 48, HorizontalTextAlignment = TextAlignment.Center }
                                .Bind(Label.TextProperty, static (CookingViewModel vm) => vm.TimerText),

                            // Start / Pause / Resume (the label comes from the ViewModel).
                            new Button()
                                .BindCommand(static (CookingViewModel vm) => vm.ToggleTimerCommand)
                                .Bind(Button.TextProperty, static (CookingViewModel vm) => vm.TimerButtonText),

                            new Button { Text = "Reset timer" }
                                .BindCommand(static (CookingViewModel vm) => vm.ResetTimerCommand)
                        }
                    }
                    .Bind(VisualElement.IsVisibleProperty, static (CookingViewModel vm) => vm.HasTimer),

                    // Navigation between steps. Back is hidden on the first step.
                    new Button { Text = "Back" }
                        .BindCommand(static (CookingViewModel vm) => vm.BackCommand)
                        .Bind(VisualElement.IsVisibleProperty, static (CookingViewModel vm) => vm.CanGoBack),

                    // Says "Next", or "Finish" on the last step.
                    new Button()
                        .BindCommand(static (CookingViewModel vm) => vm.NextCommand)
                        .Bind(Button.TextProperty, static (CookingViewModel vm) => vm.NextButtonText)
                }
            }
        };
    }

    // Leaving the page (Finish or the system back button): stop the timer
    // and unsubscribe, so the app-wide timer doesn't keep this ViewModel alive.
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.Detach();
    }
}