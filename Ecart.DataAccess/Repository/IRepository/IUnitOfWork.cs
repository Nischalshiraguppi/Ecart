using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepo CategoryRepo { get; }
		void Save();
	}
}
