using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<PersonalData> PersonalData { get; set; }

        public DbSet<DataBisness> DataBisness { get; set; }

        public DbSet<KindOfPerson> KindOfPerson { get; set; }

        public DbSet<Municipality> Municipality { get; set; }

        public DbSet<TypeDocument> TypeDocument { get; set; }
    }
}
