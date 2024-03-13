using Syncfusion.Maui.Chat;
using System.ComponentModel;

namespace MauiChat
{
    public class MessageModel
    {
        #region Constructor

        public MessageModel()
        {
        }
        #endregion

        #region Public Properties
        public ChatSuggestions? Suggestions { get; set; }
        public Author? User { get; set; }
        public string? Text { get; set; }
        #endregion
    }
}
