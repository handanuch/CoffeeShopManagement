<template>
  <WideDiv>
    <WideDivTitle :title="t('seq_mgt')" :badge="$label" />
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
            <Button
              @click="resetData"
              :spin="isResetting"
              :disabled="isResetting"
              class="btn btn-warning mb-2 me-2"
              icon="mdi mdi-plus"
              >{{ t("reset") }}</Button
            >
          </div>
        </div>
        <!-- end col-->
      </div>
      <table class="table table-responsive">
        <thead class="table-light">
          <tr>
            <th>{{ t("s_no") }}</th>
            <th>{{ t("schema") }}</th>
            <th>{{ t("sqmg_name") }}</th>
            <th>{{ t("full_name") }}</th>
            <th>{{ t("table_name") }}</th>
            <th>{{ t("field_name") }}</th>
            <th>{{ t("created_by") }}</th>
            <th>{{ t("modify_by") }}</th>
            <th>{{ t("action") }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(x, i) in datalist" :key="x.SQMG_ID">
            <td>{{ x.SQMG_NO }}</td>
            <th>{{ x.SCHEMA }}</th>
            <td @click="historyData(x)">{{ x.SQMG_NAME }}</td>
            <td>{{ x.SQMG_FULL_NAME }}</td>
            <td>{{ x.TABLE_NAME }}</td>
            <td>{{ x.FIELD_NAME }}</td>
            <td><TwoCells :first="x.TR_DISPLAY_NAME" :second="x.TR_DATE" /></td>
            <td>
              <TwoCells :first="x.TR_DISPLAY_NAME" :second="x.LTR_DATE" />
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
          v-model="dto.SQMG_NO"
          type="number"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('schema')" :rq="true">
        <input
          v-model="dto.SCHEMA"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('sqmg_name')" :rq="true">
        <input
          v-model="dto.SQMG_NAME"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('full_name')" :rq="true">
        <input
          v-model="dto.SQMG_FULL_NAME"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('table_name')" :rq="true">
        <input
          v-model="dto.TABLE_NAME"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('field_name')" :rq="true">
        <input
          v-model="dto.FIELD_NAME"
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
          <tr v-for="(x, i) in datahistory" :key="x.DTGTM_ID">
            <td>{{ i + 1 }}</td>
            <td>{{ x.DTGTM_CODE }}</td>
            <td>{{ x.TR_STS }}</td>
            <td>{{ x.TR_COMMENT }}</td>
            <td>{{ x.TR_DISPLAY_NAME }}</td>
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
import lang from "@/locales/SequenceMgt.json";

const { t } = useI18n({ messages: lang });
const dto = reactive({
  SQMG_ID: -1,
  SQMG_NO: 0,
  SCHEMA: "",
  SQMG_NAME: "",
  SQMG_FULL_NAME: "",
  TABLE_NAME: "",
  FIELD_NAME: "",
  FILTER: "",
  PMS_CODE: "wfmSequenceMgt",
});

const $view = ref(View.DATA);
const $disable = ref(false);
const $label = computed(() => {
  if ($view.value == View.HISTORY) return t("trx_history");
  else if ($view.value == View.FORM && dto.SQMG_ID <= 0) return t("new");
  else if ($view.value == View.FORM && $disable.value == true) return t("view");
  else if ($view.value == View.FORM && $disable.value == false)
    return t("edit");
  else return "";
});
const datalist = ref([]);
const datahistory = ref([]);
const isSaving = ref(false);
const isResetting = ref(false);

const viewData = () => {
  $api.post("/api/sequenceMgt/viewdata", dto, (data) => {
    datalist.value = data;
  });
};

const clearData = () => {
  dto.SQMG_ID = -1;
  dto.SQMG_NO = 0;
  dto.SCHEMA = "";
  dto.SQMG_NAME = "";
  dto.SQMG_FULL_NAME = "";
  dto.TABLE_NAME = "";
  dto.FIELD_NAME = "";
};

const verifyData = () => {
  if (dto.SQMG_NO < 0) {
    $msg.show(t("invalid", [t("s_no")]));
    return false;
  } else if (dto.SCHEMA.trim() == "") {
    $msg.show(t("invalid", [t("schema")]));
    return false;
  } else if (dto.SQMG_NAME.trim() == "") {
    $msg.show(t("invalid", [t("sqmg_name")]));
    return false;
  } else if (dto.SQMG_FULL_NAME.trim() == "") {
    $msg.show(t("invalid", [t("full_name")]));
    return false;
  } else if (dto.TABLE_NAME.trim() == "") {
    $msg.show(t("invalid", [t("table_name")]));
    return false;
  } else if (dto.FIELD_NAME.trim() == "") {
    $msg.show(t("invalid", [t("field_name")]));
    return false;
  }
  return true;
};

const newData = () => {
  clearData();
  $disable.value = false;
  $view.value = View.FORM;
};

const resetData = () => {
  $msg.confirm(t("confirm_reset"), () => {
    $api.post(
      "/api/sequenceMgt/reset",
      dto,
      () => {
        $msg.success(t("success_reset"));
      },
      isResetting
    );
  });
};
const saveData = () => {
  if (!verifyData()) return;
  $msg.confirm(t("confirm_save"), () => {
    $api.post(
      "/api/sequenceMgt/save",
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
  dto.SQMG_ID = x.SQMG_ID;
  datahistory.value = [];
  $api.post("/api/sequenceMgt/getstm", dto, (data) => {
    datahistory.value = data;
  });
};

const detailData = (x) => {
  clearData();
  $view.value = View.FORM;
  $disable.value = true;
  dto.SQMG_ID = x.SQMG_ID;
  $api.post(
    "/api/sequenceMgt/getdata",
    dto,
    (data) => {
      const x = data[0];
      dto.SQMG_NO = x.SQMG_NO;
      dto.SCHEMA = x.SCHEMA;
      dto.SQMG_NAME = x.SQMG_NAME;
      dto.SQMG_FULL_NAME = x.SQMG_FULL_NAME;
      dto.TABLE_NAME = x.TABLE_NAME;
      dto.FIELD_NAME = x.FIELD_NAME;
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
    dto.TR_DVAL = JSON.stringify([{ SQMG_ID: x.SQMG_ID }]);
    console.log(dto);
    $api.post(
      "/api/sequenceMgt/delete",
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
