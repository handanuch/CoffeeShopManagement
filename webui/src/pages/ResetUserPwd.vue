<template>
  <WideDiv>
    <WideDivTitle :title="t('reset_pwd')" :badge="$label" />
    <div v-show="$view == View.FORM">
      <VInput :label="t('user_name')" :rq="true">
        <input
          v-model="dto.USER_NAME"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('default_pwd')">
        <input
          v-model="dto.PASSWORD"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput class="s-btn justify-content-between">
        <a
          @click="$view = View.HISTORY"
          class="bottom-dash"
          href="javascript:;"
        >
          {{ t("trx_history") }}
        </a>
        <Button
          @click="saveData"
          :spin="isSaving"
          :disabled="isSaving"
          icon="fas fa-save"
          class="btn btn-primary"
        >
          {{ t("save") }}
        </Button>
      </VInput>
    </div>
    <div v-show="$view == View.HISTORY">
      <table class="table table-responsive">
        <thead class="table-light">
          <tr>
            <th>{{ t("s_no") }}</th>
            <th>{{ t("trx_code") }}</th>
            <th>{{ t("trx_type") }}</th>
            <th>{{ t("description") }}</th>
            <th>{{ t("user") }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(x, i) in datahistory" :key="x.DEPTM_ID">
            <td>{{ i + 1 }}</td>
            <td>{{ x.DEPTM_CODE }}</td>
            <td>{{ x.DEPTM_CODE }}</td>
            <td>{{ x.DEPTM_CODE }}</td>
            <td>{{ x.DEPTM_CODE }}</td>
          </tr>
        </tbody>
      </table>
      <div class="row mb-2">
        <div class="col-sm-4"></div>
        <div class="col-sm-8">
          <div class="text-sm-end">
            <Button
              @click="$view = View.FORM"
              class="btn btn-outline-danger mb-2 me-2"
              icon="fas fa-times"
              >{{ t("cancel") }}</Button
            >
          </div>
        </div>
      </div>
    </div>
  </WideDiv>
</template>
<script setup>
import { ref, computed, reactive, onMounted } from "vue";
import { $api, $msg } from "@/utils/helper";
import { useI18n } from "vue-i18n";
import { View } from "@/utils/constant";
import lang from "@/locales/ResetUserPwd.json";

const { t } = useI18n({ messages: lang });
const dto = reactive({
  USER_NAME: "",
  PASSWORD: "FINTECH",
  FILTER: "",
  PMS_CODE: "wfmResetUserPwd",
});

const $view = ref(View.FORM);
const $disable = ref(false);
const $label = computed(() => {
  if ($view.value == View.HISTORY) return t("trx_history");
  else if ($view.value == View.FORM && dto.DEP_ID <= 0) return t("new");
  else if ($view.value == View.FORM && $disable.value == true) return t("view");
  else if ($view.value == View.FORM && $disable.value == false)
    return t("edit");
  else return "";
});
const datahistory = ref([]);
const isSaving = ref(false);


const clearData = () => {
  dto.USER_NAME = "";
  dto.PASSWORD = "FINTECH";
};

const verifyData = () => {
  if (dto.USER_NAME.trim() == "") {
    $msg.show(t("invalid", [t("user_name")]));
    return false;
  }
  return true;
};

const saveData = () => {
  if (!verifyData()) return;
  $msg.confirm(t("confirm_save"), () => {
    $api.post(
      "/api/user/resetpwd",
      dto,
      (data) => {
        $msg.success(t("success_save"), () => {
          $view.value = View.FORM;
          clearData();
        });
      },
      isSaving
    );
  });
};

const historyData = (x) => {
  $view.value = View.HISTORY;
  dto.DEP_ID = x.DEP_ID;
  datahistory.value = [];
  $api.post("/api/user/getstm", dto, (data) => {
    datahistory.value = data;
  });
};

// onMounted(() => {
//   viewData();
// });
</script>
