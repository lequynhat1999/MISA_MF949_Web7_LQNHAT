<template>
  <div id="myModal" class="modal" :class="{ 'hidden-modal': isOpenModal }">
    <div class="modal-content">
      <div class="btn-top">
        <div
          class="btn-close"
          v-shortkey="['esc']"
          @shortkey="closeFormDetail"
          title="Đóng (ESC)"
          @click="closeFormDetail"
        ></div>
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
                    name="Code"
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
                      @blur="checkDuplicateEmployeeCode"
                    />
                    <!-- <span style="color: red">{{ errors[0] }}</span> -->
                  </ValidationProvider>
                </div>
                <div class="input width-60">
                  <div class="text-modal">
                    <b>Tên <span style="color: red">*</span></b>
                  </div>
                  <ValidationProvider
                    rules="requiredName"
                    name="Name"
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
                    <!-- <span style="color: red">{{ errors[0] }}</span> -->
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
                  <datepicker
                    class="width-100"
                    v-model="employee.DateOfBirth"
                    placeholder="DD/MM/YYYY"
                    :format="'DD/MM/YYYY'"
                    :value-type="'YYYY-MM-DD'"
                    :disabled-date="(date) => date >= new Date()"
                  ></datepicker>
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
                      v-model="employee.Gender"
                      value="1"
                    />
                    <label for="Nam" class="text-radio">Nam</label>
                    <input
                      type="radio"
                      id="Nữ"
                      name="gender"
                      class="radio-gender"
                      v-model="employee.Gender"
                      value="0"
                    />
                    <label for="Nữ" class="text-radio">Nữ</label>
                    <input
                      type="radio"
                      id="Khác"
                      name="gender"
                      class="radio-gender"
                      v-model="employee.Gender"
                      value="2"
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
                  <ValidationProvider
                    rules="requiredDepartment"
                    name="Department"
                    v-slot="{ errors }"
                  >
                    <Combobox
                      style="border-radius: 4px; height: 33px"
                      class="width-100"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      v-model="employee.DepartmentId"
                      :title="errors[0]"
                    />
                    <!-- <span style="color: red">{{ errors[0] }}</span> -->
                  </ValidationProvider>
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
                  <datepicker
                    class="width-100"
                    v-model="employee.IndentityDate"
                    placeholder="DD/MM/YYYY"
                    :format="'DD/MM/YYYY'"
                    :value-type="'YYYY-MM-DD'"
                    :disabled-date="(date) => date >= new Date()"
                  ></datepicker>
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
                <!-- <span style="color: red">{{ errors[0] }}</span> -->
              </ValidationProvider>
            </div>
          </div>
          <div class="row-bellow width-100 flex">
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Tài khoản ngân hàng</b>
              </div>
              <ValidationProvider
                rules="numericAccount"
                name="AccountNumber"
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
                <!-- <span style="color: red">{{ errors[0] }}</span> -->
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
          <button
            class="btn-white"
            @click="saveBtnClick"
            title="Cất (Ctrl + S)"
            v-shortkey="['ctrl', 's']"
            @shortkey="saveBtnClick"
          >
            <div class="text-add">Cất</div>
          </button>
        </div>
        <div class="btn-save-add">
          <button
            class="m-btn"
            @click="saveAddBtnClick"
            title="Cất và thêm (Ctrl + Shift + S)"
            v-shortkey="['ctrl', 'shift', 's']"
            @shortkey="saveAddBtnClick"
          >
            <div class="text-add">Cất và thêm</div>
          </button>
        </div>
      </div>
      <PopupConfirmSave
        ref="popupConfirmSave"
        @closeModal="closeModal"
        @saveBtnClick="saveBtnClick"
      />
      <PopupWarning
        :isHiddenWarning="isHiddenWarning"
        :textError="textError"
        @closeWarning="closeWarning"
      />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
import { extend } from "vee-validate";
import { required, email, numeric } from "vee-validate/dist/rules";
import PopupConfirmSave from "../components/base/BasePopupConfirmSave.vue";
import Combobox from "../components/base/BaseCombobox.vue";
import PopupWarning from "../components/base/BasePopupWarning.vue";

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

// custom rule check required department
extend("requiredDepartment", {
  ...required,
  message: "Đơn vị không được để trống",
});

// custom rule format account number
extend("numericAccount", {
  ...numeric,
  message: "Tài khoản ngân hàng chỉ có thể chứa số",
});

