using System.Collections;

/*
  BitArray 壓縮 bool 集合，每位 1 位，超省空間。
用索引器讀寫位，支援位運算（AND、OR、XOR、NOT）。
適合大量布林旗標，像位域操作。
 */
var bits = new BitArray(2); // 創建長度 2 的 BitArray（初始全 false）
bits[1] = true; // 設第 1 位為 true（索引從 0 開始）
Console.WriteLine(bits[0]); // false（第 0 位）
Console.WriteLine(bits[1]); // true（第 1 位）

bits.Xor(bits); // 每位與自己異或，false 變 false，true 變 false
Console.WriteLine(bits[1]); // false（因為 true XOR true = false）