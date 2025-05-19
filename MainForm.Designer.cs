using System;
using System.Windows.Forms;

namespace Cookbook
{
    public partial class MainForm : Form
    {
        private RecipeManager recipeManager;
        private Recipe currRecipe;
        private const int maxNumOfIngredients = 50;
        private const int maxNumOfRecipes = 200;

        private PictureBox pictureBox;
        private ComboBox cmbCategory;
        private ListBox lstRecipes;
        private TextBox txtRecipeName;
        private Label lblRecipeDetails;
        private Button btnAddRecipe;
        private Button btnEditRecipe;
        private Button btnRemoveRecipe;
        private Button btnClearInput;
        private Button btnAddIngredients;
        private Button btnAddImage;
        private Label lblIngredients;
        private Label lblRecipeName;
        private Label lblCategory;
        private GroupBox grpAddNewRecipe;

        private void InitializeComponent()
        {
            cmbCategory = new ComboBox();
            lstRecipes = new ListBox();
            txtRecipeName = new TextBox();
            lblRecipeDetails = new Label();
            btnAddRecipe = new Button();
            btnEditRecipe = new Button();
            btnRemoveRecipe = new Button();
            btnClearInput = new Button();
            btnAddIngredients = new Button();
            btnAddImage = new Button();
            lblIngredients = new Label();
            lblRecipeName = new Label();
            lblCategory = new Label();
            pictureBox = new PictureBox();
            grpAddNewRecipe = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            grpAddNewRecipe.SuspendLayout();
            SuspendLayout();

            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(287, 88);
            cmbCategory.Margin = new Padding(4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 33);
            cmbCategory.TabIndex = 3;

            lstRecipes.FormattingEnabled = true;
            lstRecipes.ItemHeight = 25;
            lstRecipes.Location = new Point(26, 300);
            lstRecipes.Margin = new Padding(4);
            lstRecipes.Name = "lstRecipes";
            lstRecipes.Size = new Size(499, 379);
            lstRecipes.TabIndex = 2;
            lstRecipes.SelectedIndexChanged += lstRecipes_SelectedIndexChanged;

            txtRecipeName.Location = new Point(188, 38);
            txtRecipeName.Margin = new Padding(4);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(249, 31);
            txtRecipeName.TabIndex = 1;

            lblRecipeDetails.AutoSize = false;
            lblRecipeDetails.Location = new Point(549, 316);
            lblRecipeDetails.Margin = new Padding(4);
            lblRecipeDetails.Name = "lblRecipeDetails";
            lblRecipeDetails.Size = new Size(436, 363);
            lblRecipeDetails.TabIndex = 9;
            lblRecipeDetails.Text = string.Empty;

            btnAddRecipe.Location = new Point(97, 225);
            btnAddRecipe.Margin = new Padding(4);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(294, 38);
            btnAddRecipe.TabIndex = 1;
            btnAddRecipe.Text = "Add Recipe";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += btnAddRecipe_Click;

            btnEditRecipe.Location = new Point(26, 699);
            btnEditRecipe.Margin = new Padding(4);
            btnEditRecipe.Name = "btnEditRecipe";
            btnEditRecipe.Size = new Size(150, 38);
            btnEditRecipe.TabIndex = 3;
            btnEditRecipe.Text = "Change";
            btnEditRecipe.UseVisualStyleBackColor = true;
            btnEditRecipe.Click += btnEditRecipe_Click;

            btnRemoveRecipe.Location = new Point(200, 699);
            btnRemoveRecipe.Margin = new Padding(4);
            btnRemoveRecipe.Name = "btnRemoveRecipe";
            btnRemoveRecipe.Size = new Size(150, 38);
            btnRemoveRecipe.TabIndex = 4;
            btnRemoveRecipe.Text = "Delete";
            btnRemoveRecipe.UseVisualStyleBackColor = true;
            btnRemoveRecipe.Click += btnRemoveRecipe_Click;

            btnClearInput.Location = new Point(375, 699);
            btnClearInput.Margin = new Padding(4);
            btnClearInput.Name = "btnClearInput";
            btnClearInput.Size = new Size(150, 38);
            btnClearInput.TabIndex = 5;
            btnClearInput.Text = "Clear Input";
            btnClearInput.UseVisualStyleBackColor = true;
            btnClearInput.Click += btnClearInput_Click;

            btnAddIngredients.Location = new Point(25, 138);
            btnAddIngredients.Margin = new Padding(4);
            btnAddIngredients.Name = "btnAddIngredients";
            btnAddIngredients.Size = new Size(412, 38);
            btnAddIngredients.TabIndex = 4;
            btnAddIngredients.Text = "Add Ingredients and Instructions";
            btnAddIngredients.UseVisualStyleBackColor = true;
            btnAddIngredients.Click += btnAddIngredients_Click;

            btnAddImage.Location = new Point(561, 225);
            btnAddImage.Margin = new Padding(4);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(250, 38);
            btnAddImage.TabIndex = 7;
            btnAddImage.Text = "Add Image";
            btnAddImage.UseVisualStyleBackColor = true;

            lblIngredients.AutoSize = true;
            lblIngredients.Location = new Point(562, 275);
            lblIngredients.Margin = new Padding(4, 0, 4, 0);
            lblIngredients.Name = "lblIngredients";
            lblIngredients.Size = new Size(121, 25);
            lblIngredients.TabIndex = 8;
            lblIngredients.Text = "INGREDIENTS";

            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(25, 38);
            lblRecipeName.Margin = new Padding(4, 0, 4, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(112, 25);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe name";

            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(25, 88);
            lblCategory.Margin = new Padding(4, 0, 4, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(84, 25);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category";

            pictureBox.Location = new Point(562, 25);
            pictureBox.Margin = new Padding(4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(250, 188);
            pictureBox.TabIndex = 6;
            pictureBox.TabStop = false;

            grpAddNewRecipe.Controls.Add(lblRecipeName);
            grpAddNewRecipe.Controls.Add(txtRecipeName);
            grpAddNewRecipe.Controls.Add(lblCategory);
            grpAddNewRecipe.Controls.Add(cmbCategory);
            grpAddNewRecipe.Controls.Add(btnAddIngredients);
            grpAddNewRecipe.Location = new Point(25, 25);
            grpAddNewRecipe.Margin = new Padding(4);
            grpAddNewRecipe.Name = "grpAddNewRecipe";
            grpAddNewRecipe.Padding = new Padding(4);
            grpAddNewRecipe.Size = new Size(500, 188);
            grpAddNewRecipe.TabIndex = 0;
            grpAddNewRecipe.TabStop = false;
            grpAddNewRecipe.Text = "Add New Recipe";

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 750);
            Controls.Add(grpAddNewRecipe);
            Controls.Add(btnAddRecipe);
            Controls.Add(lstRecipes);
            Controls.Add(btnEditRecipe);
            Controls.Add(btnRemoveRecipe);
            Controls.Add(btnClearInput);
            Controls.Add(pictureBox);
            Controls.Add(btnAddImage);
            Controls.Add(lblIngredients);
            Controls.Add(lblRecipeDetails);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Apu Cookbook by Ibrahim Ogunbanjo";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            grpAddNewRecipe.ResumeLayout(false);
            grpAddNewRecipe.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}