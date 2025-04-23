using System.Security.AccessControl;
using WMPLib;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootMedia;
        WindowsMediaPlayer explosion;

        PictureBox[] stars;
        int playerSpeed;

        int backgroundspeed;
        Random rnd;

        PictureBox[] munitions;
        int munitionSpeed;

        PictureBox[] enemies;
        int enemiSpeed;

        PictureBox[] enemiesMunition;
        int enemiesMunitionSpeed;

        int score;
        int level;
        int difficulty;
        bool pause;
        bool gameIsOver;
        Label scorelbl;
        Label levellbl;

        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pause = false;
            gameIsOver = false;
            score = 0;
            level = 1;
            difficulty = 9;

            backgroundspeed = 4;
            stars = new PictureBox[30];
            rnd = new Random();
            playerSpeed = 4;
            munitionSpeed = 10;
            enemiSpeed = 4;
            enemiesMunitionSpeed = 4;
            munitions = new PictureBox[5];
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            scorelbl = new Label();
            scorelbl.Location = new Point(10, 10);
            scorelbl.Size = new Size(200, 30);
            scorelbl.Text = "Score: 0"; 
            scorelbl.Font = new Font("Arial", 14, FontStyle.Bold); 
            scorelbl.ForeColor = Color.White; 
            this.Controls.Add(scorelbl);

            // Khởi tạo Label level
            levellbl = new Label();
            levellbl.Location = new Point(10, 40);
            levellbl.Size = new Size(200, 30);
            levellbl.Text = "Level: 1";
            levellbl.Font = new Font("Arial", 14, FontStyle.Bold);
            levellbl.ForeColor = Color.White;
            this.Controls.Add(levellbl);


            // Load images
            Image munition = Image.FromFile(@"asserts\munition.png");
            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8, 8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }

            Image enemi1 = Image.FromFile(@"asserts\E1.png");
            Image enemi2 = Image.FromFile(@"asserts\E2.png");
            Image enemi3 = Image.FromFile(@"asserts\E3.png");
            Image boss1 = Image.FromFile(@"asserts\Boss1.png");
            Image boss2 = Image.FromFile(@"asserts\Boss2.png");

            enemies = new PictureBox[10];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                enemies[i].BackColor = Color.Transparent;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, 50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemi1;
            enemies[2].Image = enemi1;
            enemies[3].Image = enemi2;
            enemies[4].Image = enemi2;
            enemies[5].Image = enemi2;
            enemies[6].Image = enemi3;
            enemies[7].Image = enemi3;
            enemies[8].Image = enemi3;
            enemies[9].Image = boss2;

            // create WMP
            gameMedia = new WindowsMediaPlayer();
            shootMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            // load all song
            gameMedia.URL = "songs\\ThemeSong.mp3";
            shootMedia.URL = "songs\\ShootSong.mp3";
            explosion.URL = "songs\\DefearSong.mp3";

            // Setup songs setting
            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 1;
            shootMedia.settings.volume = 10;
            explosion.settings.volume = 6;

            for (int i = 0; i < stars.Length; i++)
            {
                Color[] starColors = { Color.White, Color.Wheat, Color.LightGray, Color.LightYellow };
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(0, this.ClientSize.Width), rnd.Next(-100, this.ClientSize.Height));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = starColors[rnd.Next(starColors.Length)];
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = starColors[rnd.Next(starColors.Length)];
                }

                this.Controls.Add(stars[i]);
            }

            // Enemies Munition
            enemiesMunition = new PictureBox[10];

            for (int i = 0; i < enemiesMunition.Length; i++)
            {
                enemiesMunition[i] = new PictureBox();
                enemiesMunition[i].Size = new Size(2, 25);
                enemiesMunition[i].Visible = false;
                enemiesMunition[i].BackColor = Color.Yellow;
                int x = rnd.Next(0, 10);
                enemiesMunition[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesMunition[i]);
            }

            gameMedia.controls.play();
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < this.ClientSize.Width - 10)
            {
                Player.Left += playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top + Player.Height + playerSpeed <= this.ClientSize.Height)
            {
                Player.Top += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!gameIsOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        label.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        label.Location = new Point(this.Width / 2 - label.Width / 2, this.Height / 2 - label.Height / 2 - 50);
                        label.Text = "PAUSE";
                        label.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }
        }

        private void MoveMunitionTimer_Tick(object sender, EventArgs e)
        {
            shootMedia.controls.play();
            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0 && munitions[i].Visible)
                {
                    munitions[i].Top -= munitionSpeed;
                    Collision();
                }
                else
                {
                    int bulletX = Player.Left + (Player.Width / 2) - (munitions[i].Width / 2);
                    int bulletY = Player.Top - (i * 20);
                    munitions[i].Location = new Point(bulletX, bulletY);
                    munitions[i].Visible = true;
                }
            }
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiSpeed);
        }

        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds) || munitions[1].Bounds.IntersectsWith(enemies[i].Bounds) || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();

                    score += 1;
                    scorelbl.Text = (score < 10) ? "0" + score.ToString() : score.ToString();

                    if (score % 30 == 0)
                    {
                        level += 1;
                        levellbl.Text = (level < 10) ? "0" + level.ToString() : level.ToString();

                        if (enemiSpeed <= 10 && enemiesMunitionSpeed <= 10 && difficulty >= 0)
                        {
                            difficulty--;
                            enemiSpeed++;
                            enemiesMunitionSpeed++;
                        }

                        if (level == 30)
                        {
                            GameOver("Well Done");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }
                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void GameOver(string str)
        {
            label.Text = str;
            label.Location = new Point(this.Width / 2 - label.Width / 2, this.Height / 2 - label.Height - 60);
            Replay.Location = new Point(this.Width / 2 - Replay.Width / 2, this.Height / 2 - 50);
            Exit.Location = new Point(this.Width / 2 - Exit.Width / 2, this.Height / 2 + Replay.Height - 20);
            label.Visible = true;
            Replay.Visible = true;
            Exit.Visible = true;

            gameMedia.controls.stop();
            StopTimers();

            scorelbl.Text = "Score: " + score;
            levellbl.Text = "Level: " + level;
        }

        private void StopTimers()
        {
            MoveBgTimer.Stop();
            MoveEnemiesTimer.Stop();
            MoveMunitionTimer.Stop();
            EnemiesMunitionTimer.Stop();
        }

        private void StartTimers()
        {
            MoveBgTimer.Start();
            MoveEnemiesTimer.Start();
            MoveMunitionTimer.Start();
            EnemiesMunitionTimer.Start();
        }

        private void EnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < enemiesMunition.Length; i++)
            {
                if (enemiesMunition[i].Top < this.Height)
                {
                    enemiesMunition[i].Visible = true;
                    enemiesMunition[i].Top += enemiesMunitionSpeed;
                    CollisionWithEnemiesMunition();
                }
                else
                {
                    enemiesMunition[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    enemiesMunition[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }

        private void CollisionWithEnemiesMunition()
        {
            for (int i = 0; i < enemiesMunition.Length; i++)
            {
                if (enemiesMunition[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemiesMunition[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("GameOver");
                }
            }
        }

        private void Replay_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
