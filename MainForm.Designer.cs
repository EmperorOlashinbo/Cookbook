using System;
using System.Windows.Forms;

namespace Cookbook
{
    public partial class MainForm : Form
    {
        private RecipeManager recipeManager;          // Manages the collection of recipes
        private Recipe currRecipe;                   // Holds the currently selected recipe
        private const int maxNumOfIngredients = 50;  // Maximum number of ingredients allowed per recipe
        private const int maxNumOfRecipes = 200;     // Maximum number of recipes allowed in the manager

        private PictureBox pictureBox;               // Displays an image associated with a recipe
        private ComboBox cmbCategory;                // Dropdown for selecting a recipe category
        private ListBox lstRecipes;                  // Displays the list of recipes
        private TextBox txtRecipeName;               // Input field for the recipe name
        private TextBox txtDescription;              // Multiline input field for the recipe description
        private Button btnAddRecipe;                 // Button to add a new recipe
        private Button btnEditRecipe;                // Button to edit an existing recipe
        private Button btnRemoveRecipe;              // Button to remove a recipe
        private Button btnClearInput;                // Button to clear all input fields
        private Button btnAddIngredients;            // Button to add ingredients and instructions
        private Button btnAddImage;                  // Button to add an image to a recipe
        private Label lblIngredients;                // Label for the ingredients section
        private Label lblRecipeName;                 // Label for the recipe name input
        private Label lblCategory;                   // Label for the category dropdown
        private GroupBox grpAddNewRecipe;            // Groups controls for adding a new recipe

