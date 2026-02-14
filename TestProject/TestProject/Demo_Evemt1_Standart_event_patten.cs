Stock s = new Stock();
s.Price = 100;
s.PriceChange += (sender, e) => Console.WriteLine("Price changed from {0} to {1}", ((PriceChangeEventArgs)e)._oldPrice,
    ((PriceChangeEventArgs)e)._newPrice);
s.Price = 200;


public class PriceChangeEventArgs : EventArgs
{
    public readonly decimal _oldPrice;
    public readonly decimal _newPrice;

    public PriceChangeEventArgs(decimal oldPrice, decimal newPrice)
    {
        _oldPrice = oldPrice;
        _newPrice = newPrice;
    }
}

//public delegate void PriceChangeEventHandler(object sender, EventArgs e);

class Stock
{
    decimal _price;
    public event EventHandler<PriceChangeEventArgs> PriceChange;



    protected virtual void OnPriceChange(PriceChangeEventArgs e)
    {
        PriceChange?.Invoke(this, e);
        //Console.WriteLine("OnPriceChange called");
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (_price == value) return;
            var oldPrice = _price;
            _price = value;
            OnPriceChange(new PriceChangeEventArgs(oldPrice, _price));
        }
    }
}
