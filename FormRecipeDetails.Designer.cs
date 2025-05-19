namespace Cookbook
{
    public partial class FormRecipeDetails : Form
    {
        private ListBox lstIngredients;
        private TextBox txtIngredient;
        private TextBox txtRecipeName;
        private TextBox txtDescription;
        private Button btnAddIngredient;
        private Button btnEditIngredient;
        private Button btnDeleteIngredient;
        private Button btnOK;
        private Button btnCancel;
        private Label lblRecipeName;
        private Label lblNumOfIngredients;
        private TextBox txtNumOfIngredients;
        private Label lblDescription;

        private void InitializeComponent()
        {
            txtRecipeName = new TextBox();
            txtNumOfIngredients = new TextBox();
            lstIngredients = new ListBox();
            txtDescription = new TextBox();
            txtIngredient = new TextBox();
            btnAddIngredient = new Button();
            btnEditIngredient = new Button();
            btnDeleteIngredient = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            lblRecipeName = new Label();
            lblNumOfIngredients = new Label();
            lblDescription = new Label();
            SuspendLayout();

            txtRecipeName.Location = new Point(150, 23);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(275, 31);
            txtRecipeName.TabIndex = 0;

            txtNumOfIngredients.Location = new Point(220, 373);
            txtNumOfIngredients.Name = "txtNumOfIngredients";
            txtNumOfIngredients.ReadOnly = true;
            txtNumOfIngredients.Size = new Size(40, 31);
            txtNumOfIngredients.TabIndex = 2;

            lstIngredients.FormattingEnabled = true;
            lstIngredients.ItemHeight = 25;
            lstIngredients.Location = new Point(17, 138);
            lstIngredients.Name = "lstIngredients";
            lstIngredients.Size = new Size(408, 229);
            lstIngredients.TabIndex = 3;

            txtDescription.Location = new Point(496, 138);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(446, 229);
            txtDescription.TabIndex = 4;

            txtIngredient.Location = new Point(17, 56);
            txtIngredient.Name = "txtIngredient";
            txtIngredient.Size = new Size(408, 31);
            txtIngredient.TabIndex = 1;

            btnAddIngredient.Location = new Point(17, 93);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(111, 39);
            btnAddIngredient.TabIndex = 5;
            btnAddIngredient.Text = "Add";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += new EventHandler(btnAddIngredient_Click);

            btnEditIngredient.Location = new Point(148, 93);
            btnEditIngredient.Name = "btnEditIngredient";
            btnEditIngredient.Size = new Size(125, 39);
            btnEditIngredient.TabIndex = 6;
            btnEditIngredient.Text = "Edit";
            btnEditIngredient.UseVisualStyleBackColor = true;
            btnEditIngredient.Click += new EventHandler(btnEditIngredient_Click);

            btnDeleteIngredient.Location = new Point(308, 93);
            btnDeleteIngredient.Name = "btnDeleteIngredient";
            btnDeleteIngredient.Size = new Size(117, 39);
            btnDeleteIngredient.TabIndex = 7;
            btnDeleteIngredient.Text = "Delete";
            btnDeleteIngredient.UseVisualStyleBackColor = true;
            btnDeleteIngredient.Click += new EventHandler(btnDeleteIngredient_Click);

            btnOK.Location = new Point(738, 395);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 33);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += new EventHandler(btnOK_Click);

            btnCancel.Location = new Point(867, 395);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 33);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new EventHandler(btnCancel_Click);

            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(17, 23);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(161, 25);
            lblRecipeName.TabIndex = 12;
            lblRecipeName.Text = "Name and amount";

            lblNumOfIngredients.AutoSize = true;
            lblNumOfIngredients.Location = new Point(17, 373);
            lblNumOfIngredients.Name = "lblNumOfIngredients";
            lblNumOfIngredients.Size = new Size(196, 25);
            lblNumOfIngredients.TabIndex = 14;
            lblNumOfIngredients.Text = "Number of ingredients:";

            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(496, 91);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(272, 25);
            lblDescription.TabIndex = 11;
            lblDescription.Text = "Description/Cooking instructions";

            ClientSize = new Size(1039, 456);
            Controls.Add(txtDescription);
            Controls.Add(txtIngredient);
            Controls.Add(lblNumOfIngredients);
            Controls.Add(lblDescription);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnDeleteIngredient);
            Controls.Add(btnEditIngredient);
            Controls.Add(btnAddIngredient);
            Controls.Add(lstIngredients);
            Controls.Add(txtNumOfIngredients);
            Controls.Add(txtRecipeName);
            Controls.Add(lblRecipeName);
            Name = "FormRecipeDetails";
            Text = "Add Ingredients & Instructions";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}