        // Method to initialize and configure all UI components
        private void InitializeComponent()
        {
            cmbCategory = new ComboBox();            // Creates a new ComboBox for categories
            lstRecipes = new ListBox();              // Creates a new ListBox for recipes
            txtRecipeName = new TextBox();           // Creates a new TextBox for recipe name input
            txtDescription = new TextBox();          // Creates a new TextBox for recipe description
            btnAddRecipe = new Button();             // Creates a new Button for adding recipes
            btnEditRecipe = new Button();            // Creates a new Button for editing recipes
            btnRemoveRecipe = new Button();          // Creates a new Button for removing recipes
            btnClearInput = new Button();            // Creates a new Button for clearing input
            btnAddIngredients = new Button();        // Creates a new Button for adding ingredients
            btnAddImage = new Button();              // Creates a new Button for adding an image
            lblIngredients = new Label();            // Creates a new Label for ingredients
            lblRecipeName = new Label();             // Creates a new Label for recipe name
            lblCategory = new Label();               // Creates a new Label for category
            pictureBox = new PictureBox();           // Creates a new PictureBox for displaying images
            grpAddNewRecipe = new GroupBox();        // Creates a new GroupBox for organizing add recipe controls
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit(); // Begins initialization of PictureBox
            grpAddNewRecipe.SuspendLayout();         // Suspends layout logic for the GroupBox
            SuspendLayout();                         // Suspends layout logic for the form
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList; // Sets the ComboBox to dropdown list style
            cmbCategory.FormattingEnabled = true;    // Enables formatting for the ComboBox
            cmbCategory.Location = new Point(287, 88); // Sets the position of the ComboBox
            cmbCategory.Margin = new Padding(4);     // Sets the margin around the ComboBox
            cmbCategory.Name = "cmbCategory";        // Assigns a name to the ComboBox
            cmbCategory.Size = new Size(150, 33);    // Sets the size of the ComboBox
            cmbCategory.TabIndex = 3;                // Sets the tab order for the ComboBox
            // 
            // lstRecipes
            // 
            lstRecipes.FormattingEnabled = true;     // Enables formatting for the ListBox
            lstRecipes.ItemHeight = 25;              // Sets the height of each item in the ListBox
            lstRecipes.Location = new Point(26, 300); // Sets the position of the ListBox
            lstRecipes.Margin = new Padding(4);      // Sets the margin around the ListBox
            lstRecipes.Name = "lstRecipes";          // Assigns a name to the ListBox
            lstRecipes.Size = new Size(499, 379);    // Sets the size of the ListBox
            lstRecipes.TabIndex = 2;                 // Sets the tab order for the ListBox
            lstRecipes.SelectedIndexChanged += lstRecipes_SelectedIndexChanged; // Event handler for selection change
            // 
            // txtRecipeName
            // 
            txtRecipeName.Location = new Point(188, 38); // Sets the position of the recipe name TextBox
            txtRecipeName.Margin = new Padding(4);   // Sets the margin around the TextBox
            txtRecipeName.Name = "txtRecipeName";    // Assigns a name to the TextBox
            txtRecipeName.Size = new Size(249, 31);  // Sets the size of the TextBox
            txtRecipeName.TabIndex = 1;              // Sets the tab order for the TextBox
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(549, 316); // Sets the position of the description TextBox
            txtDescription.Margin = new Padding(4);  // Sets the margin around the TextBox
            txtDescription.Multiline = true;         // Enables multiline input for the TextBox
            txtDescription.Name = "txtDescription";  // Assigns a name to the TextBox
            txtDescription.Size = new Size(436, 363); // Sets the size of the TextBox
            txtDescription.TabIndex = 9;             // Sets the tab order for the TextBox
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Location = new Point(97, 225); // Sets the position of the add recipe Button
            btnAddRecipe.Margin = new Padding(4);    // Sets the margin around the Button
            btnAddRecipe.Name = "btnAddRecipe";      // Assigns a name to the Button
            btnAddRecipe.Size = new Size(294, 38);   // Sets the size of the Button
            btnAddRecipe.TabIndex = 1;               // Sets the tab order for the Button
            btnAddRecipe.Text = "Add Recipe";        // Sets the display text of the Button
            btnAddRecipe.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnAddRecipe.Click += btnAddRecipe_Click; // Event handler for button click
            // 
            // btnEditRecipe
            // 
            btnEditRecipe.Location = new Point(26, 699); // Sets the position of the edit recipe Button
            btnEditRecipe.Margin = new Padding(4);   // Sets the margin around the Button
            btnEditRecipe.Name = "btnEditRecipe";    // Assigns a name to the Button
            btnEditRecipe.Size = new Size(150, 38);  // Sets the size of the Button
            btnEditRecipe.TabIndex = 3;              // Sets the tab order for the Button
            btnEditRecipe.Text = "Change";           // Sets the display text of the Button
            btnEditRecipe.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnEditRecipe.Click += btnEditRecipe_Click; // Event handler for button click
            // 
            // btnRemoveRecipe
            // 
            btnRemoveRecipe.Location = new Point(200, 699); // Sets the position of the remove recipe Button
            btnRemoveRecipe.Margin = new Padding(4); // Sets the margin around the Button
            btnRemoveRecipe.Name = "btnRemoveRecipe"; // Assigns a name to the Button
            btnRemoveRecipe.Size = new Size(150, 38); // Sets the size of the Button
            btnRemoveRecipe.TabIndex = 4;            // Sets the tab order for the Button
            btnRemoveRecipe.Text = "Delete";         // Sets the display text of the Button
            btnRemoveRecipe.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnRemoveRecipe.Click += btnRemoveRecipe_Click; // Event handler for button click
            // 
            // btnClearInput
            // 
            btnClearInput.Location = new Point(375, 699); // Sets the position of the clear input Button
            btnClearInput.Margin = new Padding(4);   // Sets the margin around the Button
            btnClearInput.Name = "btnClearInput";    // Assigns a name to the Button
            btnClearInput.Size = new Size(150, 38);  // Sets the size of the Button
            btnClearInput.TabIndex = 5;              // Sets the tab order for the Button
            btnClearInput.Text = "Clear Input";      // Sets the display text of the Button
            btnClearInput.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnClearInput.Click += btnClearInput_Click; // Event handler for button click
            // 
            // btnAddIngredients
            // 
            btnAddIngredients.Location = new Point(25, 138); // Sets the position of the add ingredients Button
            btnAddIngredients.Margin = new Padding(4); // Sets the margin around the Button
            btnAddIngredients.Name = "btnAddIngredients"; // Assigns a name to the Button
            btnAddIngredients.Size = new Size(412, 38); // Sets the size of the Button
            btnAddIngredients.TabIndex = 4;          // Sets the tab order for the Button
            btnAddIngredients.Text = "Add Ingredients and Instructions"; // Sets the display text of the Button
            btnAddIngredients.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnAddIngredients.Click += btnAddIngredients_Click; // Event handler for button click
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(561, 225); // Sets the position of the add image Button
            btnAddImage.Margin = new Padding(4);     // Sets the margin around the Button
            btnAddImage.Name = "btnAddImage";        // Assigns a name to the Button
            btnAddImage.Size = new Size(250, 38);    // Sets the size of the Button
            btnAddImage.TabIndex = 7;                // Sets the tab order for the Button
            btnAddImage.Text = "Add Image";          // Sets the display text of the Button
            btnAddImage.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            // 
            // lblIngredients
            // 
            lblIngredients.AutoSize = true;          // Allows the label to automatically adjust its size
            lblIngredients.Location = new Point(562, 275); // Sets the position of the ingredients Label
            lblIngredients.Margin = new Padding(4, 0, 4, 0); // Sets the margin around the Label
            lblIngredients.Name = "lblIngredients";  // Assigns a name to the Label
            lblIngredients.Size = new Size(121, 25); // Sets the initial size of the Label
            lblIngredients.TabIndex = 8;             // Sets the tab order for the Label
            lblIngredients.Text = "INGREDIENTS";     // Sets the display text of the Label
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;           // Allows the label to automatically adjust its size
            lblRecipeName.Location = new Point(25, 38); // Sets the position of the recipe name Label
            lblRecipeName.Margin = new Padding(4, 0, 4, 0); // Sets the margin around the Label
            lblRecipeName.Name = "lblRecipeName";    // Assigns a name to the Label
            lblRecipeName.Size = new Size(112, 25);  // Sets the initial size of the Label
            lblRecipeName.TabIndex = 0;              // Sets the tab order for the Label
            lblRecipeName.Text = "Recipe name";      // Sets the display text of the Label
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;             // Allows the label to automatically adjust its size
            lblCategory.Location = new Point(25, 88); // Sets the position of the category Label
            lblCategory.Margin = new Padding(4, 0, 4, 0); // Sets the margin around the Label
            lblCategory.Name = "lblCategory";        // Assigns a name to the Label
            lblCategory.Size = new Size(84, 25);     // Sets the initial size of the Label
            lblCategory.TabIndex = 2;                // Sets the tab order for the Label
            lblCategory.Text = "Category";           // Sets the display text of the Label
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(562, 25); // Sets the position of the PictureBox
            pictureBox.Margin = new Padding(4);      // Sets the margin around the PictureBox
            pictureBox.Name = "pictureBox";          // Assigns a name to the PictureBox
            pictureBox.Size = new Size(250, 188);    // Sets the size of the PictureBox
            pictureBox.TabIndex = 6;                 // Sets the tab order for the PictureBox
            pictureBox.TabStop = false;              // Prevents the PictureBox from being focused via tab
            // 
            // grpAddNewRecipe
            // 
            grpAddNewRecipe.Controls.Add(lblRecipeName); // Adds the recipe name Label to the GroupBox
            grpAddNewRecipe.Controls.Add(txtRecipeName); // Adds the recipe name TextBox to the GroupBox
            grpAddNewRecipe.Controls.Add(lblCategory);   // Adds the category Label to the GroupBox
            grpAddNewRecipe.Controls.Add(cmbCategory);   // Adds the category ComboBox to the GroupBox
            grpAddNewRecipe.Controls.Add(btnAddIngredients); // Adds the ingredients Button to the GroupBox
            grpAddNewRecipe.Location = new Point(25, 25); // Sets the position of the GroupBox
            grpAddNewRecipe.Margin = new Padding(4); // Sets the margin around the GroupBox
            grpAddNewRecipe.Name = "grpAddNewRecipe"; // Assigns a name to the GroupBox
            grpAddNewRecipe.Padding = new Padding(4); // Sets the internal padding of the GroupBox
            grpAddNewRecipe.Size = new Size(500, 188); // Sets the size of the GroupBox
            grpAddNewRecipe.TabIndex = 0;            // Sets the tab order for the GroupBox
            grpAddNewRecipe.TabStop = false;         // Prevents the GroupBox from being focused via tab
            grpAddNewRecipe.Text = "Add New Recipe"; // Sets the display text of the GroupBox
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F); // Sets the scaling dimensions for the form
            AutoScaleMode = AutoScaleMode.Font;      // Sets the scaling mode to font-based
            ClientSize = new Size(998, 750);         // Sets the size of the form's client area
            Controls.Add(grpAddNewRecipe);           // Adds the GroupBox to the form
            Controls.Add(btnAddRecipe);              // Adds the add recipe Button to the form
            Controls.Add(lstRecipes);                // Adds the recipes ListBox to the form
            Controls.Add(btnEditRecipe);             // Adds the edit recipe Button to the form
            Controls.Add(btnRemoveRecipe);           // Adds the remove recipe Button to the form
            Controls.Add(btnClearInput);             // Adds the clear input Button to the form
            Controls.Add(pictureBox);                // Adds the PictureBox to the form
            Controls.Add(btnAddImage);               // Adds the add image Button to the form
            Controls.Add(lblIngredients);            // Adds the ingredients Label to the form
            Controls.Add(txtDescription);            // Adds the description TextBox to the form
            Margin = new Padding(4);                 // Sets the margin around the form
            Name = "MainForm";                       // Assigns a name to the form
            Text = "Apu Cookbook by Ibrahim Ogunbanjo"; // Sets the title of the form
            Load += MainForm_Load;                   // Event handler for form load
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit(); // Ends initialization of PictureBox
            grpAddNewRecipe.ResumeLayout(false);     // Resumes layout logic for the GroupBox
            grpAddNewRecipe.PerformLayout();         // Applies layout changes to the GroupBox
            ResumeLayout(false);                     // Resumes layout logic for the form
            PerformLayout();                         // Applies layout changes to the form
        }
    }
}