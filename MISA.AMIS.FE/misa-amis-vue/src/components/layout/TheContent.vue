<template>
  <div class="content">
    <employee-list/>
  </div>
</template>

<script>
import EmployeeList from "../../view/EmployeeList.vue";
export default {
    name:"TheContent",
    components:{
      EmployeeList
    }
}
</script>

<style>
.content{
  width: calc(100% - 178px);
  height: calc(100vh - 48px);
  float: left;
}
</style>