using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class FamilyWalletContext : DbContext
    {
        public FamilyWalletContext() : base()
        { }

        public FamilyWalletContext(DbContextOptions options) : base(options)
        { }
    }
}
