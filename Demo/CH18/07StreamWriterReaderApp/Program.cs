Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");

WriteFun();

//ReadFun();

static void WriteFun()
{
    //取得一個StreamWriter物件,並寫入資料
    //using (StreamWriter writer = File.CreateText("reminders.txt"))
    using (StreamWriter writer = new StreamWriter(path: "reminders.txt", append: true))
    {
        writer.AutoFlush = false; //不會自動寫入資料,直到呼叫Flush()或Close()
        writer.WriteLine("Don't forget Mother's Day this year...");
        writer.WriteLine("Don't forget Father's Day this year...");
        writer.WriteLine("Don't forget these numbers:");
        for (int i = 0; i < 10; i++)
        {
            writer.Write(i + " ");
        }
        //插入一個換行
        writer.Write(writer.NewLine);
    }
    Console.WriteLine("Created file and wrote some thoughts...");
    //File.Delete("reminders.txt");
}

static void ReadFun()
{
    Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");
    // 現在從檔案讀取資料。
    Console.WriteLine("Here are your thoughts:\n");
    using (StreamReader reader = File.OpenText("reminders.txt"))
    {
        string input = null;
        while ((input = reader.ReadLine()) != null)
        {
            Console.WriteLine(input);
        }
    }
}
