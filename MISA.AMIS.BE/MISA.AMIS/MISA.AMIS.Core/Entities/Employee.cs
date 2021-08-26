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
        /// CreatedBy : LP(26/8)
        public Guid EmployeeId { get; set; }



        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy : LP(26/8)
        [Required]
        public string EmployeeCode { get; set; }



        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy : LP(26/8)
        [Required]
        public string FullName { get; set; }



        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy : LP(26/8)
        public DateTime? DateOfBirth { get; set; }



        /// <summary>
        /// Giới tính
        /// </summary>
        /// CreatedBy : LP(26/8)
        public int Gender { get; set; }



        /// <summary>
        /// Đơn vị id
        /// </summary>
        [Required]
        public Guid DepartmentId { get; set; }



        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string IdentityNumber { get; set; }



        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// CreatedBy : LP(26/8)
        public DateTime? IdentityDate { get; set; }



        /// <summary>
        /// Nơi cấp
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string IdentityPlace { get; set; }



        /// <summary>
        /// Chức danh
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string PositionName { get; set; }



        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string Address { get; set; }



        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string PhoneNumber { get; set; }



        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string Hotline { get; set; }



        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string Email { get; set; }



        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string AccountNumber { get; set; }



        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string BankName { get; set; }



        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string BranchName { get; set; }




        /// <summary>
        /// Tên đơn vị
        /// </summary>
        /// CreatedBy : LP(26/8)
        public string DepartmentName { get; set; }

        public string DepartmentCode { get; set; }


    }
}
