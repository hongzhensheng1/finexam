using Newtonsoft.Json;

namespace MauiApp1;

public partial class FivePage : ContentPage
{
    private const string ApiKey = "ce6be1b74cc11740978f1f893c8c6f37";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
    public FivePage()
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
        string tainanCity = "lat=22.9997&lon=120.2270";
        string url = $"{BaseUrl}?{tainanCity}&appid={ApiKey}&units=metric&lang=zh_tw";
        var response = await client.GetStringAsync($"{BaseUrl}?q=Tainan&appid={ApiKey}&units=metric");
        var weatherData = JsonConvert.DeserializeObject<TainanWeatherData>(response);

        // 更新 UI
        Tainan.Text = $"台南州廳的天氣: {weatherData.Main.Temp}°C";
    }
}

// 天氣資訊的模型
public class TainanWeatherData
{
    public Main Main { get; set; }
}

public class Main
{
    public float Temp { get; set; }
}