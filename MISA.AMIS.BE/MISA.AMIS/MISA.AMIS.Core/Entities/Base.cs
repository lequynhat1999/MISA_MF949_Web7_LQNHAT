﻿using MISA.AMIS.Core.MISAEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    #region Attribute
    /// <summary>
    /// Cờ check việc bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }

    /// <summary>
    /// Cờ check việc trùng dữ liệu
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckExist : Attribute
    {

    }

    /// <summary>
    /// Cờ check định dạng email
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckEmail : Attribute
    {

    }

    /// <summary>
    /// Cờ check việc map property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotMap : Attribute
    {

    }

    /// <summary>
    /// Name của property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Name : Attribute
    {
        public string FieldName = string.Empty;
        public Name(string fieldName)
        {
            FieldName = fieldName;
        }
    }


    #endregion
    public class Base
    {
        #region Property
        /// <summary>
        /// Trạng thái của object
        /// </summary>
        [NotMap]
        public EnumEntityState EntityState { get; set; } = EnumEntityState.Add;

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Được chỉnh sửa bởi
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}

