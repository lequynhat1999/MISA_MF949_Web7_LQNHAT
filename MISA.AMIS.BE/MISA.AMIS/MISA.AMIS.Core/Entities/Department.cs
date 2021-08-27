using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    public class Department : Base
    {
        /// <summary>
        /// Id của phòng ban
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Code của phòng ban
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên của phòng ban
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string DepartmentName { get; set; }
    }
}
