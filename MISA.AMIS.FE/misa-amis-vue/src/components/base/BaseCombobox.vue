<template>
  <div class="combobox" @click="toggleCombobox">
    <div class="combobox-search flex">
      <input type="text" class="width-100" v-model="keysearch" />
      <div class="combobox-icon" :class="{ rotate: !isHiddenCombobox }">
        <div class="btn-combobox"></div>
      </div>
    </div>
    <div class="combobox-data" :class="{ 'hidden-combobox': isHiddenCombobox }">
      <table>
        <thead>
          <tr>
            <th>Mã đơn vị</th>
            <th>Tên đơn vị</th>
          </tr>
        </thead>
        <tbody v-if="value != null">
          <tr
            v-for="(department, index) in departments"
            :key="index"
            @click="selectDepartment(index)"
            :class="{
              'combobox-active':
                item.DepartmentCode == department.DepartmentCode ? true : false,
            }"
          >
            <td>{{ department.DepartmentCode }}</td>
            <td>{{ department.DepartmentName }}</td>
          </tr>
        </tbody>
        <tbody v-else-if="value == null">
          <tr
            v-for="(department, index) in options"
            :key="index"
            @click="selectDepartment(index)"
          >
            <td>{{ department.DepartmentCode }}</td>
            <td>{{ department.DepartmentName }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Combobox",
  props: ["value"],
  data() {
    return {
      // trạng thái của combobox
      isHiddenCombobox: true,
      // data departments
      departments: [],
      // department theo index
      item: {},
      options: [],
      keysearch: "",
    };
  },
  created() {
    this.getDepartment();
  },
  watch: {
    keysearch() {
      this.searchDepartment();
    },
    value() {
      this.setValueDepartment();
    },
  },
  methods: {
    /*----------------------------------------------------
     * Bắt sự kiện click vào combobox
     * CreatedBy: LQNHAT(30/08/2021)
     */
    toggleCombobox() {
      this.isHiddenCombobox = !this.isHiddenCombobox;
    },

    /**-------------------------------------------------------------
     * Lấy ra tất cả đơn vị
     * CreatedBy:LQNHAT(30/08/2021)
     */
    getDepartment() {
      // var self = this;
      axios.get(`https://localhost:44383/api/v1/departments`).then((res) => {
        this.departments = res.data;
        this.options = res.data;
        console.log(this.departments);
      });
    },

    /**-----------------------------------------------------------
     * Select department
     * CreatedBy: LQNHAT(30/08/2021)
     */
    selectDepartment(index) {
      if (index >= 0 && index <= this.departments.length) {
        this.item = this.departments[index];
        this.$emit("selectedDepartment", this.item.DepartmentId);
        this.keysearch = this.item.DepartmentName;
      }
    },

    /**-----------------------------------------------------------------
     * Hàm set value department khi mở form sửa
     * CreatedBy: LQNHAT(30/08/2021)
     */
    setValueDepartment() {
      let flag = true;
      this.options.forEach((department, index) => {
        if (department.DepartmentId == this.value) {
          this.selectDepartment(index);
          flag = false;
        }
      });
      if (flag) {
        this.keysearch = "";
      }
    },

    /**---------------------------------------------------------------
     * Tìm kiếm đơn vị
     * CreatedBy : LQNHAT(30/08/2021)
     */
    searchDepartment() {
      if (this.keysearch != "") {
        this.isHiddenCombobox = false;
        this.departments = [];
        this.options.forEach((department) => {
          if (
            department.DepartmentCode.includes(this.keysearch) ||
            department.DepartmentName.includes(this.keysearch)
          ) {
            this.departments.push(department);
            console.log(this.departments);
          }
        });
      } else {
        this.isHiddenCombobox = false;
      }
    },

    /**----------------------------------------------------------------------
     * Hàm check event khi click ra bên ngoài combobox
     * CreatedBy: LQNHAT(28/08/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.isHiddenCombobox = true;
        this.isRotate = false;
      }
    },
  },
  mounted() {
    document.addEventListener("click", this.close);
  },
};
</script>

<style>
</style>