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
                      tabindex="1"
                      maxlength="255"
                      class="input-modal width-100"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      :title="errors[0]"
                      @blur="checkDuplicateEmployeeCode"
                    />
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
                      maxlength="255"
                      tabindex="2"
                      v-model="employee.FullName"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      :title="errors[0]"
                    />
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
                    ref="dateOfBirth"
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
                      tabindex="6"
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
                      :tabIndex="tabIndex"
                      :class="{
                        'border-red': errors.length > 0 ? true : false,
                      }"
                      v-model="employee.DepartmentId"
                      :title="errors[0]"
                    />
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
                    tabindex="7"
                    v-model="employee.IdentityNumber"
                  />
                </div>
                <div class="input width-35">
                  <div class="text-modal">
                    <b>Ngày cấp</b>
                  </div>
                  <datepicker
                    class="width-100"
                    ref="identityDate"
                    v-model="employee.IdentityDate"
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
                    maxlength="255"
                    tabindex="4"
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
                    tabindex="9"
                    class="input-modal width-100"
                    maxlength="255"
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
                  tabindex="10"
                  class="input-modal width-100"
                  maxlength="255"
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
                tabindex="11"
                class="input-modal width-100"
                maxlength="255"
                v-model="employee.PhoneNumber"
              />
            </div>
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>ĐT cố định</b>
              </div>
              <input
                type="text"
                tabindex="12"
                class="input-modal width-100"
                maxlength="255"
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
                  tabindex="13"
                  class="input-modal width-100"
                  maxlength="255"
                  v-model="employee.Email"
                  :class="{
                    'border-red': errors.length > 0 ? true : false,
                  }"
                  :title="errors[0]"
                />
              </ValidationProvider>
            </div>
          </div>
          <div class="row-bellow width-100 flex">
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Tài khoản ngân hàng</b>
              </div>
              <input
                type="text"
                tabindex="14"
                class="input-modal width-100"
                maxlength="255"
                v-model="employee.AccountNumber"
              />
            </div>
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Tên ngân hàng</b>
              </div>
              <input
                type="text"
                tabindex="15"
                class="input-modal width-100"
                maxlength="255"
                v-model="employee.BankName"
              />
            </div>
            <div class="input pdr-8 width-25">
              <div class="text-modal">
                <b>Chi nhánh</b>
              </div>
              <input
                type="text"
                tabindex="16"
                class="input-modal width-100"
                maxlength="255"
                v-model="employee.BranchName"
              />
            </div>
          </div>
        </div>
      </ValidationObserver>
      <div class="paging-modal flex">
        <div class="btn-cancel-modal">
          <button class="btn-white" @click="closeModal" tabindex="17">
            <div class="text-add">Hủy</div>
          </button>
        </div>
        <div class="btn-save">
          <button
            class="btn-white"
            tabindex="18"
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
            tabindex="19"
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
        :isError="isError"
        @closeWarning="closeWarning"
      />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
import { extend } from "vee-validate";
import { required, email} from "vee-validate/dist/rules";
import PopupConfirmSave from "../components/base/BasePopupConfirmSave.vue";
import Combobox from "../components/base/BaseCombobox.vue";
import PopupWarning from "../components/base/BasePopupWarning.vue";
import { URL_API, MESSAGE, MODE } from "../js/const.js";
import stringInject from "stringinject";

// custom rule required code
extend("requiredCode", {
  ...required,
  message: MESSAGE.REQUIRED_CODE,
});

// custom rule required fullname
extend("requiredName", {
  ...required,
  message: MESSAGE.REQUIRED_NAME,
});

// custom rule check email
extend("checkEmail", {
  ...email,
  message: MESSAGE.CHECK_EMAIL,
});

