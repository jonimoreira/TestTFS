namespace ONS.MaquinaInequacoes.WindowsFormApplication
{
    partial class MaquinaInequacoesServiceClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaquinaInequacoesServiceClient));
            this.txtBoxMemoriaCalculoEntrada = new System.Windows.Forms.TextBox();
            this.txtBoxListaDecisoes = new System.Windows.Forms.TextBox();
            this.txtBoxMemoriaCalculoSaida = new System.Windows.Forms.TextBox();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxMemoriaCalculoEntrada
            // 
            this.txtBoxMemoriaCalculoEntrada.Location = new System.Drawing.Point(449, 121);
            this.txtBoxMemoriaCalculoEntrada.Multiline = true;
            this.txtBoxMemoriaCalculoEntrada.Name = "txtBoxMemoriaCalculoEntrada";
            this.txtBoxMemoriaCalculoEntrada.Size = new System.Drawing.Size(220, 376);
            this.txtBoxMemoriaCalculoEntrada.TabIndex = 0;
            this.txtBoxMemoriaCalculoEntrada.Text = resources.GetString("txtBoxMemoriaCalculoEntrada.Text");
            // 
            // txtBoxListaDecisoes
            // 
            this.txtBoxListaDecisoes.Location = new System.Drawing.Point(12, 121);
            this.txtBoxListaDecisoes.Multiline = true;
            this.txtBoxListaDecisoes.Name = "txtBoxListaDecisoes";
            this.txtBoxListaDecisoes.Size = new System.Drawing.Size(421, 376);
            this.txtBoxListaDecisoes.TabIndex = 1;
            this.txtBoxListaDecisoes.Text = resources.GetString("txtBoxListaDecisoes.Text");
            // 
            // txtBoxMemoriaCalculoSaida
            // 
            this.txtBoxMemoriaCalculoSaida.Location = new System.Drawing.Point(688, 121);
            this.txtBoxMemoriaCalculoSaida.Multiline = true;
            this.txtBoxMemoriaCalculoSaida.Name = "txtBoxMemoriaCalculoSaida";
            this.txtBoxMemoriaCalculoSaida.Size = new System.Drawing.Size(218, 376);
            this.txtBoxMemoriaCalculoSaida.TabIndex = 2;
            // 
            // btnExecutar
            // 
            this.btnExecutar.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecutar.Location = new System.Drawing.Point(558, 507);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(110, 39);
            this.btnExecutar.TabIndex = 3;
            this.btnExecutar.Text = "Executar";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(796, 507);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(110, 39);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(897, 60);
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lista de decisões:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(445, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Memória de cáculo (entrada):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(685, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Memória de cáculo (saída):";
            // 
            // MaquinaInequacoesServiceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 553);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.txtBoxMemoriaCalculoSaida);
            this.Controls.Add(this.txtBoxListaDecisoes);
            this.Controls.Add(this.txtBoxMemoriaCalculoEntrada);
            this.Name = "MaquinaInequacoesServiceClient";
            this.Text = "Cliente Maquina Inequações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxMemoriaCalculoEntrada;
        private System.Windows.Forms.TextBox txtBoxListaDecisoes;
        private System.Windows.Forms.TextBox txtBoxMemoriaCalculoSaida;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

