using Ecart.DataAccess.Data;
using Ecart.DataAccess.Repository.IRepository;
using Ecart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.DataAccess.Repository
{
	public class CategoryRepo : Repository<Category>, ICategoryRepo
	{
		private readonly ApplicationDbContext _db;
		public CategoryRepo(ApplicationDbContext db) : base(db) 
		{
			_db = db; 
		}
		
		public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Category category)
		{
			_db.Update(category);
		}
	}
}
