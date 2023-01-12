namespace FarmasiCase.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }
        public void AddUrunler(Urunler urun, int adet)
        {
            var line = _cartLines.FirstOrDefault(i => i.Urunler.Id == urun.Id);
            if (line == null)
            {
                _cartLines.Add(new CartLine() { Urunler = urun, Adet = adet });
            }
            else
            {
                line.Adet += adet;
            }
        }
        public void DeleteUrunler(Urunler urun)
        {
            _cartLines.RemoveAll(i => i.Urunler.Id == urun.Id);
        }
        public decimal Total()
        {
            return _cartLines.Sum(i => i.Urunler.Fiyat * i.Adet);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }

        internal void AddUrunler(object urunler)
        {
            throw new NotImplementedException();
        }
    }
    public class CartLine
    {
        public Urunler Urunler { get; set; }
        public int Adet { get; set; }
        
    }
}
