<template>
  <div class="box-content">
    <div class="title-content">
      <BaseTitle :title="title" />
      <div class="btn-add-employee">
        <button
          class="m-btn"
          @click="openModal"
          title="Thêm mới nhân viên (Ctrl + Shift + A)"
          v-shortkey="['ctrl', 'shift', 'a']"
          @shortkey="openModal"
        >
          <div class="text-add">Thêm mới nhân viên</div>
        </button>
      </div>
    </div>
    <div class="box-toolbar">
      <div class="toolbar">
        <div class="toolbar-right">
          <div class="box-search">
            <input
              type="text"
              class="input-search"
              placeholder="Tìm kiếm theo Mã, Tên nhân viên"
              v-model="keysearch"
              @keyup.enter="searchByKeysearch"
            />
            <div class="icon-search"></div>
          </div>

          <div
            class="reload"
            title="Lấy lại dữ liệu"
            @click="reloadTableAndFilter"
          ></div>
          <div
            class="export"
            title="Xuất khẩu dữ liệu ra file excel"
            @click="exportEmployee"
          ></div>
        </div>
      </div>
    </div>
    <div class="box-table">
      <div class="box-table-employee">
        <div class="table-employee">
          <table border="0" cellspacing="0" width="100%">
            <thead>
              <th class="column-sticky-left border-none">
                <input type="checkbox" style="width: 16px; height: 18px" />
              </th>
              <th class="column-sticky-left-2">MÃ NHÂN VIÊN</th>
              <th class="column-sticky-left-3">TÊN NHÂN VIÊN</th>
              <th>GIỚI TÍNH</th>
              <th style="text-align: center">NGÀY SINH</th>
              <th title="Số chứng minh nhân dân">SỐ CMND</th>
              <th>CHỨC DANH</th>
              <th>TÊN ĐƠN VỊ</th>
              <th>SỐ TÀI KHOẢN</th>
              <th>TÊN NGÂN HÀNG</th>
              <th class="border-none">CHI NHÁNH TK NGÂN HÀNG</th>
              <th class="column-sticky-right" style="text-align: center">
                CHỨC NĂNG
              </th>
            </thead>
            <tbody ref="refTbody">
              <tr
                v-for="(employee, index) in employees"
                :key="index"
                @dblclick="rowClick(index)"
              >
                <td class="column-sticky-left border-none">
                  <input type="checkbox" class="size-checkbox" />
                </td>
                <td class="column-sticky-left-2">
                  {{ employee.EmployeeCode }}
                </td>
                <td class="column-sticky-left-3" :title="employee.FullName">
                  {{ employee.FullName }}
                </td>
                <td>{{ employee.GenderName }}</td>
                <td style="text-align: center">
                  {{ formatDate(employee.DateOfBirth) }}
                </td>
                <td>{{ employee.IdentityNumber }}</td>
                <td>{{ employee.PositionName }}</td>
                <td>{{ employee.DepartmentName }}</td>
                <td>{{ employee.AccountNumber }}</td>
                <td>{{ employee.BankName }}</td>
                <td class="border-none">
                  {{ employee.BranchName }}
                </td>
                <td class="column-sticky-right">
                  <div class="option-wrapper flex">
                    <div class="btn-edit" @click="rowClick(index)">Sửa</div>
                    <div
                      class="box-option"
                      :class="{
                        'border-box':
                          selectedRow == index && contextMenu.isShow == true
                            ? true
                            : false,
                      }"
                    >
                      <div
                        class="btn-option"
                        @click.stop="openContextMenu($event, index)"
                        ref="btnOption"
                      ></div>
                    </div>
                  </div>
                </td>
              </tr>
              <tr v-if="employees.length == 0 ? true : false">
                <td colspan="9" style="text-align: center">Không có dữ liệu</td>
              </tr>
            </tbody>
          </table>
          <div
            class="dropdown-option"
            :style="{ top: contextMenu.positionY, left: contextMenu.positionX }"
            v-if="contextMenu.isShow"
            ref="contextMenu"
          >
            <div class="option-item" @click="cloneEmployee">Nhân bản</div>
            <div class="option-item" @click="deleteEmployee">Xóa</div>
            <div class="option-item-disabled">Ngừng sử dụng</div>
          </div>
        </div>
      </div>
    </div>
    <div class="box-paging">
      <div class="paging">
        <div class="amount-record">
          Tổng số : <b>{{ amountPage }}</b> bản ghi
        </div>
        <div class="paging-right flex">
          <div class="page-size">
            <Dropdown
              :data="dataPage"
              ref="textDropdownPaging"
              @get="getValPageSize"
              @setValueDefaultDropdown="setValueDefaultDropdown"
            />
          </div>
          <div class="index-page">
            <paginate
              :page-count="numPages"
              :page-range="3"
              :margin-pages="1"
              prev-text="Trước"
              next-text="Sau"
              :container-class="'pagination'"
              :page-class="'page-item'"
              :prev-link-class="'btn-pre'"
              :next-link-class="'btn-next'"
              :click-handler="clickPaging"
              ref="pagination"
            >
            </paginate>
          </div>
        </div>
      </div>
    </div>
    <EmployeeDetail
      :isOpenModal="isOpenModal"
      ref="modeForm"
      :mode="modeFormDetail"
      @closeForm="closeForm"
      @reloadTableAndFilter="reloadTableAndFilter"
    />
    <Loading :isLoading="isLoading" />
    <PopupDelete
      ref="popupDelete"
      @reloadTableAndFilter="reloadTableAndFilter"
    />
  </div>
