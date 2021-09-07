<template>
  <div
    class="modal-confirm-delete"
    :class="{ 'hidden-delete': isHiddenDelete }"
  >
    <div class="modal-content-save">
      <div class="content-confirm-save">
        <div class="title-popup title-popup-delete flex">
          <div class="box-img"><div class="img-confirm-delete"></div></div>
          <div class="text-confirm-delete">
            {{ msg }}
          </div>
        </div>
        <div class="btn-popup-save flex">
          <div class="btn-cancel-save">
            <button class="btn-white" @click="cancelDelete">
              <div class="text-add">Không</div>
            </button>
          </div>
          <div class="btn-confirm-save">
            <button class="m-btn" @click="confirmDelete">
              <div class="text-add">Có</div>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { URL_API, MESSAGE } from "../../js/const.js";
import stringInject from "stringinject";
export default {
  name: "BasePopupConfirmSave",
  data() {
    return {
      // trạng thái của popup
      isHiddenDelete: true,
      // đối tượng nhân viên
      employee: {},
      // id nhân viên
      employeeId: "",
      msg: "",
    };
  },
  methods: {
    /**-----------------------------------
     * Bắt sự kiện đóng popup delete
     * CreatedBy : LQNHAT(29/08/2021)
     */
    cancelDelete() {
      this.isHiddenDelete = true;
    },

    /**--------------------------------
     * Sự kiện mở popup delete
     * CreatedBy: LQNHAT(29/08/2021)
     */
    openPopupDelete(employee) {
      this.isHiddenDelete = false;
      this.employee = employee;
      this.employeeId = employee.EmployeeId;
      this.msg = stringInject(MESSAGE.CONFIRM_DELETE, [employee.EmployeeCode]);
    },

    /**------------------------------------------------------------------------
     * Xác nhận xóa nhân viên
     * CreatedBy: LQNHAT(29/08/2021)
     */
    confirmDelete() {
      var self = this;
      try {
        axios
          .delete(URL_API.API_EMPLOYEE + "/" + self.employeeId)
          .then((res) => {
            if (res.status == 200) {
              self.$toast.success(MESSAGE.SUCCESS_DELETE, {
                timeout: 2000,
              });
              self.isHiddenDelete = true;
              // load lại table
              self.$emit("reloadTableAndFilter");
            }
            else
            {
              this.$toast.error(MESSAGE.ERROR_DELETE, {
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
  },
};
</script>

<style>
</style>