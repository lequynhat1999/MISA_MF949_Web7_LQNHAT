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
            Bạn có thực sự muốn xóa Nhân viên có mã nhân viên {{ employee.EmployeeCode }} không?
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
    },

    confirmDelete() {
      var self = this;
      axios
        .delete(`https://localhost:44383/api/v1/employees/${this.employeeId}`)
        .then((res) => {
          self.$toast.success("Xóa nhân viên thành công", {
            timeout: 2000,
          });
          self.isHiddenDelete = true;
          self.$emit("reloadTableAndFilter");
          console.log(res);
        });
    },
  },
};
</script>

<style>
</style>