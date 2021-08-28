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
            <td>{{ formatDate(employee.DateOfBirth) }}</td>
            <td>{{ employee.IdentityNumber }}</td>
            <td>{{ employee.PositionName }}</td>
            <td>{{ employee.DepartmentName }}</td>
            <td>{{ employee.AccountNumber }}</td>
            <td>{{ employee.BankName }}</td>
            <td>{{ employee.BranchName }}</td>
            <td>Sửa</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="paging">
      <div class="amount-record">Tổng số : 46 bản ghi</div>
      <div class="page-size">
        <Dropdown :data="dataPage" @get="getValPageSize" />
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
  </div>
</template>

<script>
import BaseTitle from "../components/base/BaseTitle.vue";
import EmployeeDetail from "./EmployeeDetail.vue";
import Dropdown from "../components/base/BaseDropdown.vue";
import axios from "axios";
import moment from "moment";
export default {
  components: {
    BaseTitle,
    EmployeeDetail,
    Dropdown,
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
      pageSize: 0,
      // 1 object nhân viên
      employee: {},
      // mảng các object nhân viên
      employees: [],
      // mode form detail: 0 là add, 1 là edit
      modeFormDetail: 0,
    };
  },
  created() {
    this.loadData();
  },
  methods: {
    /**------------------------------------------------
     * Bắt sự kiện mở form chi tiết
     * CreatedBy: LQNHAT(28/08/2021)
     */
    openModal() {
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = 0;
      this.$refs.modeForm.show(this.modeFormDetail);
    },

    /**---------------------------------------------------
     * Bắt sự kiện dbclik hoặc khi ấn vào nút sửa
     * CreatedBy: LQNHAT(28/08/2021)
     */
    rowClick(employeeId) {
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = 1;
      this.$refs.modeForm.show(this.modeFormDetail,employeeId);
      debugger; // eslint-disable-line
    },

    /**--------------------------------------------------
     * Set value cho pageSize
     * CreatedBy: LQNHAT(28/08/2021)
     */
    getValPageSize(valuePageSize) {
      this.pageSize = valuePageSize;
      console.log(this.pageSize);
    },

    /**-------------------------------------------------------
     * Load data lên table
     * CreatedBy: LQNHAT(28/08/2021)
     */
    loadData() {
      var self = this;
      axios
        .get(`https://localhost:44383/api/v1/employees`)
        .then((res) => {
          self.employees = res.data;
        })
        .catch((error) => {
          console.log(error);
        });
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