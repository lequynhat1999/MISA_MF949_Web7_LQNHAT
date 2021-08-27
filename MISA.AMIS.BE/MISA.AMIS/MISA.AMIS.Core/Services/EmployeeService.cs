﻿using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region DECLARE
        IEmployeeRepository _employeeRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _serviceResult = new ServiceResult();
            _employeeRepository = employeeRepository;
        }

        public ServiceResult ExportEmployees(string folder)
        {
            try
            {

                // tạo file với đường dẫn wwwroot, tên là danh_sach_nhan_vien
                var file = new FileInfo(Path.Combine(folder, "Danh_sach_nhan_vien.xlsx"));

                using (var package = new ExcelPackage(file))
                {
                    // tên worksheet
                    var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

                    // custom Title
                    workSheet.Cells["A1:I1"].Merge = true;
                    workSheet.Cells["A1:I1"].Value = "DANH SÁCH NHÂN VIÊN";
                    workSheet.Cells["A1:I1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells["A1:I1"].Style.Font.Name = "Arial";
                    workSheet.Cells["A1:I1"].Style.Font.Size = 16;
                    workSheet.Cells["A1:I1"].Style.Font.Bold = true;
                    workSheet.Cells["A2:I2"].Merge = true;

                    // tiêu đề bảng excel
                    workSheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(3).Style.Font.Bold = true;
                    workSheet.Row(3).Style.Font.Name = "Arial";
                    workSheet.Row(3).Style.Font.Size = 10;

                    // đổ màu cho tiêu đề
                    workSheet.Cells["A3:I3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["A3:I3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#d8d8d8"));

                    // tiêu đề 
                    workSheet.Cells[3, 1].Value = "STT";
                    workSheet.Cells[3, 2].Value = "Mã nhân viên";
                    workSheet.Cells[3, 3].Value = "Tên nhân viên";
                    workSheet.Cells[3, 4].Value = "Giới tính";
                    workSheet.Cells[3, 5].Value = "Ngày sinh";
                    workSheet.Cells[3, 6].Value = "Chức danh";
                    workSheet.Cells[3, 7].Value = "Tên đơn vị";
                    workSheet.Cells[3, 8].Value = "Số tài khoản";
                    workSheet.Cells[3, 9].Value = "Tên ngân hàng";

                    // lấy danh sách nhân viên
                    var employees = _employeeRepository.Get();
                    // bắt đầu từ hàng thứ 4
                    int row = 4;
                    // số thứ tự
                    int count = 1;
                    // duyệt thông tin vào ô trong file excel
                    foreach (var employee in employees)
                    {
                        // value các trường thông tin
                        workSheet.Cells[row, 1].Value = count;
                        workSheet.Cells[row, 2].Value = employee.EmployeeCode;
                        workSheet.Cells[row, 3].Value = employee.FullName;
                        workSheet.Cells[row, 4].Value = employee.GenderName;
                        workSheet.Cells[row, 5].Value = employee.DateOfBirth == null ? "" : DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        workSheet.Cells[row, 6].Value = employee.PositionName;
                        workSheet.Cells[row, 7].Value = employee.DepartmentName;
                        workSheet.Cells[row, 8].Value = employee.AccountNumber;
                        workSheet.Cells[row, 9].Value = employee.BankName;

                        // style cho cột STT và cột ngày sinh
                        workSheet.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        workSheet.Cells[row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        // style cho các dòng trong file
                        workSheet.Row(row).Style.Font.Name = "Times New Roman";
                        workSheet.Row(row).Style.Font.Size = 11;
                        row++;
                        count++;
                    }

                    // tính length của file excel
                    string modelRange = "A3:I" + (employees.Count() + 3).ToString();
                    var modelTable = workSheet.Cells[modelRange];

                    // Thêm viền cho các ô
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    // fix width cho từng column
                    workSheet.Column(1).AutoFit();
                    workSheet.Column(2).AutoFit();
                    workSheet.Column(3).AutoFit();
                    workSheet.Column(4).AutoFit();
                    workSheet.Column(5).AutoFit();
                    workSheet.Column(6).AutoFit();
                    workSheet.Column(7).AutoFit();
                    workSheet.Column(8).AutoFit();
                    workSheet.Column(9).AutoFit();
                    package.Save();
                }
                _serviceResult.MISACode = MISAEnum.EnumServiceResult.Success;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                var msg = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra",
                };
                _serviceResult.Data = msg;
                _serviceResult.MISACode = MISAEnum.EnumServiceResult.InternalServerError;
                return _serviceResult;
            }
        }


        #endregion

        #region Methods

        #endregion
    }
}

