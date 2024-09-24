import { defineStore } from "pinia";
import { ref, computed } from "vue";

const useLoadingStore = defineStore("loading", () => {
  const taskList = ref([]);
  const loading = computed(() => taskList.value.length > 0);

  const addTask = (id) => {
    taskList.value.push(id);
  };
  const removeTask = (id) => {
    taskList.value = taskList.value.filter((x) => x != id);
  };

  return { loading, addTask, removeTask };
});

export default useLoadingStore;
