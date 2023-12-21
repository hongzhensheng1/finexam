using Newtonsoft.Json;

namespace MauiApp1;

public partial class ThirdPage : ContentPage
{
    private const string ApiKey = "ce6be1b74cc11740978f1f893c8c6f37";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
    public ThirdPage()
	{
		InitializeComponent();
    }
    private async void OnWeatherButtonClicked(object sender, EventArgs e)
    {
        await FetchWeatherData();
    }

    private async Task FetchWeatherData()
    {
        var client = new HttpClient();
        string taipeiCity = "lat=25.0375&lon=121.5637";
        string url = $"{BaseUrl}?{taipeiCity}&appid={ApiKey}&units=metric&lang=zh_tw";
        var response = await client.GetStringAsync($"{BaseUrl}?q=Taipei&appid={ApiKey}&units=metric");
        var weatherData = JsonConvert.DeserializeObject<TaipeiWeatherData>(response);

        // 更新 UI
        Taipei.Text = $"台北州廳的天氣: {weatherData.Main.Temp}°C";
}

// 天氣資訊的模型
public class TaipeiWeatherData
{
    public Main Main { get; set; }
}

    public class TaipeiMain
    {
        public float Temp { get; set; }
    }
}