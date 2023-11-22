using Catan.GameFields;
using Catan.Tiles;
using System.Text;

namespace Catan.Utilities {
    public static class GameFieldUtility {

        public static string GetFieldString(GameField gameField) {
            Tile?[][] Field = gameField.Field;
            StringBuilder field = new();

            for (int i = 0; i < Field.Length; i++) {

                StringBuilder line1 = new();
                StringBuilder line2 = new();
                StringBuilder line3 = new();
                StringBuilder line4 = new();
                StringBuilder line5 = new();
                StringBuilder line6 = new();
                StringBuilder line7 = new();

                if (i % 2 == 1 && i < Field.Length / 2 + 1) {
                    line1.Insert(0, "      ");
                    line2.Insert(0, "      ");
                    line3.Insert(0, "      ");
                    line4.Insert(0, "      ");
                }

                if (i >= Field.Length / 2 + 1) {
                    line1.Append("(  )  ");
                    line2.Append("     \\");
                    line3.Append("      ");
                    line4.Append("      ");
                    line5.Append("      ");
                    line6.Append("      ");
                    line7.Append("      ");
                }

                for (int j = 0; j < Field[i].Length; j++) {
                    Tile? tile = Field[i][j];

                    if (tile != null) {
                        line1.Append("      (" + (tile.GetBuildingByPoint(Tiles.Directions.TilePoint.TOPPOINT) != null ? "XX" : "  ") + ")  ");
                        line2.Append("    /  " + i + " " + j + " \\");
                        line3.Append("(  )  [" + (tile.DiceNumber < 10 ? " " : null) + tile.DiceNumber + "]  ");
                        line4.Append(" ¦¦   " + (tile.ResourceType.ToString().Length >= 4 ? tile.ResourceType.ToString()[..4] : tile.ResourceType.ToString()[..3] + " ") + "  ");
                        line5.Append("(  )        ");
                        line6.Append("    \\      /");
                        line7.Append("      (  )  ");

                    } else if (j < Field[i].Length / 2 && Field[i][j + 1] != null && i % 2 == 0 && i > Field.Length / 2) {
                        line1.Insert(0, "      ");
                        line2.Insert(0, "      ");
                        line3.Insert(0, "      ");
                        line4.Insert(0, "      ");
                        line5.Insert(0, "      ");
                        line6.Insert(0, "      ");
                        line7.Insert(0, "      ");

                    } else if (j < Field[i].Length / 2) {
                        line1.Insert(0, "            ");
                        line2.Insert(0, "            ");
                        line3.Insert(0, "            ");
                        line4.Insert(0, "            ");
                        line5.Insert(0, "            ");
                        line6.Insert(0, "            ");
                        line7.Insert(0, "            ");
                    }
                }

                if (i > Field.Length / 2) {
                    line1.Append("      (  )");
                    line2.Append("    /     ");
                }

                line3.Append("(  )");
                line4.Append(" ¦¦ ");

                field.Append(line1);
                field.AppendLine();
                field.Append(line2);
                field.AppendLine();
                field.Append(line3);
                field.AppendLine();
                field.Append(line4);
                field.AppendLine();

                if (i == Field.Length - 1) {
                    line5.Append("(  )");
                    field.Append(line5);
                    field.AppendLine();
                    field.Append(line6);
                    field.AppendLine();
                    field.Append(line7);
                    field.AppendLine();
                }
            }

            return field.ToString();
        }
    }
}
