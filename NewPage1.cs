using Microsoft.Maui.Layouts;

namespace MauiApp2;

public class Joke : View
{
	public Joke(string joke)
	{
		 new FlexLayout
		{
			JustifyContent = FlexJustify.Center,
			AlignItems = FlexAlignItems.Center,

			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = $"{joke}"
				}
			}
		};
	}
}