namespace Growth_Website.Models.Interface
{
    public interface depCart
    {
        public void addcart(Cart p);
        public List<Cart> GetCart();
        public void removeCart(Cart c);
        public void removeall();
    }
}
