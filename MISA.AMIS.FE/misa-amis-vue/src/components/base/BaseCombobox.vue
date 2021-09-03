<template>
  <div class="combobox">
    <div class="combobox-search flex">
      <input type="text" class="width-100" v-model="keysearch"  />
      <div
        class="combobox-icon"
        :class="{ rotate: !isHiddenCombobox }"
        @click="toggleCombobox"
      >
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
        <tbody>
          <tr
            v-for="(department, index) in departments"
            :key="index"
            @click="selectDepartment(index)"
            :class="{
              'combobox-active':
                currentDepartmentId == department.DepartmentId ? true : false,
            }"
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
      // data departments động
      departments: [],
      // data departments tĩnh
      options: [],
      // text input
      keysearch: null,
      // departmentId hiện tại
      currentDepartmentId: "",
      // check có đang search hay k
      isSearching: true,
    };
  },
  created() {
     this.getDepartment();
  },
  mounted() {
    document.addEventListener("click", this.close);
  },
  watch: {
    keysearch() {
      this.searchByKeysearch();
    },
    value()
    {
     this.setValueDepartment();
    }
  },
  methods: {
    /*----------------------------------------------------
     * Bắt sự kiện click vào combobox
     * CreatedBy: LQNHAT(30/08/2021)
     */
    toggleCombobox() {
      this.isHiddenCombobox = !this.isHiddenCombobox;
      this.getDepartment();
    },

    /**-------------------------------------------------------------
     * Lấy ra tất cả đơn vị
     * CreatedBy:LQNHAT(30/08/2021)
     */
    getDepartment() {
      var self = this;
      axios.get(`https://localhost:44383/api/v1/departments`).then((res) => {
        self.departments = res.data;
        self.options = res.data;
      });
    },

    /**----------------------------------------------------------------------
     * Select department
     * CreatedBy: LQNHAT(31/08/2021)
     */
    selectDepartment(index) {
      this.currentDepartmentId = this.departments[index].DepartmentId;
      this.keysearch = this.departments[index].DepartmentName;
      // emit value sang cho v-model
      this.$emit("input", this.currentDepartmentId);
      this.isSearching = false;
    },

    /**-----------------------------------------------------------------------
     * Search theo keysearch
     * CreatedBy: LQNHAT(31/08/2021)
     */
    searchByKeysearch() {
      if (this.isSearching) {
        // mở dropdown
        this.isHiddenCombobox = false;
        this.isRotate = true;
      } else {
        // đóng dropdown
        this.isHiddenCombobox = true;
        this.isRotate = false;
      }
      // check nếu keysearch có giá trị
      if (this.keysearch != null && this.keysearch.length > 0) {
        this.departments = [];
        // filter
        this.options.forEach((element) => {
          if (
            element.DepartmentName.toLowerCase().includes(
              this.keysearch.toLowerCase()
            ) ||
            element.DepartmentCode.toLowerCase().includes(
              this.keysearch.toLowerCase()
            )
          ) {
            this.departments.push(element);
          }
        });
        this.isSearching = true;
      } else {
        // nếu keysearch null thì clear
        this.currentDepartmentId = null;
        this.keysearch = null;
        this.departments = this.options;
        this.isSearching = true;
      }
    },

    /**---------------------------------------------------------
     * Bind data departmentName lên input
     * CreatedBy: LQNHAT(31/08/2021)
     */
    setValueDepartment() {
      let flag = false;
      // filter trong mảng options
      this.options.forEach((element) => {
        if (element.DepartmentId == this.value) {
          this.currentDepartmentId = this.value;
          this.keysearch = element.DepartmentName;
          flag = true;
        }
      });
      // nếu departmentId null
      if (!flag) {
        this.currentDepartmentId = null;
        this.keysearch = null;
      }
      this.isSearching = false;
    },

    /**----------------------------------------------------------------------
     * Hàm check event khi click ra bên ngoài combobox
     * CreatedBy: LQNHAT(28/08/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        // check currentDepartmentId có giá trị
        if(this.currentDepartmentId != null)
        {
          let flag = false;
          // gán value cho keysearch
          this.options.forEach(element => {
            if(element.DepartmentId == this.currentDepartmentId)
            {
              this.keysearch = element.DepartmentName;
              flag = true;
              this.isHiddenCombobox = true;
            }
          });
          // nếu không thì keysearch null
          if(!flag)
          {
            this.currentDepartmentId = null;
            this.keysearch = null;
          }
        }
        else
        {
          this.keysearch = null;
        }
        this.isHiddenCombobox = true;
      }
    },
  },
};
</script>

<style>
</style>