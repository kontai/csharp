using DynamicKeyword;

//UseObjectVariable();
//PrintThreeStrings();
ChangeDynamicDataType();
static void UseObjectVariable()
{
    // 建立一個 Person 類別的新實體，
    // 並把它指派給一個 System.Object 型別的變數。
    object o = new Person() { FirstName = "Mike", LastName = "Larson" };
    // 必須把 object 轉型為 Person，才能存取
    // Person 的屬性。
    Console.WriteLine("Person's first name is {0}", ((Person)o).FirstName);
}
static void PrintThreeStrings()
{
    var s1 = "Greetings";
    object s2 = "From";
    dynamic s3 = "Minneapolis";
    Console.WriteLine("s1 is of type: {0}", s1.GetType());
    Console.WriteLine("s2 is of type: {0}", s2.GetType());
    Console.WriteLine("s3 is of type: {0}", s3.GetType());
}

static void ChangeDynamicDataType()
{
    // 宣告一個名為 "t" 的
    // 單一 dynamic 資料點。
    dynamic t = "Hello!";
    Console.WriteLine("t is of type: {0}", t.GetType());
    t = false;
    Console.WriteLine("t is of type: {0}", t.GetType());
    t = new List<int>();
    Console.WriteLine("t is of type: {0}", t.GetType());
}
