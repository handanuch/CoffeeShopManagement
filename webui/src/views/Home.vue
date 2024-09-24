<template>
  <AppHeader />
  <AppMenu />
  <div class="main-content">
    <div class="tab-container">
      <ul class="tab-bar nav nav-tabs nav-tabs-custom">
        <li v-for="x in $tab.list" class="nav-item" :key="x.PMS_CODE">
          <a
            @click="$tab.activate(x)"
            class="nav-link"
            :class="{ active: $tab.current == x.PMS_CODE }"
          >
            <span class=""><i :class="x.IMG"></i></span>
            <span class="">
              {{ " " }}{{ lang == "en" ? x.PMS_NAME_ENG : x.PMS_NAME_LOCAL }}
            </span>
            <span @click.stop="$tab.close(x)" class="fas fa-times"></span>
          </a>
        </li>
      </ul>
      <div class="tab-content">
        <div
          v-show="$tab.current == x.PMS_CODE"
          v-for="x in $tab.list"
          class="tab-pane"
          :class="{ active: $tab.current == x.PMS_CODE }"
          :key="x.PMS_CODE"
        >
          <component :is="$page(x.PMS_FORM_NAME)"></component>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { $page } from "@/utils/helper";
import useTabStore from "@/stores/tab";
import router from "@/config/router";
import AppHeader from "@/views/AppHeader.vue";
import AppMenu from "@/views/AppMenu.vue";

const lang = localStorage.getItem("lang");

const signed = sessionStorage.getItem("signed") === "true";
if (!signed) router.push("/login");

const $tab = useTabStore();
</script>
