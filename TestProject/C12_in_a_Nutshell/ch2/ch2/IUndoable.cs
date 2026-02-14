namespace ch2;

public interface IUndoable
{
    void undo();
    static virtual string? num => null;
    static abstract string History{get; }    // Static abstract property to get History count

}

internal interface IRedoable:IUndoable
{
    //void redo();
}