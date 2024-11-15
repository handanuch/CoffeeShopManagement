<template>
  <WideDiv>
    <h5>{{ t("employee") }}</h5>
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
                <th> {{ t("emp_name_kh") }} </th>
                <th> {{ t("emp_name_en") }} </th>
                <th> {{ t("gender") }} </th>
                <th> {{ t("phone") }} </th>
                <th> {{ t("status") }} </th>
                <th> {{ t("start_date") }} </th>
                
                <th style="text-align: center;">{{ t("action") }}</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(x, i) in datalist" :key="x.EMP_ID">
                <td>{{ i+ 1 }}</td>
                <th>{{ x.NAME_KH }}</th>
                <td>{{ x.NAME_EN }}</td>
                <td>{{ x.GENDER }}</td>
                <td>{{ x.PHONE }}</td>
                <td>{{ x.EMP_STS }}</td>
                <td>{{ x.START_DATE }}</td>
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
        <VInput :label="t('emp_code')" :rq="true">
          <input
            v-model="dto.EMP_CODE"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('name_kh')" :rq="true">
          <input
            v-model="dto.NAME_KH"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>

        <VInput :label="t('name_en')">
          <input
            v-model="dto.NAME_EN"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('gender')">
          <input
            v-model="dto.GENDER"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('phone')">
          <input
            v-model="dto.PHONE"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('status')">
          <input
            v-model="dto.EMP_STS"
            type="text"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('start_date')">
          <input
            v-model="dto.START_DATE"
            type="date"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('department')">
          <input
            v-model="dto.DEP_ID"
            type="number"
            class="form-control"
            :disabled="$disable"
          />
        </VInput>
        <VInput :label="t('position')">
          <input
            v-model="dto.POS_ID"
            type="number"
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
  EMP_ID: -1,
  EMP_CODE: "",
  NAME_EN: "",
  NAME_KH: "",
  PHONE: "",
  DEP_ID: 1,
  POS_ID: 1,
  STAT_DATE: new Date(),
  EMP_STS: "ACTIVE",
  MOBILE: "",
  GENDER: "",
  
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
  $api.post("/api/employee/viewdata", dto, (data) => {
    datalist.value = data;
    console.log(data)
  });
};
const detailData = (x) => {
  $view.value = View.FORM;
  $disable.value = true;
  dto.EMP_ID = x.EMP_ID;
  $api.post("/api/employee/getdata", dto, (data) =>{
    dto.EMP_IDE = data.EMP_IDE;
    dto.COM_ID = data.COM_ID;
    dto.EMP_CODE = data.EMP_CODE;
    dto.NAME_EN = data.NAME_EN;
    dto.NAME_KH = data.NAME_KH;
    dto.EMP_STS = data.EMP_STS;
    dto.PHONE = data.PHONE;
    dto.GENDER = data.GENDER;
    dto.STAT_DATE = data.STAT_DATE;
    dto.DEP_ID = data.DEP_ID;
    dto.POS_ID = data.POS_ID;
  })
}
const editClick = () => {
  $disable.value= false;
}
const saveData = () => {
  $msg.confirm(t("confirm_save"), () => {
    $api.post(
      "/api/employee/save",
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
