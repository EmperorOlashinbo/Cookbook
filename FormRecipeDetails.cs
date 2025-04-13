using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookbook
{
    public partial class FormRecipeDetails : Form
    {
        private Recipe recipe;                   // Holds the recipe being edited or created

        // Constructor for the FormRecipeDetails form
        public FormRecipeDetails(Recipe recipe)
        {
            InitializeComponent();               // Initializes all UI components defined in the designer
            this.recipe = recipe ?? new Recipe(50); // Assigns the provided recipe or creates a new one if null
            LoadRecipeDetails();                 // Loads the recipe details into the form controls
        }

        // Method to load the recipe details into the form's controls
        private void LoadRecipeDetails()
        {
            if (recipe != null)                  // Checks if the recipe is not null
            {
                txtRecipeName.Text = recipe.Name; // Sets the recipe name in the TextBox
                txtDescription.Text = recipe.Description; // Sets the description in the TextBox
                txtInstructions.Text = recipe.Instructions; // Sets the instructions in the TextBox
                PopulateIngredientsListBox();    // Populates the ingredients ListBox with recipe ingredients
            }
        }

        // Method to populate the ListBox with the recipe's ingredients
        private void PopulateIngredientsListBox()
        {
            lstIngredients.Items.Clear();        // Clears all existing items from the ListBox
            foreach (var ingredient in recipe.Ingredients) // Loops through the recipe's ingredients
            {
                if (!string.IsNullOrEmpty(ingredient)) // Checks if the ingredient is not null or empty
                {
                    lstIngredients.Items.Add(ingredient); // Adds the ingredient to the ListBox
                }
            }
            txtNumOfIngredients.Text = lstIngredients.Items.Count.ToString(); // Updates the ingredient count display
        }

        // Event handler for the "Add Ingredient" button click
        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            string ingredient = txtIngredient.Text.Trim(); // Gets and trims the ingredient input
            if (!string.IsNullOrEmpty(ingredient)) // Checks if the ingredient is not empty
            {
                for (int i = 0; i < recipe.MaxNumOfIngredients; i++) // Loops through the ingredients array
                {
                    if (string.IsNullOrEmpty(recipe.Ingredients[i])) // Finds the first empty slot
                    {
                        recipe.Ingredients[i] = ingredient; // Adds the ingredient to the recipe
                        lstIngredients.Items.Add(ingredient); // Adds the ingredient to the ListBox
                        txtIngredient.Clear();       // Clears the input TextBox
                        break;                       // Exits the loop after adding
                    }
                }
                txtNumOfIngredients.Text = lstIngredients.Items.Count.ToString(); // Updates the ingredient count
            }
        }

        // Event handler for the "Edit Ingredient" button click
        private void btnEditIngredient_Click(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedItem != null) // Checks if an ingredient is selected
            {
                string? selectedIngredient = lstIngredients.SelectedItem!.ToString(); // Gets the selected ingredient
                txtIngredient.Text = selectedIngredient; // Displays the ingredient in the TextBox for editing
                recipe.Ingredients[lstIngredients.SelectedIndex] = txtIngredient.Text; // Updates the recipe array
                lstIngredients.Items[lstIngredients.SelectedIndex] = txtIngredient.Text; // Updates the ListBox
            }
        }

        // Event handler for the "Delete Ingredient" button click
        private void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedItem != null) // Checks if an ingredient is selected
            {
                int selectedIndex = lstIngredients.SelectedIndex; // Gets the index of the selected item
                lstIngredients.Items.RemoveAt(selectedIndex); // Removes the ingredient from the ListBox
                recipe.Ingredients[selectedIndex] = string.Empty; // Clears the ingredient in the recipe array
                txtNumOfIngredients.Text = lstIngredients.Items.Count.ToString(); // Updates the ingredient count
            }
        }

        // Event handler for the "OK" button click
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check if recipe name is filled
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text.Trim())) // Validates the recipe name (trimmed)
            {
                MessageBox.Show("Please enter the recipe name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Shows error if name is missing
                return;                          // Exits the method if validation fails
            }

            // Check if instructions are filled
            if (string.IsNullOrWhiteSpace(txtInstructions.Text.Trim())) // Validates the instructions (trimmed)
            {
                MessageBox.Show("Please enter the cooking instructions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Shows error if instructions are missing
                return;                          // Exits the method if validation fails
            }

            // If all checks pass, update the recipe object and close the form
            recipe.Name = txtRecipeName.Text.Trim(); // Updates the recipe name (trimmed)
            recipe.Description = txtDescription.Text.Trim(); // Updates the description (trimmed)
            recipe.Instructions = txtInstructions.Text.Trim(); // Updates the instructions (trimmed)

            UpdateIngredientsInRecipe();         // Syncs the ingredients from the ListBox to the recipe

            this.DialogResult = DialogResult.OK; // Sets the dialog result to OK
            this.Close();                        // Closes the form
        }

        // Event handler for the "Cancel" button click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Sets the dialog result to Cancel
            // Note: Form closing is handled by the form's default behavior
        }

        // Method to update the recipe's ingredients array from the ListBox
        private void UpdateIngredientsInRecipe()
        {
            // Initialize new array instead of assigning null
            recipe.Ingredients = new string[recipe.MaxNumOfIngredients]; // Resets the ingredients array

            for (int i = 0; i < lstIngredients.Items.Count; i++) // Loops through the ListBox items
            {
                recipe.Ingredients[i] = lstIngredients.Items[i]?.ToString() ?? string.Empty; // Updates the recipe array with ListBox items
            }
        }

        // Method to return the updated recipe object
        public Recipe GetRecipe()
        {
            // Ensure all fields are initialized
            recipe.Name ??= string.Empty;        // Sets name to empty string if null
            recipe.Description ??= string.Empty; // Sets description to empty string if null
            recipe.Instructions ??= string.Empty; // Sets instructions to empty string if null
            recipe.Ingredients ??= new string[recipe.MaxNumOfIngredients]; // Initializes ingredients array if null

            return recipe;                       // Returns the updated recipe
        }
    }
}