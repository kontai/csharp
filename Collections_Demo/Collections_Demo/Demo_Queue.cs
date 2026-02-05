var q = new Queue<int>();
q.Enqueue(10); // 加 10，隊尾變 [10]
q.Enqueue(20); // 加 20，隊尾變 [10, 20]

int[] data = q.ToArray(); // 複製到陣列 [10, 20]
Console.WriteLine(q.Count); // 2（元素數）
Console.WriteLine(q.Peek()); // 10（看隊首）
Console.WriteLine(q.Dequeue()); // 10（拿隊首，剩 [20]）
Console.WriteLine(q.Dequeue()); // 20（拿隊首，空了）
Console.WriteLine(q.Dequeue()); // 丟例外（佇列空）