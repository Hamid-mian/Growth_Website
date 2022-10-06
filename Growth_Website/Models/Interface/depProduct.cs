using Microsoft.AspNetCore.Mvc;

namespace Growth_Website.Models.Interface
{
    public interface depProduct 
    {
        public void addToDatabase(Products p);
        public List<Products> GetCollections();
        public List<Products> GetSpecials();
        public List<Products> GetPopular();
        public bool Update(Products p,String productupName);
        public bool Delete(Products p1);
        
        public List<Products> Search(Products p);
    }
}
