Console.WriteLine("***** 體驗匿名型別的樂趣 *****\n");

// ==========================================
// 🌟 寫法 1：直接在程式碼中 (Inline) 建立匿名型別
// ==========================================
// 使用 new { 屬性名 = 值, 屬性名 = 值 } 的語法
var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };

// 現在你可以像操作一般物件一樣讀取它！
Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);

// 🚨 老鳥抓漏：以下這行如果解開註解，編譯會直接報錯！
// 因為匿名型別的屬性是唯讀的！
// myCar.Color = "Black"; 


// ==========================================
// 🌟 寫法 2：透過方法動態組裝
// ==========================================
BuildAnonymousType("BMW", "Black", 90);

var myTuple = (Color: "Blue", Make: "Honda", CurrentSpeed: 55);
Console.WriteLine(myTuple);

// 輔助方法：接收三個參數，把它們打包成一個匿名型別
static void BuildAnonymousType(string make, string color, int currSp)
{
    // 動態捏出一個沒有名字的類別實體
    var car = new { Make = make, Color = color, Speed = currSp };

    Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);

    // 🎁 編譯器的免費大禮：它幫你覆寫了 ToString()！
    Console.WriteLine("ToString() == {0}", car.ToString());
}
