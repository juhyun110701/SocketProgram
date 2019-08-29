namespace SocketMainMenu
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.clientBtn = new System.Windows.Forms.Button();
            this.serverBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clientBtn
            // 
            this.clientBtn.BackColor = System.Drawing.Color.Gold;
            this.clientBtn.Font = new System.Drawing.Font("나눔스퀘어 Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.clientBtn.Location = new System.Drawing.Point(12, 213);
            this.clientBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clientBtn.Name = "clientBtn";
            this.clientBtn.Size = new System.Drawing.Size(290, 159);
            this.clientBtn.TabIndex = 15;
            this.clientBtn.Text = "CLIENT";
            this.clientBtn.UseVisualStyleBackColor = false;
            this.clientBtn.Click += new System.EventHandler(this.ClientBtn_Click);
            // 
            // serverBtn
            // 
            this.serverBtn.BackColor = System.Drawing.Color.Gold;
            this.serverBtn.Font = new System.Drawing.Font("나눔스퀘어 Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.serverBtn.Location = new System.Drawing.Point(12, 47);
            this.serverBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serverBtn.Name = "serverBtn";
            this.serverBtn.Size = new System.Drawing.Size(290, 159);
            this.serverBtn.TabIndex = 14;
            this.serverBtn.Text = "SERVER";
            this.serverBtn.UseVisualStyleBackColor = false;
            this.serverBtn.Click += new System.EventHandler(this.ServerBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.BackColor = System.Drawing.Color.Gold;
            this.infoBtn.Font = new System.Drawing.Font("나눔스퀘어 Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.infoBtn.Location = new System.Drawing.Point(251, 14);
            this.infoBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(24, 29);
            this.infoBtn.TabIndex = 13;
            this.infoBtn.Text = "?";
            this.infoBtn.UseVisualStyleBackColor = false;
            this.infoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(32, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "SOCKET PROGRAM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(313, 391);
            this.Controls.Add(this.clientBtn);
            this.Controls.Add(this.serverBtn);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Socket Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clientBtn;
        private System.Windows.Forms.Button serverBtn;
        private System.Windows.Forms.Button infoBtn;
        private System.Windows.Forms.Label label1;
    }
}

