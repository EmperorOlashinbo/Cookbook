using System;
using System.Windows.Forms;

namespace Cookbook
{
    public partial class MainForm : Form
    {
        // Constructor for the MainForm
        public MainForm()
        {
            InitializeComponent();                    // Initializes all UI components defined in the designer
            recipeManager = new RecipeManager(maxNumOfRecipes); // Creates a new RecipeManager with the max number of recipes
            currRecipe = new Recipe(maxNumOfIngredients);       // Initializes the current recipe with max ingredients
            PopulateCategoryComboBox();              // Populates the category dropdown with available categories
        }

        // Event handler for when the form loads
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize the RecipeManager and populate the category combo box
            recipeManager = new RecipeManager(maxNumOfRecipes); // Re-initializes RecipeManager (redundant due to constructor)
            PopulateCategoryComboBox();              // Fills the category ComboBox with options
            UpdateRecipeList();                      // Updates the recipe list display
        }

        // Method to populate the category ComboBox with food categories
        private void PopulateCategoryComboBox()
        {
            cmbCategory.Items.Clear();               // Removes all existing items from the ComboBox
            cmbCategory.Items.AddRange(Enum.GetNames(typeof(FoodCategory))); // Adds all FoodCategory enum names
            cmbCategory.SelectedIndex = 0;           // Sets the default selection to the first item
        }

        // Event handler for the "Add Ingredients and Instructions" button click
        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text)) // Checks if the recipe name is empty
            {
                MessageBox.Show("Please enter the recipe name."); // Displays an error message if name is missing
                return;                              // Exits the method if validation fails
            }

            currRecipe.Name = txtRecipeName.Text;    // Sets the current recipe's name before opening the details form
            FormRecipeDetails formRecipeDetails = new FormRecipeDetails(currRecipe); // Creates a new details form
            if (formRecipeDetails.ShowDialog() == DialogResult.OK) // Shows the form as a dialog and checks result
            {
                currRecipe = formRecipeDetails.GetRecipe(); // Updates the current recipe with form data
                UpdateRecipeList();                  // Refreshes the recipe list display
            }
        }

        // Event handler for the "Add Recipe" button click
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text) || cmbCategory.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtDescription.Text)) // Validates required fields
            {
                MessageBox.Show("Please fill in all the fields."); // Shows an error if any field is missing
                return;                              // Exits the method if validation fails
            }

            currRecipe.Name = txtRecipeName.Text;    // Sets the recipe name from the TextBox
            currRecipe.Category = (FoodCategory)Enum.Parse(typeof(FoodCategory), cmbCategory.SelectedItem?.ToString() ?? string.Empty); // Sets the category from the ComboBox
            currRecipe.Description = txtDescription.Text; // Sets the description from the TextBox

            recipeManager.AddRecipe(currRecipe);     // Adds the current recipe to the manager
            UpdateRecipeListBox();                   // Updates the ListBox with the new recipe
            currRecipe = new Recipe(maxNumOfIngredients); // Resets the current recipe to a new empty instance
        }

        // Method to update the ListBox with recipe names and truncated descriptions
        private void UpdateRecipeListBox()
        {
            lstRecipes.Items.Clear();                // Clears all items from the ListBox
            for (int i = 0; i < recipeManager.NumOfElems; i++) // Loops through all recipes in the manager
            {
                var recipe = recipeManager.GetRecipe(i); // Retrieves the recipe at the current index
                if (recipe != null)                  // Checks if the recipe is not null
                {
                    lstRecipes.Items.Add($"{recipe.Name} - {recipe.Description.Substring(0, Math.Min(30, recipe.Description.Length))}..."); // Adds a formatted string to the ListBox
                }
            }
        }

        // Event handler for when the selected recipe in the ListBox changes
        private void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRecipes.SelectedIndex >= 0)       // Checks if a valid item is selected
            {
                var selectedRecipe = recipeManager.GetRecipe(lstRecipes.SelectedIndex); // Gets the selected recipe
                if (selectedRecipe != null)          // Ensures the recipe is not null
                {
                    txtDescription.Text = $"Name: {selectedRecipe.Name} \n\nDescription: {selectedRecipe.Description} \n\nIngredients: {string.Join(", ", selectedRecipe.Ingredients)}"; // Displays recipe details in the TextBox
                }
            }
        }

        // Event handler for the "Change" (edit) button click
        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstRecipes.SelectedIndex; // Gets the index of the selected recipe
            if (selectedIndex >= 0)                  // Checks if a valid item is selected
            {
                Recipe? selectedRecipe = recipeManager.GetRecipe(selectedIndex); // Retrieves the selected recipe
                if (selectedRecipe != null)          // Ensures the recipe is not null
                {
                    FormRecipeDetails formRecipeDetails = new FormRecipeDetails(selectedRecipe); // Opens the details form with the selected recipe
                    if (formRecipeDetails.ShowDialog() == DialogResult.OK) // Checks if the dialog was confirmed
                    {
                        Recipe updatedRecipe = formRecipeDetails.GetRecipe(); // Gets the updated recipe from the form
                        recipeManager.RemoveRecipe(selectedIndex); // Removes the old recipe
                        recipeManager.AddRecipe(updatedRecipe); // Adds the updated recipe
                        UpdateRecipeList();              // Refreshes the recipe list display
                    }
                }
            }
        }

        // Event handler for the "Delete" button click
        private void btnRemoveRecipe_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstRecipes.SelectedIndex; // Gets the index of the selected recipe
            if (selectedIndex >= 0)                  // Checks if a valid item is selected
            {
                recipeManager.RemoveRecipe(selectedIndex); // Removes the recipe from the manager
                UpdateRecipeList();                  // Updates the recipe list display
            }
        }

        // Event handler for the "Clear Input" button click
        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtRecipeName.Clear();                   // Clears the recipe name TextBox
            cmbCategory.SelectedIndex = -1;          // Resets the category ComboBox to no selection
            txtDescription.Clear();                  // Clears the description TextBox
            lstRecipes.SelectedIndex = -1;           // Deselects any selected item in the ListBox
        }

        // Method to update the ListBox with recipe details (name, category, ingredient count)
        private void UpdateRecipeList()
        {
            lstRecipes.Items.Clear();                // Clears all items from the ListBox
            for (int i = 0; i < recipeManager.NumOfElems; i++) // Loops through all recipes in the manager
            {
                Recipe? recipe = recipeManager.GetRecipe(i); // Retrieves the recipe at the current index
                if (recipe != null)                  // Checks if the recipe is not null
                {
                    lstRecipes.Items.Add($"{recipe.Name} {recipe.Category} {recipe.Ingredients.Length}"); // Adds a formatted string to the ListBox
                }
            }
        }
    }
}