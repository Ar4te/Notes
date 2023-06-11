using Notes.Models;

namespace Notes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId { set { LoadNote(value); } }
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }
    private async void DeleteBtn_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            if (File.Exists(_fileName))
                File.Delete(_fileName);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        Note noteModel = new();
        noteModel.Filename = fileName;
        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}