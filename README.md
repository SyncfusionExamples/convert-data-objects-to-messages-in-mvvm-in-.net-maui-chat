# convert-data-objects-to-messages-in-mvvm-in-.net-maui.chat
This sample demonstrates data binding using the ItemsSource and ItemsSourceConverter properties to use existing data collections as message collections in .NET MAUI Chat (SfChat).

## Sample

```xaml  

    <ContentPage.Resources>
        <ResourceDictionary>
            <local:MessageConverter x:Key="MessageConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>
    
    <sfChat:SfChat x:Name="sfChat"
                   CurrentUser="{Binding CurrentUser}"
                   ItemsSource="{Binding MessageCollection}"
                   ItemsSourceConverter="{StaticResource MessageConverter}"/>

Converter:

    public class MessageConverter : IChatMessageConverter
    {
        #region Public Methods

        /// <summary>
        /// Converts given data object to a chat message.
        /// </summary>
        /// <param name="data">The data object to be converted as a chat message.</param>
        /// <param name="chat">Instance of <see cref="SfChat"/>. </param>
        /// <returns>Returns the data object as a chat message.</returns>
        public IMessage ConvertToChatMessage(object data, SfChat chat)
        {
            TextMessage message = new TextMessage();
            var item = data as MessageModel;

            if (item != null && item.Text!= null && item.User!=null)
            {
                message.Text = item.Text;
                message.Author = item.User;
                message.Data = item;
                if (item?.Suggestions != null)
                {
                    message.Suggestions = item!.Suggestions;
                }
            }

            return message;
        }

        /// <summary>
        /// Converts the given chat message to a data object.
        /// </summary>
        /// <param name="chatMessage">The chat message that is to be converted as a data object.</param>
        /// <param name="chat">Instance of <see cref="SfChat"/>. </param>
        /// <returns>Returns the chat message as a data object.</returns>
        public object ConvertToData(object chatMessage, SfChat chat)
        {
            var message = new MessageModel();
            var item = chatMessage as TextMessage;

            message.Text = item!.Text;
            message.User = chat.CurrentUser;
            if (message.Suggestions != null)
            {
                message.Suggestions = chat.Suggestions;
            }
            return message;
        }
        #endregion
    }
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.