<template>
<div class="modal-confirm-save" :class="{'hidden-warning' : isHiddenWarning}">
    <div class="modal-content-save">
      <div class="content-confirm-save">
        <div class="title-popup flex">
          <div class="img-warning"></div>
          <div class="text-confirm-save">
            {{textError}}
          </div>
        </div>
        <div class="btn-popup-save">
          <div class="btn-cancel-warning">
            <button class="m-btn" @click="closeWarning">
              <div class="text-add">Đóng</div>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>  
</template>

<script>
export default {
    name:"PopupWarning",
    props:["isHiddenWarning","textError"],
    methods: {
        closeWarning()
        {
            this.$emit("closeWarning");
        }
    },
}
</script>

<style>

</style>