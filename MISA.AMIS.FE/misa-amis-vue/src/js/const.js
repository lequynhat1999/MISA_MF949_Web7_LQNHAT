// url gọi API
export const URL_API = {
    API_EMPLOYEE : "https://localhost:44383/api/v1/employees",
    API_DEPARTMENT: "https://localhost:44383/api/v1/departments",
}

export const MESSAGE = {
    ERROR_LOAD_DATA: "Không load được dữ liệu!",
    EXCEPTION_MSG: "Có lỗi xảy ra, vui lòng liên hệ với MISA!",
    SUCCESS_EXPORT: "Xuất khẩu dữ liệu nhân viên thành công!",
    ERROR_EXPORT: "Xuất khẩu dữ liệu nhân viên không thành công!",
    REQUIRED_CODE: "Mã không được để trống.",
    REQUIRED_NAME: "Họ và tên không được để trống.",
    CHECK_EMAIL: "Email không đúng định dạng.",
    REQUIRED_DEPARTMENT: "Đơn vị không được để trống.",
    CHECK_ACCOUNT: "Tài khoản ngân hàng chỉ có thể chứa số.",
    CHECK_IDENTITY: "Số CMND chỉ có thể chứa số.",
    ERROR_NEW_CODE: "Sinh mã nhân viên mới không thành công",
    CHECK_DUPLICATE_CODE: "Mã nhân viên đã tồn tại trong hệ thống.",
    ERROR_DUPLICATE_CODE: "Mã nhân viên <{0}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại.",
    SUCCESS_ADD_EMPLOYEE: "Thêm mới nhân viên thành công!",
    ERROR_ADD_EMPLOYEE: "Thêm mới nhân viên không thành công!",
    SUCCESS_EDIT_EMPLOYEE: "Sửa thông tin nhân viên thành công!",
    ERROR_EDIT_EMPLOYEE: "Sửa thông tin nhân viên không thành công!",
    CHECK_DATA_CHANGE: "Dữ liệu đã bị thay đổi. Bạn có muốn cất không?",
    CONFIRM_DELETE: "Bạn có thực sự muốn xóa Nhân viên <{0}> không?",
    SUCCESS_DELETE: "Xóa nhân viên thành công",
    ERROR_DELETE: "Xóa nhân viên không thành công",
}