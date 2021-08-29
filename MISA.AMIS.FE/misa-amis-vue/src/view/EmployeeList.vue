<template>
  <div class="box-content">
    <div class="title-content">
      <BaseTitle :title="title" />
      <div class="btn-add-employee">
        <button class="m-btn" @click="openModal">
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
            v-model="keysearch"
            @input="searchByKeysearch"
          />
          <div class="icon-search"></div>
        </div>

        <div
          class="reload"
          title="Lấy lại dữ liệu"
          @click="reloadTableAndFilter"
        ></div>
        <div class="export" title="Xuất ra excel"></div>
      </div>
    </div>
    <div class="table-employee">
      <table border="0" cellspacing="0" width="100%">
        <thead>
          <th><input type="checkbox" style="width: 16px; height: 18px" /></th>
          <th>MÃ NHÂN VIÊN</th>
          <th>TÊN NHÂN VIÊN</th>
          <th>GIỚI TÍNH</th>
          <th style="text-align: center">NGÀY SINH</th>
          <th>SỐ CMND</th>
          <th>CHỨC DANH</th>
          <th>TÊN ĐƠN VỊ</th>
          <th>SỐ TÀI KHOẢN</th>
          <th>TÊN NGÂN HÀNG</th>
          <th>CHI NHÁNH TK NGÂN HÀNG</th>
          <th style="text-align: center">CHỨC NĂNG</th>
        </thead>
        <tbody>
          <tr
            v-for="employee in employees"
            :key="employee.EmployeeId"
            @dblclick="rowClick(employee.EmployeeId)"
          >
            <td>
              <input type="checkbox" style="width: 16px; height: 18px" />
            </td>
            <td>{{ employee.EmployeeCode }}</td>
            <td :title="employee.FullName">{{ employee.FullName }}</td>
            <td>{{ employee.GenderName }}</td>
            <td style="text-align: center">
              {{ formatDate(employee.DateOfBirth) }}
            </td>
            <td>{{ employee.IdentityNumber }}</td>
            <td>{{ employee.PositionName }}</td>
            <td>{{ employee.DepartmentName }}</td>
            <td>{{ employee.AccountNumber }}</td>
            <td>{{ employee.BankName }}</td>
            <td>{{ employee.BranchName }}</td>
            <td>
              <!-- div bao quanh chức năng  -->
              <div class="option-wrapper flex">
                <!-- nút sửa -->
                <div class="btn-edit" @click="rowClick(employee.EmployeeId)">
                  Sửa
                </div>
                <!-- div bao quanh option -->
                <div
                  class="box-option"
                  :class="{ 'border-box': !isHiddenOption }"
                >
                <!-- icon option -->
                  <div class="btn-option" @click="btnOptionClick()"></div>
                  <!-- dropdown-option -->
                  <div
                    class="dropdown-option"
                    :class="{ 'option-hidden': isHiddenOption }"
                    @click="btnOptionClick()"
                  >
                  <!-- option-item -->
                    <div class="option-item">Nhân bản</div>
                    <div class="option-item">Xóa</div>
                    <div class="option-item">Ngừng sử dụng</div>
                  </div>
                </div>
              </div>
            </td>
          </tr>
          <tr v-if="employees.length == 0 ? true : false">
            <td colspan="12" style="text-align: center">
              Không có dữ liệu để hiển thị
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="paging">
      <div class="amount-record">
        Tổng số : <b>{{ amountPage }}</b> bản ghi
      </div>
      <div class="page-size">
        <Dropdown
          :data="dataPage"
          ref="textDropdownPaging"
          @get="getValPageSize"
          @setValueDefaultDropdown="setValueDefaultDropdown"
        />
      </div>
      <div class="index-page">
        <div class="index-paging btn-pre">Trước</div>
        <div class="index-paging page-number">1</div>
        <div class="index-paging page-number">2</div>
        <div class="index-paging page-number">3</div>
        <div class="index-paging btn-next">Sau</div>
      </div>
    </div>
    <EmployeeDetail
      :isOpenModal="isOpenModal"
      @openModal="openModal"
      ref="modeForm"
      :mode="modeFormDetail"
    />
    <Loading :isLoading="isLoading" />
  </div>
</template>