export default {
  name: "EmployeeDetail",
  components: {
    PopupConfirmSave,
    Combobox,
    PopupWarning,
  },
  props: ["isOpenModal"],
  data() {
    return {
      // object nhân viên
      employee: {},
      // object ban đầu
      employeeOriginalAdd: {},
      employeeOriginalEdit: {},
      employeeCodeDuplicate: "",
      // Id của nhân viên
      employeeId: "",
      // mode cho modal : 0 là add - 1 là edit
      mode: 0,
      newEmployeeCode: "",
      notifications: [],
      // trạng thái popup warning
      isHiddenWarning: true,
      // lỗi validate
      textError: "",
      isDuplicate: false,
    };
  },
  methods: {
    /**
     * Check trùng mã nhân viên
     * CreatedBy: LQNHAT(31/08/2021)
     */
    checkDuplicateEmployeeCode() {
      var self = this;
      // binding data
      axios
        .get("https://localhost:44383/api/v1/employees")
        .then((res) => {
          self.employees = res.data;
          self.employees.forEach((item) => {
            if (
              self.employee.EmployeeCode == item.EmployeeCode &&
              self.employee.EmployeeId != item.EmployeeId
            ) {
              this.isDuplicate = true;
              this.employeeCodeDuplicate = item.EmployeeCode;
            }
          });
        })
        .catch((res) => {
          console.log(res);
        });
    },

    /**------------------------------------------------------------------------------
     * Sự kiện click nút X
     * CreatedBy: LQNHAT(30/08/2021)
     */
    closeFormDetail() {
      console.log(
        "employeeOriginalAdd " + Object.values(this.employeeOriginalAdd)
      );
      console.log(
        "employeeOriginalEdit " + Object.values(this.employeeOriginalEdit)
      );
      console.log("employee " + Object.values(this.employee));
      if (this.mode == 0) {
        if (
          JSON.stringify(Object.values(this.employeeOriginalAdd)) ===
          JSON.stringify(Object.values(this.employee))
        ) {
          this.$emit("closeForm");
          this.$refs.form_employee.reset();
        } else {
          this.$refs.popupConfirmSave.openPopupConfirmSave();
        }
      } else {
        if (
          JSON.stringify(Object.values(this.employeeOriginalEdit)) ===
          JSON.stringify(Object.values(this.employee))
        ) {
          this.$emit("closeForm");
          this.$refs.form_employee.reset();
        } else {
          this.$refs.popupConfirmSave.openPopupConfirmSave();
        }
      }
    },

    /**--------------------------------------------------
     * Bắt sự kiện đóng popup warning
     * CreatedBy: LQNHAT(30/08/2021)
     */
    closeWarning() {
      this.isHiddenWarning = true;
    },

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
    show(mode, id) {
      this.mode = mode;
      this.employeeId = id;
      if (mode == 0) {
        this.employee = {};
        this.employee.Gender = 1;
        this.autoNewEmployeeCode();
      } else {
        this.bindDataToForm();
      }
    },

    /**---------------------------------------------------
     * Hàm nhân bản nhân viên
     * CreatedBy:LQNHAT(29/08/2021)
     */
    cloneToEmployee(employee) {
      this.employee = employee;
      // this.employee.EmployeeId = null;
      this.autoNewEmployeeCode();
      this.mode = 0;
      this.employee.EmployeeId = "00000000-0000-0000-0000-000000000000";
    },

    /*--------------------------------------------------
     * Hàm bắt sự kiện khi click btn Cất
     * CreatedBy : LQNHAT(28/08/2021)
     */
    saveBtnClick() {
      // set errors
      if (this.isDuplicate == true) {
        this.$refs.form_employee.setErrors({
          Code: [`Mã nhân viên đã tồn tại trong hệ thống`],
        });
        this.isDuplicate = false;
        this.isHiddenWarning = false;
        this.textError = `Mã nhân viên ${this.employeeCodeDuplicate} đã tồn tại trong hệ thống`;
        return;
      }
      this.$refs.popupConfirmSave.closePopupConfirmSave();
      this.$refs.form_employee.validate().then((success) => {
        if (!success) {
          // validate hiện popup warning
          this.showPopupWarning();
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
      // set errors
      if (this.isDuplicate == true) {
        this.$refs.form_employee.setErrors({
          Code: [`Mã nhân viên đã tồn tại trong hệ thống`],
        });
        this.isDuplicate = false;
        this.isHiddenWarning = false;
        this.textError = `Mã nhân viên ${this.employeeCodeDuplicate} đã tồn tại trong hệ thống`;
        return;
      }
      this.$refs.popupConfirmSave.closePopupConfirmSave();
      this.$refs.form_employee.validate().then((success) => {
        if (!success) {
          // validate hiện popup warning
          this.showPopupWarning();
          return;
        }
        if (this.mode == 0) {
          //add nv
          this.addEmployee();
          this.$refs.form_employee.reset();
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

    /**-----------------------------------------------------------
     * Hiển thị popup warning
     * CreatedBy: LQNHAT(30/08/2021)
     */
    showPopupWarning() {
      this.notifications = this.$refs.form_employee.errors;
      console.log(this.notifications);
      if (this.notifications.Code.length > 0) {
        this.isHiddenWarning = false;
        this.textError = this.notifications.Code[0];
      }
      if (this.notifications.Name.length > 0) {
        this.isHiddenWarning = false;
        this.textError = this.notifications.Name[0];
      }
      if (this.notifications.Department.length > 0) {
        this.isHiddenWarning = false;
        this.textError = this.notifications.Department[0];
      }
      if (this.notifications.Email.length > 0) {
        this.isHiddenWarning = false;
        this.textError = this.notifications.Email[0];
      }
      if (this.notifications.AccountNumber.length > 0) {
        this.isHiddenWarning = false;
        this.textError = this.notifications.AccountNumber[0];
      }
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
          this.employee = {};
          this.autoNewEmployeeCode();
          debugger; // eslint-disable-line
        })
        .catch((errror) => {
          console.log(errror);
        });
    },

    /**------------------------------------------------------------------------
     * Sửa thông tin nhân viên
     * CreatedBy: LQNHAT(30/08/2021)
     */
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
          this.$set(self.employee, "EmployeeCode", res.data);
          self.employeeOriginalAdd.Gender = 1;
          self.employeeOriginalAdd.EmployeeCode = res.data;
          self.$nextTick(() => self.$refs.txtEmployeeCode.focus());
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
          // assign employee cho employeeOriginalEdit
          Object.assign(this.employeeOriginalEdit, this.employee);
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