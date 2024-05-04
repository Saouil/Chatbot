using Microsoft.Maui.Controls;

namespace Chatbot
{
	public partial class MessageBubble : ContentView
	{
		private const double MaxBubbleWidth = 320;
		public MessageBubble()
		{
			InitializeComponent();
			BindingContext = new MessageViewModel();
			SizeChanged += OnSizeChanged;
		}

		private void OnSizeChanged(object? sender, EventArgs e)
		{
			double maxWidth = GetMessageBubbleWidth();
			BubbleFrame.WidthRequest = maxWidth;

			AnimateMessageBubble();
		}

		// Got problem here
		private double GetMessageBubbleWidth()
		{
			var viewModel = (MessageViewModel)BindingContext;
			double screenWidth = DeviceDisplay.MainDisplayInfo.Width;

			var labelSizeRequest = MessageContent.Measure(MaxBubbleWidth, double.PositiveInfinity);
			double labelWidth = labelSizeRequest.Request.Width;

            double MinBubbleWidth = Math.Min(labelWidth, MaxBubbleWidth);

            if (labelWidth > MaxBubbleWidth)
			{
				return Math.Min(Math.Max(labelWidth, MinBubbleWidth), MaxBubbleWidth);
			}
			else
			{
				return labelWidth;
			}
		}

		private async void AnimateMessageBubble()
		{
			await BubbleFrame.FadeTo(1, 1500);
		}
	}
}

