using System.Collections.ObjectModel;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace NoteKeeper
{
    public partial class MainPage : ContentPage {
        private const string NotesKey = "SavedNotes";
        private ObservableCollection<string> Notes { get; set; } = new ObservableCollection<string>();

        public MainPage() {
            InitializeComponent();
            BindingContext = this;

            LoadNotes();
        }
        private void OnSaveNote(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(NoteEditor.Text)) return;
            Notes.Add(NoteEditor.Text);
            SaveNotes();
            NoteEditor.Text = "";
        }
        
        private void OnDeleteNotes(object sender, EventArgs e) {
            Notes.Clear();
            Preferences.Remove(NotesKey);
        }

        private void SaveNotes() {
            var jsonNotes = JsonConvert.SerializeObject(Notes);
            Preferences.Set(NotesKey, jsonNotes);
        }

        private void LoadNotes() {
            if (!Preferences.ContainsKey(NotesKey)) return;
            var jsonNotes = Preferences.Get(NotesKey, "[]");
            var savedNotes = JsonConvert.DeserializeObject<ObservableCollection<string>>(jsonNotes);

            if (savedNotes == null) return;
            foreach (var note in savedNotes) {
                Notes.Add(note);
            }
        }
    }
}