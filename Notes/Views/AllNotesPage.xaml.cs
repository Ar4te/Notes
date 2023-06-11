using Notes.Models;

namespace Notes.Views;

public partial class AllNotePage : ContentPage
{
    public AllNotePage()
    {
        InitializeComponent();

        BindingContext = new AllNotes();
    }

    protected override void OnAppearing()
    {
        ((AllNotes)BindingContext).LoadNotes();
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var note = (Note)e.CurrentSelection[0];

            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            notesCollection.SelectedItems = null;
        }
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}