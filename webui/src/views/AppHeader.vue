<template>
  <header id="page-topbar">
    <div class="navbar-header">
      <div class="d-flex">
        <div class="navbar-brand-box">
          <a href="javascript:;" class="logo">
            <span class="logo-sm">
              <h4 style="margin-top: 22px">IC</h4>
            </span>
            <span class="logo-lg">
              <h4 style="margin-top: 22px">IT COFFEE</h4>
            </span>
          </a>
        </div>

        <button
          @click="menu"
          type="button"
          class="btn btn-sm px-3 font-size-16 header-item waves-effect"
        >
          <i class="fa fa-fw fa-bars"></i>
        </button>
      </div>

      <div class="d-flex">
        <div class="dropdown d-none d-lg-inline-block ms-1">
          <button
            @click="fullscreen"
            type="button"
            class="btn header-item noti-icon waves-effect"
          >
            <i :class="fsicon"></i>
          </button>
        </div>

        <div class="dropdown d-inline-block ms-1">
          <button
            @click="toggleTheme"
            type="button"
            class="btn header-item noti-icon waves-effect"
          >
            <i :class="thicon"></i>
          </button>
        </div>

        <div class="dropdown d-inline-block">
          <button
            type="button"
            class="btn header-item noti-icon waves-effect"
            id="page-header-notifications-dropdown"
            data-bs-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            <i class="bx bx-bell bx-tada"></i>
            <span class="badge bg-danger rounded-pill">{{ notify }}</span>
          </button>
          <!-- <div
            class="dropdown-menu dropdown-menu-lg dropdown-menu-end p-0"
            aria-labelledby="page-header-notifications-dropdown"
          >
            <div class="p-3">
              <div class="row align-items-center">
                <div class="col">
                  <h6 class="m-0" key="t-notifications">Notifications</h6>
                </div>
                <div class="col-auto">
                  <a href="#!" class="small" key="t-view-all"> View All</a>
                </div>
              </div>
            </div>
            <div data-simplebar style="max-height: 230px">
              <a
                href="javascript: void(0);"
                class="text-reset notification-item"
              >
                <div class="d-flex">
                  <div class="avatar-xs me-3">
                    <span
                      class="avatar-title bg-primary rounded-circle font-size-16"
                    >
                      <i class="bx bx-cart"></i>
                    </span>
                  </div>
                  <div class="flex-grow-1">
                    <h6 class="mb-1" key="t-your-order">
                      Your order is placed
                    </h6>
                    <div class="font-size-12 text-muted">
                      <p class="mb-1" key="t-grammer">
                        If several languages coalesce the grammar
                      </p>
                      <p class="mb-0">
                        <i class="mdi mdi-clock-outline"></i>
                        <span key="t-min-ago">3 min ago</span>
                      </p>
                    </div>
                  </div>
                </div>
              </a>
              <a
                href="javascript: void(0);"
                class="text-reset notification-item"
              >
                <div class="d-flex">
                  <img
                    src=""
                    class="me-3 rounded-circle avatar-xs"
                    alt="user-pic"
                  />
                  <div class="flex-grow-1">
                    <h6 class="mb-1">James Lemire</h6>
                    <div class="font-size-12 text-muted">
                      <p class="mb-1" key="t-simplified">
                        It will seem like simplified English.
                      </p>
                      <p class="mb-0">
                        <i class="mdi mdi-clock-outline"></i>
                        <span key="t-hours-ago">1 hours ago</span>
                      </p>
                    </div>
                  </div>
                </div>
              </a>
              <a
                href="javascript: void(0);"
                class="text-reset notification-item"
              >
                <div class="d-flex">
                  <div class="avatar-xs me-3">
                    <span
                      class="avatar-title bg-success rounded-circle font-size-16"
                    >
                      <i class="bx bx-badge-check"></i>
                    </span>
                  </div>
                  <div class="flex-grow-1">
                    <h6 class="mb-1" key="t-shipped">Your item is shipped</h6>
                    <div class="font-size-12 text-muted">
                      <p class="mb-1" key="t-grammer">
                        If several languages coalesce the grammar
                      </p>
                      <p class="mb-0">
                        <i class="mdi mdi-clock-outline"></i>
                        <span key="t-min-ago">3 min ago</span>
                      </p>
                    </div>
                  </div>
                </div>
              </a>

              <a
                href="javascript: void(0);"
                class="text-reset notification-item"
              >
                <div class="d-flex">
                  <img
                    src=""
                    class="me-3 rounded-circle avatar-xs"
                    alt="user-pic"
                  />
                  <div class="flex-grow-1">
                    <h6 class="mb-1">Salena Layfield</h6>
                    <div class="font-size-12 text-muted">
                      <p class="mb-1" key="t-occidental">
                        As a skeptical Cambridge friend of mine occidental.
                      </p>
                      <p class="mb-0">
                        <i class="mdi mdi-clock-outline"></i>
                        <span key="t-hours-ago">1 hours ago</span>
                      </p>
                    </div>
                  </div>
                </div>
              </a>
            </div>
            <div class="p-2 border-top d-grid">
              <a
                class="btn btn-sm btn-link font-size-14 text-center"
                href="javascript:void(0)"
              >
                <i class="mdi mdi-arrow-right-circle me-1"></i>
                <span key="t-view-more">View More..</span>
              </a>
            </div>
          </div> -->
        </div>

        <div class="dropdown d-inline-block">
          <button
            type="button"
            class="btn header-item waves-effect"
            id="page-header-user-dropdown"
            data-bs-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            <img
              class="rounded-circle header-profile-user"
              :src="$session.IMG || img"
              :alt="$session.DISPLAY_NAME"
            />
            <span class="d-none d-xl-inline-block ms-1">
              {{ $session.USER_NAME }}
            </span>
            <i class="mdi mdi-chevron-down d-none d-xl-inline-block"></i>
          </button>
          <div class="dropdown-menu dropdown-menu-end">
            <a @click="profile" class="dropdown-item" href="javascript:;">
              <i class="bx bx-user font-size-16 align-middle me-1"></i>
              <span>{{ t("profile") }}</span>
            </a>
            <a @click="lockscreen" class="dropdown-item" href="javascript:;">
              <i class="bx bx-lock-open font-size-16 align-middle me-1"></i>
              <span>{{ t("lock_screen") }}</span>
            </a>
            <div class="dropdown-divider"></div>
            <a
              @click="logout"
              class="dropdown-item text-danger"
              href="javascript:;"
            >
              <i
                class="bx bx-power-off font-size-16 align-middle me-1 text-danger"
              ></i>
              <span>{{ t("logout") }}</span>
            </a>
          </div>
        </div>

        <div class="dropdown d-inline-block">
          <button
            type="button"
            class="btn header-item noti-icon right-bar-toggle waves-effect"
          >
            <i class="bx bx-cog bx-spin"></i>
          </button>
        </div>
      </div>
    </div>
  </header>
