import { createApp } from "vue";
import App from "@/App.vue";
import pinia from "@/config/pinia";
import router from "@/config/router";
import i18n from "@/config/i18n";
import { $usr } from "@/utils/helper";
import Button from "@/widgets/Button.vue";
import Pagination from "@/widgets/Pagination.vue";
import Stepper from "@/widgets/Stepper.vue";
import WideDiv from "@/components/WideDiv.vue";
import WideDivTitle from "@/components/WideDivTitle.vue";
import VInput from "@/components/VInput.vue";
import TwoCells from "@/components/TwoCells.vue";
import ActionCells from "@/components/ActionCells.vue";

$usr.apply();

import "@/assets/css/icons.css";
import "@/assets/css/fonts.css";
import "@/assets/css/bootstrap.css";
import "@/assets/css/app.css";
import "simplebar/dist/simplebar.css";
import "metismenujs/style";
import "@/assets/css/styles.css";

const app = createApp(App);
app.use(pinia);
app.use(router);
app.use(i18n);

app.component("Button", Button);
app.component("Pagination", Pagination);
app.component("Stepper", Stepper);
app.component("VInput", VInput);
app.component("WideDiv", WideDiv);
app.component("WideDivTitle", WideDivTitle);
app.component("TwoCells", TwoCells);
app.component("ActionCells", ActionCells);
app.mount("#app");

import "@/assets/js/bootstrap.bundle";
import "simplebar/dist/index";
