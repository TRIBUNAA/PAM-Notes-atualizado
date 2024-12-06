namespace PAMNotes
{
    public partial class MainPage : ContentPage
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "Notes.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(filePath))
            {
                NoteEditor.Text = File.ReadAllText(filePath);
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string texto = NoteEditor.Text;
            TextLabel.Text = "Arquivo foi salvo em: " + filePath;
            File.WriteAllText(filePath, texto);
            DisplayAlert("Operação Concluída", "Arquivo foi salvado com sucesso!", "Ok");
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                DisplayAlert("Operação Concluída", "Arquivo foi apagado com sucesso!", "Ok");
                NoteEditor.Text = string.Empty;
                TextLabel.Text = "";
            }
            else
            {
                DisplayAlert("Erro", "Arquivo não encontrado", "Ok");
            }
        }
    }

}
