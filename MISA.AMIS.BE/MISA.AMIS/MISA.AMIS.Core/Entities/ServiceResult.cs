﻿using MISA.AMIS.Core.MISAEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    /// <summary>
    /// Kết quả khi xử lý nghiệp vụ
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Kết quả nhận vào
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Thông điệp nhận vào
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Check sự hợp lệ
        /// </summary>
        public EnumServiceResult MISACode { get; set; }

    }
}
