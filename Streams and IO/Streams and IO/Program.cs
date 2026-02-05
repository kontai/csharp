// 創建名為 test.txt 的檔案

using (Stream s = new FileStream("test.txt", FileMode.Create))
{
    Console.WriteLine(s.CanRead); // True（能讀）
    Console.WriteLine(s.CanWrite); // True（能寫）
    Console.WriteLine(s.CanSeek); // True（能定位）

    s.WriteByte(101); // 寫字節 'e'（ASCII 101）
    s.WriteByte(102); // 寫字節 'f'（ASCII 102）
    byte[] block = { 1, 2, 3, 4, 5 }; // 寫 5 個字節
    s.Write(block, 0, block.Length); // 從頭寫 5 個字節

    Console.WriteLine(s.Length); // 7（總長度）
    Console.WriteLine(s.Position); // 7（當前位置，檔案尾）
    s.Position = 0; // 回檔案頭

    Console.WriteLine(s.ReadByte()); // 101（讀 'e'）
    Console.WriteLine(s.ReadByte()); // 102（讀 'f'）

    // 讀回 block 陣列
    Console.WriteLine(s.Read(block, 0, block.Length)); // 5（讀 5 個字節：1,2,3,4,5）
    Console.WriteLine(s.Read(block, 0, block.Length)); // 0（已到尾，無數據）

}