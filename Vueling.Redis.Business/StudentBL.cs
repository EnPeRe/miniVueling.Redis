using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Redis.Dao;

namespace Vueling.Redis.Business
{
    public class StudentBL
    {
        StudentDao stDao;

        public StudentBL()
        {
            stDao = new StudentDao();
        }
        public void Add<T>(string key, T value)
        {
            stDao.Save<T>(key, value);
        }

        public T Read<T>(string key)
        {
            return stDao.Read<T>(key);
        }
    }
}
