using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OLPL_API_Server.Controllers
{
    public class SecController : ApiController
    {
        // GET: api/Sec
        public string Get()
        {
            _OLPL_Apps_SecTableAdapters.OLPL_Apps_SecTableAdapter tb = new _OLPL_Apps_SecTableAdapters.OLPL_Apps_SecTableAdapter();
            OLPL_API_Server._OLPL_Apps_Sec.OLPL_Apps_SecDataTable tb1 = new OLPL_API_Server._OLPL_Apps_Sec.OLPL_Apps_SecDataTable();
            tb.Fill(tb1);
            return String.Join(Environment.NewLine, tb1.Rows.OfType<DataRow>().Select(x => String.Join(" ; ", x.ItemArray)));
        }

        // GET: api/Sec/5
        public string Get(string id)
        {
            _OLPL_Apps_SecTableAdapters.OLPL_Apps_SecTableAdapter tb = new _OLPL_Apps_SecTableAdapters.OLPL_Apps_SecTableAdapter();
            OLPL_API_Server._OLPL_Apps_Sec.OLPL_Apps_SecDataTable tb1 = new OLPL_API_Server._OLPL_Apps_Sec.OLPL_Apps_SecDataTable();
            tb.FillBy(tb1, id);
            return String.Join(Environment.NewLine, tb1.Rows.OfType<DataRow>().Select(x => String.Join(" ; ", x.ItemArray)));
        }

        // POST: api/Sec
        public void Post(SecDataModel dd1)
        {
            if (dd1.CPUName != null)
            {
                _OLPL_Apps_SecTableAdapters.OLPL_Apps_SecTableAdapter tb = new _OLPL_Apps_SecTableAdapters.OLPL_Apps_SecTableAdapter();
                OLPL_API_Server._OLPL_Apps_Sec.OLPL_Apps_SecDataTable tb1 = new OLPL_API_Server._OLPL_Apps_Sec.OLPL_Apps_SecDataTable();
                tb.FillBy(tb1, dd1.CPUName);
                DataRow dr = tb1.NewRow();
                if (tb1.Count > 0)
                {
                    if (dd1.TimeContact == null) { dd1.TimeContact = DateTime.Now.ToString(); }
                    tb.UpdateQuery(DateTime.Parse(dd1.TimeContact), dd1.Result_Admin_User, dd1.Result_Admin_Group, dd1.Result_User_Pass_Changed, dd1.CPUName,dd1.Result_Maint_User);
                }
                else
                {
                    if (dd1.TimeContact == null) { dd1.TimeContact = DateTime.Now.ToString(); }
                    tb.Insert(dd1.CPUName, DateTime.Parse(dd1.TimeContact), dd1.Result_Admin_User, dd1.Result_Admin_Group, dd1.Result_User_Pass_Changed, dd1.Result_Maint_User);
                }
            }
           
        }

        // PUT: api/Sec/5
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE: api/Sec/5
        public void Delete(int id)
        {
        }
    }
}
