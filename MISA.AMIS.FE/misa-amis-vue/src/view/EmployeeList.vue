<template>
  <div class="box-content">
    <div class="title-content">
      <BaseTitle :title="title" />
      <div class="btn-add-employee">
        <button class="m-btn">
          <div class="text-add">Thêm mới nhân viên</div>
        </button>
      </div>
    </div>
    <div class="toolbar">
      <div class="toolbar-right">
        <div class="box-search">
          <input
            type="text"
            class="input-search"
            placeholder="Tìm kiếm theo Mã, Tên"
          />
          <div class="icon-search"></div>
        </div>
        <div class="reload"></div>
        <div class="export"></div>
      </div>
    </div>
      <div class="table-employee">
        <table border="0" cellspacing="0" width="100%">
          <thead>
            <th><input type="checkbox" style="width: 16px; height: 18px" /></th>
            <th>MÃ NHÂN VIÊN</th>
            <th>TÊN NHÂN VIÊN</th>
            <th>GIỚI TÍNH</th>
            <th>NGÀY SINH</th>
            <th>SỐ CMND</th>
            <th>CHỨC DANH</th>
            <th>TÊN ĐƠN VỊ</th>
            <th>SỐ TÀI KHOẢN</th>
            <th>TÊN NGÂN HÀNG</th>
            <th>CHI NHÁNH TK NGÂN HÀNG</th>
            <th>CHỨC NĂNG</th>
          </thead>
          <tbody>
            <tr>
              <td>
                <input type="checkbox" style="width: 16px; height: 18px" />
              </td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
            <tr>
              <td><input type="checkbox" /></td>
              <td>NV-0001</td>
              <td>Lê Quý Nhật</td>
              <td>Nam</td>
              <td>08/11/1999</td>
              <td>0123456</td>
              <td>Nhân viên</td>
              <td>Phòng đào tạo</td>
              <td>0123456</td>
              <td>ACB Bank</td>
              <td>Hà Thành</td>
              <td>Sửa</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="paging">
        <div class="amount-record">Tổng số : 46 bản ghi</div>
        <div class="page-size">
          <select id="select-size">
            <option value="10">10 bản ghi trên 1 trang</option>
            <option value="20">20 bản ghi trên 1 trang</option>
            <option value="30">30 bản ghi trên 1 trang</option>
            <option value="40">40 bản ghi trên 1 trang</option>
          </select>
        </div>
        <div class="index-page">
          <div class="index-paging btn-pre">Trước</div>
          <div class="index-paging page-number">1</div>
          <div class="index-paging page-number">2</div>
          <div class="index-paging page-number">...</div>
          <div class=" index-paging page-number">52</div>
          <div class="index-paging btn-next">Sau</div>
        </div>
      </div>
    </div>
</template>

<script>
import BaseTitle from "../components/base/BaseTitle.vue";
export default {
  components: {
    BaseTitle,
  },
  data() {
    return {
      title: "Nhân viên",
    };
  },
};
</script>

<style>
@import "../css/employee/list.css";
@import "../css/base/button.css";
@import "../css/base/input.css";
@import "../css/base/table.css";
@import "../css/base/paging.css";
</style>