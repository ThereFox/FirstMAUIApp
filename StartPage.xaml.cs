using System.Net;

namespace MauiApp2;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();

    }
	public async void GetNewJokesWithRerander(object sender, EventArgs e)
	{
		removeAllComponents(Container);
        await randerJokes(4);
    }

	private async Task<string> getJoke(HttpClient client)
	{
        var message = new HttpRequestMessage(HttpMethod.Get, "https://v2.jokeapi.dev/joke/Programming?format=txt&type=single");
        var result = await client.SendAsync(message);
        return await result.Content.ReadAsStringAsync();
    }

	private View createJokeComponent(string content)
	{
        return new ContentView()
			{
				Padding = new Thickness(20, 5, 20, 5),
				Margin = new Thickness(5, 5, 5, 5),
				BackgroundColor = Color.FromHex("b60aff"),
				Content = new Label() { Text = content },
			};
    }
	private async Task randerJokes(int countOfJokes)
	{
        var client = new HttpClient();

        for (int i = 0; i < countOfJokes; i++)
        {
            var joke = await getJoke(client);
            var jokeComponent = createJokeComponent(joke);
			renderComponent(jokeComponent);
        }
    }
	private void renderComponent(View jokeComponent)
	{
        Container.Children.Add(jokeComponent);
    }
	private void removeAllComponents(Layout view)
	{
        view.Children.Clear();
    }

}