</template>

<script setup>
import { ref, onMounted } from "vue";
import { useI18n } from "vue-i18n";
import router from "@/config/router";
import useSessionStore from "@/stores/session";
import useTabStore from "@/stores/tab";
import lang from "@/locales/Home.json";
import img from "@/assets/images/default_user.png";
import { $usr } from "@/utils/helper";

const $session = useSessionStore();
const $tab = useTabStore();
const { t } = useI18n({ messages: lang });
const notify = ref(0);
const fsicon = ref("bx bx-fullscreen");
const thicon = ref(
  localStorage.getItem("theme") == "dark" ? "bx bx-moon" : "bx bx-sun"
);

onMounted(() => {
  document.addEventListener(
    "fullscreenchange",
    () =>
      (fsicon.value = document.fullscreenElement
        ? "bx bx-exit-fullscreen"
        : "bx bx-fullscreen")
  );
});

const toggleTheme = () => {
  const theme = localStorage.getItem("theme") == "dark" ? "light" : "dark";
  $usr.theme(theme);
  thicon.value = theme == "dark" ? "bx bx-moon" : "bx bx-sun";
};

const fullscreen = () => {
  if (!document.fullscreenElement) {
    document.documentElement.requestFullscreen();
  } else {
    if (document.exitFullscreen) {
      document.exitFullscreen();
    }
  }
};

const menu = () => {
  document.body.classList.toggle("sidebar-enable");
  if (window.innerWidth >= 992) {
    document.body.classList.toggle("vertical-collpsed");
  } else {
    document.body.classList.remove("vertical-collpsed");
  }
};

const profile = () => {
  $tab.open({
    PMS_CODE: "wfmProfile",
    PMS_NAME_LOCAL: "ព័ត៌មានផ្ទាល់ខ្លួន",
    PMS_NAME_ENG: "Profile",
    PMS_FORM_NAME: "Profile",
    IMG: "fas fa-user",
  });
};

const lockscreen = () => {};

const logout = () => {
  sessionStorage.removeItem("signed");
  router.push("/login");
};
</script>
