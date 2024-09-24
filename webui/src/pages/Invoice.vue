<template>
  <WideDiv>
    <h5>Invoice</h5>
    <div v-show="$view == View.DATA">
      <div class="row mb-2">
        <div class="col-sm-4">
          <div class="input-group me-2 mb-2">
            <input
              @keyup.enter="viewData();"
              v-model="dto.FILTER"
              type="text"
              class="form-control"
              autocomplete="off"
            />
            <Button
              @click="viewData"
              class="btn btn-primary"
              icon="fas fa-search"
            ></Button>
          </div>
        </div>
        <div class="col-sm-8">
          <div class="text-sm-end">
            <Button
              @click="newData"
              class="btn btn-success mb-2 me-2"
              icon="bx bx-add-to-queue"
              >new</Button
            >
          </div>
        </div>
        <!-- end col-->
      </div>
      <div id="table">
        <div class="table-scroll">
          <table class="table table-responsive table-sm">
            <thead class="table-light">
              <tr>
                <th> Nº </th>
                <th> Code </th>
                <th> Name KH </th>
                <th>Name EN</th>
                <th>Address</th>
                <th>Phone</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(x, i) in datalist" :key="x.COM_ID">
                <td>{{ i+ 1 }}</td>
                <th>{{ x.COM_CODE }}</th>
                <td>{{ x.COM_NAME_ENG }}</td>
                <td>{{ x.COM_NAME_LOCAL }}</td>
                <td>
                  {{ x.ADDR_EN }}
                </td>
                <td>
                  {{ x.PHONE }}
                </td>
                <td style="text-align: center">
                  <a
                    @click="detailData(x)"
                    href="javascript:;"
                    class="text-primary"
                  >
                    <i class="mdi mdi-eye font-size-18"></i>
                  </a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
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
