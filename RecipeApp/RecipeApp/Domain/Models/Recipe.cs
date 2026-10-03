namespace RecipeApp.Domain.Models;

public record Recipe(string Title, IReadOnlyList<string> Ingredients, IReadOnlyList<RecipeStep> Steps)
{
    public int StepCount => Steps.Count;
}