// custom rule check required department
extend("requiredDepartment", {
  ...required,
  message: MESSAGE.REQUIRED_DEPARTMENT,
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
      // mã nhân viên trùng
      employeeCodeDuplicate: "",
      // Id của nhân viên
      employeeId: "",
      // mode cho modal : 0 là add - 1 là edit
      mode: MODE.ADD,
      // mảng chứa lỗi khi validate
      notifications: [],
      // trạng thái popup warning
      isHiddenWarning: true,
      // lỗi validate
      textError: "",
      // check trạng thái khi validate duplicate
      isDuplicate: false,
      // check trạng thái img của popup
      isError: true,
      // tabindex của combobox
      tabIndex: 3,
    };
  },
  mounted() {
    // set tabindex cho 2 trường datepicker
    this.setTabindex("dateOfBirth", 5);
    this.setTabindex("identityDate", 8);
  },
  methods: {
    /**--------------------------------------------
     * Hàm check mode
     * CreateBy : LQNHAT(28/08/2021)
     */
    show(mode, id) {
      this.mode = mode;
      this.employeeId = id;
      // mode == 0 thì sinh mã mới
      if (mode == MODE.ADD) {
        this.employee = {};
        this.employee.Gender = 1;
        this.autoNewEmployeeCode();
      }
      // mode == 1 thì bind data lên form
      else {
        this.bindDataToForm();
      }
    },

    /**-----------------------------------------------------------------
     * Hàm sinh tự động mã nhân viên
     * CreateBy: LQNhat (28/08/2021)
     */
    autoNewEmployeeCode() {
      let self = this;
      try {
        axios
          .get(URL_API.API_EMPLOYEE + "/newEmployeeCode")
          .then((res) => {
            if (res.status == 200) {
              // gán mã mới
              this.$set(self.employee, "EmployeeCode", res.data);
              // gán value cho object để so sánh
              self.employeeOriginalAdd.Gender = 1;
              self.employeeOriginalAdd.EmployeeCode = res.data;
              // focus vào ô mã
              self.$nextTick(() => self.$refs.txtEmployeeCode.focus());
            } else {
              this.$toast.error(MESSAGE.ERROR_NEW_CODE, {
                timeout: 2000,
              });
            }
          })
          .catch((err) => {
            console.log(err);
          });
      } catch (error) {
        console.log(error);
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
          timeout: 2000,
        });
      }
    },

    /**---------------------------------------------------------
     * Hàm bind dữ liệu từ table lên form thông tin chi tiết
     * CreateBy: LQNhat(28/08/2021)
     */
    bindDataToForm() {
      var self = this;
      try {
        // call api
        axios
          .get(URL_API.API_EMPLOYEE + "/" + self.employeeId)
          .then((res) => {
            if (res.status == 200) {
              self.employee = res.data;
              // format date về đúng định dạng
              self.employee.DateOfBirth = self.formatDate(res.data.DateOfBirth);
              self.employee.IdentityDate = self.formatDate(
                res.data.IdentityDate
              );
              // assign employee cho employeeOriginalEdit
              Object.assign(this.employeeOriginalEdit, this.employee);
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

    /*--------------------------------------------------
     * Hàm bắt sự kiện khi click btn Cất
     * CreatedBy : LQNHAT(28/08/2021)
     */
    saveBtnClick() {
      // set error cho EmployeeCode
      if (this.isDuplicate == true) {
        this.$refs.form_employee.setErrors({
          Code: [MESSAGE.CHECK_DUPLICATE_CODE],
        });
        this.isDuplicate = false;
        this.isHiddenWarning = false;
        this.isError = false;
        this.textError = stringInject(MESSAGE.ERROR_DUPLICATE_CODE, [
          this.employeeCodeDuplicate,
        ]);
        return;
      }
      // đóng popup
      this.$refs.popupConfirmSave.closePopupConfirmSave();
      // validate cả form
      this.$refs.form_employee.validate().then((success) => {
        if (!success) {
          // validate hiện popup warning
          this.showPopupWarning();
          return;
        }
        // nếu không có lỗi
        if (this.mode == MODE.ADD) {
          //add nv
          this.addEmployee();
          // clear object
          this.employee = {};
          // đóng form
          this.$emit("closeForm");
          // reset error
          this.$refs.form_employee.reset();
        } else {
          //edit nv
          this.editEmployee();
          // đóng form
          this.$emit("closeForm");
          // reset error
          this.$refs.form_employee.reset();
        }
      });
    },

    /**-----------------------------------------------------------
     * Bắt sự kiện nút cất và thêm
     * CreatedBy: LQNHAT(29/08/2021)
     */
    saveAddBtnClick() {
      // set error cho EmployeeCode
      if (this.isDuplicate == true) {
        this.$refs.form_employee.setErrors({
          Code: [MESSAGE.CHECK_DUPLICATE_CODE],
        });
        this.isDuplicate = false;
        this.isHiddenWarning = false;
        this.isError = false;
        this.textError = stringInject(MESSAGE.ERROR_DUPLICATE_CODE, [
          this.employeeCodeDuplicate,
        ]);
        return;
      }
      // đóng popup
      this.$refs.popupConfirmSave.closePopupConfirmSave();
      // validate cả form
      this.$refs.form_employee.validate().then((success) => {
        if (!success) {
          // validate hiện popup warning
          this.showPopupWarning();
          return;
        }
        // nếu không có lỗi
        if (this.mode == MODE.ADD) {
          //add nv
          this.addEmployee();
          // reset error
          this.$refs.form_employee.reset();
          // gán mode = 0 để add
          this.mode = MODE.ADD;
          debugger; // eslint-disable-line
        } else {
          //edit nv
          this.editEmployee();
          // reset error
          this.$refs.form_employee.reset();
          // clear object
          this.employee = {};
          // sinh mã mới
          this.autoNewEmployeeCode();
          // gán mode = 0 để add
          this.mode = MODE.ADD;
          this.employee.Gender = 1;
          debugger; // eslint-disable-line
        }
      });
    },

    /**
     * Check trùng mã nhân viên
     * CreatedBy: LQNHAT(31/08/2021)
     */
    checkDuplicateEmployeeCode() {
      var self = this;
      try {
        // binding data
        axios
          .get(URL_API.API_EMPLOYEE)
          .then((res) => {
            if (res.status == 200) {
              self.employees = res.data;
              // foreach để tìm giá trị trùng
              self.employees.forEach((item) => {
                if (
                  self.employee.EmployeeCode == item.EmployeeCode &&
                  self.employee.EmployeeId != item.EmployeeId
                ) {
                  this.isDuplicate = true;
                  this.employeeCodeDuplicate = item.EmployeeCode;
                }
              });
            } else {
              this.$toast.error(MESSAGE.ERROR_LOAD_DATA, {
                timeout: 2000,
              });
            }
          })
          .catch((res) => {
            console.log(res);
          });
      } catch (error) {
        console.log(error);
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
          timeout: 2000,
        });
      }
    },

    /**-----------------------------------------------------------
     * Hiển thị popup warning
     * CreatedBy: LQNHAT(30/08/2021)
     */
    showPopupWarning() {
      // lấy ra mảng error khi validate cả form
      this.notifications = this.$refs.form_employee.errors;
      console.log(this.notifications);
      // check length
      if (this.notifications.Code.length > 0) {
        this.isHiddenWarning = false;
        this.isError = true;
        this.textError = this.notifications.Code[0];
      }
      if (this.notifications.Name.length > 0) {
        this.isHiddenWarning = false;
        this.isError = true;
        this.textError = this.notifications.Name[0];
      }
      if (this.notifications.Department.length > 0) {
        this.isHiddenWarning = false;
        this.isError = true;
        this.textError = this.notifications.Department[0];
      }
      if (this.notifications.Email.length > 0) {
        this.isHiddenWarning = false;
        this.isError = true;
        this.textError = this.notifications.Email[0];
      }
    },

    /*------------------------------------------------------------------------
     * Hàm thêm mới nhân viên
     * CreatedBy : LQNHAT(28/08/2021)
     */
    addEmployee() {
      var self = this;
      try {
        axios
          .post(URL_API.API_EMPLOYEE, self.employee)
          .then((res) => {
            if (res.status == 201) {
              // load lại table
              self.$emit("reloadTableAndFilter");
              this.$toast.success(MESSAGE.SUCCESS_ADD_EMPLOYEE, {
                timeout: 2000,
              });
              // clear object
              this.employee = {};
              // sinh mã mới
              this.autoNewEmployeeCode();
              this.employee.Gender = 1;
              // debugger; // eslint-disable-line
            } else {
              this.$toast.error(MESSAGE.ERROR_ADD_EMPLOYEE, {
                timeout: 2000,
              });
            }
          })
          .catch((errror) => {
            console.log(errror);
          });
      } catch (error) {
        console.log(error);
        this.$toast.error(MESSAGE.EXCEPTION_MSG, {
          timeout: 2000,
        });
      }
    },

    /**------------------------------------------------------------------------
     * Sửa thông tin nhân viên
     * CreatedBy: LQNHAT(30/08/2021)
     */
    editEmployee() {
      var self = this;
      try {
        axios
          .put(URL_API.API_EMPLOYEE + "/" + self.employeeId, self.employee)
          .then((res) => {
            if (res.status == 200) {
              console.log(res);
              // load lại table
              self.$emit("reloadTableAndFilter");
              this.$toast.success(MESSAGE.SUCCESS_EDIT_EMPLOYEE, {
                timeout: 2000,
              });
            } else {
              this.$toast.error(MESSAGE.ERROR_EDIT_EMPLOYEE, {
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

    /**---------------------------------------------------
     * Hàm nhân bản nhân viên
     * CreatedBy:LQNHAT(29/08/2021)
     */
    cloneToEmployee(employee) {
      this.employee = employee;
      // this.employee.EmployeeId = null;
      this.autoNewEmployeeCode();
      this.mode = MODE.ADD;
      this.employee.EmployeeId = "00000000-0000-0000-0000-000000000000";
    },

    /**------------------------------------------------------------------------------
     * Sự kiện click nút X
     * CreatedBy: LQNHAT(30/08/2021)
     */
    closeFormDetail() {
      // check mode
      if (this.mode == MODE.ADD) {
        if (
          JSON.stringify(Object.values(this.employeeOriginalAdd)) ===
          JSON.stringify(Object.values(this.employee))
        ) {
          // close form
          this.$emit("closeForm");
          // reset error
          this.$refs.form_employee.reset();
        } else {
          // mở popup
          this.$refs.popupConfirmSave.openPopupConfirmSave();
        }
      } else {
        if (
          JSON.stringify(Object.values(this.employeeOriginalEdit)) ===
          JSON.stringify(Object.values(this.employee))
        ) {
          // close form
          this.$emit("closeForm");
          // reset error
          this.$refs.form_employee.reset();
        } else {
          // mở popup
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

    /**----------------------------------------------------------
     * Hàm format ngày tháng năm trên form chỉnh sửa
     * CreateBy:LQNhat(28/08/2021)
     */
    formatDate(date) {
      if (date) {
        return moment(String(date)).format("yyyy-MM-DD");
      }
    },

    /**-----------------------------------------------------------------
     * Set tabindex cho trường datepicker
     * CreatedBy:LQNHAT(01/09/2021)
     */
    setTabindex(refName, tab) {
      this.$refs[refName].$refs.input.setAttribute("tabindex", tab);
    },
  },
};
</script>

<style>
</style>