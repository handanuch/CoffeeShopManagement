<template>
  <WideDiv>
    <h5>{{ t("user") }}</h5>
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
              >{{ t("new") }}</Button
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
                <th> {{ t("s_no") }} </th>
                <th> {{ t("user_name") }} </th>
                <th> {{ t("display_name") }} </th>
                
                <th style="text-align: center;">{{ t("action") }}</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(x, i) in datalist" :key="x.COM_ID">
                <td>{{ i+ 1 }}</td>
                <th>{{ x.USER_NAME }}</th>
                <td>{{ x.DISPLAY_NAME }}</td>
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
    <div v-show="$view == View.FORM">
    <div class="row">
      <div class="table-scroll">
        <VInput :label="t('user_name')" :rq="true">
          <input
            v-model="dto.USER_NAME"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('display_name')" :rq="true">
          <input
            v-model="dto.DISPLAY_NAME"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>

        <VInput :label="t('emp_id')">
          <input
            v-model="dto.EMP_ID"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('email')">
          <input
            v-model="dto.EMAIL"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('password')">
          <input
            v-model="dto.PASS"
            type="password"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('con_password')">
          <input
            v-model="CON_PASS"
            type="password"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>


        <VInput class="s-btn">
          <Button
            @click="$view = View.DATA"
            icon="fas fa-times"
            class="btn btn-outline-danger mr-2"
          >{{ t("cancel") }}</Button>
          <Button
            v-show="!$disable"
            @click="saveData"
            :spin="isSaving"
            :disabled="isSaving"
            icon="fas fa-save"
            class="btn btn-primary"
          >
            {{ t("save") }}
          </Button>
          <Button
            v-show="$disable"
            @click="editClick"
            icon="fas fa-edit"
            class="btn btn-info mr-2"
          >
            {{ t("edit") }}
          </Button>
        </VInput>
      </div>
    </div>
  </div>
  </WideDiv>
</template>

<script setup>
import { ref, computed, reactive, onMounted } from "vue";
import { $api, $msg, $date } from "@/utils/helper";
import { View } from "@/utils/constant";
import useTabStore from "@/stores/tab";
import lang from "./User.json";
import { useI18n } from "vue-i18n";
const { t } = useI18n({ messages: lang });
const $tab = useTabStore();

const dto = reactive({
  COM_ID: 1,
  US_ID: -1,
  COM_NO: 0,
  USER_NAME: "",
  DISPLAY_NAME: "",
  PASS: "",
  EMP_ID:1,
  IS_LOCK: false,
  LOCK_DATE: new Date(),
  LOGIN_STATUS: "",
  LLOG_IN: "",
  IS_ONLINE: "",
  LLOG_OUT: "",
  EMAIL: "",
  IMG: "",
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
  $api.post("/api/user/viewdata", dto, (data) => {
    datalist.value = data;
    console.log(data)
  });
};
const detailData = (x) => {
  $view.value = View.FORM;
  $disable.value = true;
  dto.COM_ID = x.COM_ID;
  $api.post("/api/user/getdata", dto, (data) =>{
    dto.US_ID = data.US_ID;
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
      "/api/user/save",
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
