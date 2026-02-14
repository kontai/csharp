namespace CH19;
class MyClass
{
    public IEnumerator<string> GetEnumerator()
    {
        return BlackAndWhite(); //返回枚舉器
    }
    public IEnumerator<string> BlackAndWhite()  //迭代器
    {
        yield return "black";
        yield return "gray";
        yield return "white";
    }
}
public class IteratorIEnumerator
{
    static void Main(string[] args)
    {
        MyClass mc = new MyClass();
        foreach (string shade in mc)    //使用MyClass的實例(不檢查接口，只檢查接口的實現)
        {
            Console.WriteLine(shade);
        }
    }
}