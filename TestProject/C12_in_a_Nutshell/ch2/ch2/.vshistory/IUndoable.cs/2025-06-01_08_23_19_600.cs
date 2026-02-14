namespace ch2;

public interface IUndoable
{
    void undo();
}

internal interface IRedoable:IUndoable
{
    //void redo();
}