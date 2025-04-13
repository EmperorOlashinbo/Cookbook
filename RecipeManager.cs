using Cookbook;

public class RecipeManager
{
    private Recipe[] recipeList;            // Array to store the collection of recipes
    private int maxNumOfRecipes;            // Maximum number of recipes the manager can hold
    private int numOfElems;                 // Current number of recipes in the collection
    private string[] ingredients;           // Array to store a list of ingredients (not tied to a specific recipe)

    // Constructor to initialize the RecipeManager with a maximum number of recipes
    public RecipeManager(int maxNumOfRecipes)
    {
        this.maxNumOfRecipes = maxNumOfRecipes;     // Sets the maximum number of recipes allowed
        recipeList = new Recipe[maxNumOfRecipes];   // Initializes the recipe array with the specified size
        numOfElems = 0;                             // Initializes the current number of recipes to zero
        ingredients = Array.Empty<string>();        // Initializes the ingredients array as an empty array
    }

    // Method to retrieve a recipe at a specific index
    public Recipe? GetRecipe(int index)
    {
        if (index >= 0 && index < numOfElems)       // Checks if the index is within valid bounds
        {
            return recipeList[index];               // Returns the recipe at the specified index
        }
        return null;                                // Returns null if the index is out of bounds
    }

    // Method to add a recipe to the collection
    public void AddRecipe(Recipe recipe)
    {
        if (numOfElems < maxNumOfRecipes)           // Checks if there is space to add a new recipe
        {
            recipeList[numOfElems] = recipe;        // Adds the recipe to the next available slot
            numOfElems++;                           // Increments the count of recipes
        }
        // Does nothing if the collection is full
    }

    // Method to remove a recipe from the collection by index
    public void RemoveRecipe(int index)
    {
        if (index >= 0 && index < numOfElems)       // Checks if the index is within valid bounds
        {
            MoveElementsOneStepToLeft(index);       // Shifts elements to fill the gap left by removal
            numOfElems--;                           // Decrements the count of recipes
        }
        // Does nothing if the index is out of bounds
    }

    // Property to get or set the ingredients array, with null protection
    public string[] Ingredients
    {
        get { return ingredients ?? Array.Empty<string>(); }  // Returns the ingredients array, or an empty array if null
        set { ingredients = value ?? Array.Empty<string>(); } // Sets the ingredients array, defaulting to empty if null
    }

    // Private helper method to shift elements left in the recipe array after removal
    private void MoveElementsOneStepToLeft(int index)
    {
        for (int i = index + 1; i < numOfElems; i++)     // Loops through elements after the removal index
        {
            recipeList[i - 1] = recipeList[i];           // Moves each element one position to the left
        }
        recipeList[numOfElems - 1] = null!;              // Sets the last element to null (using null-forgiving operator)
    }

    // Read-only property to get the current number of recipes
    public int NumOfElems
    {
        get { return numOfElems; }                       // Returns the current number of recipes in the collection
    }
}