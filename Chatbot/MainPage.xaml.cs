using Microsoft.Maui.Controls;
using Microsoft.Maui.Networking;
using System;

namespace Chatbot
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Frame_Tapped(object sender, EventArgs e)
        {
            MessageEntry.Focus(); //Support touch the frame to Enter 
        }

        private void MessageEntry_Completed(object sender, EventArgs e)
        {
            // No Need to limit
        }

        private async void SendMessage_Clicked(object sender, EventArgs e)
        {
            // Monitor Device Network Connectivity
            var current = Connectivity.NetworkAccess;
            if(current != NetworkAccess.Internet)
            {
                await DisplayAlert("No Internet Access", "Please check your internet and try again!", "OK");
                return;
            };


            async void ButtonClickAnimate()
            {
                // Display the Message user enter with MessageBubble
                string message = MessageEntry.Text;
                if (!string.IsNullOrEmpty(message))
                {
                    var messageBubble = new MessageBubble
                    {
                        BindingContext = new MessageViewModel { MessageText = message, BubbleColor = Colors.White, HorizontalAlignment = LayoutOptions.End }
                    };

                    MessageContainer.Children.Add(messageBubble);

                    MessageEntry.Text = "";

                }
            }

            // Simple Clicking Animation for Button
            if (sender is Button button)
            {
                await button.ScaleTo(0.75, 50, Easing.CubicOut);
                await button.ScaleTo(1, 50, Easing.CubicIn);
            }

            ButtonClickAnimate();
        }
    }
}
