using SearchInOldSystem.DatabaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchInOldSystem.Services

{
    public interface IOldSystemMessages
    {
        IList<PostSendr> GetOldMessages(string RespCode, string LtrYear, string LtrNo, string LtrTitle , bool MessageTypeOut, bool MessageTypeIn, string MessageOrgnaization,DateTime StartDate,DateTime EndDate) ;
        List<Employees> GetOldMessageDoc( string ltr_no, int LtrYear);
    }
}
