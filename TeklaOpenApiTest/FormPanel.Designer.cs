namespace moldar
{
    partial class FormPanel
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtDx = new System.Windows.Forms.TextBox();
            this.txtDz = new System.Windows.Forms.TextBox();
            this.lblDx = new System.Windows.Forms.Label();
            this.lblDz = new System.Windows.Forms.Label();
            this.lblMuroSeleccionado = new System.Windows.Forms.Label();
            this.btnSeleccionarMuro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdIzq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddDer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Crear Diagonales";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDx
            // 
            this.txtDx.Location = new System.Drawing.Point(60, 76);
            this.txtDx.Name = "txtDx";
            this.txtDx.Size = new System.Drawing.Size(100, 20);
            this.txtDx.TabIndex = 1;
            this.txtDx.Leave += new System.EventHandler(this.txtDx_Leave);
            // 
            // txtDz
            // 
            this.txtDz.Location = new System.Drawing.Point(60, 102);
            this.txtDz.Name = "txtDz";
            this.txtDz.Size = new System.Drawing.Size(100, 20);
            this.txtDz.TabIndex = 2;
            this.txtDz.Leave += new System.EventHandler(this.txtDz_Leave);
            // 
            // lblDx
            // 
            this.lblDx.AutoSize = true;
            this.lblDx.Location = new System.Drawing.Point(12, 76);
            this.lblDx.Name = "lblDx";
            this.lblDx.Size = new System.Drawing.Size(42, 13);
            this.lblDx.TabIndex = 3;
            this.lblDx.Text = "Delta X";
            // 
            // lblDz
            // 
            this.lblDz.AutoSize = true;
            this.lblDz.Location = new System.Drawing.Point(12, 102);
            this.lblDz.Name = "lblDz";
            this.lblDz.Size = new System.Drawing.Size(42, 13);
            this.lblDz.TabIndex = 4;
            this.lblDz.Text = "Delta Y";
            // 
            // lblMuroSeleccionado
            // 
            this.lblMuroSeleccionado.AutoSize = true;
            this.lblMuroSeleccionado.Location = new System.Drawing.Point(111, 44);
            this.lblMuroSeleccionado.Name = "lblMuroSeleccionado";
            this.lblMuroSeleccionado.Size = new System.Drawing.Size(0, 13);
            this.lblMuroSeleccionado.TabIndex = 5;
            // 
            // btnSeleccionarMuro
            // 
            this.btnSeleccionarMuro.Location = new System.Drawing.Point(15, 12);
            this.btnSeleccionarMuro.Name = "btnSeleccionarMuro";
            this.btnSeleccionarMuro.Size = new System.Drawing.Size(145, 23);
            this.btnSeleccionarMuro.TabIndex = 6;
            this.btnSeleccionarMuro.Text = "Seleccionar Muro";
            this.btnSeleccionarMuro.UseVisualStyleBackColor = true;
            this.btnSeleccionarMuro.Click += new System.EventHandler(this.btnSeleccionarMuro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Muro Seleccionado:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Crear Placa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Adicional Izq";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtAdIzq
            // 
            this.txtAdIzq.Location = new System.Drawing.Point(267, 76);
            this.txtAdIzq.Name = "txtAdIzq";
            this.txtAdIzq.Size = new System.Drawing.Size(100, 20);
            this.txtAdIzq.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Adicional Der";
            // 
            // txtAddDer
            // 
            this.txtAddDer.Location = new System.Drawing.Point(267, 102);
            this.txtAddDer.Name = "txtAddDer";
            this.txtAddDer.Size = new System.Drawing.Size(100, 20);
            this.txtAddDer.TabIndex = 12;
            // 
            // FormPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 143);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddDer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAdIzq);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSeleccionarMuro);
            this.Controls.Add(this.lblMuroSeleccionado);
            this.Controls.Add(this.lblDz);
            this.Controls.Add(this.lblDx);
            this.Controls.Add(this.txtDz);
            this.Controls.Add(this.txtDx);
            this.Controls.Add(this.button1);
            this.Name = "FormPanel";
            this.Text = "Creacion de Diagonales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDx;
        private System.Windows.Forms.TextBox txtDz;
        private System.Windows.Forms.Label lblDx;
        private System.Windows.Forms.Label lblDz;
        private System.Windows.Forms.Label lblMuroSeleccionado;
        private System.Windows.Forms.Button btnSeleccionarMuro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdIzq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddDer;
    }
}

