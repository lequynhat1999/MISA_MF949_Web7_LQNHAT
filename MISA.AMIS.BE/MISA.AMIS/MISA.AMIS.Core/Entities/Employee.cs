using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    public class Employee : Base
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        [CheckExist]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy : LP(26/8)
        [Required]
        [CheckExist]
        [Name("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        [Required]
        [Name("Họ và tên")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public int? Gender { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        [Required]
        [Name("Id phòng ban")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        [CheckExist]
        [Name("Số chứng minh thư")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Tên chức danh
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string PositionName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string Hotline { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        [CheckEmail]
        public string Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string AccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        public string BranchName { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        [NotMap]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Code phòng ban
        /// </summary>
        /// CreatedBy : LQNHAT(27/08/2021)
        [NotMap]
        public string DepartmentCode { get; set; }


    }
}
