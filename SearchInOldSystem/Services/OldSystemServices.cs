using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SearchInOldSystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SearchInOldSystem.Services
{
    public class OldSystemServices : IOldSystemMessages
    {
        private readonly OldSysDBContext _context;

        public OldSystemServices(OldSysDBContext context)
        {
            _context = context;
        }

        public IList<PostSendr> GetOldMessages(string RespCode, string LtrYear, string LtrNo, string LtrTitle, bool MessageTypeOut, bool MessageTypeIn, string MessageOrgnaization, DateTime StartDate, DateTime EndDate)

        {
            var messages = _context.PostSendr.Where(x => (x.WplacRecno == RespCode || x.WplacExpno == RespCode) && ( x.EnterDate >= StartDate && x.EnterDate <= EndDate)).ToList();

            //if (LtrYear != null)
            //{
            //    messages = messages.Where(x => x.LtrYear != null && x.LtrYear == LtrYear).ToList();
            //}

            if (LtrNo != null)
            {
                messages = messages.Where(x => x.LaterNo != null && x.LaterNo.ToString() == LtrNo).ToList();
            }

            if (LtrTitle != null)
            {
                messages = messages.Where(x => x.LaterInfor != null && x.LaterInfor.Contains(LtrTitle)).ToList();
            }

            if (MessageTypeOut == true && MessageTypeIn == true)
                messages = messages.Where(x => x.WplacRecno == RespCode || x.WplacExpno == RespCode).ToList();
            else if (MessageTypeOut == true && MessageTypeIn == false)
                messages = messages.Where(x => x.WplacRecno == RespCode).ToList();
            else if (MessageTypeOut == false && MessageTypeIn == true)
                messages = messages.Where(x => x.WplacExpno == RespCode).ToList();
            

            //if (StartDate != null && EndDate != null)//&& StartDate >= DateTime.Now.AddYears(-1)
            //{
            //    messages = messages.Where(x => x.EnterDate >= StartDate && x.EnterDate <= EndDate).ToList();

            //}


                if (MessageOrgnaization != null)
            {
                messages = messages.Where(x => (x.WplacExpl != null && x.WplacExpl.Contains(MessageOrgnaization)) || (x.WplacRecl != null && x.WplacRecl.Contains(MessageOrgnaization))).ToList();
            }

            return messages.OrderByDescending(x => x.EnterDate).ToList();

        }

        public List<Employees> GetOldMessageDoc(string LtrNo, int LtrYear = 2021)
        {
            return _context.Employees.Where(x => x.SltrNo == LtrNo && x.LtrYear == LtrYear).ToList();
           
        }

    }
}
