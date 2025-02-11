using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace NoteKeeper
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Notes { get; set; } = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnSaveNote(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NoteEditor.Text))
            {
                Notes.Add(NoteEditor.Text);
                NoteEditor.Text = "";
            }
        }

        private void OnDeleteNotes(object sender, EventArgs e)
        {
            Notes.Clear();
        }
    }
}