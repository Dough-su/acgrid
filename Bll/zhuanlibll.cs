using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace Bll
{
    public class zhuanlibll
    {
        zhuanliDal dal = new zhuanliDal();



        public int Update(zhuanli model)//更新操作
        {
            return dal.Update(model);
        }
        public int Insert(zhuanli model)//插入数据
        {
            return dal.Insert(model);
        }
    }
}