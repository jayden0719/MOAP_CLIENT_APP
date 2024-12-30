namespace MOAP_CLIENT_APP
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
            groupBox1 = new GroupBox();
            FileConnect = new Button();
            FileSearch = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            FilePathDir = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            MsgSocket = new Button();
            textBox12 = new TextBox();
            textBox11 = new TextBox();
            dateTimePicker2 = new DateTimePicker();
            label11 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox10 = new TextBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            groupBox3 = new GroupBox();
            button4 = new Button();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            textBox15 = new TextBox();
            textBox8 = new TextBox();
            dateTimePicker3 = new DateTimePicker();
            label15 = new Label();
            label16 = new Label();
            textBox9 = new TextBox();
            dateTimePicker4 = new DateTimePicker();
            label10 = new Label();
            label17 = new Label();
            label9 = new Label();
            label18 = new Label();
            label19 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FileConnect);
            groupBox1.Controls.Add(FileSearch);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(FilePathDir);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(623, 171);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "파일 전송";
            // 
            // FileConnect
            // 
            FileConnect.BackColor = SystemColors.AppWorkspace;
            FileConnect.FlatStyle = FlatStyle.Flat;
            FileConnect.Location = new Point(274, 72);
            FileConnect.Name = "FileConnect";
            FileConnect.Size = new Size(72, 23);
            FileConnect.TabIndex = 11;
            FileConnect.Text = "연결 요청";
            FileConnect.UseVisualStyleBackColor = false;
            FileConnect.Click += FileConnect_Click;
            // 
            // FileSearch
            // 
            FileSearch.BackColor = SystemColors.AppWorkspace;
            FileSearch.FlatStyle = FlatStyle.Flat;
            FileSearch.Location = new Point(267, 26);
            FileSearch.Name = "FileSearch";
            FileSearch.Size = new Size(77, 25);
            FileSearch.TabIndex = 10;
            FileSearch.Text = "파일 선택";
            FileSearch.UseVisualStyleBackColor = false;
            FileSearch.Click += FileSearch_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(101, 120);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(169, 23);
            textBox5.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(101, 72);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(169, 23);
            textBox4.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(440, 69);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(101, 23);
            textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(421, 27);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(136, 23);
            textBox2.TabIndex = 6;
            // 
            // FilePathDir
            // 
            FilePathDir.Location = new Point(101, 27);
            FilePathDir.Name = "FilePathDir";
            FilePathDir.Size = new Size(166, 23);
            FilePathDir.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(363, 72);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 4;
            label5.Text = "서버 PORT :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(363, 30);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "서버 IP :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 123);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 2;
            label3.Text = "전송 결과 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 75);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "서버 연결 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 30);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "파일 선택 :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(MsgSocket);
            groupBox2.Controls.Add(textBox12);
            groupBox2.Controls.Add(textBox11);
            groupBox2.Controls.Add(dateTimePicker2);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(textBox10);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(12, 189);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(623, 171);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "문자 조회";
            // 
            // MsgSocket
            // 
            MsgSocket.BackColor = SystemColors.AppWorkspace;
            MsgSocket.FlatStyle = FlatStyle.Flat;
            MsgSocket.Location = new Point(272, 99);
            MsgSocket.Name = "MsgSocket";
            MsgSocket.Size = new Size(77, 25);
            MsgSocket.TabIndex = 12;
            MsgSocket.Text = "연결 요청";
            MsgSocket.UseVisualStyleBackColor = false;
            MsgSocket.Click += MsgSocket_Click;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(101, 128);
            textBox12.Name = "textBox12";
            textBox12.ReadOnly = true;
            textBox12.Size = new Size(165, 23);
            textBox12.TabIndex = 25;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(101, 99);
            textBox11.Name = "textBox11";
            textBox11.ReadOnly = true;
            textBox11.Size = new Size(166, 23);
            textBox11.TabIndex = 24;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(215, 63);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(91, 23);
            dateTimePicker2.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(194, 68);
            label11.Name = "label11";
            label11.Size = new Size(15, 15);
            label11.TabIndex = 22;
            label11.Text = "~";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(97, 63);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(93, 23);
            dateTimePicker1.TabIndex = 21;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(85, 27);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(124, 23);
            textBox10.TabIndex = 20;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(29, 69);
            label14.Name = "label14";
            label14.Size = new Size(62, 15);
            label14.TabIndex = 19;
            label14.Text = "조회기간 :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(29, 102);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 18;
            label13.Text = "서버 연결 :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(29, 136);
            label12.Name = "label12";
            label12.Size = new Size(66, 15);
            label12.TabIndex = 17;
            label12.Text = "조회 결과 :";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(505, 32);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(101, 23);
            textBox6.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 35);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 1;
            label6.Text = "아이디 :";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(273, 32);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(136, 23);
            textBox7.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(428, 35);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 13;
            label7.Text = "서버 PORT :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(215, 35);
            label8.Name = "label8";
            label8.Size = new Size(52, 15);
            label8.TabIndex = 12;
            label8.Text = "서버 IP :";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(textBox13);
            groupBox3.Controls.Add(textBox14);
            groupBox3.Controls.Add(textBox15);
            groupBox3.Controls.Add(textBox8);
            groupBox3.Controls.Add(dateTimePicker3);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(textBox9);
            groupBox3.Controls.Add(dateTimePicker4);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(label19);
            groupBox3.Location = new Point(12, 366);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(623, 178);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "팩스 조회";
            // 
            // button4
            // 
            button4.BackColor = SystemColors.AppWorkspace;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(267, 103);
            button4.Name = "button4";
            button4.Size = new Size(77, 25);
            button4.TabIndex = 26;
            button4.Text = "연결 요청";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(75, 28);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(124, 23);
            textBox13.TabIndex = 27;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(89, 132);
            textBox14.Name = "textBox14";
            textBox14.ReadOnly = true;
            textBox14.Size = new Size(177, 23);
            textBox14.TabIndex = 34;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(89, 103);
            textBox15.Name = "textBox15";
            textBox15.ReadOnly = true;
            textBox15.Size = new Size(177, 23);
            textBox15.TabIndex = 33;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(505, 28);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new Size(101, 23);
            textBox8.TabIndex = 19;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Format = DateTimePickerFormat.Short;
            dateTimePicker3.Location = new Point(215, 67);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(91, 23);
            dateTimePicker3.TabIndex = 32;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(19, 36);
            label15.Name = "label15";
            label15.Size = new Size(50, 15);
            label15.TabIndex = 26;
            label15.Text = "아이디 :";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(194, 73);
            label16.Name = "label16";
            label16.Size = new Size(15, 15);
            label16.TabIndex = 31;
            label16.Text = "~";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(273, 28);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(136, 23);
            textBox9.TabIndex = 18;
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.Format = DateTimePickerFormat.Short;
            dateTimePicker4.Location = new Point(85, 67);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(105, 23);
            dateTimePicker4.TabIndex = 30;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(215, 31);
            label10.Name = "label10";
            label10.Size = new Size(52, 15);
            label10.TabIndex = 16;
            label10.Text = "서버 IP :";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(17, 73);
            label17.Name = "label17";
            label17.Size = new Size(62, 15);
            label17.TabIndex = 29;
            label17.Text = "조회기간 :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(428, 31);
            label9.Name = "label9";
            label9.Size = new Size(71, 15);
            label9.TabIndex = 17;
            label9.Text = "서버 PORT :";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(17, 106);
            label18.Name = "label18";
            label18.Size = new Size(66, 15);
            label18.TabIndex = 28;
            label18.Text = "서버 연결 :";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(17, 140);
            label19.Name = "label19";
            label19.Size = new Size(66, 15);
            label19.TabIndex = 27;
            label19.Text = "조회 결과 :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 557);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "클라이언트";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox FilePathDir;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button FileConnect;
        private Button FileSearch;
        private Button MsgSocket;
        private TextBox textBox12;
        private TextBox textBox11;
        private DateTimePicker dateTimePicker2;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox10;
        private Label label14;
        private Label label13;
        private Label label12;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox7;
        private Label label7;
        private Label label8;
        private TextBox textBox8;
        private TextBox textBox9;
        private Label label10;
        private Label label9;
        private Button button4;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private DateTimePicker dateTimePicker3;
        private Label label15;
        private Label label16;
        private DateTimePicker dateTimePicker4;
        private Label label17;
        private Label label18;
        private Label label19;
    }
}
