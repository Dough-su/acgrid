using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace Bll
{
    public class lunwenBll
    {
        lunwenDal dal = new lunwenDal();


   
        public int Update(lunwen model)//更新操作
        {
            return dal.Update(model);
        }
    }
}
