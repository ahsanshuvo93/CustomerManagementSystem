using CustomerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementSystem.App_Code
{
    public class SourceInfo
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();
        public Dictionary<string, string> DictionarySource()
        {
            Dictionary<string, string> _dictSource = new Dictionary<string, string>();

            var _tblSource = db.tblSource.SqlQuery("select * from tblSource").ToList();

            for (int _i = 0; _i < _tblSource.Count(); _i++)
            {
                _dictSource.Add(_tblSource[_i].Source.ToString(), _tblSource[_i].Color.ToString());
            }

            return _dictSource;
        }
    }
}