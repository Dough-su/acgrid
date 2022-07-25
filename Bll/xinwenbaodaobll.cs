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
        public class xinwenbaodaobll
        {
            xinwenbaodaoDal dal = new xinwenbaodaoDal();



            public int Update(xinwenbaodao model)//更新操作
            {
                return dal.Update(model);
            }
            public int Insert(xinwenbaodao model)//插入数据
            {
                return dal.Insert(model);
            }
        }
    }
}