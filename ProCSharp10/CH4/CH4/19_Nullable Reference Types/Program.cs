// 假設專案設定為 <Nullable>enable</Nullable>

using System.Diagnostics.CodeAnalysis;

Person person = new Person("kontai");
ProcessPerson(person);
static void ProcessPerson(Person p)
{
    // --- 安全存取 ---
    // 因為 Name 是 non-nullable，編譯器知道這一定安全，不會給警告。
    Console.WriteLine(p.Name.Length);

    // --- 危險存取 ---
    // 編譯警告：Description 可能是 null，直接存取 Length 可能會崩潰。
    // Console.WriteLine(p.Description.Length); // <--- Warning CS8602

    // --- 正確防禦 ---
    if (p.Description != null)
    {
        // 編譯器很聰明，它知道你檢查過了，這行不會給警告 (Flow Analysis)
        Console.WriteLine(p.Description.Length);
    }
}

internal class Person
{
    // 1. Non-nullable property
    // 編譯警告：Name 必須在建構子結束前被初始化，因為它不允許為 null。
    public string Name { get; set; }

    // 2. Nullable property
    // 這是合法的，Description 可以是 null。
    public string? Description { get; set; }

    public Person(string name)
    {
        Name = name; // 初始化 Name，消除警告
        // Description 沒初始化沒關係，因為它預設就是 null
    }
}