using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DownloadWebsite.Data
{
    public class SoftwareDbContext: DbContext
    {
        public SoftwareDbContext(DbContextOptions<SoftwareDbContext> options = null) : base(options)
        {
        }
        public DbSet<File> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    public class File
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
