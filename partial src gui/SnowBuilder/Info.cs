using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns1;
using Siticone.Desktop.UI.WinForms;
using SnowBuilder.Properties;

namespace SnowBuilder
{
	
	public class Info : Form
	{
		public enum enmAction
		{
			wait,
			start,
			close
		}

		public enum enmType
		{
			Success,
			Warning,
			Error,
			Info
		}

		private enmAction action;

		private int x;

		private int y;

		private IContainer components = null;

		private ns1.SiticonePanel siticonePanel1;

		private Siticone.Desktop.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		private SiticoneHtmlLabel siticoneHtmlLabel1;

		private Timer timer1;

		private PictureBox pictureBox1;

		public Info()
		{
			InitializeComponent();
		}

		[System.Reflection.ObfuscationAttribute(Feature = "ControlFlow", Exclude = true)]
		public void showAlert(string msg, enmType type)
		{
			int num = 0;
			enmType enmType = default(enmType);
			int num2 = default(int);
			string name = default(string);
			bool flag = default(bool);
			bool flag2 = default(bool);
			Info info = default(Info);
			enmType enmType2 = default(enmType);
			while (true)
			{
				if (num == 33)
				{
					goto IL_03c6;
				}
				goto IL_03e8;
				IL_03e8:
				if (num == 18)
				{
					enmType = type;
					num = 19;
				}
				if (num == 3)
				{
					num2 = 1;
					num = 4;
				}
				if (num == 15)
				{
					goto IL_0378;
				}
				goto IL_03b9;
				IL_0158:
				num2++;
				num = 15;
				goto IL_0162;
				IL_03c6:
				pictureBox1.BackgroundImage = Resources.warning;
				num = 34;
				goto IL_03e8;
				IL_02a5:
				pictureBox1.BackgroundImage = Resources.success;
				num = 23;
				goto IL_02c8;
				IL_032f:
				if (num == 9)
				{
					base.Name = name;
					num = 10;
				}
				if (num != 35)
				{
					if (num == 12)
					{
						base.Location = new Point(x, y);
						num = 13;
					}
					if (num != 32)
					{
						if (num == 16)
						{
							if (flag)
							{
								goto IL_033c;
							}
							num = 17;
						}
						if (num == 27)
						{
							siticonePanel1.FillColor = Color.FromArgb(138, 0, 1);
							num = 28;
						}
						if (num != 29)
						{
							if (num == 4)
							{
								goto IL_0378;
							}
							if (num == 38)
							{
								action = enmAction.start;
								num = 39;
							}
							if (num != 36)
							{
								goto IL_0140;
							}
						}
					}
				}
				goto IL_02f3;
				IL_03b9:
				if (num == 11)
				{
					y = Screen.PrimaryScreen.WorkingArea.Height - base.Height * num2 - 5 * num2;
					num = 12;
				}
				if (num == 39)
				{
					timer1.Interval = 1;
					num = 40;
				}
				if (num == 34)
				{
					BackColor = Color.DarkOrange;
					num = 35;
				}
				if (num == 37)
				{
					Show();
					num = 38;
				}
				if (num == 1)
				{
					base.Opacity = 0.0;
					num = 2;
				}
				if (num == 5)
				{
					goto IL_033c;
				}
				goto IL_036c;
				IL_0378:
				flag = num2 < 10;
				num = 16;
				goto IL_03b9;
				IL_029c:
				if (num == 7)
				{
					flag2 = info == null;
					num = 8;
				}
				if (num == 20)
				{
					switch (enmType2)
					{
					case enmType.Success:
						goto IL_02a5;
					case enmType.Info:
						goto IL_02d5;
					case enmType.Error:
						goto IL_0308;
					case enmType.Warning:
						goto IL_03c6;
					}
					num = 21;
				}
				if (num != 13)
				{
					if (num == 28)
					{
						siticonePanel1.BorderColor = Color.FromArgb(138, 0, 1);
						num = 29;
					}
					if (num == 24)
					{
						siticonePanel1.BorderColor = Color.SeaGreen;
						num = 25;
					}
					if (num == 0)
					{
						num = 1;
					}
					if (num == 41)
					{
						break;
					}
					continue;
				}
				goto IL_0266;
				IL_02f3:
				siticoneHtmlLabel1.Text = msg;
				num = 37;
				goto IL_0140;
				IL_0140:
				if (num == 30)
				{
					goto IL_02d5;
				}
				goto IL_02e9;
				IL_0266:
				x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
				num = 18;
				goto IL_029c;
				IL_02e9:
				if (num == 22)
				{
					goto IL_02a5;
				}
				goto IL_02c8;
				IL_033c:
				name = "alert" + num2;
				num = 6;
				goto IL_036c;
				IL_02d5:
				pictureBox1.BackgroundImage = Resources.info;
				num = 31;
				goto IL_02e9;
				IL_0162:
				if (num == 23)
				{
					siticonePanel1.FillColor = Color.SeaGreen;
					num = 24;
				}
				if (num == 40)
				{
					timer1.Start();
					num = 41;
				}
				if (num == 2)
				{
					base.StartPosition = FormStartPosition.Manual;
					num = 3;
				}
				if (num == 10)
				{
					x = Screen.PrimaryScreen.WorkingArea.Width - base.Width + 15;
					num = 11;
				}
				if (num != 25 && num != 21)
				{
					if (num == 31)
					{
						siticonePanel1.BackColor = Color.FromArgb(1, 103, 204);
						num = 32;
					}
					if (num == 6)
					{
						info = (Info)Application.OpenForms[name];
						num = 7;
					}
					if (num == 17)
					{
						goto IL_0266;
					}
					goto IL_029c;
				}
				goto IL_02f3;
				IL_02c8:
				if (num == 19)
				{
					enmType2 = enmType;
					num = 20;
				}
				if (num == 14)
				{
					goto IL_0158;
				}
				goto IL_0162;
				IL_036c:
				if (num == 8)
				{
					if (!flag2)
					{
						goto IL_0158;
					}
					num = 9;
				}
				if (num == 26)
				{
					goto IL_0308;
				}
				goto IL_032f;
				IL_0308:
				pictureBox1.BackgroundImage = Resources.error;
				num = 27;
				goto IL_032f;
			}
		}

