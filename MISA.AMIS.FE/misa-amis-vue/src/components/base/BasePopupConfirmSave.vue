<template>
  <div class="modal-confirm-save" :class="{'hidden-popup-save': this.isHiddenPopupSave}">
    <div class="modal-content-save">
      <div class="content-confirm-save">
        <div class="title-popup flex">
          <div class="img-confirm-save"></div>
          <div class="text-confirm-save">
            {{msg}}
          </div>
        </div>
        <div class="btn-popup-save flex">
          <div class="btn-cancel-save">
            <button class="btn-white" >
              <div class="text-add" @click="closePopupConfirmSave">Hủy</div>
            </button>
          </div>
          <div class="btn-no-save">
            <button class="btn-white">
              <div class="text-add" @click="closePopupAndForm">Không</div>
            </button>
          </div>
          <div class="btn-confirm-save">
            <button class="m-btn" @click="confirmSave">
              <div class="text-add">Có</div>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { MESSAGE } from "../../js/const.js"
export default {
  name: "BasePopupConfirmSave",
  data() {
    return {
      isHiddenPopupSave: true,
      msg: MESSAGE.CHECK_DATA_CHANGE,
    }
  },
  methods: {
    /**----------------------------------------------------
     * Bắt sự kiện open popup
     * CreatedBy: LQNHAT(30/08/2021)
     */
    openPopupConfirmSave()
    {
      this.isHiddenPopupSave = false;
    },

    /**--------------------------------------------------------
     * Bắt sự kiện đóng popup
     * CreatedBy: LQNHAT(30/08/2021)
     */
    closePopupConfirmSave()
    {
      this.isHiddenPopupSave = true;
    },

    /**------------------------------------------------------------
     * Đóng popup và đóng form
     * CreatedBy: LQNHAT(30/08/2021)
     */
    closePopupAndForm()
    {
      this.closePopupConfirmSave();
      this.$emit("closeModal");
    },

    /**-------------------------------------------------------
     * Thực hiện cất nhân viên
     * CreatedBy: LQNHAT(30/08/2021)
     */
    confirmSave()
    {
      this.$emit("saveBtnClick");
    }
  },
};
</script>

<style>
</style>