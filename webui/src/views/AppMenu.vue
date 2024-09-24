<template>
  <div class="vertical-menu">
    <div data-simplebar class="h-100">
      <div id="sidebar-menu">
        <ul class="metismenu list-unstyled" id="side-menu">
          <li class="menu-title">{{ t("menu") }}</li>
          <li v-for="x in menu">
            <!-- <a href="javascript:;" class="has-arrow waves-effect"> -->
            <a @click="$tab.open(x)" href="javascript:;">
              <i :class="x.IMG"></i>
              <span :key="x.PMS_CODE">
                {{ $lng == "en" ? x.PMS_NAME_ENG : x.PMS_NAME_LOCAL }}
              </span>
            </a>
          </li>
        </ul> 
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import MetisMenu from "metismenujs";
import useTabStore from "@/stores/tab";
import { useI18n } from "vue-i18n";
import lang from "@/locales/Home.json";

const { t } = useI18n({ messages: lang });
const $tab = useTabStore();
const $lng = localStorage.getItem("lang") || "en";
const menu = ref([]);

const loadMenu = () => {
  menu.value = [
  {
      PMS_CODE: "wfmDashboard",
      PMS_NAME_ENG: "Dashboard",
      PMS_NAME_LOCAL: "Dashboard",
      PMS_FORM_NAME: "Dashboard",
      IMG: "bx bx-line-chart",
    },
    {
      PMS_CODE: "wfmMenu",
      PMS_NAME_ENG: "Menu",
      PMS_NAME_LOCAL: "Menu",
      PMS_FORM_NAME: "Menu",
      IMG: "bx bxs-food-menu",
    },
    {
      PMS_CODE: "wfmCompany",
      PMS_NAME_ENG: "Company",
      PMS_NAME_LOCAL: "ក្រុមហ៊ុន",
      PMS_FORM_NAME: "Company",
      IMG: "bx bx-grid-alt",
    },
    {
      PMS_CODE: "wfmDepartment",
      PMS_NAME_ENG: "Department",
      PMS_NAME_LOCAL: "នាយកដ្ឋាន",
      PMS_FORM_NAME: "Department",
      IMG: "bx bx-grid-alt",
    },
    {
      PMS_CODE: "wfmUnit",
      PMS_NAME_ENG: "Unit",
      PMS_NAME_LOCAL: "ផ្នែក",
      PMS_FORM_NAME: "Unit",
      IMG: "bx bx-grid-alt",
    },
    {
      PMS_CODE: "wfmPosition",
      PMS_NAME_ENG: "Position",
      PMS_NAME_LOCAL: "តួនាទី",
      PMS_FORM_NAME: "Position",
      IMG: "bx bx-grid-alt",
    },
    {
      PMS_CODE: "wfmCreateUser",
      PMS_NAME_ENG: "Create User",
      PMS_NAME_LOCAL: "Create User",
      PMS_FORM_NAME: "CreateUser",
      IMG: "bx bx-user-plus",
    },
    {
      PMS_CODE: "wfmPermission",
      PMS_NAME_ENG: "Permission",
      PMS_NAME_LOCAL: "Permission",
      PMS_FORM_NAME: "Permission",
      IMG: "bx bx-pencil",
    },
    {
      PMS_CODE: "wfmRole",
      PMS_NAME_ENG: "Role",
      PMS_FORM_NAME: "Role",
      IMG: "bx bx-grid-alt",
    },
    {
      PMS_CODE: "wfmItem",
      PMS_NAME_ENG: "Item",
      PMS_NAME_LOCAL: "Item",
      PMS_FORM_NAME: "Item",
      IMG: "bx bx-package",
    },
    {
      PMS_CODE: "wfmInvoice",
      PMS_NAME_ENG: "Invoice",
      PMS_NAME_LOCAL: "Invoice",
      PMS_FORM_NAME: "Invoice",
      IMG: "bx bx-file",
    },
    {
      PMS_CODE: "wfmUser",
      PMS_NAME_ENG: "User",
      PMS_NAME_LOCAL: "User",
      PMS_FORM_NAME: "User",
      IMG: "bx bx-user-plus",
    },
    {
      PMS_CODE: "wfmReport",
      PMS_NAME_ENG: "Report",
      PMS_NAME_LOCAL: "Report",
      PMS_FORM_NAME: "Report",
      IMG: "bx bx-notepad",
    },
    
  ];
  new MetisMenu("#side-menu");
};

onMounted(() => {
  loadMenu();
});
</script>
