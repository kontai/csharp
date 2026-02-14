using System.Collections;
using System.Windows.Markup;

namespace CH18;

/// <summary>
/// 闗鍵字where提供泛型約束，主約束只能有一個(這裡是S)，次約束可以有多個
/// </summary>
/// <typeparam name="S"></typeparam>
internal class SortedList<S>
    where S : IComparable<S>
{ }

internal class LinkedList<M, N>
    where M : IComparable<M>
    where N : ICloneable
{ }

class MyDictionary<KeyType, ValueType>
    where KeyType : IEnumerable,
    new()   //構造函數約束
{ }

public class ConstraintGeneric
{
    static void Main(string[] args)
    {

    }
}