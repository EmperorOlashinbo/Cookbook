namespace Cookbook
{
    public partial class FormRecipeDetails : Form
    {
        private ListBox lstIngredients;          // ListBox to display the list of ingredients
        private TextBox txtIngredient;           // TextBox for entering a new or edited ingredient
        private TextBox txtRecipeName;           // TextBox for entering the recipe name
        private TextBox txtDescription;          // TextBox for entering the recipe description
        private Button btnAddIngredient;         // Button to add an ingredient to the list
        private Button btnEditIngredient;        // Button to edit a selected ingredient
        private Button btnDeleteIngredient;      // Button to delete a selected ingredient
        private Button btnOK;                    // Button to confirm and save changes
        private Button btnCancel;                // Button to cancel and close the form
        private Label lblInstructions;           // Label for the description/instructions section
        private Label lblRecipeName;             // Label for the recipe name input
        private Label lblNumOfIngredients;       // Label for the number of ingredients display
        private TextBox txtNumOfIngredients;     // TextBox to display the count of ingredients
        private TextBox txtInstructions;         // TextBox for entering cooking instructions

        // Method to initialize and configure all UI components
        private void InitializeComponent()
        {
            txtRecipeName = new TextBox();       // Creates a new TextBox for the recipe name
            txtNumOfIngredients = new TextBox(); // Creates a new TextBox for the ingredient count
            lstIngredients = new ListBox();      // Creates a new ListBox for ingredients
            txtDescription = new TextBox();      // Creates a new TextBox for the description
            txtIngredient = new TextBox();       // Creates a new TextBox for ingredient input
            txtInstructions = new TextBox();     // Creates a new TextBox for instructions
            btnAddIngredient = new Button();     // Creates a new Button for adding ingredients
            btnEditIngredient = new Button();    // Creates a new Button for editing ingredients
            btnDeleteIngredient = new Button();  // Creates a new Button for deleting ingredients
            btnOK = new Button();                // Creates a new Button for confirming changes
            btnCancel = new Button();            // Creates a new Button for canceling changes
            lblInstructions = new Label();       // Creates a new Label for instructions
            lblRecipeName = new Label();         // Creates a new Label for the recipe name
            lblNumOfIngredients = new Label();   // Creates a new Label for the ingredient count
            SuspendLayout();                     // Suspends layout logic for the form
            // 
            // txtRecipeName
            // 
            txtRecipeName.Location = new Point(17, 56); // Sets the position of the recipe name TextBox
            txtRecipeName.Name = "txtRecipeName";       // Assigns a name to the TextBox
            txtRecipeName.Size = new Size(408, 31);     // Sets the size of the TextBox
            txtRecipeName.TabIndex = 0;                 // Sets the tab order for the TextBox
            // 
            // txtNumOfIngredients
            // 
            txtNumOfIngredients.Location = new Point(365, 389); // Sets the position of the ingredient count TextBox
            txtNumOfIngredients.Name = "txtNumOfIngredients";   // Assigns a name to the TextBox
            txtNumOfIngredients.ReadOnly = true;                // Makes the TextBox read-only
            txtNumOfIngredients.Size = new Size(40, 31);        // Sets the size of the TextBox
            txtNumOfIngredients.TabIndex = 2;                   // Sets the tab order for the TextBox
            // 
            // lstIngredients
            // 
            lstIngredients.FormattingEnabled = true;     // Enables formatting for the ListBox
            lstIngredients.ItemHeight = 25;              // Sets the height of each item in the ListBox
            lstIngredients.Location = new Point(17, 138); // Sets the position of the ListBox
            lstIngredients.Name = "lstIngredients";      // Assigns a name to the ListBox
            lstIngredients.Size = new Size(408, 229);    // Sets the size of the ListBox
            lstIngredients.TabIndex = 3;                 // Sets the tab order for the ListBox
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(496, 138); // Sets the position of the description TextBox
            txtDescription.Multiline = true;               // Enables multiline input for the TextBox
            txtDescription.Name = "txtDescription";        // Assigns a name to the TextBox
            txtDescription.Size = new Size(446, 229);      // Sets the size of the TextBox
            txtDescription.TabIndex = 4;                   // Sets the tab order for the TextBox
            // 
            // txtIngredient
            // 
            txtIngredient.Location = new Point(17, 56);    // Sets the position of the ingredient TextBox
            txtIngredient.Name = "txtIngredient";          // Assigns a name to the TextBox
            txtIngredient.Size = new Size(408, 31);        // Sets the size of the TextBox
            txtIngredient.TabIndex = 1;                    // Sets the tab order for the TextBox
            // 
            // txtInstructions
            // 
            txtInstructions.Location = new Point(496, 138); // Sets the position of the instructions TextBox
            txtInstructions.Multiline = true;               // Enables multiline input for the TextBox
            txtInstructions.Name = "txtInstructions";       // Assigns a name to the TextBox
            txtInstructions.Size = new Size(446, 229);      // Sets the size of the TextBox
            txtInstructions.TabIndex = 10;                  // Sets the tab order for the TextBox
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Location = new Point(17, 93);  // Sets the position of the add ingredient Button
            btnAddIngredient.Name = "btnAddIngredient";     // Assigns a name to the Button
            btnAddIngredient.Size = new Size(111, 39);      // Sets the size of the Button
            btnAddIngredient.TabIndex = 5;                  // Sets the tab order for the Button
            btnAddIngredient.Text = "Add";                  // Sets the display text of the Button
            btnAddIngredient.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnAddIngredient.Click += new EventHandler(btnAddIngredient_Click); // Attaches the click event handler
            // 
            // btnEditIngredient
            // 
            btnEditIngredient.Location = new Point(148, 93); // Sets the position of the edit ingredient Button
            btnEditIngredient.Name = "btnEditIngredient";    // Assigns a name to the Button
            btnEditIngredient.Size = new Size(125, 39);      // Sets the size of the Button
            btnEditIngredient.TabIndex = 6;                  // Sets the tab order for the Button
            btnEditIngredient.Text = "Edit";                 // Sets the display text of the Button
            btnEditIngredient.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnEditIngredient.Click += new EventHandler(btnEditIngredient_Click); // Attaches the click event handler
            // 
            // btnDeleteIngredient
            // 
            btnDeleteIngredient.Location = new Point(308, 93); // Sets the position of the delete ingredient Button
            btnDeleteIngredient.Name = "btnDeleteIngredient";  // Assigns a name to the Button
            btnDeleteIngredient.Size = new Size(117, 39);      // Sets the size of the Button
            btnDeleteIngredient.TabIndex = 7;                  // Sets the tab order for the Button
            btnDeleteIngredient.Text = "Delete";               // Sets the display text of the Button
            btnDeleteIngredient.UseVisualStyleBackColor = true; // Uses the system visual style for the background
            btnDeleteIngredient.Click += new EventHandler(btnDeleteIngredient_Click); // Attaches the click event handler
            // 
            // btnOK
            // 
            btnOK.Location = new Point(738, 395);          // Sets the position of the OK Button
            btnOK.Name = "btnOK";                          // Assigns a name to the Button
            btnOK.Size = new Size(75, 33);                 // Sets the size of the Button
            btnOK.TabIndex = 8;                            // Sets the tab order for the Button
            btnOK.Text = "OK";                             // Sets the display text of the Button
            btnOK.UseVisualStyleBackColor = true;          // Uses the system visual style for the background
            btnOK.Click += new EventHandler(btnOK_Click);  // Attaches the click event handler
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(867, 395);      // Sets the position of the Cancel Button
            btnCancel.Name = "btnCancel";                  // Assigns a name to the Button
            btnCancel.Size = new Size(75, 33);             // Sets the size of the Button
            btnCancel.TabIndex = 9;                        // Sets the tab order for the Button
            btnCancel.Text = "Cancel";                     // Sets the display text of the Button
            btnCancel.UseVisualStyleBackColor = true;      // Uses the system visual style for the background
            btnCancel.Click += new EventHandler(btnCancel_Click); // Attaches the click event handler
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;               // Allows the label to automatically adjust its size
            lblInstructions.Location = new Point(496, 91); // Sets the position of the instructions Label
            lblInstructions.Name = "lblInstructions";      // Assigns a name to the Label
            lblInstructions.Size = new Size(272, 25);      // Sets the initial size of the Label
            lblInstructions.TabIndex = 11;                 // Sets the tab order for the Label
            lblInstructions.Text = "Description/Cooking instructions"; // Sets the display text of the Label
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;                 // Allows the label to automatically adjust its size
            lblRecipeName.Location = new Point(17, 23);    // Sets the position of the recipe name Label
            lblRecipeName.Name = "lblRecipeName";          // Assigns a name to the Label
            lblRecipeName.Size = new Size(161, 25);        // Sets the initial size of the Label
            lblRecipeName.TabIndex = 12;                   // Sets the tab order for the Label
            lblRecipeName.Text = "Name and amount";        // Sets the display text of the Label
            // 
            // lblNumOfIngredients
            // 
            lblNumOfIngredients.AutoSize = true;           // Allows the label to automatically adjust its size
            lblNumOfIngredients.Location = new Point(17, 399); // Sets the position of the ingredient count Label
            lblNumOfIngredients.Name = "lblNumOfIngredients";  // Assigns a name to the Label
            lblNumOfIngredients.Size = new Size(196, 25);      // Sets the initial size of the Label
            lblNumOfIngredients.TabIndex = 14;                 // Sets the tab order for the Label
            lblNumOfIngredients.Text = "Number of ingredients:"; // Sets the display text of the Label
            // 
            // FormRecipeDetails
            // 
            ClientSize = new Size(1039, 456);              // Sets the size of the form's client area
            Controls.Add(txtInstructions);                 // Adds the instructions TextBox to the form
            Controls.Add(txtIngredient);                   // Adds the ingredient TextBox to the form
            Controls.Add(lblNumOfIngredients);             // Adds the ingredient count Label to the form
            Controls.Add(lblRecipeName);                   // Adds the recipe name Label to the form
            Controls.Add(lblInstructions);                 // Adds the instructions Label to the form
            Controls.Add(btnCancel);                       // Adds the Cancel Button to the form
            Controls.Add(btnOK);                           // Adds the OK Button to the form
            Controls.Add(btnDeleteIngredient);             // Adds the delete ingredient Button to the form
            Controls.Add(btnEditIngredient);               // Adds the edit ingredient Button to the form
            Controls.Add(btnAddIngredient);                // Adds the add ingredient Button to the form
            Controls.Add(txtDescription);                  // Adds the description TextBox to the form
            Controls.Add(lstIngredients);                  // Adds the ingredients ListBox to the form
            Controls.Add(txtNumOfIngredients);             // Adds the ingredient count TextBox to the form
            Controls.Add(txtRecipeName);                   // Adds the recipe name TextBox to the form
            Name = "FormRecipeDetails";                    // Assigns a name to the form
            Text = "Add Ingredients & Instructions";       // Sets the title of the form
            ResumeLayout(false);                           // Resumes layout logic for the form
            PerformLayout();                               // Applies layout changes to the form
        }
    }
}