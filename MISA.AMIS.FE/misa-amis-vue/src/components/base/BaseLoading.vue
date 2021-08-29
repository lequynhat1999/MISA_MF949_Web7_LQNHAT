<template>
  <div class="base-loading" :class="{ loading: isLoading }">
    <img
      src="../../assets/img/loading.svg"
      :class="{ 'hidden-img': !isLoading }"
    />
  </div>
</template>

<script>
export default {
  name: "BaseLoading",
  props: ["isLoading"],
};
</script>

<style>
.hidden-img {
  display: none;
}

.loading {
  position: fixed;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1111;
  -webkit-animation: spin 2s linear infinite;
  animation: spin 2s linear infinite;
}

/* Safari */
@-webkit-keyframes spin {
  0% {
    -webkit-transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(360deg);
  }
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>