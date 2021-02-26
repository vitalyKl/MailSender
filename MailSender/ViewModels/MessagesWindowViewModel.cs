using MailSender.Infrastructure;
using MailSender.View;
using MailSender.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    class MessagesWindowViewModel: ViewModel
    {
        private string _Title = "Сообщения";
        private readonly MessagesRepository _Messages;

        public string Title { get => _Title; set => Set(ref _Title, value); }
        public ObservableCollection<Message> Messages { get; } = new();

        public MessagesWindowViewModel(MessagesRepository messages)
        {
            _Messages = messages;
        }
        private void LoadMessages()
        {
            foreach (var message in _Messages.GetAll())
                Messages.Add(message);
        }

        private ICommand _LoadMessagesCommand;
        public ICommand LoadMessagesCommand => _LoadMessagesCommand ??= new 
    }
}
