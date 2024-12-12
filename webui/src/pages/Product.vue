<template>
  <WideDiv>
    <h5>{{ t("product") }}</h5>
    <div v-show="$view == View.DATA">
      <div class="row mb-2">
        <div class="col-sm-4">
          <div class="input-group me-2 mb-2">
            <input
              @keyup.enter="viewData()"
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
                <th>{{ t("s_no") }}</th>
                <th>{{ t("pro_name_kh") }}</th>
                <th>{{ t("pro_name_en") }}</th>
                <th>{{ t("pro_price") }}</th>
                <th>{{ t("pro_sts") }}</th>
                <th>{{ t("create_date") }}</th>
                <th>{{ t("modify_date") }}</th>
                <th style="text-align: center">{{ t("action") }}</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(x, i) in datalist" :key="x.PRO_ID">
                <td>{{ i + 1 }}</td>
                <th>{{ x.PRO_NAME_KH }}</th>
                <td>{{ x.PRO_NAME_EN }}</td>
                <td>{{ x.PRO_PRICE }}</td>
                <td>{{ x.PRO_STS }}</td>
                <td>{{ $date.format(x.CREATION_DATE, "DD MMM YYYY") }}</td>
                <td>{{ $date.format(x.MODIFY_DATE, "DD MMM YYYY") }}</td>
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
          <VInput :label="t('pro_code')" :rq="true">
            <input
              v-model="dto.PRO_CODE"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput :label="t('pro_name_kh')" :rq="true">
            <input
              v-model="dto.PRO_NAME_KH"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>

          <VInput :label="t('pro_name_en')">
            <input
              v-model="dto.PRO_NAME_EN"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <VInput :label="t('pro_price')">
            <input
              v-model="dto.PRO_PRICE"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>
          <!-- <VInput :label="t('status')">
            <input
              v-model="dto.EMP_STS"
              type="text"
              class="form-control"
              :disabled="$disable"
            />
          </VInput> -->
          <VInput :label="t('create_date')">
            <input
              v-model="dto.CREATION_DATE"
              type="date"
              class="form-control"
              :disabled="$disable"
            />
          </VInput>

          <VInput class="s-btn">
            <Button
              @click="$view = View.DATA"
              icon="fas fa-times"
              class="btn btn-outline-danger mr-2"
              >{{ t("cancel") }}</Button
            >
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
  PRO_ID: 1,
  EMP_ID: -1,
  PRO_CODE: "",
  PRO_NAME_KH: "",
  PRO_NAME_EN: "",
  PRO_PRICE: "",
  PRO_STS: "ACTIVE",
  CREATION_DATE: new Date(),
  MODIFY_DATE: new Date(),
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
  $api.post("/api/product/viewdata", dto, (data) => {
    datalist.value = data;
    console.log(data);
  });
};
const detailData = (x) => {
  $view.value = View.FORM;
  $disable.value = true;
  dto.EMP_ID = x.EMP_ID;
  $api.post("/api/product/getdata", dto, (data) => {
    dto.PRO_ID = data.PRO_ID;
    dto.PRO_CODE = data.PRO_CODE;
    dto.PRO_NAME_KH = data.PRO_NAME_KH;
    dto.PRO_NAME_EN = data.PRO_NAME_EN;
    dto.PRO_PRICE = data.PRO_PRICE;
    dto.TR_US = getNumber(data.TR_US);
    dto.PRO_STS = data.PRO_STS;
    dto.CREATION_DATE = data.CREATION_DATE;
    dto.MODIFY_DATE = data.MODIFY_DATE;
  });
};
const editClick = () => {
  $disable.value = false;
};
const saveData = () => {
  $msg.confirm(t("confirm_save"), () => {
    $api.post(
      "/api/product/save",
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
