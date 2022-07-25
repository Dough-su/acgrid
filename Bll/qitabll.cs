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
        public class qitabll
        {
            qitaDal dal = new qitaDal();



            public int Update(qita model)//更新操作
            {
                return dal.Update(model);
            }
            public int Insert(qita model)//插入数据
            {
                return dal.Insert(model);
            }
        }
    }
}