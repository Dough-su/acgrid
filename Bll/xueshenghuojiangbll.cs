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
        public class xueshenghuojiangbll
        {
            xueshenghuojiangDal dal = new xueshenghuojiangDal();



            public int Update(xueshenghuojiang model)//更新操作
            {
                return dal.Update(model);
            }
            public int Insert(xueshenghuojiang model)//插入数据
            {
                return dal.Insert(model);
            }
        }
    }
}