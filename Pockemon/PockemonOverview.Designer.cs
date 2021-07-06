using System.Windows.Forms;

namespace Pockemon
{
    partial class PockemonOverview
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PockemonOverview));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.next_btn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.prev_btn = new System.Windows.Forms.Button();
            this.search_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.show_variations_btn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.p_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(381, 385);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(736, 95);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(52, 30);
            this.next_btn.TabIndex = 2;
            this.next_btn.Text = ">>";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            this.next_btn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.next_btn_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(409, 131);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(379, 304);
            this.listBox1.TabIndex = 3;
            // 
            // prev_btn
            // 
            this.prev_btn.Location = new System.Drawing.Point(678, 95);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(52, 30);
            this.prev_btn.TabIndex = 4;
            this.prev_btn.Text = "<<";
            this.prev_btn.UseVisualStyleBackColor = true;
            this.prev_btn.Click += new System.EventHandler(this.prev_btn_Click);
            this.prev_btn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.prev_btn_KeyPress);
            // 
            // search_box
            // 
            this.search_box.BackColor = System.Drawing.SystemColors.Window;
            this.search_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_box.Location = new System.Drawing.Point(465, 50);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(323, 21);
            this.search_box.TabIndex = 5;
            this.search_box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.search_box_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(406, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "z.B. id: 1, 33, 500;  name: ditto, squirtle  ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // show_variations_btn
            // 
            this.show_variations_btn.Location = new System.Drawing.Point(409, 95);
            this.show_variations_btn.Name = "show_variations_btn";
            this.show_variations_btn.Size = new System.Drawing.Size(123, 30);
            this.show_variations_btn.TabIndex = 9;
            this.show_variations_btn.Text = "Show variations";
            this.show_variations_btn.UseVisualStyleBackColor = true;
            this.show_variations_btn.Click += new System.EventHandler(this.show_variations_btn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(551, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(122, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // p_name
            // 
            this.p_name.AutoSize = true;
            this.p_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p_name.Location = new System.Drawing.Point(12, 8);
            this.p_name.Name = "p_name";
            this.p_name.Size = new System.Drawing.Size(0, 31);
            this.p_name.TabIndex = 11;
            // 
            // PockemonOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.p_name);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.show_variations_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search_box);
            this.Controls.Add(this.prev_btn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.next_btn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PockemonOverview";
            this.Text = "PockemonOverview";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button prev_btn;
        private System.Windows.Forms.TextBox search_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button show_variations_btn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Label p_name;
    }
}

