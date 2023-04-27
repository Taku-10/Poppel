namespace GoodFoodSystem.PresentationLayer
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.viewCustomrbtn = new System.Windows.Forms.Button();
            this.viewProductbtn = new System.Windows.Forms.Button();
            this.searchbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.startOrderbtn = new System.Windows.Forms.Button();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.ExpiryTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.expiryLabel = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.supplierTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.supplierlbl = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.prodnameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.signInbtn = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.adminlabel = new System.Windows.Forms.Label();
            this.loMode = new System.Windows.Forms.Button();
            this.expiredProductsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(37, 72);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(627, 22);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // logoutbtn
            // 
            this.logoutbtn.Location = new System.Drawing.Point(647, 865);
            this.logoutbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(125, 34);
            this.logoutbtn.TabIndex = 2;
            this.logoutbtn.Text = "Log Out";
            this.logoutbtn.UseVisualStyleBackColor = true;
            this.logoutbtn.Click += new System.EventHandler(this.logibtnb_Click);
            // 
            // viewCustomrbtn
            // 
            this.viewCustomrbtn.Location = new System.Drawing.Point(230, 865);
            this.viewCustomrbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewCustomrbtn.Name = "viewCustomrbtn";
            this.viewCustomrbtn.Size = new System.Drawing.Size(125, 34);
            this.viewCustomrbtn.TabIndex = 4;
            this.viewCustomrbtn.Text = "View Customers";
            this.viewCustomrbtn.UseVisualStyleBackColor = true;
            this.viewCustomrbtn.Click += new System.EventHandler(this.viewCustomrbtn_Click);
            // 
            // viewProductbtn
            // 
            this.viewProductbtn.Location = new System.Drawing.Point(35, 865);
            this.viewProductbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewProductbtn.Name = "viewProductbtn";
            this.viewProductbtn.Size = new System.Drawing.Size(125, 34);
            this.viewProductbtn.TabIndex = 5;
            this.viewProductbtn.Text = "View Products";
            this.viewProductbtn.UseVisualStyleBackColor = true;
            this.viewProductbtn.Click += new System.EventHandler(this.viewProductbtn_Click);
            // 
            // searchbtn
            // 
            this.searchbtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.searchbtn.FlatAppearance.BorderSize = 0;
            this.searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchbtn.ForeColor = System.Drawing.Color.White;
            this.searchbtn.Location = new System.Drawing.Point(695, 69);
            this.searchbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(97, 25);
            this.searchbtn.TabIndex = 6;
            this.searchbtn.Text = "Search";
            this.searchbtn.UseVisualStyleBackColor = false;
            this.searchbtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 117);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1054, 420);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // startOrderbtn
            // 
            this.startOrderbtn.Location = new System.Drawing.Point(454, 865);
            this.startOrderbtn.Name = "startOrderbtn";
            this.startOrderbtn.Size = new System.Drawing.Size(99, 34);
            this.startOrderbtn.TabIndex = 8;
            this.startOrderbtn.Text = "Start Order";
            this.startOrderbtn.UseVisualStyleBackColor = true;
            this.startOrderbtn.Click += new System.EventHandler(this.startOrderbtn_Click);
            // 
            // priceTextBox
            // 
            this.priceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceTextBox.Location = new System.Drawing.Point(1510, 483);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(213, 24);
            this.priceTextBox.TabIndex = 53;
            // 
            // ExpiryTextBox
            // 
            this.ExpiryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpiryTextBox.Location = new System.Drawing.Point(1510, 420);
            this.ExpiryTextBox.Name = "ExpiryTextBox";
            this.ExpiryTextBox.Size = new System.Drawing.Size(213, 24);
            this.ExpiryTextBox.TabIndex = 52;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(1377, 486);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(42, 18);
            this.priceLabel.TabIndex = 51;
            this.priceLabel.Text = "Price";
            // 
            // expiryLabel
            // 
            this.expiryLabel.AutoSize = true;
            this.expiryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiryLabel.Location = new System.Drawing.Point(1363, 423);
            this.expiryLabel.Name = "expiryLabel";
            this.expiryLabel.Size = new System.Drawing.Size(83, 18);
            this.expiryLabel.TabIndex = 50;
            this.expiryLabel.Text = "Expiry Date";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityTextBox.Location = new System.Drawing.Point(1510, 349);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(213, 24);
            this.quantityTextBox.TabIndex = 49;
            // 
            // supplierTextBox
            // 
            this.supplierTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierTextBox.Location = new System.Drawing.Point(1510, 300);
            this.supplierTextBox.Name = "supplierTextBox";
            this.supplierTextBox.Size = new System.Drawing.Size(213, 24);
            this.supplierTextBox.TabIndex = 48;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(1510, 248);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(213, 24);
            this.descriptionTextBox.TabIndex = 47;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameTextBox.Location = new System.Drawing.Point(1510, 200);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(213, 24);
            this.productNameTextBox.TabIndex = 46;
            // 
            // idTextBox
            // 
            this.idTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTextBox.Location = new System.Drawing.Point(1510, 138);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(213, 24);
            this.idTextBox.TabIndex = 45;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(1363, 352);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(62, 18);
            this.quantityLabel.TabIndex = 44;
            this.quantityLabel.Text = "Quantity";
            // 
            // supplierlbl
            // 
            this.supplierlbl.AutoSize = true;
            this.supplierlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierlbl.Location = new System.Drawing.Point(1357, 300);
            this.supplierlbl.Name = "supplierlbl";
            this.supplierlbl.Size = new System.Drawing.Size(61, 18);
            this.supplierlbl.TabIndex = 43;
            this.supplierlbl.Text = "Supplier";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(1357, 248);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(83, 18);
            this.descriptionLabel.TabIndex = 42;
            this.descriptionLabel.Text = "Description";
            // 
            // prodnameLabel
            // 
            this.prodnameLabel.AutoSize = true;
            this.prodnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodnameLabel.Location = new System.Drawing.Point(1360, 197);
            this.prodnameLabel.Name = "prodnameLabel";
            this.prodnameLabel.Size = new System.Drawing.Size(104, 18);
            this.prodnameLabel.TabIndex = 41;
            this.prodnameLabel.Text = "Product Name";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.Location = new System.Drawing.Point(1363, 138);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(22, 18);
            this.idLabel.TabIndex = 40;
            this.idLabel.Text = "ID";
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.RosyBrown;
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Controls.Add(this.cancelbtn);
            this.loginPanel.Controls.Add(this.signInbtn);
            this.loginPanel.Controls.Add(this.passwordTextBox);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Controls.Add(this.usernameTextBox);
            this.loginPanel.Location = new System.Drawing.Point(384, 99);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(639, 413);
            this.loginPanel.TabIndex = 54;
            this.loginPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginPanel_MouseDown);
            this.loginPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.loginPanel_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(222, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 32);
            this.label3.TabIndex = 14;
            this.label3.Text = "AdminLogin";
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(392, 303);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(109, 66);
            this.cancelbtn.TabIndex = 13;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // signInbtn
            // 
            this.signInbtn.Location = new System.Drawing.Point(195, 303);
            this.signInbtn.Name = "signInbtn";
            this.signInbtn.Size = new System.Drawing.Size(109, 66);
            this.signInbtn.TabIndex = 12;
            this.signInbtn.Text = "Sign In";
            this.signInbtn.UseVisualStyleBackColor = true;
            this.signInbtn.Click += new System.EventHandler(this.signInbtn_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(228, 205);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(273, 22);
            this.passwordTextBox.TabIndex = 11;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(228, 132);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(273, 22);
            this.usernameTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(489, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 46);
            this.label4.TabIndex = 55;
            this.label4.Text = "Poppel";
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(1436, 566);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(99, 34);
            this.updatebtn.TabIndex = 57;
            this.updatebtn.Text = "UPDATE";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(1598, 566);
            this.addbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(125, 34);
            this.addbtn.TabIndex = 56;
            this.addbtn.Text = "INSERT";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(1270, 566);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(99, 34);
            this.deletebtn.TabIndex = 58;
            this.deletebtn.Text = "DELETE";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // adminlabel
            // 
            this.adminlabel.AutoSize = true;
            this.adminlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminlabel.Location = new System.Drawing.Point(1504, 83);
            this.adminlabel.Name = "adminlabel";
            this.adminlabel.Size = new System.Drawing.Size(176, 32);
            this.adminlabel.TabIndex = 15;
            this.adminlabel.Text = "AdminLogin";
            // 
            // loMode
            // 
            this.loMode.Location = new System.Drawing.Point(1729, 65);
            this.loMode.Name = "loMode";
            this.loMode.Size = new System.Drawing.Size(111, 47);
            this.loMode.TabIndex = 59;
            this.loMode.Text = "Logout Mode";
            this.loMode.UseVisualStyleBackColor = true;
            this.loMode.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // expiredProductsBtn
            // 
            this.expiredProductsBtn.Location = new System.Drawing.Point(958, 859);
            this.expiredProductsBtn.Name = "expiredProductsBtn";
            this.expiredProductsBtn.Size = new System.Drawing.Size(162, 47);
            this.expiredProductsBtn.TabIndex = 60;
            this.expiredProductsBtn.Text = "Generate Expired Products";
            this.expiredProductsBtn.UseVisualStyleBackColor = true;
            this.expiredProductsBtn.Click += new System.EventHandler(this.expiredProductsBtn_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1907, 924);
            this.Controls.Add(this.expiredProductsBtn);
            this.Controls.Add(this.loMode);
            this.Controls.Add(this.adminlabel);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.ExpiryTextBox);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.expiryLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.supplierTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.supplierlbl);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.prodnameLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.startOrderbtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.viewProductbtn);
            this.Controls.Add(this.viewCustomrbtn);
            this.Controls.Add(this.logoutbtn);
            this.Controls.Add(this.searchTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Button viewCustomrbtn;
        private System.Windows.Forms.Button viewProductbtn;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button startOrderbtn;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox ExpiryTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label expiryLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox supplierTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label supplierlbl;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label prodnameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button signInbtn;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Label adminlabel;
        private System.Windows.Forms.Button loMode;
        private System.Windows.Forms.Button expiredProductsBtn;
    }
}