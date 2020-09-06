using System;
using System.Collections.Generic;
using System.Text;

namespace Bizentro.Swbiz.DAL.Models.Inquery
{
    public class Inquery
    {
        public string InqNo { get; set; }
        public string Channel { get; set; }

        public string TaskWork { get; set; }

        public string Title { get; set; }
        public string DueDate { get; set; }
        public string Status { get; set; }

        public static Inquery[] GetList()
        {
            Inquery[] result = new Inquery[]
            {
                new Inquery { InqNo="20170912-272472", Channel="메일문의", TaskWork="게시판", Title="ggggggggggg", DueDate="N/A", Status="처리중" },
                new Inquery { InqNo="20170911-272387", Channel="전화문의", TaskWork="게시판", Title="테스트", DueDate="N/A", Status="처리중" },
                new Inquery { InqNo="20170908-272331", Channel="메일문의", TaskWork="MES시스템", Title="뭐라카노", DueDate="N/A", Status="처리중" }

            };
            return result;
        }
    }
}
