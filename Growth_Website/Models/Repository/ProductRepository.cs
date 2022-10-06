using Growth_Website.Models.Interface;
using Microsoft.EntityFrameworkCore;
using Growth_Website.Models;
using Microsoft.AspNetCore.Mvc;
namespace Growth_Website.Models.Repository
{
    public class ProductRepository : depProduct

    {
        
        public void addToDatabase(Products p)
        {
            var db = new DbContextClass();
            p.lastModifiedDate = p.CreatedDate = DateTime.Now;

            db.Products.Add(p);
            db.SaveChangesAsync();
        }

        public List<Products> GetCollections()
        {
            List<Products> p = new List<Products>();

            var db = new DbContextClass();
           
                p = db.Products.Where(p => p.productType == "Collections" || p.productType == "collections").ToList();
          
            return p;
        }
        public List<Products> GetSpecials()
        {
            List<Products> p = new List<Products>();

           

            var db = new DbContextClass();
          
            p = db.Products.Where(p => p.productType == "Specials" || p.productType == "specials").ToList();
          
            return p;
        }

        public List<Products> GetPopular()
        {
            List<Products> p = new List<Products>();

            var db = new DbContextClass();
            p = db.Products.Where(p => p.productType == "Popular" || p.productType == "popular").ToList();
           
            return p;
        }


        public bool Update(Products p1, String productupName)
        {
            var db = new DbContextClass();
            Products? p2=new Products();
             p2 = db.Products.Where(p => p.productType == p1.productType && p.productName == p1.productName).FirstOrDefault();
           
            if (p2 != null)
            {
                if (productupName != null && p2.price != 0 )
                {
                    p2.productName = productupName;
                    p2.price = p1.price;
                    p2.lastModifiedDate = DateTime.Now;
                    p2.LastModifiedUserId = p1.LastModifiedUserId;
                    db.SaveChanges();
                    return true;
                }
            }


            return false;
        }

        public bool Delete(Products p1)
        {
            var db = new DbContextClass();
            Products? p2 = new Products();
            Cart? p3 = new Cart();
            if (p1.productName != null)
            {
                
                     p2 = db.Products.Where(p => p.productType == p1.productType && p.productName == p1.productName).FirstOrDefault();
                     p3 = db.Cart.Where(p => p.productType == p1.productType && p.productName == p1.productName).FirstOrDefault();
                if (p2 != null)
                {
                    p2.IsActive = false;
                    if(p3!=null)
                    {
                        db.Remove(p3);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public List<Products> Search(Products p1)
        {
            List<Products> p = new List<Products>();
            var db = new DbContextClass();
            p = db.Products.Where(p2 => p2.price == p1.price && p2.productType == p1.productType).ToList();

            return p;
        }



}
}
