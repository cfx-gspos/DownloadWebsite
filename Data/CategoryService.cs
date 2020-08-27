using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadWebsite.Data
{
    public class CategoryService
    {
        private SoftwareDbContext db;
        public CategoryService(SoftwareDbContext db)
        {
            this.db = db;
        }
        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public void Add(Category obj)
        {
            db.Categories.Add(obj);
            db.SaveChanges();
        }
        public void Update(Category inputObj)
        {
            var obj = db.Categories.FirstOrDefault(x => x.ID == inputObj.ID);
            PropertyCopy.Copy(inputObj, obj);
            db.SaveChanges();
        }
        public void Delete(Category animal)
        {
            db.Categories.Remove(db.Categories.FirstOrDefault(x => x.ID == animal.ID));
            db.SaveChanges();
        }
    }
}