		[System.Reflection.ObfuscationAttribute(Feature = "ControlFlow", Exclude = true)]
		private void timer1_Tick(object sender, EventArgs e)
		{
			int num = 0;
			bool flag = default(bool);
			bool flag2 = default(bool);
			enmAction enmAction = default(enmAction);
			int left = default(int);
			bool flag3 = default(bool);
			enmAction enmAction2 = default(enmAction);
			do
			{
				if (num == 23)
				{
					if (!flag)
					{
						break;
					}
					num = 24;
				}
				if (num == 22)
				{
					flag = base.Opacity == 0.0;
					num = 23;
				}
				if (num == 10)
				{
					flag2 = x < base.Location.X;
					num = 11;
				}
				if (num == 21)
				{
					base.Left -= 3;
					num = 22;
				}
				switch (num)
				{
				case 1:
					enmAction = action;
					num = 2;
					break;
				case 7:
					return;
				}
				if (num == 12)
				{
					left = base.Left;
					num = 13;
				}
				if (num == 6)
				{
					action = enmAction.close;
					num = 7;
				}
				switch (num)
				{
				case 16:
					if (flag3)
					{
						num = 17;
						goto default;
					}
					return;
				default:
					if (num == 19)
					{
						goto IL_014e;
					}
					goto IL_017f;
				case 18:
					return;
					IL_018c:
					num = 4;
					goto IL_018f;
					IL_017f:
					if (num == 9)
					{
						base.Opacity += 0.1;
						num = 10;
					}
					if (num != 25)
					{
						if (num == 5)
						{
							goto IL_011f;
						}
						goto IL_0144;
					}
					return;
					IL_011f:
					timer1.Interval = 5000;
					num = 6;
					goto IL_0144;
					IL_014e:
					timer1.Interval = 1;
					num = 20;
					goto IL_017f;
					IL_018f:
					if (num == 11)
					{
						if (!flag2)
						{
							goto IL_01a7;
						}
						num = 12;
					}
					if (num == 15)
					{
						goto IL_01a7;
					}
					goto IL_01be;
					IL_0144:
					if (num == 13)
					{
						base.Left = left - 1;
						num = 14;
					}
					switch (num)
					{
					case 2:
						enmAction2 = enmAction;
						num = 3;
						break;
					case 4:
						return;
					}
					if (num == 3)
					{
						switch (enmAction2)
						{
						case enmAction.wait:
							break;
						case enmAction.close:
							goto IL_014e;
						default:
							goto IL_018c;
						case enmAction.start:
							goto IL_01f2;
						}
						goto IL_011f;
					}
					goto IL_018f;
					IL_0202:
					if (num == 20)
					{
						base.Opacity -= 0.1;
						num = 21;
					}
					if (num == 0)
					{
						num = 1;
					}
					break;
					IL_01f2:
					timer1.Interval = 1;
					num = 9;
					goto IL_0202;
					IL_01be:
					if (num == 24)
					{
						Close();
						num = 25;
					}
					switch (num)
					{
					case 17:
						action = enmAction.wait;
						num = 18;
						break;
					case 14:
						return;
					}
					if (num == 8)
					{
						goto IL_01f2;
					}
					goto IL_0202;
					IL_01a7:
					flag3 = base.Opacity == 1.0;
					num = 16;
					goto IL_01be;
				}
			}
			while (num != 26);
		}

		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		[System.Reflection.ObfuscationAttribute(Feature = "ControlFlow", Exclude = true)]
		private void InitializeComponent()
		{
			int num = 0;
			do
			{
				if (num == 3)
				{
					siticoneControlBox1 = new Siticone.Desktop.UI.WinForms.SiticoneControlBox();
					num = 4;
				}
				if (num == 52)
				{
					ForeColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 53;
				}
				if (num == 24)
				{
					siticoneControlBox1.ShadowDecoration.Parent = siticoneControlBox1;
					num = 25;
				}
				switch (num)
				{
				case 58:
						break;
				case 34:
					siticoneHtmlLabel1.Size = new System.Drawing.Size(69, 25);
					num = 35;
					break;
				}
				if (num == 9)
				{
					siticonePanel1.BorderColor = System.Drawing.Color.FromArgb(1, 103, 204);
					num = 10;
				}
				if (num == 6)
				{
					pictureBox1 = new System.Windows.Forms.PictureBox();
					num = 7;
				}
				if (num == 31)
				{
					siticoneHtmlLabel1.ForeColor = System.Drawing.Color.White;
					num = 32;
				}
				if (num == 21)
				{
					siticoneControlBox1.IconColor = System.Drawing.Color.White;
					num = 22;
				}
				if (num == 41)
				{
					pictureBox1.Size = new System.Drawing.Size(40, 36);
					num = 42;
				}
				if (num == 40)
				{
					pictureBox1.Name = "pictureBox1";
					num = 41;
				}
				if (num == 47)
				{
					base.ClientSize = new System.Drawing.Size(443, 113);
					num = 48;
				}
				if (num == 37)
				{
					timer1.Tick += new System.EventHandler(timer1_Tick);
					num = 38;
				}
				if (num == 56)
				{
					Text = "";
					num = 57;
				}
				if (num == 4)
				{
					siticoneHtmlLabel1 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 5;
				}
				if (num == 44)
				{
					base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
					num = 45;
				}
				if (num == 8)
				{
					SuspendLayout();
					num = 9;
				}
				if (num == 20)
				{
					siticoneControlBox1.HoverState.Parent = siticoneControlBox1;
					num = 21;
				}
				if (num == 19)
				{
					siticoneControlBox1.FillColor = System.Drawing.Color.Transparent;
					num = 20;
				}
				if (num == 61)
				{
					PerformLayout();
					num = 62;
				}
				if (num == 11)
				{
					siticonePanel1.FillColor = System.Drawing.Color.FromArgb(1, 103, 204);
					num = 12;
				}
				if (num == 45)
				{
					base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					num = 46;
				}
				if (num == 55)
				{
					base.ShowInTaskbar = false;
					num = 56;
				}
				if (num == 39)
				{
					pictureBox1.Location = new System.Drawing.Point(42, 38);
					num = 40;
				}
				if (num == 14)
				{
					siticonePanel1.ShadowDecoration.Parent = siticonePanel1;
					num = 15;
				}
				if (num == 60)
				{
					ResumeLayout(false);
					num = 61;
				}
				if (num == 2)
				{
					siticonePanel1 = new ns1.SiticonePanel();
					num = 3;
				}
				if (num == 57)
				{
					base.TopMost = true;
					num = 58;
				}
				if (num == 13)
				{
					siticonePanel1.Name = "siticonePanel1";
					num = 14;
				}
				if (num == 1)
				{
					components = new System.ComponentModel.Container();
					num = 2;
				}
				if (num == 54)
				{
					base.Name = "Info";
					num = 55;
				}
				if (num == 28)
				{
					siticoneHtmlLabel1.BackColor = System.Drawing.Color.Transparent;
					num = 29;
				}
				if (num == 50)
				{
					base.Controls.Add(siticoneControlBox1);
					num = 51;
				}
				if (num == 59)
				{
					((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
					num = 60;
				}
				if (num == 26)
				{
					siticoneControlBox1.TabIndex = 1;
					num = 27;
				}
				if (num == 17)
				{
					siticoneControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
					num = 18;
				}
				if (num == 42)
				{
					pictureBox1.TabIndex = 13;
					num = 43;
				}
				if (num == 33)
				{
					siticoneHtmlLabel1.Name = "siticoneHtmlLabel1";
					num = 34;
				}
				if (num == 38)
				{
					pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
					num = 39;
				}
				if (num == 29)
				{
					siticoneHtmlLabel1.Enabled = false;
					num = 30;
				}
				if (num == 23)
				{
					siticoneControlBox1.Name = "siticoneControlBox1";
					num = 24;
				}
				if (num == 22)
				{
					siticoneControlBox1.Location = new System.Drawing.Point(384, 22);
					num = 23;
				}
				if (num == 53)
				{
					base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
					num = 54;
				}
				if (num == 15)
				{
					siticonePanel1.Size = new System.Drawing.Size(10, 112);
					num = 16;
				}
				if (num == 10)
				{
					siticonePanel1.CustomBorderColor = System.Drawing.Color.FromArgb(1, 103, 204);
					num = 11;
				}
				if (num == 46)
				{
					BackColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 47;
				}
				if (num == 12)
				{
					siticonePanel1.Location = new System.Drawing.Point(0, 0);
					num = 13;
				}
				if (num == 25)
				{
					siticoneControlBox1.Size = new System.Drawing.Size(50, 60);
					num = 26;
				}
				if (num == 51)
				{
					base.Controls.Add(siticonePanel1);
					num = 52;
				}
				if (num == 18)
				{
					siticoneControlBox1.CustomIconSize = 50f;
					num = 19;
				}
				if (num == 16)
				{
					siticonePanel1.TabIndex = 0;
					num = 17;
				}
				if (num == 48)
				{
					base.Controls.Add(pictureBox1);
					num = 49;
				}
				if (num == 36)
				{
					siticoneHtmlLabel1.Text = "Message";
					num = 37;
				}
				if (num == 27)
				{
					siticoneControlBox1.Click += new System.EventHandler(siticoneControlBox1_Click);
					num = 28;
				}
				if (num == 43)
				{
					pictureBox1.TabStop = false;
					num = 44;
				}
				if (num == 7)
				{
					((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
					num = 8;
				}
				if (num == 32)
				{
					siticoneHtmlLabel1.Location = new System.Drawing.Point(92, 42);
					num = 33;
				}
				if (num == 49)
				{
					base.Controls.Add(siticoneHtmlLabel1);
					num = 50;
				}
				if (num == 5)
				{
					timer1 = new System.Windows.Forms.Timer(components);
					num = 6;
				}
				if (num == 30)
				{
					siticoneHtmlLabel1.Font = new System.Drawing.Font("Leelawadee UI", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
					num = 31;
				}
				if (num == 35)
				{
					siticoneHtmlLabel1.TabIndex = 12;
					num = 36;
				}
				if (num == 0)
				{
					num = 1;
				}
			}
			while (num != 62);
		}
	}
}
