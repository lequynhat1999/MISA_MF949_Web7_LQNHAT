<template>
  <div id="myModal" class="modal" :class="{ 'hidden-modal': isOpenModal }">
    <div class="modal-content">
      <div class="btn-top">
        <div class="btn-close" title="Đóng(ESC)" @click="closeModal"></div>
        <div class="btn-help" title="Giúp(F1)"></div>
      </div>
      <div class="header-modal">
        <div class="title-modal">Thông tin nhân viên</div>
        <div class="checkbox-customer">
          <input
            type="checkbox"
            id="checkboxCustomer"
            style="width: 16px; height: 18px"
          />
          <label for="checkboxCustomer" class="text-checkbox"
            >Là khách hàng</label
          >
        </div>
        <div class="checkbox-supplier">
          <input
            type="checkbox"
            id="checkboxSupplier"
            style="width: 16px; height: 18px"
          />
          <label for="checkboxSupplier" class="text-checkbox"
            >Là nhà cung cấp</label
          >
        </div>
      </div>
      <div class="content-modal">
        <div class="row width-100 flex">
          <div class="row-wrapper width-50 flex">
            <div class="row-left width-100 flex">
              <div class="input pdr-8 width-35">
                <div class="text-modal">
                  <b>Mã <span style="color: red">*</span></b>
                </div>
                <input
                  type="text"
                  ref="txtEmployeeCode"
                  v-model="employee.EmployeeCode"
                  class="input-modal width-100"
                />
              </div>
              <div class="input width-60">
                <div class="text-modal">
                  <b>Tên <span style="color: red">*</span></b>
                </div>
                <input type="text" class="input-modal width-100" v-model="employee.FullName"/>
              </div>
            </div>
          </div>
          <div class="row-wrapper width-50 flex">
            <div class="row-left width-100 flex">
              <div class="input width-35">
                <div class="text-modal">
                  <b>Ngày sinh</b>
                </div>
                <input type="date" class="input-modal width-100" v-model="employee.DateOfBirth"/>
              </div>
              <div class="input pdl-16 width-65">
                <div class="text-modal">
                  <b>Giới tính</b>
                </div>
                <div class="value-gender flex">
                  <input
                    type="radio"
                    id="Nam"
                    name="gender"
                    class="radio-gender"
                    :checked=" employee.GenderName == 'Nam' ? true : false "
                  />
                  <label for="Nam" class="text-radio">Nam</label>
                  <input
                    type="radio"
                    id="Nữ"
                    name="gender"
                    class="radio-gender"
                    :checked=" employee.GenderName == 'Nữ' ? true : false "
                  />
                  <label for="Nữ" class="text-radio">Nữ</label>
                  <input
                    type="radio"
                    id="Khác"
                    name="gender"
                    class="radio-gender"
                    :checked=" employee.GenderName == 'Không xác định' ? true : false "
                  />
                  <label for="Khác" class="text-radio">Khác</label>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row-bellow width-100 flex">
          <div class="row-wrapper width-50 flex">
            <div class="row-left width-100 flex">
              <div class="input width-95">
                <div class="text-modal">
                  <b>Đơn vị <span style="color: red">*</span></b>
                </div>
                <input type="text" class="input-modal width-100"  v-model="employee.DepartmentName"/>
              </div>
            </div>
          </div>
          <div class="row-wrapper width-50 flex">
            <div class="row-left width-100 flex">
              <div class="input pdr-8 width-60">
                <div class="text-modal">
                  <b>Số CMND </b>
                </div>
                <input type="text" class="input-modal width-100" v-model="employee.IdentityNumber"/>
              </div>
              <div class="input width-35">
                <div class="text-modal">
                  <b>Ngày cấp</b>
                </div>
                <input type="date" class="input-modal width-100" v-model="employee.IdentityDate"/>
              </div>
            </div>
          </div>
        </div>
        <div class="row-bellow width-100 flex">
          <div class="row-wrapper width-50 flex">
            <div class="row-left width-100 flex">
              <div class="input width-95">
                <div class="text-modal">
                  <b>Chức danh</b>
                </div>
                <input type="text" class="input-modal width-100" v-model="employee.PositionName"/>
              </div>
            </div>
          </div>
          <div class="row-wrapper width-50 flex">
            <div class="row-left width-100 flex">
              <div class="input width-95">
                <div class="text-modal">
                  <b>Nơi cấp</b>
                </div>
                <input type="text" class="input-modal width-100" v-model="employee.IdentityPlace"/>
              </div>
            </div>
          </div>
        </div>
        <div class="row-bellow pdt-16 width-100 flex">
          <div class="row-left width-100 flex">
            <div class="input pdr-20 width-100">
              <div class="text-modal">
                <b>Địa chỉ</b>
              </div>
              <input type="text" class="input-modal width-100" v-model="employee.Address"/>
            </div>
          </div>
        </div>
        <div class="row-bellow width-100 flex">
          <div class="input pdr-8">
            <div class="text-modal">
              <b>ĐT di động</b>
            </div>
            <input type="text" class="input-modal width-100" v-model="employee.PhoneNumber"/>
          </div>
          <div class="input pdr-8">
            <div class="text-modal">
              <b>ĐT cố định</b>
            </div>
            <input type="text" class="input-modal width-100" v-model="employee.HotLine"/>
          </div>
          <div class="input pdr-8">
            <div class="text-modal">
              <b>Email</b>
            </div>
            <input type="text" class="input-modal width-100" v-model="employee.Email"/>
          </div>
        </div>
        <div class="row-bellow width-100 flex">
          <div class="input pdr-8">
            <div class="text-modal">
              <b>Tài khoản ngân hàng</b>
            </div>
            <input type="text" class="input-modal width-100" v-model="employee.AccountNumber"/>
          </div>
          <div class="input pdr-8">
            <div class="text-modal">
              <b>Tên ngân hàng</b>
            </div>
            <input type="text" class="input-modal width-100" v-model="employee.BankName"/>
          </div>
          <div class="input pdr-8">
            <div class="text-modal">
              <b>Chi nhánh</b>
            </div>
            <input type="text" class="input-modal width-100" v-model="employee.BranchName"/>
          </div>
        </div>
      </div>
      <div class="paging-modal flex">
        <div class="btn-cancel-modal">
          <button class="btn-white" @click="closeModal">
            <div class="text-add">Hủy</div>
          </button>
        </div>
        <div class="btn-save">
          <button class="btn-white">
            <div class="text-add">Cất</div>
          </button>
        </div>
        <div class="btn-save-add">
          <button class="m-btn">
            <div class="text-add">Cất và thêm</div>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
