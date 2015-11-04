namespace OdysseyDesktopClient
{
    partial class form_friend_manager
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
            this.button2 = new System.Windows.Forms.Button();
            this.listbox_users = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_friend = new System.Windows.Forms.Button();
            this.button_decline = new System.Windows.Forms.Button();
            this.button_accept = new System.Windows.Forms.Button();
            this.button_view_profile = new System.Windows.Forms.Button();
            this.button_friend_request = new System.Windows.Forms.Button();
            this.button_suggestion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(445, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 33);
            this.button2.TabIndex = 30;
            this.button2.TabStop = false;
            this.button2.Text = "Cerrar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // listbox_users
            // 
            this.listbox_users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listbox_users.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listbox_users.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox_users.ForeColor = System.Drawing.Color.White;
            this.listbox_users.FormattingEnabled = true;
            this.listbox_users.ItemHeight = 20;
            this.listbox_users.Location = new System.Drawing.Point(189, 12);
            this.listbox_users.Name = "listbox_users";
            this.listbox_users.Size = new System.Drawing.Size(250, 282);
            this.listbox_users.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(445, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 329);
            this.panel3.TabIndex = 40;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Nombre de Usuario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nivel de Popularidad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-1, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Clasificación de Biblioteca";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_view_profile);
            this.panel1.Controls.Add(this.button_accept);
            this.panel1.Controls.Add(this.button_decline);
            this.panel1.Location = new System.Drawing.Point(189, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 41);
            this.panel1.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_suggestion);
            this.panel2.Controls.Add(this.button_friend_request);
            this.panel2.Controls.Add(this.button_friend);
            this.panel2.Location = new System.Drawing.Point(10, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 329);
            this.panel2.TabIndex = 42;
            // 
            // button_friend
            // 
            this.button_friend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_friend.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_friend.FlatAppearance.BorderSize = 0;
            this.button_friend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_friend.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_friend.ForeColor = System.Drawing.Color.White;
            this.button_friend.Location = new System.Drawing.Point(1, 16);
            this.button_friend.Name = "button_friend";
            this.button_friend.Size = new System.Drawing.Size(167, 34);
            this.button_friend.TabIndex = 42;
            this.button_friend.TabStop = false;
            this.button_friend.Text = "Amigos";
            this.button_friend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_friend.UseVisualStyleBackColor = false;
            this.button_friend.Click += new System.EventHandler(this.button_friend_Click);
            // 
            // button_decline
            // 
            this.button_decline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_decline.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_decline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_decline.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_decline.ForeColor = System.Drawing.Color.White;
            this.button_decline.Location = new System.Drawing.Point(0, 0);
            this.button_decline.Name = "button_decline";
            this.button_decline.Size = new System.Drawing.Size(78, 41);
            this.button_decline.TabIndex = 47;
            this.button_decline.TabStop = false;
            this.button_decline.Text = "✕";
            this.button_decline.UseVisualStyleBackColor = false;
            // 
            // button_accept
            // 
            this.button_accept.BackColor = System.Drawing.Color.Green;
            this.button_accept.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_accept.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_accept.ForeColor = System.Drawing.Color.Transparent;
            this.button_accept.Location = new System.Drawing.Point(172, 0);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(78, 41);
            this.button_accept.TabIndex = 48;
            this.button_accept.TabStop = false;
            this.button_accept.Text = "✓";
            this.button_accept.UseVisualStyleBackColor = false;
            // 
            // button_view_profile
            // 
            this.button_view_profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button_view_profile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_view_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_view_profile.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_view_profile.ForeColor = System.Drawing.Color.White;
            this.button_view_profile.Location = new System.Drawing.Point(84, 0);
            this.button_view_profile.Name = "button_view_profile";
            this.button_view_profile.Size = new System.Drawing.Size(82, 41);
            this.button_view_profile.TabIndex = 49;
            this.button_view_profile.TabStop = false;
            this.button_view_profile.Text = "〄";
            this.button_view_profile.UseVisualStyleBackColor = false;
            // 
            // button_friend_request
            // 
            this.button_friend_request.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_friend_request.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_friend_request.FlatAppearance.BorderSize = 0;
            this.button_friend_request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_friend_request.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_friend_request.ForeColor = System.Drawing.Color.White;
            this.button_friend_request.Location = new System.Drawing.Point(1, 61);
            this.button_friend_request.Name = "button_friend_request";
            this.button_friend_request.Size = new System.Drawing.Size(167, 34);
            this.button_friend_request.TabIndex = 43;
            this.button_friend_request.TabStop = false;
            this.button_friend_request.Text = "Solicitudes Pendientes";
            this.button_friend_request.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_friend_request.UseVisualStyleBackColor = false;
            this.button_friend_request.Click += new System.EventHandler(this.button_friend_request_Click);
            // 
            // button_suggestion
            // 
            this.button_suggestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_suggestion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_suggestion.FlatAppearance.BorderSize = 0;
            this.button_suggestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_suggestion.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_suggestion.ForeColor = System.Drawing.Color.White;
            this.button_suggestion.Location = new System.Drawing.Point(1, 108);
            this.button_suggestion.Name = "button_suggestion";
            this.button_suggestion.Size = new System.Drawing.Size(167, 34);
            this.button_suggestion.TabIndex = 44;
            this.button_suggestion.TabStop = false;
            this.button_suggestion.Text = "Recomendaciones";
            this.button_suggestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_suggestion.UseVisualStyleBackColor = false;
            this.button_suggestion.Click += new System.EventHandler(this.button_suggestion_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 27);
            this.label4.TabIndex = 50;
            this.label4.Text = "Nombre de Usuario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 27);
            this.label5.TabIndex = 51;
            this.label5.Text = "Nombre de Usuario";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 27);
            this.label6.TabIndex = 52;
            this.label6.Text = "Nombre de Usuario";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(-1, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 27);
            this.label7.TabIndex = 54;
            this.label7.Text = "Nombre de Usuario";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(-1, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Clasificación de Biblioteca";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // form_friend_manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(643, 407);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.listbox_users);
            this.Controls.Add(this.button2);
            this.Name = "form_friend_manager";
            this.Text = "<z";
            this.Load += new System.EventHandler(this.form_friend_manager_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listbox_users;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_friend;
        private System.Windows.Forms.Button button_decline;
        private System.Windows.Forms.Button button_view_profile;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Button button_suggestion;
        private System.Windows.Forms.Button button_friend_request;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}