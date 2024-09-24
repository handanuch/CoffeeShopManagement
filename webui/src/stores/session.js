import { defineStore } from "pinia";
import { ref } from "vue";

const useSessionStore = defineStore(
  "session",
  () => {
    const USER_NAME = ref("admin");
    const DISPLAY_NAME = ref("Administrator");
    const IMG = ref("");

    return { USER_NAME, DISPLAY_NAME, IMG };
  },
  { persist: true }
);

export default useSessionStore;
