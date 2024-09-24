<template>
    <WideDiv>
      
      <div class="">

<div class="table-scroll">
    <div class="container-fluid">

        <!-- start page title -->
        <div class="row">
            <div class="col-12">
                <div class="page-title-box d-flex align-items-center justify-content-between">
                    <h4 class="mb-0 font-size-18">Item</h4>

                    <!-- <div class="page-title-right">
                        <ol class="breadcrumb m-0">
                            <li class="breadcrumb-item">Item</li>
                            <li class="breadcrumb-item active">Item</li>
                        </ol>
                    </div> -->

                </div>
            </div>
        </div>
        <!-- end page title -->

        <div class="row">
            <div class="col-lg-3">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title mb-4">Filter</h4>

                        <div>
                            <h5 class="font-size-14 mb-3">Drink</h5>
                            <ul class="list-unstyled product-list">
                                <li><a href="#"><i class="mdi mdi-chevron-right mr-1"></i> Hort Drink</a></li>
                                <li><a href="#"><i class="mdi mdi-chevron-right mr-1"></i> Ice</a></li>
                                <li><a href="#"><i class="mdi mdi-chevron-right mr-1"></i> Smoothie</a></li>
                                <li><a href="#"><i class="mdi mdi-chevron-right mr-1"></i> Fast food</a></li>
                            </ul>
                        </div>
                        <!-- <div class="mt-4 pt-3">
                            <h5 class="font-size-14 mb-3">Price</h5>
                            <input type="text" id="pricerange">
                        </div> -->

                        <!-- <div class="mt-4 pt-3">
                            <h5 class="font-size-14 mb-3">Discount</h5>
                            <div class="custom-control custom-checkbox mt-2">
                                <input type="checkbox" class="custom-control-input" id="productdiscountCheck1">
                                <label class="custom-control-label" for="productdiscountCheck1">Less than 10%</label>
                            </div>
                            <div class="custom-control custom-checkbox mt-2">
                                <input type="checkbox" class="custom-control-input" id="productdiscountCheck2">
                                <label class="custom-control-label" for="productdiscountCheck2">10% or more</label>
                            </div>
                            <div class="custom-control custom-checkbox mt-2">
                                <input type="checkbox" class="custom-control-input" id="productdiscountCheck3" checked>
                                <label class="custom-control-label" for="productdiscountCheck3">20% or more</label>
                            </div>
                            <div class="custom-control custom-checkbox mt-2">
                                <input type="checkbox" class="custom-control-input" id="productdiscountCheck4">
                                <label class="custom-control-label" for="productdiscountCheck4">30% or more</label>
                            </div>
                            <div class="custom-control custom-checkbox mt-2">
                                <input type="checkbox" class="custom-control-input" id="productdiscountCheck5">
                                <label class="custom-control-label" for="productdiscountCheck5">40% or more</label>
                            </div>
                            <div class="custom-control custom-checkbox mt-2">
                                <input type="checkbox" class="custom-control-input" id="productdiscountCheck6">
                                <label class="custom-control-label" for="productdiscountCheck6">50% or more</label>
                            </div>
                        </div> -->

                        <!-- <div class="mt-4 pt-3">
                            <h5 class="font-size-14 mb-3">Customer Rating</h5>
                            <div>
                                <div class="custom-control custom-checkbox mt-2">
                                    <input type="checkbox" class="custom-control-input" id="productratingCheck1">
                                    <label class="custom-control-label" for="productratingCheck1">4 <i class="bx bx-star text-warning"></i>  & Above</label>
                                </div>
                                <div class="custom-control custom-checkbox mt-2">
                                    <input type="checkbox" class="custom-control-input" id="productratingCheck2">
                                    <label class="custom-control-label" for="productratingCheck2">3 <i class="bx bx-star text-warning"></i>  & Above</label>
                                </div>
                                <div class="custom-control custom-checkbox mt-2">
                                    <input type="checkbox" class="custom-control-input" id="productratingCheck3">
                                    <label class="custom-control-label" for="productratingCheck3">2 <i class="bx bx-star text-warning"></i>  & Above</label>
                                </div>
                                <div class="custom-control custom-checkbox mt-2">
                                    <input type="checkbox" class="custom-control-input" id="productratingCheck4">
                                    <label class="custom-control-label" for="productratingCheck4">1 <i class="bx bx-star text-warning"></i></label>
                                </div>
                                
                            </div>
                        </div> -->
                    </div>
                </div>
                
            </div>
            <div class="col-lg-9">
                    
                <div class="row mb-3">
                    <div class="col-xl-4 col-sm-6">
                        <div class="mt-2">
                            <h5>Coffee</h5>
                        </div>
                    </div>
                    <div class="col-lg-8 col-sm-6">
                        <!-- <form class="mt-4 mt-sm-0 float-sm-right form-inline">
                            <div class="search-box mr-2">
                                <div class="position-relative">
                                    <input type="text" class="form-control border-0" placeholder="Search...">
                                    <i class="bx bx-search-alt search-icon"></i>
                                </div>
                            </div>
                            <ul class="nav nav-pills product-view-nav">
                                <li class="nav-item">
                                    <a class="nav-link active" href="#"><i class="bx bx-grid-alt"></i></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="bx bx-list-ul"></i></a>
                                </li>
                            </ul>
                            
                            
                        </form> -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-xl-4 col-sm-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="product-img position-relative">
                                    <div class="avatar-sm product-ribbon">
                                        <span class="avatar-title rounded-circle  bg-primary">
                                            - 25 %
                                        </span>
                                    </div>
                                    <img src="@/assets/images/icelatte.jpg" alt="" class="img-fluid mx-auto d-block">
                                </div>
                                <div class="mt-4 text-center">
                                    <h5 class="mb-3 text-truncate"><a href="#" class="text-dark">Ice Latte</a></h5>
                                    
                                    <p class="text-muted">
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                    </p>
                                    <h5 class="my-0"><span class="text-muted mr-2"></span> <b>$2</b></h5>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-sm-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="product-img position-relative">
                                    <img src="@/assets/images/Cappuccino.jpg" alt="" class="img-fluid mx-auto d-block">
                                </div>
                                <div class="mt-4 text-center">
                                    <h5 class="mb-3 text-truncate"><a href="#" class="text-dark">Cappuccino</a></h5>
                                    
                                    <p class="text-muted">
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star"></i>
                                    </p>
                                    <h5 class="my-0"><span class="text-muted mr-2"></span> <b>$2</b></h5>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-sm-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="product-img position-relative">
                                    <div class="avatar-sm product-ribbon">
                                        <span class="avatar-title rounded-circle  bg-primary">
                                            - 20 %
                                        </span>
                                    </div>
                                    <img src="@/assets/images/Vanilla Sweet Cream.jpg" alt="" class="img-fluid mx-auto d-block">
                                </div>
                                <div class="mt-4 text-center">
                                    <h5 class="mb-3 text-truncate"><a href="#" class="text-dark">Vanilla Sweet Cream</a></h5>
                                    
                                    <p class="text-muted">
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star"></i>
                                    </p>
                                    <h5 class="my-0"><span class="text-muted mr-2"></span> <b>$2</b></h5>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-sm-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="product-img position-relative">

                                    
                                    <img src="@/assets/images/Americano.jpg" alt="" class="img-fluid mx-auto d-block">
                                </div>
                                <div class="mt-4 text-center">
                                    <h5 class="mb-3 text-truncate"><a href="#" class="text-dark"></a>Americano</h5>
                                    
                                    <p class="text-muted">
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star"></i>
                                    </p>
                                    <h5 class="my-0"><span class="text-muted mr-2"></span> <b>$2</b></h5>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-sm-6">
                        <div class="card">
                            <div class="card-body">
                                
                                <div class="product-img position-relative">
                                    <div class="avatar-sm product-ribbon">
                                        <span class="avatar-title rounded-circle  bg-primary">
                                            - 22 %
                                        </span>
                                    </div>
                                    <img src="@/assets/images/frappe.jpg" alt="" class="img-fluid mx-auto d-block">
                                </div>
                                <div class="mt-4 text-center">
                                    <h5 class="mb-3 text-truncate"><a href="#" class="text-dark">IT Frappe</a></h5>
                                    
                                    <p class="text-muted">
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star"></i>
                                    </p>
                                    <h5 class="my-0"><span class="text-muted mr-2"></span> <b>$3</b></h5>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-4 col-sm-6">
                        <div class="card">
                            <div class="card-body">
                                <div class="product-img position-relative">
                                    <div class="avatar-sm product-ribbon">
                                        <span class="avatar-title rounded-circle bg-primary">
                                            - 28 %
                                        </span>
                                    </div>
                                    <img src="@/assets/images/Iced Americano.jpg" alt="" class="img-fluid mx-auto d-block">
                                </div>
                                <div class="mt-4 text-center">
                                    <h5 class="mb-3 text-truncate"><a href="#" class="text-dark">Iced Americano</a></h5>
                                    
                                    <p class="text-muted">
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star text-warning"></i>
                                        <i class="bx bx-star"></i>
                                    </p>
                                    <h5 class="my-0"><span class="text-muted mr-2"></span> <b>$3</b></h5>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end row -->

                <div class="row">
                    <div class="col-lg-12">
                        <ul class="pagination pagination-rounded justify-content-center mt-4">
                            <li class="page-item disabled">
                                <a href="#" class="page-link"><i class="mdi mdi-chevron-left"></i></a>
                            </li>
                            <li class="page-item">
                                <a href="#" class="page-link">1</a>
                            </li>
                            <li class="page-item active">
                                <a href="#" class="page-link">2</a>
                            </li>
                            <li class="page-item">
                                <a href="#" class="page-link">3</a>
                            </li>
                            <li class="page-item">
                                <a href="#" class="page-link">4</a>
                            </li>
                            <li class="page-item">
                                <a href="#" class="page-link">5</a>
                            </li>
                            <li class="page-item">
                                <a href="#" class="page-link"><i class="mdi mdi-chevron-right"></i></a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <!-- end row -->

    </div> <!-- container-fluid -->
