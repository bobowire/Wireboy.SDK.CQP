using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wireboy.SDK.CQP.Models
{
    public class QQJsonAttribute : Attribute
    {
        /// <summary>
        /// 顺序编码
        /// </summary>
        public int OrderNo { set; get; }
        public QQJsonAttribute(int orderNo)
        {
            OrderNo = orderNo;
        }
    }
}