</template>

<script>
import BaseTitle from "../components/base/BaseTitle.vue";
import EmployeeDetail from "./EmployeeDetail.vue";
import Dropdown from "../components/base/BaseDropdown.vue";
import Loading from "../components/base/BaseLoading.vue";
import PopupDelete from "../components/base/BasePoupDelete.vue";
import { URL_API, MESSAGE,MODE } from "../js/const.js";
import axios from "axios";
import moment from "moment";
export default {
  components: {
    BaseTitle,
    EmployeeDetail,
    Dropdown,
    Loading,
    PopupDelete,
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
      // id của nhân viên
      employeeId: "",
      // mode form detail: 0 là add, 1 là edit
      modeFormDetail: MODE.ADD,
      // hidden option
      isHiddenOption: true,
      // loading
      isLoading: false,
      // trạng thái của contextMenu
      contextMenu: {
        isShow: false,
        positionX: "0px",
        positionY: "0px",
      },
      // row được chọn
      selectedRow: -1,
    };
  },
  created() {
    // lấy ra toàn bộ data
    this.getEmployeesByFilter(this.pageIndex, this.pageSize, this.keysearch);
    document.addEventListener("click", this.clickOutSide);
  },

  methods: {
    /*-----------------------------------------------------------------
     *Lấy ra danh sách nhân viên theo các tiêu chí và phân trang
     *CreateBy: LQNhat(28/08/2021)
     */
    getEmployeesByFilter() {
      var self = this;
      try {
        self.isLoading = true;
        axios
          .get(
            URL_API.API_EMPLOYEE +
              "/filter?pageIndex=" +
              self.pageIndex +
              "&pageSize=" +
              self.pageSize +
              "&keysearch=" +
              self.keysearch
          )
          .then((res) => {
            if (res.status == 200) {
              // lấy ra mảng employees
              self.employees = res.data.Data;
              // lấy ra số lượng bản ghi
              self.amountPage = res.data.TotalRecord;
              // lấy ra số lượng trang
              self.numPages = res.data.TotalPage;
              self.isLoading = false;
            } else {
              this.$toast.error(MESSAGE.ERROR_LOAD_DATA, {
                timeout: 2000,
              });
            }
          })
          .catch((error) => {
            console.log(error);
          });
      } catch (error) {
        console.log(error);
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
              timeout: 2000,
            });
      }
    },

    /**-------------------------------------------------------
     * Reload lại data của table
     * CreatedBy: LQNHAT(28/08/2021)
     */
    reloadTableAndFilter() {
      var self = this;
      try {
        self.isLoading = true;
        axios
          .get(
            URL_API.API_EMPLOYEE +
              "/filter?pageIndex=" +
              self.pageIndex +
              "&pageSize=" +
              self.pageSize
          )
          .then((res) => {
            if (res.status == 200) {
              // lấy ra mảng employees
              self.employees = res.data.Data;
              // lấy ra tổng số bản ghi
              self.amountPage = res.data.TotalRecord;
              // lấy ra tổng số trang
              self.numPages = res.data.TotalPage;
              // trỏ về trang đầu tiên
              self.$refs.pagination.selectFirstPage();
              // keysearch null
              self.keysearch = "";
              self.isLoading = false;
            } else {
              this.$toast.error(MESSAGE.ERROR_LOAD_DATA, {
                timeout: 2000,
              });
            }
          })
          .catch((error) => {
            console.log(error);
          });
      } catch (error) {
        console.log(error);
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
              timeout: 2000,
            });
      }
    },

    /**--------------------------------------------------
     * Set value cho pageSize
     * CreatedBy: LQNHAT(28/08/2021)
     */
    getValPageSize(valuePageSize) {
      this.pageSize = valuePageSize;
      this.getEmployeesByFilter(this.pageIndex, this.pageSize, this.keysearch);
    },

    /**--------------------------------------------------------------------------
     * Sự kiện click vào page
     * CreatedBy: LQNHAT(31/08/2021)
     */
    clickPaging(pageNum) {
      this.pageIndex = pageNum;
      this.getEmployeesByFilter(this.pageIndex, this.pageSize, this.keysearch);
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

    /**--------------------------------------------------------------------------
     * Set value deafault cho dropdown paging
     * CreatedBy: LQNHAT(28/08/2021)
     */
    setValueDefaultDropdown(value) {
      this.pageSize = value;
    },

    /**----------------------------------------------------------------------------
     * Mở context menu
     * CreatedBy: LQNHAT(01/09/2021)
     */
    openContextMenu(event, index) {
      let target = event.currentTarget;
      // nếu mà đang ở dòng cuối cùng trong bảng
      if (index == this.pageSize - 1) {
        this.contextMenu = {
          isShow: true,
          positionX: target.getBoundingClientRect().x - 83 + "px",
          positionY: target.getBoundingClientRect().y - 90 + "px",
        };
      }
      // các dòng trong bảng
      else {
        this.contextMenu = {
          isShow: true,
          positionX: target.getBoundingClientRect().x - 83 + "px",
          positionY: target.getBoundingClientRect().y + 20 + "px",
        };
      }
      this.selectedRow = index;
    },

    /**--------------------------------------------------------------------------
     * Đóng context menu
     * CreatedBy: LQNHAT(01/09/2021)
     */
    closeContextMenu() {
      this.contextMenu = {
        isShow: false,
        positionX: 0 + "px",
        positionY: 0 + "px",
      };
    },

    /**----------------------------------------------------------------------------------
     * Click ra ngoài thì đóng context menu
     * CreatedBy: LQNHAT(01/09/2021)
     */
    clickOutSide(e) {
      let el = this.$refs.contextMenu;
      let icon = this.$refs.btnOption;
      let target = e.target;
      this.selectedRow = -1;
      if (el) {
        if (
          icon.every((icon) => icon !== target) &&
          el !== target &&
          !el.contains(target)
        ) {
          this.contextMenu.isShow = false;
        }
      }
    },

    /**------------------------------------------------------------------------
     * Xuất khẩu nhân viên
     * CreatedBy:LQNHAT(31/08/2021)
     */
    exportEmployee() {
      var self = this;
      try {
        self.isLoading = true;
        axios
          .get(URL_API.API_EMPLOYEE + "/export")
          .then((res) => {
            if (res.status == 200) {
              // download file excel về máy
              window.location = res.data.Data;
              self.$toast.success(MESSAGE.SUCCESS_EXPORT, {
                timeout: 2000,
              });
              self.isLoading = false;
            }
            else
            {
              self.$toast.error(MESSAGE.ERROR_EXPORT, {
                timeout: 2000,
              });
            }
          })
          .catch((error) => {
            console.log(error);
          });
      } catch (error) {
        console.log(error);
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
              timeout: 2000,
            });
      }
    },

    /**---------------------------------------------------------
     * Hàm bắt sự kiện xóa nhân viên
     * CreatedBy: LQNHAT(29/08/2021)
     */
    deleteEmployee() {
      let employee = this.employees[this.selectedRow];
      this.$refs.popupDelete.openPopupDelete(employee);
      this.closeContextMenu();
    },

    /**-----------------------------------------------------------------
     * Hàm bắt sự kiện nhân bản nhân viên
     * CreatedBy: LQNHAT(29/08/2021)
     */
    cloneEmployee() {
      let employee = this.employees[this.selectedRow];
      this.isOpenModal = !this.isOpenModal;
      this.$refs.modeForm.cloneToEmployee(employee);
      this.closeContextMenu();
    },

    /**------------------------------------------------
     * Bắt sự kiện mở form chi tiết
     * CreatedBy: LQNHAT(28/08/2021)
     */
    openModal() {
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = MODE.ADD;
      this.$refs.modeForm.show(this.modeFormDetail);
    },

    /**---------------------------------------------------------
     * Bắt sự kiện đóng form chi tiết
     * CreatedBy : LQNHAT(28/08/2021)
     */
    closeForm() {
      this.isOpenModal = true;
    },

    /**---------------------------------------------------
     * Bắt sự kiện dbclik hoặc khi ấn vào nút sửa
     * CreatedBy: LQNHAT(28/08/2021)
     */
    rowClick(index) {
      this.employeeId = this.employees[index].EmployeeId;
      this.isOpenModal = !this.isOpenModal;
      this.modeFormDetail = MODE.EDIT;
      this.$refs.modeForm.show(this.modeFormDetail, this.employeeId);
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
@import "../css/base/popup-confirm-save.css";
@import "../css/base/popup-delete.css";
@import "../css/base/combobox.css";
@import "../css/base/popup-warning.css";
@import "../css/page/content.css";
@import "../css/base/title.css";
</style>