<template>
  <div class="modal-confirm-save" :class="{'hidden-popup-save': isHiddenPopupSave}">
    <div class="modal-content-save">
      <div class="content-confirm-save">
        <div class="title-popup flex">
          <div class="img-confirm-save"></div>
          <div class="text-confirm-save">
            Dữ liệu đã bị thay đổi. Bạn có muốn cất không?
          </div>
        </div>
        <div class="btn-popup-save flex">
          <div class="btn-cancel-save">
            <button class="btn-white" >
              <div class="text-add">Hủy</div>
            </button>
          </div>
          <div class="btn-no-save">
            <button class="btn-white">
              <div class="text-add">Không</div>
            </button>
          </div>
          <div class="btn-confirm-save">
            <button class="m-btn">
              <div class="text-add">Có</div>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BasePopupConfirmSave",
  data() {
    return {
      isHiddenPopupSave: true,
    }
  },
};
</script>

<style>
</style>