using Apps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IBLL
{
    public interface ISysSampleBLL
    {
         List<SysSample> GetList(string queryStr);
         bool Create(SysSample entity);
         bool Delete(string id);
         bool Edit(SysSample entity);
         bool IsExists(string id);
         SysSample GetById(string id);
         bool IsExist(string id);

    }
}
