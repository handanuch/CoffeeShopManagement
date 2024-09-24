<template>
  <WideDiv>
    <WideDivTitle :title="t('unit')" :badge="$label" />
    <div v-show="$view == View.DATA">
      <div class="row mb-2">
        <div class="col-sm-4">
          <div class="input-group me-2 mb-2">
            <input
              @keyup.enter="viewData"
              v-model="dto.FILTER"
              type="text"
              class="form-control"
              autocomplete="off"
              :placeholder="t('search_3dot')"
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
              icon="mdi mdi-plus"
              >{{ t("new") }}</Button
            >
          </div>
        </div>
        <!-- end col-->
      </div>
      <table class="table table-responsive">
        <thead class="table-light">
          <tr>
            <th>{{ t("s_no") }}</th>
            <th>{{ t("code") }}</th>
            <th>{{ t("name_kh") }}</th>
            <th>{{ t("name_en") }}</th>
            <th>{{ t("created_by") }}</th>
            <th>{{ t("modify_by") }}</th>
            <th>{{ t("action") }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(x, i) in datalist" :key="x.UNIT_ID">
            <td>{{ x.UNIT_NO }}</td>
            <th @click="historyData(x)">{{ x.UNIT_CODE }}</th>
            <td>{{ x.UNIT_NAME_LOCAL }}</td>
            <td>{{ x.UNIT_NAME_ENG }}</td>
            <td><TwoCells :first="x.TR_DISPLAY_NAME" :second="x.TR_DATE" /></td>
            <td>
              <TwoCells :first="x.LTR_DISPLAY_NAME" :second="x.LTR_DATE" />
            </td>
            <td>
              <ActionCells
                @view="detailData(x)"
                @edit="editData(x)"
                @delete="deleteData(x)"
              />
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-show="$view == View.FORM">
      <VInput :label="t('s_no')" :rq="true">
        <input
          v-model="dto.UNIT_NO"
          type="number"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('code')" :rq="true">
        <input
          v-model="dto.UNIT_CODE"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('name_kh')" :rq="true">
        <input
          v-model="dto.UNIT_NAME_LOCAL"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('name_en')" :rq="true">
        <input
          v-model="dto.UNIT_NAME_ENG"
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
          >{{ t("cancel") }}</Button
        >
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
          <tr v-for="(x, i) in datahistory" :key="x.UNITTM_ID">
            <td>{{ i + 1 }}</td>
            <td>{{ x.UNITTM_CODE }}</td>
            <td>{{ x.UNITTM_CODE }}</td>
            <td>{{ x.UNITTM_CODE }}</td>
            <td>{{ x.UNITTM_CODE }}</td>
          </tr>
        </tbody>
      </table>
      <div class="row mb-2">
        <div class="col-sm-4"></div>
        <div class="col-sm-8">
          <div class="text-sm-end">
            <Button
              @click="$view = View.DATA"
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
import lang from "@/locales/Unit.json";

const { t } = useI18n({ messages: lang });
const dto = reactive({
  // DEP_ID: -1,
  DEP_CODE: "",
  UNIT_ID: -1,
  UNIT_NO: 0,
  UNIT_CODE: "",
  UNIT_NAME_LOCAL: "",
  UNIT_NAME_ENG: "",
  FILTER: "",
  PMS_CODE: "wfmUnit",
});

const $view = ref(View.DATA);
const $disable = ref(false);
const $label = computed(() => {
  if ($view.value == View.HISTORY) return t("trx_history");
  else if ($view.value == View.FORM && dto.UNIT_ID <= 0) return t("new");
  else if ($view.value == View.FORM && $disable.value == true) return t("view");
  else if ($view.value == View.FORM && $disable.value == false)
    return t("edit");
  else return "";
});
const datalist = ref([]);
const datahistory = ref([]);
const isSaving = ref(false);

const clearData = () => {
  dto.DEP_ID = -1;
  dto.DEP_CODE = "";
  dto.UNIT_ID = -1;
  dto.UNIT_NO = 0;
  dto.UNIT_CODE = "";
  dto.UNIT_NAME_LOCAL = "";
  dto.UNIT_NAME_ENG = "";
};

const viewData = () => {
  // $api.post("/api/unit/viewdata", dto, (data) => {
  //   datalist.value = data;
  // });
};

const verifyData = () => {
  if (dto.UNIT_NO < 0) {
    $msg.show(t("invalid", [t("s_no")]));
    return false;
  } else if (dto.UNIT_CODE.trim() == "") {
    $msg.show(t("invalid", [t("code")]));
    return false;
  } else if (dto.UNIT_NAME_LOCAL.trim() == "") {
    $msg.show(t("invalid", [t("name_kh")]));
    return false;
  } else if (dto.UNIT_NAME_ENG.trim() == "") {
    $msg.show(t("invalid", [t("name_en")]));
    return false;
  }
  return true;
};

const newData = () => {
  clearData();
  $disable.value = false;
  $view.value = View.FORM;
};

const saveData = () => {
  if (!verifyData()) return;
  $msg.confirm(t("confirm_save"), () => {
    $api.post(
      "/api/unit/save",
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

const historyData = (x) => {
  $view.value = View.HISTORY;
  dto.UNIT_ID = x.UNIT_ID;
  datahistory.value = [];
  $api.post("/api/unit/getstm", dto, (data) => {
    datahistory.value = data;
  });
};

const detailData = (x) => {
  clearData();
  $view.value = View.FORM;
  $disable.value = true;
  dto.UNIT_ID = x.UNIT_ID;
  $api.post(
    "/api/unit/getdata",
    dto,
    (data) => {
      const x = data[0];
      dto.DEP_ID = x.DEP_ID;
      dto.UNIT_NO = x.UNIT_NO;
      dto.UNIT_CODE = x.UNIT_CODE;
      dto.UNIT_NAME_LOCAL = x.UNIT_NAME_LOCAL;
      dto.UNIT_NAME_ENG = x.UNIT_NAME_ENG;
    },
    null,
    (ok) => {
      if (ok) $msg.error(t("data_not_found"));
    }
  );
};

const editData = (x) => {
  detailData(x);
  $disable.value = false;
};

const deleteData = (x) => {
  $msg.confirm(t("confirm_delete"), () => {
    dto.TR_DVAL = JSON.stringify([{ UNIT_ID: x.UNIT_ID }]);
    console.log(dto);
    $api.post(
      "/api/unit/delete",
      dto,
      (data) => {
        $msg.success(t("success_delete"), () => {
          viewData();
        });
      },
      null,
      (ok) => {
        if (ok) $msg.error(t("data_not_found"));
      }
    );
  });
};

onMounted(() => {
  viewData();
});
</script>
