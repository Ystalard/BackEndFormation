using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.FrameWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
