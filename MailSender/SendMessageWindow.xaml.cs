using MailSender.Infrastructure;
using MailSender.Models;
using MailSender.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для SendMessageWindow.xaml
    /// </summary>
    public partial class SendMessageWindow : Window, IUser, IMailMessage
    {
        private ServersImporter se = new ServersImporter();
        private Infrastructure.MailSender ms = new Infrastructure.MailSender();
        public SendMessageWindow()
        {
            InitializeComponent();
            ComServerSelector.ItemsSource = se.servers;
        }

        public string Login { get => TxtLogin.Text;}
        public SecureString Password { get => PassLogin.SecurePassword; }
        public string Subject { get => TxtSubject.Text; }
        public string MailBody { get => TxtBody.Text; }
        public string Recipient { get => TxtRecipient.Text; }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtBlkAutorizeStatus.Text = "";
                ms.Authorize((MailServer)ComServerSelector.SelectedItem, TxtLogin.Text, PassLogin.SecurePassword);
                TabStepsList.SelectedIndex++;
            }
            catch (SmtpException)
            {
                TxtBlkAutorizeStatus.Text = "Авторизация не удалась! Проверьте правильность вводимых данных!";
            }

            
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TabStepsList.SelectedIndex++;
                ms.Send(this, this, ComServerSelector.SelectedItem as MailServer);                
                TxtBStatus.Text = "Сообщение успешно отправлено!";
                IconStatus.Icon = FontAwesome.WPF.FontAwesomeIcon.CheckCircle;
                IconStatus.Foreground = Brushes.Green;
            }
            catch
            {
                TxtBStatus.Text = "Ошибка при отправке сообщения!";
                IconStatus.Icon = FontAwesome.WPF.FontAwesomeIcon.FrownOutline;
                IconStatus.Foreground = Brushes.Red;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
