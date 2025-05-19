using System;
using System.Windows.Forms;

namespace Cookbook
{
    public partial class FormRecipeDetails : Form
    {
        private readonly Recipe recipe;

        public FormRecipeDetails(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe ?? new Recipe(50);
            LoadRecipeDetails();
        }

        private void LoadRecipeDetails()
        {
            if (recipe != null)
            {
                txtRecipeName.Text = recipe.Name ?? string.Empty;
                txtDescription.Text = recipe.Description ?? string.Empty;
                PopulateIngredientsListBox();
            }
        }

        private void PopulateIngredientsListBox()
        {
            lstIngredients.Items.Clear();
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient))
                {
                    lstIngredients.Items.Add(ingredient);
                }
            }
            txtNumOfIngredients.Text = lstIngredients.Items.Count.ToString();
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            string ingredient = txtIngredient.Text.Trim();
            if (!string.IsNullOrEmpty(ingredient))
            {
                if (lstIngredients.SelectedIndex >= 0)
                {
                    recipe.Ingredients[lstIngredients.SelectedIndex] = ingredient;
                    lstIngredients.Items[lstIngredients.SelectedIndex] = ingredient;
                }
                else if (recipe.AddIngredient(ingredient))
                {
                    lstIngredients.Items.Add(ingredient);
                }
                txtIngredient.Clear();
                txtNumOfIngredients.Text = lstIngredients.Items.Count.ToString();
            }
        }

        private void btnEditIngredient_Click(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedItem != null)
            {
                txtIngredient.Text = lstIngredients.SelectedItem.ToString();
                lstIngredients.SelectedIndex = -1;
            }
        }

        private void btnDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedItem != null)
            {
                int selectedIndex = lstIngredients.SelectedIndex;
                recipe.RemoveIngredient(selectedIndex);
                lstIngredients.Items.RemoveAt(selectedIndex);
                txtNumOfIngredients.Text = lstIngredients.Items.Count.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text.Trim()))
            {
                MessageBox.Show("Please enter the recipe name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
            {
                MessageBox.Show("Please enter the cooking instructions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            recipe.Name = txtRecipeName.Text.Trim();
            recipe.Description = txtDescription.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Recipe GetRecipe()
        {
            recipe.Name ??= string.Empty;
            recipe.Description ??= string.Empty;
            recipe.Ingredients ??= new string[recipe.MaxNumOfIngredients];
            return recipe;
        }
    }
}