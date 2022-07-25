using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace Bll
{ 

namespace Bll
{
    public class gerenhuojiangbll
    {
        gerenhuojiangDal dal = new gerenhuojiangDal();



        public int Update(gerenhuojiang model)//更新操作
        {
            return dal.Update(model);
        }
        public int Insert(gerenhuojiang model)//插入数据
        {
            return dal.Insert(model);
        }
    }
}
}
