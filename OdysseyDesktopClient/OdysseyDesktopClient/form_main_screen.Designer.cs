namespace OdysseyDesktopClient
{
    partial class form_main_screen
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listview_data = new System.Windows.Forms.ListView();
            this.column_song_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_artista = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textbox_lyrics = new System.Windows.Forms.TextBox();
            this.label_lyrics = new System.Windows.Forms.Label();
            this.label_genre = new System.Windows.Forms.Label();
            this.label_year = new System.Windows.Forms.Label();
            this.label_album = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.label_artist = new System.Windows.Forms.Label();
            this.panel_biblioteca = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_timer_final = new System.Windows.Forms.Label();
            this.label_timer_inicial = new System.Windows.Forms.Label();
            this.panel_like = new System.Windows.Forms.Panel();
            this.button_like = new System.Windows.Forms.Button();
            this.label_like = new System.Windows.Forms.Label();
            this.label_like_counter = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button_sinc = new System.Windows.Forms.Button();
            this.button_play = new System.Windows.Forms.Button();
            this.button_previous = new System.Windows.Forms.Button();
            this.panel_comentario = new System.Windows.Forms.Panel();
            this.listbox_comentarios = new System.Windows.Forms.ListBox();
            this.label_comentario = new System.Windows.Forms.Label();
            this.textbox_comment = new System.Windows.Forms.TextBox();
            this.progressbar_song = new System.Windows.Forms.ProgressBar();
            this.button_next = new System.Windows.Forms.Button();
            this.panel_player = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_dislike_counter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label_song_reproductions = new System.Windows.Forms.Label();
            this.panel_complement = new System.Windows.Forms.Panel();
            this.button_id3_launcher = new System.Windows.Forms.Button();
            this.button_add_music = new System.Windows.Forms.Button();
            this.button_logo = new System.Windows.Forms.Button();
            this.label_profile_username = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.textbox_buscador_canciones = new System.Windows.Forms.TextBox();
            this.button_voice_searcher = new System.Windows.Forms.Button();
            this.combobox_user_searcher = new System.Windows.Forms.ComboBox();
            this.label_buscador_canciones = new System.Windows.Forms.Label();
            this.label_buscador_usuarios = new System.Windows.Forms.Label();
            this.panel_user = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_friends = new System.Windows.Forms.Button();
            this.button_friend_manager = new System.Windows.Forms.Button();
            this.button_cloud_library = new System.Windows.Forms.Button();
            this.button__personal_library = new System.Windows.Forms.Button();
            this.panel_biblioteca.SuspendLayout();
            this.panel_like.SuspendLayout();
            this.panel_comentario.SuspendLayout();
            this.panel_player.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_complement.SuspendLayout();
            this.panel_user.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listview_data
            // 
            this.listview_data.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listview_data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_song_id,
            this.column_artista,
            this.column_title,
            this.column_album,
            this.column_year,
            this.column_genre});
            this.listview_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_data.ForeColor = System.Drawing.Color.White;
            this.listview_data.FullRowSelect = true;
            this.listview_data.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listview_data.Location = new System.Drawing.Point(-1, 34);
            this.listview_data.MultiSelect = false;
            this.listview_data.Name = "listview_data";
            this.listview_data.Size = new System.Drawing.Size(829, 238);
            this.listview_data.TabIndex = 17;
            this.listview_data.UseCompatibleStateImageBehavior = false;
            this.listview_data.View = System.Windows.Forms.View.Details;
            this.listview_data.SelectedIndexChanged += new System.EventHandler(this.listview_data_SelectedIndexChanged);
            // 
            // column_song_id
            // 
            this.column_song_id.Text = "ID";
            this.column_song_id.Width = 70;
            // 
            // column_artista
            // 
            this.column_artista.Text = "Artista";
            this.column_artista.Width = 150;
            // 
            // column_title
            // 
            this.column_title.Text = "Título";
            this.column_title.Width = 150;
            // 
            // column_album
            // 
            this.column_album.Text = "Álbum";
            this.column_album.Width = 150;
            // 
            // column_year
            // 
            this.column_year.Text = "Año";
            this.column_year.Width = 150;
            // 
            // column_genre
            // 
            this.column_genre.Text = "Género";
            this.column_genre.Width = 150;
            // 
            // textbox_lyrics
            // 
            this.textbox_lyrics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textbox_lyrics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_lyrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textbox_lyrics.ForeColor = System.Drawing.Color.White;
            this.textbox_lyrics.Location = new System.Drawing.Point(827, 34);
            this.textbox_lyrics.Multiline = true;
            this.textbox_lyrics.Name = "textbox_lyrics";
            this.textbox_lyrics.Size = new System.Drawing.Size(294, 238);
            this.textbox_lyrics.TabIndex = 8;
            this.textbox_lyrics.TextChanged += new System.EventHandler(this.textbox_lyrics_TextChanged);
            // 
            // label_lyrics
            // 
            this.label_lyrics.AutoSize = true;
            this.label_lyrics.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lyrics.ForeColor = System.Drawing.SystemColors.Window;
            this.label_lyrics.Location = new System.Drawing.Point(1044, 36);
            this.label_lyrics.Name = "label_lyrics";
            this.label_lyrics.Size = new System.Drawing.Size(39, 15);
            this.label_lyrics.TabIndex = 7;
            this.label_lyrics.Text = "Letra";
            // 
            // label_genre
            // 
            this.label_genre.AutoSize = true;
            this.label_genre.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_genre.ForeColor = System.Drawing.SystemColors.Window;
            this.label_genre.Location = new System.Drawing.Point(666, 9);
            this.label_genre.Name = "label_genre";
            this.label_genre.Size = new System.Drawing.Size(50, 15);
            this.label_genre.TabIndex = 5;
            this.label_genre.Text = "Género";
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_year.ForeColor = System.Drawing.SystemColors.Window;
            this.label_year.Location = new System.Drawing.Point(523, 9);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(30, 15);
            this.label_year.TabIndex = 4;
            this.label_year.Text = "Año";
            // 
            // label_album
            // 
            this.label_album.AutoSize = true;
            this.label_album.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_album.ForeColor = System.Drawing.SystemColors.Window;
            this.label_album.Location = new System.Drawing.Point(372, 9);
            this.label_album.Name = "label_album";
            this.label_album.Size = new System.Drawing.Size(47, 15);
            this.label_album.TabIndex = 3;
            this.label_album.Text = "Álbum";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.SystemColors.Window;
            this.label_title.Location = new System.Drawing.Point(222, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(43, 15);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "Título";
            // 
            // label_artist
            // 
            this.label_artist.AutoSize = true;
            this.label_artist.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_artist.ForeColor = System.Drawing.SystemColors.Window;
            this.label_artist.Location = new System.Drawing.Point(71, 9);
            this.label_artist.Name = "label_artist";
            this.label_artist.Size = new System.Drawing.Size(48, 15);
            this.label_artist.TabIndex = 1;
            this.label_artist.Text = "Artista";
            // 
            // panel_biblioteca
            // 
            this.panel_biblioteca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_biblioteca.Controls.Add(this.label5);
            this.panel_biblioteca.Controls.Add(this.textbox_lyrics);
            this.panel_biblioteca.Controls.Add(this.listview_data);
            this.panel_biblioteca.Controls.Add(this.label_title);
            this.panel_biblioteca.Controls.Add(this.label_artist);
            this.panel_biblioteca.Controls.Add(this.label_album);
            this.panel_biblioteca.Controls.Add(this.label_genre);
            this.panel_biblioteca.Controls.Add(this.label_year);
            this.panel_biblioteca.Location = new System.Drawing.Point(188, 70);
            this.panel_biblioteca.Name = "panel_biblioteca";
            this.panel_biblioteca.Size = new System.Drawing.Size(1125, 273);
            this.panel_biblioteca.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(833, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Letra";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label_timer_final
            // 
            this.label_timer_final.AutoSize = true;
            this.label_timer_final.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_final.ForeColor = System.Drawing.SystemColors.Window;
            this.label_timer_final.Location = new System.Drawing.Point(1212, 17);
            this.label_timer_final.Name = "label_timer_final";
            this.label_timer_final.Size = new System.Drawing.Size(43, 15);
            this.label_timer_final.TabIndex = 6;
            this.label_timer_final.Text = "04:20";
            // 
            // label_timer_inicial
            // 
            this.label_timer_inicial.AutoSize = true;
            this.label_timer_inicial.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timer_inicial.ForeColor = System.Drawing.SystemColors.Window;
            this.label_timer_inicial.Location = new System.Drawing.Point(183, 15);
            this.label_timer_inicial.Name = "label_timer_inicial";
            this.label_timer_inicial.Size = new System.Drawing.Size(43, 15);
            this.label_timer_inicial.TabIndex = 5;
            this.label_timer_inicial.Text = "00:00";
            // 
            // panel_like
            // 
            this.panel_like.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_like.Controls.Add(this.button_like);
            this.panel_like.Controls.Add(this.label_like);
            this.panel_like.Controls.Add(this.label_like_counter);
            this.panel_like.Location = new System.Drawing.Point(9, 454);
            this.panel_like.Name = "panel_like";
            this.panel_like.Size = new System.Drawing.Size(110, 63);
            this.panel_like.TabIndex = 29;
            // 
            // button_like
            // 
            this.button_like.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_like.FlatAppearance.BorderSize = 0;
            this.button_like.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_like.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_like.ForeColor = System.Drawing.Color.White;
            this.button_like.Location = new System.Drawing.Point(16, 3);
            this.button_like.Name = "button_like";
            this.button_like.Size = new System.Drawing.Size(39, 33);
            this.button_like.TabIndex = 9;
            this.button_like.TabStop = false;
            this.button_like.Text = "☀";
            this.button_like.UseVisualStyleBackColor = false;
            // 
            // label_like
            // 
            this.label_like.AutoSize = true;
            this.label_like.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_like.ForeColor = System.Drawing.SystemColors.Window;
            this.label_like.Location = new System.Drawing.Point(13, 39);
            this.label_like.Name = "label_like";
            this.label_like.Size = new System.Drawing.Size(42, 15);
            this.label_like.TabIndex = 8;
            this.label_like.Text = "Like\'s";
            // 
            // label_like_counter
            // 
            this.label_like_counter.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_like_counter.ForeColor = System.Drawing.SystemColors.Window;
            this.label_like_counter.Location = new System.Drawing.Point(61, 20);
            this.label_like_counter.Name = "label_like_counter";
            this.label_like_counter.Size = new System.Drawing.Size(40, 33);
            this.label_like_counter.TabIndex = 7;
            this.label_like_counter.Text = "0";
            this.label_like_counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(50, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 34);
            this.button2.TabIndex = 12;
            this.button2.TabStop = false;
            this.button2.Text = "↓ ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_sinc
            // 
            this.button_sinc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_sinc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_sinc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sinc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sinc.ForeColor = System.Drawing.Color.White;
            this.button_sinc.Location = new System.Drawing.Point(8, 68);
            this.button_sinc.Name = "button_sinc";
            this.button_sinc.Size = new System.Drawing.Size(31, 34);
            this.button_sinc.TabIndex = 7;
            this.button_sinc.TabStop = false;
            this.button_sinc.Text = "↑ ";
            this.button_sinc.UseVisualStyleBackColor = false;
            // 
            // button_play
            // 
            this.button_play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_play.FlatAppearance.BorderSize = 0;
            this.button_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_play.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_play.ForeColor = System.Drawing.Color.White;
            this.button_play.Location = new System.Drawing.Point(62, -2);
            this.button_play.Name = "button_play";
            this.button_play.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_play.Size = new System.Drawing.Size(60, 46);
            this.button_play.TabIndex = 0;
            this.button_play.TabStop = false;
            this.button_play.Text = "►";
            this.button_play.UseVisualStyleBackColor = false;
            // 
            // button_previous
            // 
            this.button_previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_previous.FlatAppearance.BorderSize = 0;
            this.button_previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_previous.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_previous.ForeColor = System.Drawing.Color.White;
            this.button_previous.Location = new System.Drawing.Point(16, 4);
            this.button_previous.Name = "button_previous";
            this.button_previous.Size = new System.Drawing.Size(32, 34);
            this.button_previous.TabIndex = 1;
            this.button_previous.TabStop = false;
            this.button_previous.Text = "▼";
            this.button_previous.UseVisualStyleBackColor = false;
            // 
            // panel_comentario
            // 
            this.panel_comentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_comentario.Controls.Add(this.listbox_comentarios);
            this.panel_comentario.Controls.Add(this.label_comentario);
            this.panel_comentario.Controls.Add(this.textbox_comment);
            this.panel_comentario.Location = new System.Drawing.Point(242, 399);
            this.panel_comentario.Name = "panel_comentario";
            this.panel_comentario.Size = new System.Drawing.Size(1071, 118);
            this.panel_comentario.TabIndex = 28;
            // 
            // listbox_comentarios
            // 
            this.listbox_comentarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listbox_comentarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox_comentarios.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.listbox_comentarios.ForeColor = System.Drawing.Color.White;
            this.listbox_comentarios.FormattingEnabled = true;
            this.listbox_comentarios.ItemHeight = 15;
            this.listbox_comentarios.Location = new System.Drawing.Point(3, 54);
            this.listbox_comentarios.Name = "listbox_comentarios";
            this.listbox_comentarios.Size = new System.Drawing.Size(1026, 15);
            this.listbox_comentarios.TabIndex = 16;
            // 
            // label_comentario
            // 
            this.label_comentario.AutoSize = true;
            this.label_comentario.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comentario.ForeColor = System.Drawing.SystemColors.Window;
            this.label_comentario.Location = new System.Drawing.Point(3, 5);
            this.label_comentario.Name = "label_comentario";
            this.label_comentario.Size = new System.Drawing.Size(71, 15);
            this.label_comentario.TabIndex = 15;
            this.label_comentario.Text = "Comentario";
            // 
            // textbox_comment
            // 
            this.textbox_comment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textbox_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_comment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_comment.ForeColor = System.Drawing.Color.White;
            this.textbox_comment.Location = new System.Drawing.Point(3, 29);
            this.textbox_comment.Name = "textbox_comment";
            this.textbox_comment.Size = new System.Drawing.Size(1026, 23);
            this.textbox_comment.TabIndex = 0;
            this.textbox_comment.Text = "La mejor de RHCP";
            // 
            // progressbar_song
            // 
            this.progressbar_song.BackColor = System.Drawing.Color.DimGray;
            this.progressbar_song.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressbar_song.Location = new System.Drawing.Point(232, 19);
            this.progressbar_song.Name = "progressbar_song";
            this.progressbar_song.Size = new System.Drawing.Size(971, 11);
            this.progressbar_song.TabIndex = 4;
            this.progressbar_song.Value = 30;
            // 
            // button_next
            // 
            this.button_next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_next.FlatAppearance.BorderSize = 0;
            this.button_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_next.ForeColor = System.Drawing.Color.White;
            this.button_next.Location = new System.Drawing.Point(134, 4);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(31, 34);
            this.button_next.TabIndex = 2;
            this.button_next.TabStop = false;
            this.button_next.Text = "▲";
            this.button_next.UseVisualStyleBackColor = false;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // panel_player
            // 
            this.panel_player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_player.Controls.Add(this.label_timer_final);
            this.panel_player.Controls.Add(this.label_timer_inicial);
            this.panel_player.Controls.Add(this.button_next);
            this.panel_player.Controls.Add(this.button_play);
            this.panel_player.Controls.Add(this.button_previous);
            this.panel_player.Controls.Add(this.progressbar_song);
            this.panel_player.Location = new System.Drawing.Point(9, 349);
            this.panel_player.Name = "panel_player";
            this.panel_player.Size = new System.Drawing.Size(1305, 44);
            this.panel_player.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_dislike_counter);
            this.panel1.Location = new System.Drawing.Point(125, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 63);
            this.panel1.TabIndex = 30;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(16, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 33);
            this.button3.TabIndex = 9;
            this.button3.TabStop = false;
            this.button3.Text = "☁";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Like\'s";
            // 
            // label_dislike_counter
            // 
            this.label_dislike_counter.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dislike_counter.ForeColor = System.Drawing.SystemColors.Window;
            this.label_dislike_counter.Location = new System.Drawing.Point(61, 20);
            this.label_dislike_counter.Name = "label_dislike_counter";
            this.label_dislike_counter.Size = new System.Drawing.Size(40, 33);
            this.label_dislike_counter.TabIndex = 7;
            this.label_dislike_counter.Text = "0";
            this.label_dislike_counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label_song_reproductions);
            this.panel2.Location = new System.Drawing.Point(9, 400);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 47);
            this.panel2.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Reproducciones";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label_song_reproductions
            // 
            this.label_song_reproductions.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_song_reproductions.ForeColor = System.Drawing.SystemColors.Window;
            this.label_song_reproductions.Location = new System.Drawing.Point(154, 4);
            this.label_song_reproductions.Name = "label_song_reproductions";
            this.label_song_reproductions.Size = new System.Drawing.Size(68, 37);
            this.label_song_reproductions.TabIndex = 7;
            this.label_song_reproductions.Text = "0";
            this.label_song_reproductions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_complement
            // 
            this.panel_complement.Controls.Add(this.button_id3_launcher);
            this.panel_complement.Controls.Add(this.button2);
            this.panel_complement.Controls.Add(this.button_add_music);
            this.panel_complement.Controls.Add(this.button_logo);
            this.panel_complement.Controls.Add(this.button_sinc);
            this.panel_complement.Location = new System.Drawing.Point(9, 12);
            this.panel_complement.Name = "panel_complement";
            this.panel_complement.Size = new System.Drawing.Size(173, 161);
            this.panel_complement.TabIndex = 38;
            this.panel_complement.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_complement_Paint);
            // 
            // button_id3_launcher
            // 
            this.button_id3_launcher.BackColor = System.Drawing.Color.Purple;
            this.button_id3_launcher.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_id3_launcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_id3_launcher.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_id3_launcher.ForeColor = System.Drawing.Color.White;
            this.button_id3_launcher.Location = new System.Drawing.Point(132, 68);
            this.button_id3_launcher.Name = "button_id3_launcher";
            this.button_id3_launcher.Size = new System.Drawing.Size(29, 34);
            this.button_id3_launcher.TabIndex = 39;
            this.button_id3_launcher.TabStop = false;
            this.button_id3_launcher.Text = "#";
            this.button_id3_launcher.UseVisualStyleBackColor = false;
            this.button_id3_launcher.Click += new System.EventHandler(this.button_id3_launcher_Click);
            // 
            // button_add_music
            // 
            this.button_add_music.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_add_music.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_add_music.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_music.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add_music.ForeColor = System.Drawing.Color.White;
            this.button_add_music.Location = new System.Drawing.Point(92, 68);
            this.button_add_music.Name = "button_add_music";
            this.button_add_music.Size = new System.Drawing.Size(29, 34);
            this.button_add_music.TabIndex = 38;
            this.button_add_music.TabStop = false;
            this.button_add_music.Text = "+";
            this.button_add_music.UseVisualStyleBackColor = false;
            // 
            // button_logo
            // 
            this.button_logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_logo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_logo.FlatAppearance.BorderSize = 0;
            this.button_logo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_logo.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logo.ForeColor = System.Drawing.Color.White;
            this.button_logo.Location = new System.Drawing.Point(7, 16);
            this.button_logo.Name = "button_logo";
            this.button_logo.Size = new System.Drawing.Size(150, 39);
            this.button_logo.TabIndex = 37;
            this.button_logo.TabStop = false;
            this.button_logo.Text = "Odyssey";
            this.button_logo.UseVisualStyleBackColor = false;
            // 
            // label_profile_username
            // 
            this.label_profile_username.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_profile_username.ForeColor = System.Drawing.Color.White;
            this.label_profile_username.Location = new System.Drawing.Point(778, 10);
            this.label_profile_username.Name = "label_profile_username";
            this.label_profile_username.Size = new System.Drawing.Size(178, 30);
            this.label_profile_username.TabIndex = 4;
            this.label_profile_username.Text = "Le Putin Memen";
            this.label_profile_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(962, 14);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(101, 30);
            this.button11.TabIndex = 5;
            this.button11.TabStop = false;
            this.button11.Text = "Configuración";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(1069, 14);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(52, 30);
            this.button12.TabIndex = 6;
            this.button12.TabStop = false;
            this.button12.Text = "Salir";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // textbox_buscador_canciones
            // 
            this.textbox_buscador_canciones.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_buscador_canciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textbox_buscador_canciones.Location = new System.Drawing.Point(0, 23);
            this.textbox_buscador_canciones.MaxLength = 50;
            this.textbox_buscador_canciones.Name = "textbox_buscador_canciones";
            this.textbox_buscador_canciones.Size = new System.Drawing.Size(200, 23);
            this.textbox_buscador_canciones.TabIndex = 9;
            this.textbox_buscador_canciones.TabStop = false;
            // 
            // button_voice_searcher
            // 
            this.button_voice_searcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_voice_searcher.FlatAppearance.BorderSize = 0;
            this.button_voice_searcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_voice_searcher.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_voice_searcher.ForeColor = System.Drawing.Color.White;
            this.button_voice_searcher.Location = new System.Drawing.Point(206, 21);
            this.button_voice_searcher.Name = "button_voice_searcher";
            this.button_voice_searcher.Size = new System.Drawing.Size(27, 23);
            this.button_voice_searcher.TabIndex = 10;
            this.button_voice_searcher.TabStop = false;
            this.button_voice_searcher.Text = "⛬";
            this.button_voice_searcher.UseVisualStyleBackColor = false;
            // 
            // combobox_user_searcher
            // 
            this.combobox_user_searcher.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.combobox_user_searcher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.combobox_user_searcher.FormattingEnabled = true;
            this.combobox_user_searcher.Location = new System.Drawing.Point(240, 23);
            this.combobox_user_searcher.Name = "combobox_user_searcher";
            this.combobox_user_searcher.Size = new System.Drawing.Size(216, 23);
            this.combobox_user_searcher.TabIndex = 11;
            this.combobox_user_searcher.TextChanged += new System.EventHandler(this.combobox_user_searcher_TextChanged);
            // 
            // label_buscador_canciones
            // 
            this.label_buscador_canciones.AutoSize = true;
            this.label_buscador_canciones.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_buscador_canciones.ForeColor = System.Drawing.SystemColors.Window;
            this.label_buscador_canciones.Location = new System.Drawing.Point(0, 7);
            this.label_buscador_canciones.Name = "label_buscador_canciones";
            this.label_buscador_canciones.Size = new System.Drawing.Size(113, 12);
            this.label_buscador_canciones.TabIndex = 12;
            this.label_buscador_canciones.Text = "Buscador De Canciones";
            // 
            // label_buscador_usuarios
            // 
            this.label_buscador_usuarios.AutoSize = true;
            this.label_buscador_usuarios.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_buscador_usuarios.ForeColor = System.Drawing.SystemColors.Window;
            this.label_buscador_usuarios.Location = new System.Drawing.Point(238, 8);
            this.label_buscador_usuarios.Name = "label_buscador_usuarios";
            this.label_buscador_usuarios.Size = new System.Drawing.Size(108, 12);
            this.label_buscador_usuarios.TabIndex = 13;
            this.label_buscador_usuarios.Text = "Buscador De Usuarios";
            // 
            // panel_user
            // 
            this.panel_user.Controls.Add(this.label_buscador_usuarios);
            this.panel_user.Controls.Add(this.label_buscador_canciones);
            this.panel_user.Controls.Add(this.combobox_user_searcher);
            this.panel_user.Controls.Add(this.button_voice_searcher);
            this.panel_user.Controls.Add(this.textbox_buscador_canciones);
            this.panel_user.Controls.Add(this.button12);
            this.panel_user.Controls.Add(this.button11);
            this.panel_user.Controls.Add(this.label_profile_username);
            this.panel_user.Location = new System.Drawing.Point(186, 12);
            this.panel_user.Name = "panel_user";
            this.panel_user.Size = new System.Drawing.Size(1124, 48);
            this.panel_user.TabIndex = 25;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_friends);
            this.panel3.Controls.Add(this.button_friend_manager);
            this.panel3.Controls.Add(this.button_cloud_library);
            this.panel3.Controls.Add(this.button__personal_library);
            this.panel3.Location = new System.Drawing.Point(9, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 163);
            this.panel3.TabIndex = 39;
            // 
            // button_friends
            // 
            this.button_friends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_friends.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_friends.FlatAppearance.BorderSize = 0;
            this.button_friends.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_friends.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_friends.ForeColor = System.Drawing.Color.White;
            this.button_friends.Location = new System.Drawing.Point(7, 123);
            this.button_friends.Name = "button_friends";
            this.button_friends.Size = new System.Drawing.Size(150, 34);
            this.button_friends.TabIndex = 44;
            this.button_friends.TabStop = false;
            this.button_friends.Text = "Compartir";
            this.button_friends.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_friends.UseVisualStyleBackColor = false;
            // 
            // button_friend_manager
            // 
            this.button_friend_manager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_friend_manager.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_friend_manager.FlatAppearance.BorderSize = 0;
            this.button_friend_manager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_friend_manager.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_friend_manager.ForeColor = System.Drawing.Color.White;
            this.button_friend_manager.Location = new System.Drawing.Point(6, 83);
            this.button_friend_manager.Name = "button_friend_manager";
            this.button_friend_manager.Size = new System.Drawing.Size(150, 34);
            this.button_friend_manager.TabIndex = 43;
            this.button_friend_manager.TabStop = false;
            this.button_friend_manager.Text = "Descubrir";
            this.button_friend_manager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_friend_manager.UseVisualStyleBackColor = false;
            this.button_friend_manager.Click += new System.EventHandler(this.button_friend_manager_Click);
            // 
            // button_cloud_library
            // 
            this.button_cloud_library.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_cloud_library.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_cloud_library.FlatAppearance.BorderSize = 0;
            this.button_cloud_library.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cloud_library.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cloud_library.ForeColor = System.Drawing.Color.White;
            this.button_cloud_library.Location = new System.Drawing.Point(6, 3);
            this.button_cloud_library.Name = "button_cloud_library";
            this.button_cloud_library.Size = new System.Drawing.Size(149, 34);
            this.button_cloud_library.TabIndex = 42;
            this.button_cloud_library.TabStop = false;
            this.button_cloud_library.Text = "Biblioteca Cloud";
            this.button_cloud_library.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_cloud_library.UseVisualStyleBackColor = false;
            this.button_cloud_library.Click += new System.EventHandler(this.button_cloud_library_Click);
            // 
            // button__personal_library
            // 
            this.button__personal_library.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button__personal_library.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button__personal_library.FlatAppearance.BorderSize = 0;
            this.button__personal_library.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button__personal_library.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button__personal_library.ForeColor = System.Drawing.Color.White;
            this.button__personal_library.Location = new System.Drawing.Point(6, 43);
            this.button__personal_library.Name = "button__personal_library";
            this.button__personal_library.Size = new System.Drawing.Size(149, 34);
            this.button__personal_library.TabIndex = 41;
            this.button__personal_library.TabStop = false;
            this.button__personal_library.Text = "Biblioteca Personal";
            this.button__personal_library.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button__personal_library.UseVisualStyleBackColor = false;
            // 
            // form_main_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1326, 527);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel_complement);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_user);
            this.Controls.Add(this.label_lyrics);
            this.Controls.Add(this.panel_biblioteca);
            this.Controls.Add(this.panel_like);
            this.Controls.Add(this.panel_comentario);
            this.Controls.Add(this.panel_player);
            this.Name = "form_main_screen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.form_main_screen_Load);
            this.panel_biblioteca.ResumeLayout(false);
            this.panel_biblioteca.PerformLayout();
            this.panel_like.ResumeLayout(false);
            this.panel_like.PerformLayout();
            this.panel_comentario.ResumeLayout(false);
            this.panel_comentario.PerformLayout();
            this.panel_player.ResumeLayout(false);
            this.panel_player.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel_complement.ResumeLayout(false);
            this.panel_user.ResumeLayout(false);
            this.panel_user.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listview_data;
        private System.Windows.Forms.ColumnHeader column_artista;
        private System.Windows.Forms.ColumnHeader column_title;
        private System.Windows.Forms.ColumnHeader column_album;
        private System.Windows.Forms.ColumnHeader column_year;
        private System.Windows.Forms.TextBox textbox_lyrics;
        private System.Windows.Forms.Label label_lyrics;
        private System.Windows.Forms.Label label_genre;
        private System.Windows.Forms.Label label_year;
        private System.Windows.Forms.Label label_album;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_artist;
        private System.Windows.Forms.Panel panel_biblioteca;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_timer_final;
        private System.Windows.Forms.Label label_timer_inicial;
        private System.Windows.Forms.Panel panel_like;
        private System.Windows.Forms.Button button_like;
        private System.Windows.Forms.Label label_like;
        private System.Windows.Forms.Label label_like_counter;
        private System.Windows.Forms.Button button_sinc;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Button button_previous;
        private System.Windows.Forms.Panel panel_comentario;
        private System.Windows.Forms.ListBox listbox_comentarios;
        private System.Windows.Forms.Label label_comentario;
        private System.Windows.Forms.TextBox textbox_comment;
        private System.Windows.Forms.ProgressBar progressbar_song;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Panel panel_player;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader column_song_id;
        private System.Windows.Forms.ColumnHeader column_genre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_dislike_counter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_song_reproductions;
        private System.Windows.Forms.Panel panel_complement;
        private System.Windows.Forms.Button button_id3_launcher;
        private System.Windows.Forms.Button button_add_music;
        private System.Windows.Forms.Button button_logo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_profile_username;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textbox_buscador_canciones;
        private System.Windows.Forms.Button button_voice_searcher;
        private System.Windows.Forms.ComboBox combobox_user_searcher;
        private System.Windows.Forms.Label label_buscador_canciones;
        private System.Windows.Forms.Label label_buscador_usuarios;
        private System.Windows.Forms.Panel panel_user;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_friends;
        private System.Windows.Forms.Button button_friend_manager;
        private System.Windows.Forms.Button button_cloud_library;
        private System.Windows.Forms.Button button__personal_library;
    }
}

