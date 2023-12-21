using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MauiApp1;

public partial class SecondPage : ContentPage
{
    private const string ApiKey = "ce6be1b74cc11740978f1f893c8c6f37";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
    public SecondPage()
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
        var response = await client.GetStringAsync($"{BaseUrl}?q=Taipei&appid={ApiKey}&units=metric");
        var weatherData = JsonConvert.DeserializeObject<TaiwanWeatherData>(response);

        // 更新 UI
        Taiwan.Text = $"台灣總督府的天氣: {weatherData.Main.Temp}°C";
    }
}

// 天氣資訊的模型
public class TaiwanWeatherData
{
    public Main Main { get; set; }
}

public class TaiwanMain
{
    public float Temp { get; set; }
}