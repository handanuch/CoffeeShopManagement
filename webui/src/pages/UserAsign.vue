<template>
  <WideDiv>
    <WideDivTitle :title="t('role')" :badge="$label" />
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
            <th>{{ t("user") }}</th>
            <th>{{ t("name_kh") }}</th>
            <th>{{ t("name_en") }}</th>
            <th>{{ t("action") }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(x, i) in datalist" :key="x.UR_ID">
            <td>{{ i+ 1 }}</td>
            <th>{{ x.DISPLAY_NAME }}</th>
            <td>{{ x.ROL_NAME_KH }}</td>
            <td>{{ x.ROL_NAME_EN }}</td>
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
      <VInput :label="t('user')" :rq="true">
        <XSelectList
              v-model="USER"
              rest="/api/user/viewdata"
              fields="USER_NAME,DISPLAY_NAME"
              :nullable="true"
              :autoselect="true"
            />
      </VInput>
      <VInput :label="t('role')" :rq="true">
        <XSelectList
              v-model="ROLE"
              rest="/api/role/viewdata"
              fields="ROL_CODE,ROL_NAME_EN"
              :nullable="true"
              :autoselect="true"
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
  UR_ID: -1,
  US_ID:-1,
  ROL_NO: 0,
  NEXT_LEVEL: 0,
  ROL_CODE: "",
  ROL_NAME_KH: "",
  ROL_NAME_EN: "",
  ROL_LEVEL:0,
  FILTER: "",
  TR_US: 1,
  PMS_CODE: "wfmUserAsign",
});

const $view = ref(View.DATA);
const $disable = ref(false);
const $label = computed(() => {
  if ($view.value == View.HISTORY) return t("trx_history");
  else if ($view.value == View.FORM && dto.UR_ID <= 0) return t("new");
  else if ($view.value == View.FORM && $disable.value == true) return t("view");
  else if ($view.value == View.FORM && $disable.value == false)
    return t("edit");
  else return "";
});
const datalist = ref([]);
const datahistory = ref([]);
const isSaving = ref(false);

const clearData = () => {
  dto.UR_ID = -1;
  dto.ROL_NO = 0;
  dto.ROL_CODE = "";
  dto.ROL_NAME_KH = "";
  dto.ROL_NAME_EN = "";
  dto.ROL_LEVEL = 0;
  dto.US_ID = -1;
  dto.ROL_ID =-1
};
const USER = ref(null);
const ROLE =ref(null);
const viewData = () => {
  $api.post("/api/userasign/viewdata", dto, (data) => {
    datalist.value = data;
  });
};

const verifyData = () => {
  if (dto.ROL_NO < 0) {
    $msg.show(t("invalid", [t("s_no")]));
    return false;
  } else if (dto.ROL_CODE.trim() == "") {
    $msg.show(t("invalid", [t("code")]));
    return false;
  } else if (dto.ROL_NAME_KH.trim() == "") {
    $msg.show(t("invalid", [t("name_kh")]));
    return false;
  } else if (dto.ROL_NAME_EN.trim() == "") {
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
  // if (!verifyData()) return;
  dto.US_ID = USER.value?.US_ID;
  dto.ROL_ID = ROLE.value?.ROL_ID;
  $msg.confirm(t("confirm_save"), () => {
    $api.post(
      "/api/userasign/save",
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
  $api.post("/api/role/getstm", dto, (data) => {
    datahistory.value = data;
  });
};

const detailData = (x) => {
  clearData();
  $view.value = View.FORM;
  $disable.value = true;
  dto.ROL_ID = x.ROL_ID;
  $api.post(
    "/api/userasign/getdata",
    dto,
    (data) => {
     
      dto.ROL_ID = data.ROL_ID;
      dto.ROL_NO = data.ROL_NO;
      dto.ROL_CODE = data.ROL_CODE;
      dto.ROL_NAME_KH = data.ROL_NAME_KH;
      dto.ROL_NAME_EN = data.ROL_NAME_EN;
      dto.ROL_LEVEL = data.ROL_LEVEL;
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
      "/api/role/delete",
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
