namespace E7CharactersManager
{
    partial class E7CharactersList
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFilterClass = new System.Windows.Forms.Label();
            this.checkListClass = new System.Windows.Forms.CheckedListBox();
            this.checkListGender = new System.Windows.Forms.CheckedListBox();
            this.lblFilterGender = new System.Windows.Forms.Label();
            this.checkListProperties = new System.Windows.Forms.CheckedListBox();
            this.lblFilterProperty = new System.Windows.Forms.Label();
            this.cmbCharactersList = new System.Windows.Forms.ComboBox();
            this.lblCharacters = new System.Windows.Forms.Label();
            this.checkListElements = new System.Windows.Forms.CheckedListBox();
            this.lblFilterElement = new System.Windows.Forms.Label();
            this.checkListRarity = new System.Windows.Forms.CheckedListBox();
            this.lblFilterRarity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFilterClass
            // 
            this.lblFilterClass.AutoSize = true;
            this.lblFilterClass.Location = new System.Drawing.Point(12, 9);
            this.lblFilterClass.Name = "lblFilterClass";
            this.lblFilterClass.Size = new System.Drawing.Size(73, 13);
            this.lblFilterClass.TabIndex = 0;
            this.lblFilterClass.Text = "Filter by class:";
            // 
            // checkListClass
            // 
            this.checkListClass.CheckOnClick = true;
            this.checkListClass.FormattingEnabled = true;
            this.checkListClass.Items.AddRange(new object[] {
            "Warrior",
            "Knight",
            "Thief",
            "Mage",
            "Ranger",
            "SoulWeaver"});
            this.checkListClass.Location = new System.Drawing.Point(15, 25);
            this.checkListClass.Name = "checkListClass";
            this.checkListClass.Size = new System.Drawing.Size(161, 94);
            this.checkListClass.TabIndex = 1;
            this.checkListClass.SelectedIndexChanged += new System.EventHandler(this.checkListClass_SelectedIndexChanged);
            // 
            // checkListGender
            // 
            this.checkListGender.CheckOnClick = true;
            this.checkListGender.FormattingEnabled = true;
            this.checkListGender.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.checkListGender.Location = new System.Drawing.Point(15, 251);
            this.checkListGender.Name = "checkListGender";
            this.checkListGender.Size = new System.Drawing.Size(161, 94);
            this.checkListGender.TabIndex = 3;
            this.checkListGender.SelectedIndexChanged += new System.EventHandler(this.checkListGender_SelectedIndexChanged);
            // 
            // lblFilterGender
            // 
            this.lblFilterGender.AutoSize = true;
            this.lblFilterGender.Location = new System.Drawing.Point(12, 235);
            this.lblFilterGender.Name = "lblFilterGender";
            this.lblFilterGender.Size = new System.Drawing.Size(82, 13);
            this.lblFilterGender.TabIndex = 2;
            this.lblFilterGender.Text = "Filter by gender:";
            // 
            // checkListProperties
            // 
            this.checkListProperties.CheckOnClick = true;
            this.checkListProperties.FormattingEnabled = true;
            this.checkListProperties.Items.AddRange(new object[] {
            "ClothesChange",
            "Collab",
            "Skin",
            "SpecialtyChange"});
            this.checkListProperties.Location = new System.Drawing.Point(185, 251);
            this.checkListProperties.Name = "checkListProperties";
            this.checkListProperties.Size = new System.Drawing.Size(161, 94);
            this.checkListProperties.TabIndex = 7;
            this.checkListProperties.SelectedIndexChanged += new System.EventHandler(this.checkListProperties_SelectedIndexChanged);
            // 
            // lblFilterProperty
            // 
            this.lblFilterProperty.AutoSize = true;
            this.lblFilterProperty.Location = new System.Drawing.Point(182, 235);
            this.lblFilterProperty.Name = "lblFilterProperty";
            this.lblFilterProperty.Size = new System.Drawing.Size(95, 13);
            this.lblFilterProperty.TabIndex = 6;
            this.lblFilterProperty.Text = "Filter by properties:";
            // 
            // cmbCharactersList
            // 
            this.cmbCharactersList.FormattingEnabled = true;
            this.cmbCharactersList.Location = new System.Drawing.Point(182, 25);
            this.cmbCharactersList.Name = "cmbCharactersList";
            this.cmbCharactersList.Size = new System.Drawing.Size(164, 21);
            this.cmbCharactersList.TabIndex = 9;
            // 
            // lblCharacters
            // 
            this.lblCharacters.AutoSize = true;
            this.lblCharacters.Location = new System.Drawing.Point(182, 9);
            this.lblCharacters.Name = "lblCharacters";
            this.lblCharacters.Size = new System.Drawing.Size(61, 13);
            this.lblCharacters.TabIndex = 8;
            this.lblCharacters.Text = "Characters:";
            // 
            // checkListElements
            // 
            this.checkListElements.CheckOnClick = true;
            this.checkListElements.FormattingEnabled = true;
            this.checkListElements.Items.AddRange(new object[] {
            "Fire",
            "Earth",
            "Ice",
            "Light",
            "Dark"});
            this.checkListElements.Location = new System.Drawing.Point(15, 138);
            this.checkListElements.Name = "checkListElements";
            this.checkListElements.Size = new System.Drawing.Size(161, 94);
            this.checkListElements.TabIndex = 5;
            this.checkListElements.SelectedIndexChanged += new System.EventHandler(this.checkListElements_SelectedIndexChanged);
            // 
            // lblFilterElement
            // 
            this.lblFilterElement.AutoSize = true;
            this.lblFilterElement.Location = new System.Drawing.Point(12, 122);
            this.lblFilterElement.Name = "lblFilterElement";
            this.lblFilterElement.Size = new System.Drawing.Size(86, 13);
            this.lblFilterElement.TabIndex = 4;
            this.lblFilterElement.Text = "Filter by element:";
            // 
            // checkListRarity
            // 
            this.checkListRarity.CheckOnClick = true;
            this.checkListRarity.FormattingEnabled = true;
            this.checkListRarity.Items.AddRange(new object[] {
            "3 Stars",
            "4 Stars",
            "5 Stars"});
            this.checkListRarity.Location = new System.Drawing.Point(185, 138);
            this.checkListRarity.Name = "checkListRarity";
            this.checkListRarity.Size = new System.Drawing.Size(161, 94);
            this.checkListRarity.TabIndex = 11;
            // 
            // lblFilterRarity
            // 
            this.lblFilterRarity.AutoSize = true;
            this.lblFilterRarity.Location = new System.Drawing.Point(182, 122);
            this.lblFilterRarity.Name = "lblFilterRarity";
            this.lblFilterRarity.Size = new System.Drawing.Size(71, 13);
            this.lblFilterRarity.TabIndex = 10;
            this.lblFilterRarity.Text = "Filter by rarity:";
            // 
            // E7CharactersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 354);
            this.Controls.Add(this.checkListRarity);
            this.Controls.Add(this.lblFilterRarity);
            this.Controls.Add(this.checkListElements);
            this.Controls.Add(this.lblFilterElement);
            this.Controls.Add(this.lblCharacters);
            this.Controls.Add(this.cmbCharactersList);
            this.Controls.Add(this.checkListProperties);
            this.Controls.Add(this.lblFilterProperty);
            this.Controls.Add(this.checkListGender);
            this.Controls.Add(this.lblFilterGender);
            this.Controls.Add(this.checkListClass);
            this.Controls.Add(this.lblFilterClass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "E7CharactersList";
            this.Text = "Characters Selector";
            this.Load += new System.EventHandler(this.E7CharactersList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkListClass;
        private System.Windows.Forms.Label lblFilterClass;
        private System.Windows.Forms.CheckedListBox checkListGender;
        private System.Windows.Forms.Label lblFilterGender;
        private System.Windows.Forms.CheckedListBox checkListProperties;
        private System.Windows.Forms.Label lblFilterProperty;
        private System.Windows.Forms.ComboBox cmbCharactersList;
        private System.Windows.Forms.Label lblCharacters;
        private System.Windows.Forms.CheckedListBox checkListElements;
        private System.Windows.Forms.Label lblFilterElement;
        private System.Windows.Forms.CheckedListBox checkListRarity;
        private System.Windows.Forms.Label lblFilterRarity;
    }
}

