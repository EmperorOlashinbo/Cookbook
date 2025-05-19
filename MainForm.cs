using System;
using System.Windows.Forms;

namespace Cookbook
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            recipeManager = new RecipeManager(maxNumOfRecipes);
            currRecipe = new Recipe(maxNumOfIngredients);
            PopulateCategoryComboBox();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateRecipeList();
        }

        private void PopulateCategoryComboBox()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(Enum.GetNames(typeof(FoodCategory)));
            cmbCategory.SelectedIndex = 0;
        }

        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("Please enter the recipe name.");
                return;
            }

            currRecipe.Name = txtRecipeName.Text;
            FormRecipeDetails formRecipeDetails = new FormRecipeDetails(currRecipe);
            if (formRecipeDetails.ShowDialog() == DialogResult.OK)
            {
                currRecipe = formRecipeDetails.GetRecipe();
                UpdateRecipeList();
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill in recipe name and category.");
                return;
            }

            if (cmbCategory.SelectedItem is string selectedCategory)
            {
                currRecipe.Name = txtRecipeName.Text;
                currRecipe.Category = (FoodCategory)Enum.Parse(typeof(FoodCategory), selectedCategory);
                recipeManager.AddRecipe(currRecipe);
                UpdateRecipeListBox();
                currRecipe = new Recipe(maxNumOfIngredients);
            }
            else
            {
                MessageBox.Show("Invalid category selected.");
            }
        }


        private void UpdateRecipeListBox()
        {
            lstRecipes.Items.Clear();
            for (int i = 0; i < recipeManager.NumOfElems; i++)
            {
                var recipe = recipeManager.GetRecipe(i);
                if (recipe != null)
                {
                    lstRecipes.Items.Add(recipe.Name);
                }
            }
        }

        private void lstRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRecipes.SelectedIndex >= 0)
            {
                var selectedRecipe = recipeManager.GetRecipe(lstRecipes.SelectedIndex);
                if (selectedRecipe != null)
                {
                    var ingredients = selectedRecipe.Ingredients
                        .Where(i => !string.IsNullOrEmpty(i))
                        .ToList();
                    string ingredientsText = ingredients.Any() ? string.Join(", ", ingredients) : "None";
                    lblRecipeDetails.Text = $"Name: {selectedRecipe.Name}\n\n" +
                                            $"Category: {selectedRecipe.Category}\n\n" +
                                            $"INGREDIENTS\n{ingredientsText}\n\n" +
                                            $"INSTRUCTIONS\n{selectedRecipe.Description}";
                }
            }
            else
            {
                lblRecipeDetails.Text = string.Empty;
            }
        }

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstRecipes.SelectedIndex;
            if (selectedIndex >= 0)
            {
                Recipe? selectedRecipe = recipeManager.GetRecipe(selectedIndex);
                if (selectedRecipe != null)
                {
                    FormRecipeDetails formRecipeDetails = new FormRecipeDetails(selectedRecipe);
                    if (formRecipeDetails.ShowDialog() == DialogResult.OK)
                    {
                        Recipe updatedRecipe = formRecipeDetails.GetRecipe();
                        recipeManager.RemoveRecipe(selectedIndex);
                        recipeManager.AddRecipe(updatedRecipe);
                        UpdateRecipeList();
                    }
                }
            }
        }

        private void btnRemoveRecipe_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstRecipes.SelectedIndex;
            if (selectedIndex >= 0)
            {
                recipeManager.RemoveRecipe(selectedIndex);
                UpdateRecipeList();
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtRecipeName.Clear();
            cmbCategory.SelectedIndex = -1;
            lstRecipes.SelectedIndex = -1;
            lblRecipeDetails.Text = string.Empty;
        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void UpdateRecipeList()
        {
            lstRecipes.Items.Clear();
            for (int i = 0; i < recipeManager.NumOfElems; i++)
            {
                Recipe? recipe = recipeManager.GetRecipe(i);
                if (recipe != null)
                {
                    lstRecipes.Items.Add(recipe.Name);
                }
            }
        }
    }
}