</div>
<!-- End Page-content -->


<!-- <footer class="footer">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6">
            </div>
            <div class="col-sm-6">
                <div class="text-sm-right d-none d-sm-block">
                    Design & Develop by Themesbrand
                </div>
            </div>
        </div>
    </div>
</footer> -->
</div>
      <!-- ------ -->
      <div v-show="$view == View.FORM" class="body-form">
      <div class="row">
        <div class="table-scroll">
          <VInput label="Nº" :rq="true">
            <input
              v-model="dto.COM_NO"
              type="number"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Code" :rq="true">
            <input
              v-model="dto.COM_CODE"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
  
          <VInput label="Name_khmer">
            <input
              v-model="dto.COM_NAME_LOCAL"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Name_English">
            <input
              v-model="dto.COM_NAME_ENG"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Address_khmer">
            <input
              v-model="dto.ADDR_KH"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Address_English">
            <input
              v-model="dto.ADDR_EN"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
  
          <VInput label="Phone">
            <input
              v-model="dto.PHONE"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Email">
            <input
              v-model="dto.EMAIL"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Web_Site">
            <input
              v-model="dto.WEBSITE"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Facebook">
            <input
              v-model="dto.FACEBOOK"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput label="Logo">
            <input
              v-model="dto.LOGO"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
  
          <VInput class="s-btn">
            <Button
              @click="$view = View.DATA"
              icon="fas fa-times"
              class="btn btn-outline-danger mr-2"
            >cancel</Button>
            <Button
              v-show="!$disable"
              @click="saveData"
              :spin="isSaving"
              :disabled="isSaving"
              icon="fas fa-save"
              class="btn btn-primary"
            >
              save
            </Button>
            <Button
              v-show="$disable"
              @click="editClick"
              icon="fas fa-edit"
              class="btn btn-info mr-2"
            >
              edit
            </Button>
          </VInput>
        </div>
      </div>
    </div>
    </WideDiv>
  </template>
  <style scoped>
  .table-scroll {
    max-height: 650px;
    overflow-y: auto;
  }
  .body-form {
    padding: auto;
  }
  .row {
    display: flex;
    flex-wrap: wrap;
  }
  .s-btn {
    margin-top: auto;
    display: flex;
    justify-content: flex-end;
  }
  </style>
  <script setup>
  import { ref, computed, reactive, onMounted } from "vue";
  import { $api, $msg, $date } from "@/utils/helper";
  import { View } from "@/utils/constant";
  import useTabStore from "@/stores/tab";
  import lang from "./CustomerInfo.json";
  import { useI18n } from "vue-i18n";
  const { t } = useI18n({ messages: lang });
  const $tab = useTabStore();
  
  const dto = reactive({
    COM_ID: -1,
    COM_NO: 0,
    COM_CODE: "",
    COM_INITIAL_KH: "",
    COM_INITIAL_EN: "",
    COM_NAME_LOCAL: "",
    COM_NAME_ENG: "",
    ADDR_KH: "",
    ADDR_EN: "",
    PHONE: "",
    EMAIL: "",
    WEBSITE: "",
    FACEBOOK: "",
    LOGO: "",
    TR_US: 1,
  });
  
  
  const $view = ref(View.DATA);
  const $disable = ref(false);
  
  const datalist = ref([]);
  const isSaving = ref(false);
  const newData = () => {
    $disable.value = false;
    $view.value = View.FORM;
  };
  
  const viewData = () => {
    console.log("Hellow world")
    $api.post("/api/companyinfo/viewdata", dto, (data) => {
      datalist.value = data;
      console.log(data)
    });
  };
  const detailData = (x) => {
    $view.value = View.FORM;
    $disable.value = true;
    dto.COM_ID = x.COM_ID;
    $api.post("/api/companyinfo/getdata", dto, (data) =>{
      dto.COM_ID = data.COM_ID;
      dto.COM_NO = data.COM_NO;
      dto.COM_CODE = data.COM_CODE;
      dto.COM_NAME_ENG = data.COM_NAME_ENG;
      dto.COM_NAME_LOCAL = data.COM_NAME_LOCAL;
      dto.PHONE = data.PHONE;
      dto.ADDR_EN = data.ADDR_EN;
      dto.ADDR_KH = data.ADDR_KH;
      dto.FACEBOOK = data.FACEBOOK;
      dto.EMAIL = data.EMAIL;
      dto.WEBSITE = data.WEBSIT;
      dto.LOGO = data.LOGO;
      console.log(data)
    })
  }
  const editClick = () => {
    $disable.value= false;
  }
  const saveData = () => {
    $msg.confirm(t("confirm_save"), () => {
      $api.post(
        "/api/CompanyInfo/save",
        dto,
        (data) => {
          $msg.success(t("success_save"), () => {
            $view.value = View.DATA;
            viewData();
          });
        },
        isSaving
      );
    });
  };
  onMounted(() => {
    viewData();
  });
  </script>
  