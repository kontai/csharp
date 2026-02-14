// 創建一個 Broadcaster 實例
Broadcaster b = new Broadcaster();

// 設定初始價格
b.Price = 20;

// 註冊 priceChange 事件的事件處理常式
b.priceChange += (oldPrice, newPrice) => Console.WriteLine($"Price changed from {oldPrice} to {newPrice}");

// 修改價格
b.Price = 30;
b.Price = 130;

// 定義 PriceChangeHandler 委派
/// <summary>
/// 定義 PriceChangeHandler 委派，該委派表示當價格變化時的事件處理常式。
/// </summary>
/// <param name="oldPrice">舊價格</param>
/// <param name="newPrice">新價格</param>
public delegate void PriceChangeHandler(decimal oldPrice, decimal newPrice);

// 定義 Broadcaster 類別
/// <summary>
/// 定義 Broadcaster 類別，該類別表示一個可以廣播價格變化事件的物件。
/// </summary>
public class Broadcaster
{
    // 定義 priceChange 事件
    /// <summary>
    /// 定義 priceChange 事件，該事件在價格變化時被觸發。
    /// </summary>
    public event PriceChangeHandler? priceChange;

    // 定義 _price 欄位
    private decimal _price;

    // 定義 Price 屬性
    /// <summary>
    /// 定義 Price 屬性，該屬性表示當前的價格。
    /// </summary>
    public decimal Price
    {
        get { return _price; }
        set
        {
            // 檢查價格是否變化
            if (_price == value) return;

            // 記錄舊價格
            decimal oldPrice = _price;

            // 更新價格
            _price = value;

            // 檢查 priceChange 事件是否已註冊
            if (priceChange == null) return;

            // 觸發 priceChange 事件
            priceChange(oldPrice, _price);
        }
    }
}