using Catan.GameFields;
using Terminal.Gui;

namespace Catan.Utilities {
    public class FieldWindow : Window {
        private View field;

        public FieldWindow() {
            Title = "Game Field";
            X = 30;
            Y = 0;
            Width = Dim.Fill();
            Height = Dim.Fill();

            field = new View() {
                Text = "Hallo Welt",
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

            Add(field);
        }

        public void reloadField(GameField newField) {
            Application.MainLoop.Invoke(() => {
                field.Text = GameFieldUtility.GetFieldString(newField);
            });
        }
    }
}
