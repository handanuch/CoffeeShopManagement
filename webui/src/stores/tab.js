import { defineStore } from "pinia";
import { ref } from "vue";

const useTabStore = defineStore("tab", () => {
  const list = ref([]);
  const current = ref("");
  const activate = (x) => {
    current.value = x.PMS_CODE;
  };
  const open = (x) => {
    const exists = list.value.filter((y) => y.PMS_CODE == x.PMS_CODE);
    if (exists.length > 0) {
      current.value = x.PMS_CODE;
      return;
    }
    list.value.push(x);
    current.value = x.PMS_CODE;
  };
  const close = (x) => {
    const idx = list.value.findIndex((y) => y.PMS_CODE == x.PMS_CODE);
    if (idx > -1) {
      list.value.splice(idx, 1);
      if (x.PMS_CODE != current.value) return;
      const length = list.value.length;
      if (length == 0) current.value = "";
      else if (idx == length) current.value = list.value[length - 1].PMS_CODE;
      else current.value = list.value[idx].PMS_CODE;
    }
  };

  return { list, current, activate, open, close };
});

export default useTabStore;
