using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DownloadWebsite.Data
{
    public class FileService
    {
        private SoftwareDbContext db;
        List<File> Files = new List<File>();
        public FileService(SoftwareDbContext db)
        {
            this.db = db;
            Files = db.Files.ToList();
        }
        public List<File> GetAll()
        {
            return db.Files.ToList();
        }
        public List<File> GetByCategoryID(int categoryID, string keyword = null)
        {
            List<File> retList = new List<File>();
            if (categoryID != 0)
            {
                retList = Files.Where(x => x.CategoryID == categoryID).ToList();
            }
            else
            {
                retList = Files.ToList();
            }
            if (keyword != null)
            {
                retList = retList.Where(x => x.Name.ToLower().Contains(keyword.ToLower()) || x.Description.ToLower().Contains(keyword.ToLower())).ToList();
            }
            return retList;
        }

        public void Add(File obj)
        {
            db.Files.Add(obj);
            db.SaveChanges();
        }
        public void Update(File inputObj)
        {

            var obj = db.Files.FirstOrDefault(x => x.ID == inputObj.ID);
            PropertyCopy.Copy(inputObj, obj);

            db.SaveChanges();
        }
        public void Delete(File animal)
        {
            db.Files.Remove(db.Files.FirstOrDefault(x => x.ID == animal.ID));
            db.SaveChanges();
        }
    }
}
