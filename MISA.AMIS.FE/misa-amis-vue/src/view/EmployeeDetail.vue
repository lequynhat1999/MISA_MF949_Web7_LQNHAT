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
      <ValidationObserver ref="form_employee">
        <div class="content-modal">
          <div class="row width-100 flex">
            <div class="row-wrapper width-50 flex">
              <div class="row-left width-100 flex">
                <div class="input pdr-8 width-35">
                  <div class="text-modal">
                    <b>Mã <span style="color: red">*</span></b>
                  </div>
                  <ValidationProvider
                    rules="requiredCode"
                    name="Mã"
                    v-slot="{ errors }"
                  >
                    <input
                      type="text"
                      ref="txtEmployeeCode"
                      v-model="employee.EmployeeCode"
                      class="input-modal width-100"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      :title="errors[0]"
                    />
                    <span style="color: red">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
                <div class="input width-60">
                  <div class="text-modal">
                    <b>Tên <span style="color: red">*</span></b>
                  </div>
                  <ValidationProvider
                    rules="requiredName"
                    name="Họ và tên"
                    v-slot="{ errors }"
                  >
                    <input
                      type="text"
                      class="input-modal width-100"
                      v-model="employee.FullName"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      :title="errors[0]"
                    />
                    <span style="color: red">{{ errors[0] }}</span>
                  </ValidationProvider>
                </div>
              </div>
            </div>
            <div class="row-wrapper width-50 flex">
              <div class="row-left width-100 flex">
                <div class="input width-35">
                  <div class="text-modal">
                    <b>Ngày sinh</b>
                  </div>
                  <input
                    type="date"
                    class="input-modal width-100"
                    v-model="employee.DateOfBirth"
                  />
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
                      :checked="employee.GenderName == 'Nam' ? true : false"
                      @click="employee.GenderName == 'Nam'"
                    />
                    <label for="Nam" class="text-radio">Nam</label>
                    <input
                      type="radio"
                      id="Nữ"
                      name="gender"
                      class="radio-gender"
                      :checked="employee.GenderName == 'Nữ' ? true : false"
                      @click="employee.GenderName == 'Nữ'"
                    />
                    <label for="Nữ" class="text-radio">Nữ</label>
                    <input
                      type="radio"
                      id="Khác"
                      name="gender"
                      class="radio-gender"
                      :checked="
                        employee.GenderName == 'Không xác định' ? true : false
                      "
                      @click="employee.GenderName == 'Không xác định'"
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
                  <input
                    type="text"
                    class="input-modal width-100"
                    v-model="employee.DepartmentId"
                  />
                </div>
              </div>
            </div>
            <div class="row-wrapper width-50 flex">
              <div class="row-left width-100 flex">
                <div class="input pdr-8 width-60">
                  <div class="text-modal">
                    <b>Số CMND </b>
                  </div>
                  <input
                    type="text"
                    class="input-modal width-100"
                    v-model="employee.IdentityNumber"
                  />
                </div>
                <div class="input width-35">
                  <div class="text-modal">
                    <b>Ngày cấp</b>
                  </div>
                  <input
                    type="date"
                    class="input-modal width-100"
                    v-model="employee.IdentityDate"
                  />
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
                  <input
                    type="text"
                    class="input-modal width-100"
                    v-model="employee.PositionName"
                  />
                </div>
              </div>
            </div>
            <div class="row-wrapper width-50 flex">
              <div class="row-left width-100 flex">
                <div class="input width-95">
                  <div class="text-modal">
                    <b>Nơi cấp</b>
                  </div>
                  <input
                    type="text"
                    class="input-modal width-100"
                    v-model="employee.IdentityPlace"
                  />
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
                <input
                  type="text"
                  class="input-modal width-100"
                  v-model="employee.Address"
                />
              </div>
            </div>
          </div>
          <div class="row-bellow width-100 flex">
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>ĐT di động</b>
              </div>
              <input
                type="text"
                class="input-modal width-100"
                v-model="employee.PhoneNumber"
              />
            </div>
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>ĐT cố định</b>
              </div>
              <input
                type="text"
                class="input-modal width-100"
                v-model="employee.Hotline"
              />
            </div>
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Email</b>
              </div>
              <ValidationProvider
                rules="checkEmail"
                name="Email"
                v-slot="{ errors }"
              >
                <input
                  type="text"
                  class="input-modal width-100"
                  v-model="employee.Email"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                  }"
                  :title="errors[0]"
                />
                <span style="color: red">{{ errors[0] }}</span>
              </ValidationProvider>
            </div>
          </div>
          <div class="row-bellow width-100 flex">
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Tài khoản ngân hàng</b>
              </div>
              <ValidationProvider
                rules="numeric"
                name="Tài khoản ngân hàng"
                v-slot="{ errors }"
              >
                <input
                  type="text"
                  class="input-modal width-100"
                  v-model="employee.AccountNumber"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                  }"
                  :title="errors[0]"
                />
                <span style="color: red">{{ errors[0] }}</span>
              </ValidationProvider>
            </div>
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Tên ngân hàng</b>
              </div>
              <input
                type="text"
                class="input-modal width-100"
                v-model="employee.BankName"
              />
            </div>
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Chi nhánh</b>
              </div>
              <input
                type="text"
                class="input-modal width-100"
                v-model="employee.BranchName"
              />
            </div>
          </div>
        </div>
      </ValidationObserver>
      <div class="paging-modal flex">
        <div class="btn-cancel-modal">
          <button class="btn-white" @click="closeModal">
            <div class="text-add">Hủy</div>
          </button>
        </div>
        <div class="btn-save">
          <button class="btn-white" @click="saveBtnClick">
            <div class="text-add">Cất</div>
          </button>
        </div>
        <div class="btn-save-add">
          <button class="m-btn" @click="saveAddBtnClick">
            <div class="text-add">Cất và thêm</div>
          </button>
        </div>
      </div>
      <PopupConfirmSave />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
