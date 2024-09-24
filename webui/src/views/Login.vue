<template>
  <div class="position-fixed top-0 end-0 p-2">
    <button
      @click="toggleTheme"
      class="btn btn-soft-primary btn-rounded float-end"
    >
      <i :class="thicon"></i>
    </button>
  </div>
  <div class="container-login100">
    <div class="account-pages mt-5 pt-sm-5">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-md-8 col-lg-6 col-xl-5">
          <div class="card overflow-hidden">
            <div class="bg-primary-subtle">
              <div class="row">
                <div class="col-12 container-loginhearder">
                  <div class="text-primary p-4">
                    <h5 class="text-primary">  </h5>
                    <p> </p>
                  </div>
                  <div class="text-primary p-4">
                    <h5 class="text-primary">  </h5>
                    <p> </p>
                  </div>
                </div>
                <div class="col-12">
                  <div class="p-4">
                    <h5 class="text-primary">{{ t("welcome") }}</h5>
                    <p>{{ t("sign_into_your_account") }}</p>
                    <div class="mt-2 waves-effect">
                    <img
                      @click="changeLang('km')"
                      class="ms-1"
                      src="@/assets/images/flags/km-kH.png"
                      alt=""
                      height="20"
                    />
                    <img
                      @click="changeLang('en')"
                      class="ms-1"
                      src="@/assets/images/flags/en-US.png"
                      alt=""
                      height="20"
                    />
                  </div>
                  </div>
                  
                </div>
                
                <!-- <div class="col-5 align-self-end">
                  <a href="/favicon.ico">
                  <img src="/favicon.ico" alt="Favicon" />
                  </a>
                  </div> -->
                <!-- <div class="col-5 align-self-end">
                  
                  <img
                    src="@/assets/images/Logo1.png"
                    alt=""
                    class="img-fluid"
                  />
                </div> -->
              </div>
            </div>
            <div class="card-body pt-0">
              <div class="mt-4"></div>
              <div class="p-2">
                <form @submit.prevent class="form-horizontal">
                  <!-- <div v-show="!authorized" class="mb-3">
                    <label class="form-label rq">{{ t("credential") }}</label>
                    <input
                      v-model="credential"
                      @keyup.enter="access"
                      autocomplete="username"
                      type="text"
                      class="form-control"
                    />
                  </div> -->
                  <div v-show="authorized" class="mb-3">
                    <label class="text-primary">{{ t("username") }}</label>
                    <input
                      v-model="dto.USER_NAME"
                      autocomplete="username"
                      type="text"
                      class="form-control"
                    />
                  </div>
                  <div v-show="authorized" class="mb-3">
                    <label class="text-primary">{{ t("password") }}</label>
                    <input
                      v-model="dto.PASSWORD"
                      @keyup.enter="login"
                      @keydown="
                        (event) =>
                          (capsLock = event.getModifierState('CapsLock'))
                      "
                      autocomplete="current-password"
                      v-bind="{ type: showPassword ? 'text' : 'password' }"
                      class="form-control"
                    />
                    <h6 v-show="capsLock" class="mt-2 red">
                      {{ t("caps_lock") }}
                    </h6>
                  </div>

                  <div v-show="authorized" class="form-check">
                    <input
                      v-model="rememberMe"
                      class="form-check-input"
                      type="checkbox"
                    />
                    <label
                      @click="rememberMe = !rememberMe"
                      class="form-check-label"
                    >
                      {{ t("remember_me") }}
                    </label>

                    <div class="form-check float-end">
                      <input
                        v-model="showPassword"
                        class="form-check-input"
                        type="checkbox"
                        @showPassword="showPassword = !showPassword"
                      />
                      <label
                        @click="showPassword = !showPassword"
                        class="form-check-label"
                      >
                        {{ t("show_password") }}
                      </label>
                    </div>
                  </div>

                  <div class="mt-3 d-grid">
                    <Button
                      v-show="!authorized"
                      @click="access"
                      class="btn btn-primary waves-effect waves-light"
                      icon="fas fa-key"
                      >{{ t("access") }}
                    </Button>
                    <Button
                      v-show="authorized"
                      @click="login"
                      :disabled="loginLoading"
                      class="btn btn-outline-secondary"
                      icon="fas fa-key"
                      :spin="loginLoading"
                    >
                      {{ t("login") }}
                    </Button>
                  </div>
                </form>
                
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="mt-5 text-center">
        <div>
          <h4>
            {{ t("Develop by Team POS Coffee Shop") }}
            
          </h4>
        </div>
      </div>
    </div>
  </div>
  </div>
  
</template>

<script setup>
import { ref, reactive } from "vue";
import { useI18n } from "vue-i18n";
import lang from "@/locales/Login.json";
import { $api, $msg, $usr, $b64 } from "@/utils/helper";
import router from "@/config/router";
import { onMounted } from "vue";

const { t, locale } = useI18n({ messages: lang });
const dto = reactive({
  USER_NAME: "admin",
  PASSWORD: "123",
});
const rememberMe = ref(false);
const capsLock = ref(false);
const authorized = ref(localStorage.getItem("crd") ? true : false);
const credential = ref("LOP002");
const loginLoading = ref(false);
const showPassword = ref(false);
const thicon = ref(
  localStorage.getItem("theme") == "dark" ? "bx bx-moon" : "bx bx-sun"
);

const toggleTheme = () => {
  const t = localStorage.getItem("theme") == "dark" ? "light" : "dark";
  $usr.theme(t);
  thicon.value = t == "dark" ? "bx bx-moon" : "bx bx-sun";
};

const changeLang = (s) => {
  localStorage.setItem("lang", s);
  locale.value = s;
};

const login = () => {
  if (!verifyData()) return;
  
      sessionStorage.setItem("signed", true);
      router.push("/");
    
 
};

const access = () => {
  // if (credential.value.trim() == "") {
  //   $msg.show(t("invalid", [t("credential")]));
  //   return;
  // }
  localStorage.setItem("crd", credential.value.trim());
  authorized.value = true;
};

const verifyData = () => {
  // if (dto.USER_NAME.trim() == "") {
  //   $msg.show(t("invalid", [t("username")]));
  //   return false;
  // } else if (dto.PASSWORD == "") {
  //   $msg.show(t("invalid", [t("password")]));
  //   return false;
  // }
  return true;
};

onMounted(() => {
  const rem = localStorage.getItem("rem");
  if (rem) {
    console.log("un", rem)
    const obj = JSON.parse($b64.dec(rem));
    console.log("dec",obj)
    dto.USER_NAME = obj.USER_NAME;
    dto.PASSWORD = obj.PASSWORD;
    rememberMe.value = true;
  }
});
</script>
<style scoped>
.container-login100 {
  background-image: url('@/assets/images/backlogin.jpg');
  background-size: cover;
  background-position: center;
}
.container-loginhearder{
  background-image: url('@/assets/images/hearder.jpg');
  background-size: cover;
  background-position: center;
}
.red {
  color: red;
}
.rq {
  color: red;
}
</style>