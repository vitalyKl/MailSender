using Microsoft.Extensions.DependencyInjection;

namespace MailSender.ViewModels
{
    internal class ViewModelLocator
    {
        public MessagesWindowViewModel MessagesWindowModel => App.Services.GetRequiredService<MessagesWindowViewModel>();
    }
}
