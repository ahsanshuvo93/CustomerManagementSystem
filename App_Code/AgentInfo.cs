using CustomerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementSystem.App_Code
{
    public class AgentInfo
    {
        private DBCustomerManagementSystemEntities db = new DBCustomerManagementSystemEntities();
        public Dictionary<string, string> DictionaryAgent()
        {
            Dictionary<string, string> _dictAgent = new Dictionary<string, string>();

            var _tblAgents = db.tblAgent.SqlQuery("select * from tblAgent").ToList();

            for (int _i = 0; _i < _tblAgents.Count(); _i++)
            {
                _dictAgent.Add(_tblAgents[_i].Name.ToString(), _tblAgents[_i].Color.ToString());
            }

            return _dictAgent;
        }
    }
}