import { extend } from "vee-validate";
import { required, email } from "vee-validate/dist/rules";
import PopupConfirmSave from "../components/base/BasePopupConfirmSave.vue";

// custom rule required code
extend("requiredCode", {
  ...required,
  message: "Mã không được để trống",
});

// custom rule required fullname
extend("requiredName", {
  ...required,
  message: "Họ và tên không được để trống",
});

// custom rule check email
extend("checkEmail", {
  ...email,
  message: "Email không đúng định dạng",
});

export default {
  name: "EmployeeDetail",
  components: {
    PopupConfirmSave,
  },
  props: ["isOpenModal"],
  data() {
    return {
      // object nhân viên
      employee: {},
      // Id của nhân viên
      employeeId: "",
      // mode cho modal : 0 là add - 1 là edit
      mode: 0,
      newEmployeeCode: "",
    };
  },
  methods: {
    /**-------------------------------------------
     * Hàm đóng modal
     * CreatedBy: LQNHAT(28/08/2021)
     */
    closeModal() {
      this.$emit("closeForm");
      this.$refs.form_employee.reset();
    },

    /**--------------------------------------------
     * Hàm check mode
     * CreateBy : LQNHAT(28/08/2021)
     */
    show(mode, id, employee) {
      this.mode = mode;
      this.employeeId = id;
      this.employee = employee;
      if (mode == 0) {
        this.employee = {};
        this.autoNewEmployeeCode();
      }
      //  else if (mode == 2) {
      //   this.employee.EmployeeCode = "";
      //   this.employee.EmployeeId = "";
      //   this.autoNewEmployeeCode();
      //   alert(this.employee.EmployeeCode);
      // } 
      else {
        this.bindDataToForm();
      }
    },

    /*--------------------------------------------------
     * Hàm bắt sự kiện khi click btn Cất
     * CreatedBy : LQNHAT(28/08/2021)
     */
    saveBtnClick() {
      this.$refs.form_employee.validate().then((success) => {
        if (!success) {
          return;
        }
        if (this.mode == 0) {
          //add nv
          this.addEmployee();
          this.employee = {};
          this.$emit("closeForm");
          this.$refs.form_employee.reset();
        } else {
          //edit nv
          this.editEmployee();
          this.$emit("closeForm");
          this.$refs.form_employee.reset();
        }
      });
    },

    /**-----------------------------------------------------------
     * Bắt sự kiện nút cất và thêm
     * CreatedBy: LQNHAT(29/08/2021)
     */
    saveAddBtnClick() {
      this.$refs.form_employee.validate().then((success) => {
        if (!success) {
          return;
        }
        if (this.mode == 0) {
          //add nv
          this.addEmployee();
          this.$refs.form_employee.reset();
          this.employee = {};
          this.autoNewEmployeeCode();
          this.mode = 0;
          debugger; // eslint-disable-line
        } else {
          //edit nv
          this.editEmployee();
          this.$refs.form_employee.reset();
          this.employee = {};
          this.autoNewEmployeeCode();
          this.mode = 0;
          debugger; // eslint-disable-line
        }
      });
    },

    /*------------------------------------------------------------------------
     * Hàm thêm mới nhân viên
     * CreatedBy : LQNHAT(28/08/2021)
     */
    addEmployee() {
      var self = this;
      axios
        .post(`https://localhost:44383/api/v1/employees`, self.employee)
        .then((res) => {
          console.log(res);
          self.$emit("reloadTableAndFilter");
          this.$toast.success("Thêm mới nhân viên thành công", {
            timeout: 2000,
          });
        })
        .catch((errror) => {
          console.log(errror);
        });
    },

    editEmployee() {
      var self = this;
      axios
        .put(
          `https://localhost:44383/api/v1/employees/${self.employeeId}`,
          self.employee
        )
        .then((res) => {
          console.log(res);
          self.$emit("reloadTableAndFilter");
          this.$toast.success("Sửa thông tin nhân viên thành công", {
            timeout: 2000,
          });
        })
        .catch((error) => {
          console.log(error);
        });
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

          // this.newEmployeeCode = res.data;
          // self.employee.EmployeeCode = this.newEmployeeCode;
          // self.$refs.txtEmployeeCode.focus();
          debugger; // eslint-disable-line
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
          // format date về đúng định dạng
          self.employee.DateOfBirth = self.formatDate(res.data.DateOfBirth);
          self.employee.IdentityDate = self.formatDate(res.data.IdentityDate);
          console.log(res.data);
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