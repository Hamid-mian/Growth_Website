using Growth_Website.Models.Interface;

namespace Growth_Website.Models.Repository
{
    public class CartRepository:depCart
    {
      public void addcart(Cart p)
        {
            var db = new DbContextClass();
            bool istrue = true;
            db.Cart.Where(p => p.productName == p.productName && p.productType == p.productType && p.customerId == p.customerId).ToList().ForEach(p => istrue = false);
            if(istrue=true)
            {
                db.Cart.Add(p);
                db.SaveChangesAsync();
            }
    
        }

        public List<Cart> GetCart()
        {
            List<Cart> p = new List<Cart>();

            var db = new DbContextClass();
            p = db.Cart.ToList();
            return p;
        }

        public void removeCart(Cart c)
        {
            var db = new DbContextClass();
          
            var p2 = db.Cart.Where(p =>  p.productName == c.productName && p.customerId == c.customerId).First();
            db.Remove(p2);
            db.SaveChanges();
              
        }

        public void removeall()
        {
            var db = new DbContextClass();

            var p2 = db.Cart.ToList();
            foreach(var i in p2)
            {
                db.Remove(i);
                db.SaveChanges();
            }
           
        }
    }
}