export default {
  name: "EmployeeDetail",
  props: ["isOpenModal"],
  data() {
    return {
      // object nhân viên
      employee: {},
      employeeId: "",
      // mode cho modal : 0 là add - 1 là edit
      mode: 0,
    };
  },
  methods: {
    /**-------------------------------------------
     * Hàm đóng modal
     * CreatedBy: LQNHAT(28/08/2021)
     */
    closeModal() {
      this.$emit("openModal");
    },

    /**--------------------------------------------
     * Hàm check mode
     * CreateBy : LQNHAT(28/08/2021)
     */
    show(mode,id) {
      this.employeeId = id;
      if (mode == 0) {
        this.employee = {};
        this.autoNewEmployeeCode();
      } else {
        this.bindDataToForm();
      }
    },

    /**-----------------------------------------------------------------
     * Hàm sinh tự động mã nhân viên
     * CreateBy: LQNhat (28/08/2021)
     */
    autoNewEmployeeCode() {
      let self = this;
      axios
        .get(`https://localhost:44383/api/v1/employees/newEmployeeCode`)
        .then((res) => {
          let newEmployee = {};
          newEmployee.EmployeeCode = res.data;
          self.employee = newEmployee;
          self.$refs.txtEmployeeCode.focus();
        })
        .catch((err) => {
          console.log(err);
        });
    },

    /**---------------------------------------------------------
     * Hàm bind dữ liệu từ table lên form thông tin chi tiết
     * CreateBy: LQNhat(28/08/2021)
     */
    bindDataToForm() {
      var self = this;
      // call api
      axios
        .get(`https://localhost:44383/api/v1/employees/${self.employeeId}`)
        .then((res) => {
          self.employee = res.data;
          // format salary,date về đúng định dạng
          self.employee.DateOfBirth = self.formatDate(res.data.DateOfBirth);
          self.employee.IdentityDate = self.formatDate(res.data.IdentityDate);
          console.log(res.data);
          debugger; // eslint-disable-line
        })
        .catch((error) => {
          console.log(error);
        });
    },

    /**----------------------------------------------------------
     * Hàm format ngày tháng năm trên form chỉnh sửa
     * CreateBy:LQNhat(28/08/2021)
     */
    formatDate(date) {
      if (date) {
        return moment(String(date)).format("yyyy-MM-DD");
      }
    },
  },
};
</script>

<style>
</style>