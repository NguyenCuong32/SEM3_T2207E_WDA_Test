using System;
using Microsoft.EntityFrameworkCore;

namespace Test_Tranthimaihien.Entities
{
	public class DataContext:DbContext
	{
        public DataContext(DbContextOptions options) : base(options)
        {
        }

    }
}