<script>
import BaseTitle from "../components/base/BaseTitle.vue";
import EmployeeDetail from "./EmployeeDetail.vue";
import Dropdown from "../components/base/BaseDropdown.vue";
import Loading from "../components/base/BaseLoading.vue";
import axios from "axios";
import moment from "moment";
export default {
  components: {
    BaseTitle,
    EmployeeDetail,
    Dropdown,
    Loading,
  },
  data() {
    return {
      // data cho BaseTitle
      title: "Nhân viên",
      // mở modal
      isOpenModal: true,
      // data cho dropdown paging
      dataPage: [
        { Text: "10 bản ghi trên 1 trang", Value: 10 },
        { Text: "20 bản ghi trên 1 trang", Value: 20 },
        { Text: "30 bản ghi trên 1 trang", Value: 30 },
        { Text: "40 bản ghi trên 1 trang", Value: 40 },
        { Text: "50 bản ghi trên 1 trang", Value: 50 },
      ],
      // số bản ghi trên 1 trang
      pageSize: 10,
      // trang hiện tại
      pageIndex: 1,
      // tổng số bản ghi
      amountPage: 0,
      // tổng số trang
      numPages: 0,
      // keysearch
      keysearch: "",
      // 1 object nhân viên
      employee: {},
      // mảng các object nhân viên
      employees: [],
      // mode form detail: 0 là add, 1 là edit
      modeFormDetail: 0,
      // hidden option
      isHiddenOption: true,
      // loading
      isLoading: false,
    };
  },
  created() {
    // lấy ra toàn bộ data
    this.getEmployeesByFilter(this.pageIndex, this.pageSize, this.keysearch);
  },
  methods: {
    /*-----------------------------------------------------------------
     *Lấy ra danh sách nhân viên theo các tiêu chí và phân trang
     *CreateBy: LQNhat(14/08/2021)
     */
    getEmployeesByFilter() {
      var self = this;
      self.isLoading = true;
      axios
        .get(
          `https://localhost:44383/api/v1/employees/filter?pageIndex=${this.pageIndex}
        &pageSize=${this.pageSize}&keysearch=${this.keysearch}`
        )
        .then((res) => {
          self.employees = res.data.Data;
          self.amountPage = res.data.TotalRecord;
          self.numPages = res.data.TotalPage;
          self.isLoading = false;
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**-------------------------------------------------------
     * Load data lên table
     * CreatedBy: LQNHAT(28/08/2021)
     */
    reloadTableAndFilter() {
      var self = this;
      self.pageIndex = 1;
      self.$refs.textDropdownPaging.setTextDefault();
      self.isLoading = true;
      axios
        .get(
          `https://localhost:44383/api/v1/employees/filter?pageIndex=${this.pageIndex}
            &pageSize=${this.pageSize}
          `
        )
        .then((res) => {
          self.employees = res.data.Data;
          self.amountPage = res.data.TotalRecord;
          self.numPages = res.data.TotalPage;
          self.keysearch = "";
          self.isLoading = false;
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**
     * Set value deafault cho dropdown paging
     */
    setValueDefaultDropdown(value) {
      this.pageSize = value;
    },

    /**-----------------------------------------------------------
     * Hàm bắt sự kiện khi có text thì search theo text
     * CreateBy: LQNhat(30/07/2021)
     */
    searchByKeysearch() {
      if (this.keysearch == "") {
        this.reloadTableAndFilter();
      } else {
        this.pageIndex = 1;
        this.getEmployeesByFilter(
          this.pageIndex,
          this.pageSize,
          this.keysearch
        );
      }
    },

    /**------------------------------------------------
     * Bắt sự kiện mở form chi tiết
     * CreatedBy: LQNHAT(28/08/2021)
     */
    openModal() {
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = 0;
      this.$refs.modeForm.show(this.modeFormDetail);
    },

    /**-----------------------------------------------------
     * Bắt sự kiện mở các option
     * CreatedBy: LQNHAT(28/08/2021)
     */
    btnOptionClick() {
      this.isHiddenOption = !this.isHiddenOption;
    },

    /**---------------------------------------------------
     * Bắt sự kiện dbclik hoặc khi ấn vào nút sửa
     * CreatedBy: LQNHAT(28/08/2021)
     */
    rowClick(employeeId) {
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = 1;
      this.$refs.modeForm.show(this.modeFormDetail, employeeId);
      debugger; // eslint-disable-line
    },

    /**--------------------------------------------------
     * Set value cho pageSize
     * CreatedBy: LQNHAT(28/08/2021)
     */
    getValPageSize(valuePageSize) {
      this.pageSize = valuePageSize;
      this.getEmployeesByFilter(this.pageIndex, this.pageSize, this.keysearch);
    },

    /**----------------------------------------------------------
     * Hàm format ngày tháng năm trên table
     * CreateBy:LQNhat(28/08/2021)
     */
    formatDate(value) {
      if (value) {
        return moment(String(value)).format("DD/MM/YYYY");
      }
    },
  },
};
</script>

<style>
@import "../css/employee/list.css";
@import "../css/base/button.css";
@import "../css/base/input.css";
@import "../css/base/table.css";
@import "../css/base/paging.css";
@import "../css/employee/detail.css";
@import "../css/base/width-input.css";
@import "../css/base/dropdown.css";
</style>