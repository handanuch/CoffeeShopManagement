import { createI18n } from "vue-i18n";
import lang from "@/locales/_locales.json";

const i18n = createI18n({
  legacy: false,
  locale: localStorage.getItem("lang") || "en",
  fallbackLocale: "en",
  missingWarn: false,
  fallbackWarn: false,
  messages: lang,
});

export default i18n;
