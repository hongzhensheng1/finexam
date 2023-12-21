using Newtonsoft.Json;

namespace MauiApp1;

public partial class FourPage : ContentPage
{
    private const string ApiKey = "ce6be1b74cc11740978f1f893c8c6f37";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
    public FourPage()
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
        string taichungCity = "lat=24.1424&lon=120.6814";
        string url = $"{BaseUrl}?{taichungCity}&appid={ApiKey}&units=metric&lang=zh_tw";
        var response = await client.GetStringAsync($"{BaseUrl}?q=Taichung&appid={ApiKey}&units=metric");
        var weatherData = JsonConvert.DeserializeObject<TaichungWeatherData>(response);

        // 更新 UI
        Taichung.Text = $"台中州廳的天氣: {weatherData.Main.Temp}°C";
    }
}

// 天氣資訊的模型
public class TaichungWeatherData
{
    public Main Main { get; set; }
}

public class TaichungMain
{
    public float Temp { get; set; }
}