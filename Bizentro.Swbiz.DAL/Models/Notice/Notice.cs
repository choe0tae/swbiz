using System;
using System.Collections.Generic;
using System.Text;

namespace Bizentro.Swbiz.DAL.Models.Notice
{
    public class Notice
    {
        public string No { get; set; }
        public string Title { get; set; }
        public string ReqUser { get; set; }
        public string ReqDate { get; set; }
        public string ReadCount { get; set; }

        public static Notice[] GetList()
        {
            Notice[] result = new Notice[]
            {
                new Notice { No="1", Title="[필독]2020년7월 국민연금 기준소득월액 상하한액변경관련", ReqUser="황문주", ReqDate="2020-07-03", ReadCount="85" },
                new Notice { No="1", Title="[필독]2020년 1월급여계산전변경관련 안내", ReqUser="황문주", ReqDate="2020-01-10", ReadCount="207" },
                new Notice { No="1", Title="[안내]2019년귀속연말정산사용자교육신청접수", ReqUser="황문주", ReqDate="2019-11-15", ReadCount="117" },
                new Notice { No="1", Title="[필독]2019년10월 고용보험요율인상 관련", ReqUser="황문주", ReqDate="2019-09-27", ReadCount="122" },
                new Notice { No="1", Title="[5.6 세무부가세] 자동화패치 신청 전 확인해야할 사항(20190816 패치신청", ReqUser="황문주", ReqDate="2019-07-03", ReadCount="212" }
            };
            return result;
        }
    }
}
