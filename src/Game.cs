using BoardGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace BoardGame {
    public partial class Game : Form {
        static Board board = new Board(30, 30);
        public Button[,] btnGrid = new Button[board.Row, board.Col];
        Random random = new Random();
        static string connectionString = BoardGame.Properties.Settings.Default.BoardgameConnectionString;
        static int total = 0;
        static int tempTopScore = 0;

        public Game() {
            InitializeComponent();
        }
        private void populateGrid() {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try {
                if (sqlConnection.State == ConnectionState.Closed) {
                    sqlConnection.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users WHERE username = @username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", BoardGame.Properties.Settings.Default.UserName);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader rdr = sqlCommand.ExecuteReader();

                while (rdr.Read()) {
                    this.txtBoxBestScore.Text = rdr["best_score"].ToString();
                }

                rdr.Close();

                tempTopScore = Int32.Parse(this.txtBoxBestScore.Text);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            var redColor = BoardGame.Properties.Settings.Default.ColorRed;
            var greenColor = BoardGame.Properties.Settings.Default.ColorGreen;
            var blueColor = BoardGame.Properties.Settings.Default.ColorBlue;
            var squareShape = BoardGame.Properties.Settings.Default.ShapeSquare;
            var triangleShape = BoardGame.Properties.Settings.Default.ShapeTriangle;
            var circleShape = BoardGame.Properties.Settings.Default.ShapeCircle;
            var difLevel = BoardGame.Properties.Settings.Default.DifLevel;
            if (difLevel.Equals("Easy")) {
                int size = 15;
                board = new Board(size, size);
            } else if (difLevel.Equals("Medium")) {
                int size = 9;
                board = new Board(size, size);
            } else if (difLevel.Equals("Hard")) {
                int size = 6;
                board = new Board(size, size);
            } else if (difLevel.Equals("Custom")) {
                var row = BoardGame.Properties.Settings.Default.BorderX;
                var col = BoardGame.Properties.Settings.Default.BorderY;
                board = new Board(Int32.Parse(row), Int32.Parse(col));
            }
            int btnSize = GameBoard.Width / board.Row;
            GameBoard.Width = GameBoard.Height;
            int shapes = 1;
            if (triangleShape) shapes++;
            if (circleShape) shapes++;
            if (squareShape) shapes++;
            int shapeSize = random.Next(1, shapes);
            for (int i = 0; i < board.Row; i++) {
                for (int j = 0; j < board.Col; j++) {
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Height = btnSize;
                    btnGrid[i, j].Width = btnSize;
                    btnGrid[i, j].Click += Grid_Button_Click;
                    GameBoard.Controls.Add(btnGrid[i, j]);
                    btnGrid[i, j].Location = new Point(i * btnSize, j * btnSize);
                    btnGrid[i, j].Tag = new Point(i, j);
                }
            }

            for (int i = 0; i < 3; i++)
                filler();
        }
        static int x = 0;
        static int y = 0;
        static int x1 = 0;
        static int y1 = 0;
        static Cell currentCell;
        int clickCounter = 0;

        private void Grid_Button_Click(object sender, EventArgs e) {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            clickCounter++;

            if (clickCounter % 2 == 1) {
                x = location.X; y = location.Y; currentCell = board.theGrid[x, y]; /*timer1.Start(); */
                btnGrid[x, y].BackColor = Color.Black;
            }
            if (clickCounter % 2 == 0) {
                if (btnGrid[currentCell.RowNumber, currentCell.ColNumber].Image == null) {
                    btnGrid[x, y].BackColor = Color.SkyBlue;
                    return;
                }
                x1 = location.X; y1 = location.Y; currentCell = board.theGrid[x1, y1]; /*timer1.Stop()*/;
                btnGrid[x, y].BackColor = Color.SkyBlue;
                if (btnGrid[x1, y1].Image == null) {
                    btnGrid[x1, y1].Image = btnGrid[x, y].Image;
                    btnGrid[x, y].Image = null;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..//..//sounds//Movement.wav");
                    player.Play();
                } else {
                    return;
                }

                if (total != board.Row * board.Col) {
                    for (int i = 0; i < 3; i++) {
                        filler();
                        if (total == board.Row * board.Col) {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..//..//sounds//GameOver.wav");
                            player.Play();

                            if (Int32.Parse(this.txtScore.Text) > tempTopScore) {
                                MessageBox.Show("You lose! New Best Score: " + txtScore.Text);
                            } else {
                                MessageBox.Show("You lose! Your score is : " + txtScore.Text);
                            }

                            SqlConnection sqlConnection = new SqlConnection(connectionString);
                            try {
                                if (sqlConnection.State == ConnectionState.Closed) {
                                    sqlConnection.Open();
                                }

                                SqlCommand sqlCommand = new SqlCommand("UPDATE Users SET best_score = @bestscore WHERE username = @username", sqlConnection);
                                sqlCommand.Parameters.AddWithValue("@username", BoardGame.Properties.Settings.Default.UserName);
                                sqlCommand.Parameters.AddWithValue("@bestscore", txtBoxBestScore.Text);
                                sqlCommand.ExecuteNonQuery();
                                sqlConnection.Close();

                            }
                            catch (Exception ex) {
                                MessageBox.Show(ex.Message);
                            }
                            this.Hide();
                            break;
                        }
                    }
                }
            }
            //timer1.Interval = 100;
        }

        private void Game_Load(object sender, EventArgs e) {
            populateGrid();
        }
        public void entityRemover() {
            int counter = 0;
            for (int i = 0; i < board.Row; i++) {
                for (int j = 0; j < board.Col; j++) {
                    if (j + 4 != board.Row && j + 4 < board.Row) {
                        if (btnGrid[i, j].Image != null && btnGrid[i, j + 1].Image != null && btnGrid[i, j + 2].Image != null && btnGrid[i, j + 3].Image != null && btnGrid[i, j + 4].Image != null) {
                            if (btnGrid[i, j].Image.Tag == btnGrid[i, j + 1].Image.Tag && btnGrid[i, j + 1].Image.Tag == btnGrid[i, j + 2].Image.Tag && btnGrid[i, j + 2].Image.Tag == btnGrid[i, j + 3].Image.Tag && btnGrid[i, j + 3].Image.Tag == btnGrid[i, j + 4].Image.Tag) {
                                btnGrid[i, j].Image = null;
                                btnGrid[i, j + 1].Image = null;
                                btnGrid[i, j + 2].Image = null;
                                btnGrid[i, j + 3].Image = null;
                                btnGrid[i, j + 4].Image = null;
                                total -= 5;
                                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..//..//sounds//Success.wav");
                                player.Play();
                                counter++;
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < board.Row; i++) {
                for (int j = 0; j < board.Col; j++) {
                    if (i + 4 != board.Row && i + 4 < board.Row) {
                        if (btnGrid[i, j].Image != null && btnGrid[i + 1, j].Image != null && btnGrid[i + 2, j].Image != null && btnGrid[i + 3, j].Image != null && btnGrid[i + 4, j].Image != null) {
                            if (btnGrid[i, j].Image.Tag == btnGrid[i + 1, j].Image.Tag && btnGrid[i + 1, j].Image.Tag == btnGrid[i + 2, j].Image.Tag && btnGrid[i + 2, j].Image.Tag == btnGrid[i + 3, j].Image.Tag && btnGrid[i + 3, j].Image.Tag == btnGrid[i + 4, j].Image.Tag) {
                                btnGrid[i, j].Image = null;
                                btnGrid[i + 1, j].Image = null;
                                btnGrid[i + 2, j].Image = null;
                                btnGrid[i + 3, j].Image = null;
                                btnGrid[i + 4, j].Image = null;
                                total -= 5;
                                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..//..//sounds//Success.wav");
                                player.Play();
                                counter++;
                                break;
                            }
                        }
                    }
                }
            }
            string difLevel = BoardGame.Properties.Settings.Default.DifLevel;
            if (difLevel.Equals("Easy")) {
                this.txtScore.Text = (Int32.Parse(this.txtScore.Text) + counter).ToString();
            } else if (difLevel.Equals("Medium")) {
                this.txtScore.Text = (Int32.Parse(this.txtScore.Text) + counter * 3).ToString();
            } else if (difLevel.Equals("Hard")) {
                this.txtScore.Text = (Int32.Parse(this.txtScore.Text) + counter * 5).ToString();
            }
            else if (difLevel.Equals("Custom"))
            {
                this.txtScore.Text = (Int32.Parse(this.txtScore.Text) + counter * 2).ToString();
            }

            if (Int32.Parse(this.txtScore.Text) > Int32.Parse(this.txtBoxBestScore.Text)) {
                this.txtBoxBestScore.Text = this.txtScore.Text;
            }

        }

        public List<string> colorRandomiser() {
            var redColor = BoardGame.Properties.Settings.Default.ColorRed;
            var greenColor = BoardGame.Properties.Settings.Default.ColorGreen;
            var blueColor = BoardGame.Properties.Settings.Default.ColorBlue;
            List<string> colors = new List<string>();

            if (redColor && greenColor && blueColor) {
                colors.Add("red");
                colors.Add("green");
                colors.Add("blue");
            } else if (!redColor && greenColor && blueColor) {
                colors.Add("green");
                colors.Add("blue");
            } else if (redColor && !greenColor && blueColor) {
                colors.Add("red");
                colors.Add("blue");
            } else if (redColor && greenColor && !blueColor) {
                colors.Add("red");
                colors.Add("green");
            } else if (!redColor && !greenColor && blueColor) {
                colors.Add("blue");
            } else if (redColor && !greenColor && !blueColor) {
                colors.Add("red");
            } else if (!redColor && greenColor && !blueColor) {
                colors.Add("green");
            }

            return colors;
        }


        public void filler() {
            var squareShape = BoardGame.Properties.Settings.Default.ShapeSquare;
            var triangleShape = BoardGame.Properties.Settings.Default.ShapeTriangle;
            var circleShape = BoardGame.Properties.Settings.Default.ShapeCircle;

            int row = 0;
            int col = 0;
            do {
                row = random.Next(0, board.Row);
                col = random.Next(0, board.Col);
            }
            while (btnGrid[row, col].Image != null); // Spawning every time.

            int randomShape = 0;
            List<string> randomColor = colorRandomiser();
            int index = random.Next(randomColor.Count);

            if (squareShape && triangleShape && circleShape) {
                randomShape = random.Next(0, 3);
                if (randomShape == 0) { // Square
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedSquare;
                        btnGrid[row, col].Image.Tag = "RedSquare";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueSquare;
                        btnGrid[row, col].Image.Tag = "BlueSquare";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenSquare;
                        btnGrid[row, col].Image.Tag = "GreenSquare";
                        total++;
                    }
                } else if (randomShape == 1) { // Triangle
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedTriangle;
                        btnGrid[row, col].Image.Tag = "RedTriangle";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueTriangle;
                        btnGrid[row, col].Image.Tag = "BlueTriangle";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenTriangle;
                        btnGrid[row, col].Image.Tag = "GreenTriangle";
                        total++;
                    }
                } else { // Circle
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedCircle;
                        btnGrid[row, col].Image.Tag = "RedCircle";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueCircle;
                        btnGrid[row, col].Image.Tag = "BlueCircle";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenCircle;
                        btnGrid[row, col].Image.Tag = "GreenCircle";
                        total++;
                    }
                }
                entityRemover();

            } else if (!squareShape && triangleShape && circleShape) {
                randomShape = random.Next(0, 2);
                if (randomShape == 0) {
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedTriangle;
                        btnGrid[row, col].Image.Tag = "RedTriangle";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueTriangle;
                        btnGrid[row, col].Image.Tag = "BlueTriangle";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenTriangle;
                        btnGrid[row, col].Image.Tag = "GreenTriangle";
                        total++;
                    }
                } else {
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedCircle;
                        btnGrid[row, col].Image.Tag = "RedCircle";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueCircle;
                        btnGrid[row, col].Image.Tag = "BlueCircle";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenCircle;
                        btnGrid[row, col].Image.Tag = "GreenCircle";
                        total++;
                    }
                }

            } else if (squareShape && !triangleShape && circleShape) {
                randomShape = random.Next(0, 2);
                if (randomShape == 0) {
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedSquare;
                        btnGrid[row, col].Image.Tag = "RedSquare";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueSquare;
                        btnGrid[row, col].Image.Tag = "BlueSquare";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenSquare;
                        btnGrid[row, col].Image.Tag = "GreenSquare";
                        total++;
                    }
                } else {
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedCircle;
                        btnGrid[row, col].Image.Tag = "RedCircle";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueCircle;
                        btnGrid[row, col].Image.Tag = "BlueCircle";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenCircle;
                        btnGrid[row, col].Image.Tag = "GreenCircle";
                        total++;
                    }
                }
                entityRemover();

            } else if (squareShape && triangleShape && !circleShape) {
                randomShape = random.Next(0, 2);
                if (randomShape == 0) {
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedSquare;
                        btnGrid[row, col].Image.Tag = "RedSquare";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueSquare;
                        btnGrid[row, col].Image.Tag = "BlueSquare";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenSquare;
                        btnGrid[row, col].Image.Tag = "GreenSquare";
                        total++;
                    }
                } else {
                    if (randomColor[index] == "red") {
                        btnGrid[row, col].Image = Resources.RedTriangle;
                        btnGrid[row, col].Image.Tag = "RedTriangle";
                        total++;
                    } else if (randomColor[index] == "blue") {
                        btnGrid[row, col].Image = Resources.BlueTriangle;
                        btnGrid[row, col].Image.Tag = "BlueTriangle";
                        total++;
                    } else {
                        btnGrid[row, col].Image = Resources.GreenTriangle;
                        btnGrid[row, col].Image.Tag = "GreenTriangle";
                        total++;
                    }
                }
                entityRemover();

            } else if (!squareShape && !triangleShape && circleShape) {
                if (randomColor[index] == "red") {
                    btnGrid[row, col].Image = Resources.RedCircle;
                    btnGrid[row, col].Image.Tag = "RedCircle";
                    total++;
                } else if (randomColor[index] == "blue") {
                    btnGrid[row, col].Image = Resources.BlueCircle;
                    btnGrid[row, col].Image.Tag = "BlueCircle";
                    total++;
                } else {
                    btnGrid[row, col].Image = Resources.GreenCircle;
                    btnGrid[row, col].Image.Tag = "GreenCircle";
                    total++;
                }
                entityRemover();
            } else if (squareShape && !triangleShape && !circleShape) {
                if (randomColor[index] == "red") {
                    btnGrid[row, col].Image = Resources.RedSquare;
                    btnGrid[row, col].Image.Tag = "RedSquare";
                    total++;
                } else if (randomColor[index] == "blue") {
                    btnGrid[row, col].Image = Resources.BlueSquare;
                    btnGrid[row, col].Image.Tag = "BlueSquare";
                    total++;
                } else {
                    btnGrid[row, col].Image = Resources.GreenSquare;
                    btnGrid[row, col].Image.Tag = "GreenSquare";
                    total++;
                }
                entityRemover();
            } else if (!squareShape && triangleShape && !circleShape) {
                if (randomColor[index] == "red") {
                    btnGrid[row, col].Image = Resources.RedTriangle;
                    btnGrid[row, col].Image.Tag = "RedTriangle";
                    total++;
                } else if (randomColor[index] == "blue") {
                    btnGrid[row, col].Image = Resources.BlueTriangle;
                    btnGrid[row, col].Image.Tag = "BlueTriangle";
                    total++;
                } else {
                    btnGrid[row, col].Image = Resources.GreenTriangle;
                    btnGrid[row, col].Image.Tag = "GreenTriangle";
                    total++;
                }
                entityRemover();
            }

        }
        static public bool host = false;
        public Game(bool isHost,string ip = null)
        {
            InitializeComponent();
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            if (isHost)
            {
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                MessageBox.Show("Waiting connection!");
                socket = server.AcceptSocket();
                MessageReceiver.RunWorkerAsync();
            }
            else
            {
                try
                {
                    tcpClient = new TcpClient(ip, 5732);
                    socket = tcpClient.Client;
                    MessageReceiver.RunWorkerAsync();
                    MessageBox.Show("Connected!");

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!host)
            {
                byte[] buffer = new byte[1024];
                int numberOfBytesReceived = socket.Receive(buffer);
                byte[] receivedBytes = new byte[numberOfBytesReceived];
                Array.Copy(buffer, receivedBytes, numberOfBytesReceived);
                string receivedMessage = Encoding.Default.GetString(receivedBytes);
                socket.Send(receivedBytes);
            }
            else
            {
                byte[] buffer = new byte[1024];
                int numberOfBytesReceived = socket.Receive(buffer);
                byte[] receivedBytes = new byte[numberOfBytesReceived];
                Array.Copy(buffer, receivedBytes, numberOfBytesReceived);
                string receivedMessage = Encoding.Default.GetString(receivedBytes);
                socket.Send(receivedBytes);
            }
        }

        private Socket socket;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient tcpClient;

        private void Game_FormClosing(object sender, FormClosingEventArgs e) {
            total = 0;
            tempTopScore = 0;
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }
    }
}
