<template>
  <div class="text-employee">{{this.title}}</div>
</template>

<script>
export default {
    name:"BaseTitle",
    props:["title"]
}
</script>

<style>
.text-employee
{
    font-size: 24px;
    font-weight: 700;
    color: #111;
    margin-top: 26px;
    margin-left: 21px;
}
</style>