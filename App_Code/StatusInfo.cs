using CustomerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementSystem.App_Code
{
    public class StatusInfo
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();
        public Dictionary<string, string> DictionaryStatus()
        {
            Dictionary<string, string> _dictStatus = new Dictionary<string, string>();

            var _tblStatus = db.tblStatus.SqlQuery("select * from tblStatus").ToList();

            for (int _i = 0; _i < _tblStatus.Count(); _i++)
            {
                _dictStatus.Add(_tblStatus[_i].Status.ToString(), _tblStatus[_i].Color.ToString());
            }

            return _dictStatus;
        }
    }
}