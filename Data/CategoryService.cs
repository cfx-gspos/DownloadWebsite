using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return db.Categories.Include(x => x.Files).ToList();
        }
        public List<Category> GetAllForMenu()
        {
            List<Category> retCategoryList = new List<Category>();

            var total = db.Files.ToList().Count;
            retCategoryList.Add(new Category { ID = 0, Name = $@"全部({total})" });
            var categoryList = db.Categories.Include(x => x.Files).Select(x => new Category
            {
                ID = x.ID,
                Name = $@"{x.Name} ({x.Files.Count})"
            }).ToList();
            retCategoryList.AddRange(categoryList);
            return retCategoryList;
        }
        public void Add(Category obj)
        {
            db.Categories.Add(obj);
            db.SaveChanges();
        }
        public void Update(Category inputObj)
        {
            if (inputObj.Files != null)
            {
                foreach (var file in inputObj.Files)
                {
                    if (file.CreatedDateTime == null)
                    {
                        file.CreatedDateTime = DateTime.Now;
                    }
                }
            }

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
