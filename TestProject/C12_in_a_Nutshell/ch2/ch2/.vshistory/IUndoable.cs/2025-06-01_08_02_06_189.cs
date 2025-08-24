namespace ch2;

public interface IUndoable
{
    void undo();
}

public interface IRedoable:IUndoable
{
    //void redo();
}