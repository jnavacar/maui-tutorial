namespace Phoneword;
public partial class MainPage : ContentPage
{
	string? translatedNumber;

	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
	
	private void OnTranslate(object sender, EventArgs e)
	{
		string enteredNumber = PhoneNumberText.Text;
		translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

		if (!string.IsNullOrEmpty(translatedNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = "Call " + translatedNumber;
		}
		else
		{
			CallButton.IsEnabled = false;
			CallButton.Text = "Call";
		}
	}
	
	async void OnCall(object sender, System.EventArgs e)
	{
		if (await this.DisplayAlert(
			    "Dial a Number",
			    "Would you like to call " + translatedNumber + "?",
			    "Yes",
			    "No"))
		{
			TranslateButton.Text = "You totally calling";
		}
	}


}

