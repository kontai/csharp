
object obs = Enum.ToObject(typeof(BoardSides), 3);
Console.WriteLine(obs);

BoardSides bs = (BoardSides)3;

[Flags]
public enum BoardSides { Top = 1, Left = 2, Right = 4, Bot = 8 }

