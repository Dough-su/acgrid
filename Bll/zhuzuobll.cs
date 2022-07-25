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
        public class zhuzuobll
        {
            zhuzuoDal dal = new zhuzuoDal();



            public int Update(zhuzuo model)//更新操作
            {
                return dal.Update(model);
            }
            public int Insert(zhuzuo model)//插入数据
            {
                return dal.Insert(model);
            }
        }
    }
}