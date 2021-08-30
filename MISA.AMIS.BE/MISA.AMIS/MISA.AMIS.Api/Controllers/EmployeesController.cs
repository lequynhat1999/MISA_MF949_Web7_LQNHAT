using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region DECLARE
        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService, IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment) : base(employeeRepository, employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tự sinh mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới dạng string</returns>
        /// CreateBy: LQNHAT(27/08/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult AutoNewEmployeeCode()
        {
            try
            {
                // 4. trả về client
                var newEmployeeCode = _employeeRepository.NewCode();
                return StatusCode(200, newEmployeeCode);
            }
            catch (Exception ex)
            {
                var msg = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.ResourceVnEmployee.Exception_ErrorMsg,
                };
                return StatusCode(500, msg);
            }
        }

        /// <summary>
        /// Lọc danh sách nhân viên theo các tiêu chí và phân trang
        /// </summary>
        /// <param name="pageIndex">Index của trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi hiển thị trên 1 trang</param>
        /// <param name="positionId">Id của vị trí cần tìm kiếm</param>
        /// <param name="departmentId">Id của phòng ban cần tìm kiếm</param>
        /// <param name="keysearch">Mã nhân viên, Họ và tên, SĐT cần tìm kiếm</param>
        /// <returns>Danh sách các bản ghi theo điều kiện lọc</returns>
        /// CreateBy: LQNHAT(14/08/2021)
        [HttpGet("filter")]
        public IActionResult GetEmployeesPaging(int pageIndex, int pageSize, string positionId, string departmentId, string keysearch)
        {
            try
            {
                // 4. trả về cho client
                var employeesFilter = _employeeRepository.GetByPaging(pageIndex, pageSize, positionId, departmentId, keysearch);
                if (employeesFilter != null)
                {
                    return StatusCode(200, employeesFilter);
                }
                else
                {
                    var msg = new
                    {
                        userMsg = Properties.ResourceVnEmployee.User_ErrorMsg_NoContent,
                    };
                    return StatusCode(204, msg);
                }
                //return StatusCode(200, employeesFilter);
            }
            catch (Exception ex)
            {
                var msg = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.ResourceVnEmployee.Exception_ErrorMsg,
                };
                return StatusCode(500, msg);
            }
        }

        /// <summary>
        /// Xuất khẩu dữ liệu nhân viên
        /// </summary>
        /// <returns></returns>
        /// CreatedBy : LQNHAT(27/08/2021)
        [HttpGet("Export")]
        public IActionResult ExportEmployee()
        {
            try
            {
                // đường dẫn đến wwwroot
                string folder = _hostingEnvironment.WebRootPath;

                // tạo file với đường dẫn wwwroot, tên là danh_sach_nhan_vien
                var file = new FileInfo(Path.Combine(folder, "Danh_sach_nhan_vien.xlsx"));
                if (file.Exists)
                {
                    // xóa file cũ nếu đã tồn tại
                    file.Delete();
                    // khởi tạo ra file mới tên là danh_sach_nhan_vien
                    file = new FileInfo(Path.Combine(folder, "Danh_sach_nhan_vien.xlsx"));
                }

                var serviceResult = _employeeService.ExportEmployees(folder);
                if (serviceResult.MISACode == Core.MISAEnum.EnumServiceResult.Success)
                {
                    return StatusCode(200, serviceResult.Message);
                }
                else
                {
                    var msg = new
                    {
                        userMsg = Properties.ResourceVnEmployee.User_ErrorMsg_NoContent,
                    };
                    return StatusCode(204, msg);
                }


            }
            catch (Exception ex)
            {
                var msg = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.ResourceVnEmployee.Exception_ErrorMsg,
                };
                return StatusCode(500, msg);
            }
        }
        #endregion
    }
}
