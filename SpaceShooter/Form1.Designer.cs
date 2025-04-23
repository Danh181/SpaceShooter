namespace SpaceShooter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MoveBgTimer = new System.Windows.Forms.Timer(components);
            Player = new PictureBox();
            LeftMoveTimer = new System.Windows.Forms.Timer(components);
            RightMoveTimer = new System.Windows.Forms.Timer(components);
            DownMoveTimer = new System.Windows.Forms.Timer(components);
            UpMoveTimer = new System.Windows.Forms.Timer(components);
            MoveMunitionTimer = new System.Windows.Forms.Timer(components);
            MoveEnemiesTimer = new System.Windows.Forms.Timer(components);
            EnemiesMunitionTimer = new System.Windows.Forms.Timer(components);
            Replay = new Button();
            Exit = new Button();
            label = new Label();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // MoveBgTimer
            // 
            MoveBgTimer.Enabled = true;
            MoveBgTimer.Interval = 20;
            MoveBgTimer.Tick += MoveBgTimer_Tick;
            // 
            // Player
            // 
            Player.Image = (Image)resources.GetObject("Player.Image");
            Player.Location = new Point(350, 550);
            Player.Name = "Player";
            Player.Size = new Size(84, 82);
            Player.SizeMode = PictureBoxSizeMode.Zoom;
            Player.TabIndex = 0;
            Player.TabStop = false;
            // 
            // LeftMoveTimer
            // 
            LeftMoveTimer.Interval = 5;
            LeftMoveTimer.Tick += LeftMoveTimer_Tick;
            // 
            // RightMoveTimer
            // 
            RightMoveTimer.Interval = 5;
            RightMoveTimer.Tick += RightMoveTimer_Tick;
            // 
            // DownMoveTimer
            // 
            DownMoveTimer.Interval = 5;
            DownMoveTimer.Tick += DownMoveTimer_Tick;
            // 
            // UpMoveTimer
            // 
            UpMoveTimer.Interval = 5;
            UpMoveTimer.Tick += UpMoveTimer_Tick;
            // 
            // MoveMunitionTimer
            // 
            MoveMunitionTimer.Enabled = true;
            MoveMunitionTimer.Interval = 10;
            MoveMunitionTimer.Tick += MoveMunitionTimer_Tick;
            // 
            // MoveEnemiesTimer
            // 
            MoveEnemiesTimer.Enabled = true;
            MoveEnemiesTimer.Tick += MoveEnemiesTimer_Tick;
            // 
            // EnemiesMunitionTimer
            // 
            EnemiesMunitionTimer.Enabled = true;
            EnemiesMunitionTimer.Interval = 20;
            EnemiesMunitionTimer.Tick += EnemiesMunitionTimer_Tick;
            // 
            // Replay
            // 
            Replay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Replay.Location = new Point(238, 233);
            Replay.Name = "Replay";
            Replay.Size = new Size(311, 83);
            Replay.TabIndex = 1;
            Replay.Text = "Replay";
            Replay.UseVisualStyleBackColor = true;
            Replay.Visible = false;
            Replay.Click += Replay_Click;
            // 
            // Exit
            // 
            Exit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Exit.Location = new Point(238, 379);
            Exit.Name = "Exit";
            Exit.Size = new Size(311, 87);
            Exit.TabIndex = 2;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Visible = false;
            Exit.Click += Exit_Click;
            // 
            // label
            // 
            label.Font = new Font("Times New Roman", 28F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label.ForeColor = SystemColors.Control;
            label.Location = new Point(238, 109);
            label.Name = "label";
            label.Size = new Size(311, 73);
            label.TabIndex = 3;
            label.Text = "label1";
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(778, 644);
            Controls.Add(label);
            Controls.Add(Exit);
            Controls.Add(Replay);
            Controls.Add(Player);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "SpaceShooter";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer MoveBgTimer;
        private PictureBox Player;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer MoveMunitionTimer;
        private System.Windows.Forms.Timer MoveEnemiesTimer;
        private System.Windows.Forms.Timer EnemiesMunitionTimer;
        private Button Replay;
        private Button Exit;
        private Label label;
    }
}
