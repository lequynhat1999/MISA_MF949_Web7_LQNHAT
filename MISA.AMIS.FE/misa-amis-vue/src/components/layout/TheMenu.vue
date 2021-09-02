<template>
  <div class="menu">
    <div class="logo-box">
      <div class="toggle-icon"></div>
      <div class="amis-icon"></div>
    </div>
    <div class="menu-content">
      <router-link to="/overview" class="nav-item" title="Tổng quan" exact-active-class="menu-active">
        <div class="nav-item-icon nav-item-overview"></div>
        <div class="nav-item-text">Tổng quan</div>
      </router-link>
      <router-link to="/employee" class="nav-item" title="Nhân viên" active-class="menu-active">
        <div class="nav-item-icon nav-item-money"></div>
        <div class="nav-item-text">Nhân viên</div>
      </router-link>
      <div class="nav-item" title="Tiền gửi">
        <div class="nav-item-icon nav-item-deposits"></div>
        <div class="nav-item-text">Tiền gửi</div>
      </div>
      <div class="nav-item" title="Mua hàng">
        <div class="nav-item-icon nav-item-purchase"></div>
        <div class="nav-item-text">Mua hàng</div>
      </div>
      <div class="nav-item" title="Bán hàng">
        <div class="nav-item-icon nav-item-sell"></div>
        <div class="nav-item-text">Bán hàng</div>
      </div>
      <div class="nav-item" title="Quản lý hóa đơn">
        <div class="nav-item-icon nav-item-bill"></div>
        <div class="nav-item-text">Quản lý hóa đơn</div>
      </div>
      <div class="nav-item" title="Kho">
        <div class="nav-item-icon nav-item-store"></div>
        <div class="nav-item-text">Kho</div>
      </div>
      <div class="nav-item" title="Công cụ dụng cụ">
        <div class="nav-item-icon nav-item-tools"></div>
        <div class="nav-item-text">Công cụ dụng cụ</div>
      </div>
      <div class="nav-item" title="Tài sản cố định">
        <div class="nav-item-icon nav-item-assets"></div>
        <div class="nav-item-text">Tài sản cố định</div>
      </div>
      <div class="nav-item" title="Thuế">
        <div class="nav-item-icon nav-item-tax"></div>
        <div class="nav-item-text">Thuế</div>
      </div>
      <div class="nav-item" title="Giá thành">
        <div class="nav-item-icon nav-item-price"></div>
        <div class="nav-item-text">Giá thành</div>
      </div>
      <div class="nav-item" title="Tổng hợp">
        <div class="nav-item-icon nav-item-synthetic"></div>
        <div class="nav-item-text">Tổng hợp</div>
      </div>
      <div class="nav-item" title="Ngân sách">
        <div class="nav-item-icon nav-item-budget"></div>
        <div class="nav-item-text">Ngân sách</div>
      </div>
      <div class="nav-item" title="Báo cáo">
        <div class="nav-item-icon nav-item-report"></div>
        <div class="nav-item-text">Báo cáo</div>
      </div>
      <div class="nav-item" title="Phân tích tài chính">
        <div class="nav-item-icon nav-item-finacial"></div>
        <div class="nav-item-text">Phân tích tài chính</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheMenu",
  data() {
    return {
      // active item
      isActive: true,
    };
  },
  methods: {
    /**------------------------------------------------------
     * active item menu
     * CreatedBy: LQNHAT(01/09/2021)
     */
    selectItemMenu() {
      this.isActive = !this.isActive;
    },
  },
};
</script>

<style>
@import "../../css/page/menu.css";
</style>