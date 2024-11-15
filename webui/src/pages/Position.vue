<template>
  <WideDiv>
    <WideDivTitle :title="t('position')" :badge="$label" />
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
            <th>{{ t("action") }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(x, i) in datalist" :key="x.POS_ID">
            <td>{{ x.POS_NO }}</td>
            <th @click="historyData(x)">{{ x.POS_CODE }}</th>
            <td>{{ x.POS_NAME_LOCAL }}</td>
            <td>{{ x.POS_NAME_ENG }}</td>
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
          v-model="dto.POS_NO"
          type="number"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('code')" :rq="true">
        <input
          v-model="dto.POS_CODE"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('name_kh')" :rq="true">
        <input
          v-model="dto.POS_NAME_LOCAL"
          type="text"
          class="form-control"
          :disabled="$disable"
        />
      </VInput>
      <VInput :label="t('name_en')" :rq="true">
        <input
          v-model="dto.POS_NAME_ENG"
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
    
  </WideDiv>
</template>

<script setup>
import { ref, computed, reactive, onMounted } from "vue";
import { $api, $msg } from "@/utils/helper";
import { useI18n } from "vue-i18n";
import { View } from "@/utils/constant";
import lang from "@/locales/Position.json";

const { t } = useI18n({ messages: lang });
const dto = reactive({
  POS_ID: -1,
  CMI_ID: 1,
  POS_NO: 0,
  POS_CODE: "",
  POS_NAME_LOCAL: "",
  POS_NAME_ENG: "",
  FILTER: "",
  TR_US: 1,
  PMS_CODE: "wfmPosition",
});

const $view = ref(View.DATA);
const $disable = ref(false);
const $label = computed(() => {
  if ($view.value == View.HISTORY) return t("trx_history");
  else if ($view.value == View.FORM && dto.POS_ID <= 0) return t("new");
  else if ($view.value == View.FORM && $disable.value == true) return t("view");
  else if ($view.value == View.FORM && $disable.value == false)
    return t("edit");
  else return "";
});
const datalist = ref([]);
const datahistory = ref([]);
const isSaving = ref(false);

const clearData = () => {
  dto.POS_ID = -1;
  dto.POS_NO = 0;
  dto.POS_CODE = "";
  dto.POS_NAME_LOCAL = "";
  dto.POS_NAME_ENG = "";
};

const viewData = () => {
  $api.post("/api/position/viewdata", dto, (data) => {
    datalist.value = data;
  });
};

const verifyData = () => {
  if (dto.POS_NO < 0) {
    $msg.show(t("invalid", [t("s_no")]));
    return false;
  } else if (dto.POS_CODE.trim() == "") {
    $msg.show(t("invalid", [t("code")]));
    return false;
  } else if (dto.POS_NAME_LOCAL.trim() == "") {
    $msg.show(t("invalid", [t("name_kh")]));
    return false;
  } else if (dto.POS_NAME_ENG.trim() == "") {
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
      "/api/position/save",
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
  dto.POS_ID = x.POS_ID;
  datahistory.value = [];
  $api.post("/api/position/getstm", dto, (data) => {
    datahistory.value = data;
  });
};

const detailData = (x) => {
  clearData();
  $view.value = View.FORM;
  $disable.value = true;
  dto.POS_ID = x.POS_ID;
  $api.post(
    "/api/position/getdata",
    dto,
    (data) => {
      const x = data[0];
      dto.POS_NO = x.POS_NO;
      dto.POS_CODE = x.POS_CODE;
      dto.POS_NAME_LOCAL = x.POS_NAME_LOCAL;
      dto.POS_NAME_ENG = x.POS_NAME_ENG;
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
    dto.TR_DVAL = JSON.stringify([{ POS_ID: x.POS_ID }]);
    console.log(dto);
    $api.post(
      "/api/position/delete",
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
