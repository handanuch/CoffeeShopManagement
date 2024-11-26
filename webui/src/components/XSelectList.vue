<template>
  <div class="select3">
    <button
      @click="clickHandle"
      type="button"
      class="form-control"
      :disabled="disabled"
    >
      <li>
        <img v-if="image != ''" :src="imageSelected" />
        <span>{{ textSelected }}</span>
      </li>
    </button>
    <i
      @click="clearClick"
      v-show="isOpen && nullable"
      class="bx bx-x icon-float red"
    ></i>
    <div class="select3" v-show="isOpen">
      <input
        v-model="text"
        @keyup.enter="query"
        type="text"
        class="form-control"
        :placeholder="t('search')"
      />
      <i @click="query" class="bx bx-search icon-float"></i>
      <ul>
        <li v-for="x in datalist" :key="x" @click="selectedClick(x)">
          <img v-if="image != ''" :src="x[image]" />
          <span>{{ displayFields(x) }}</span>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup>
import { ref, computed, watch, onMounted } from "vue";
import { $api } from "@/utils/helper";
import { useI18n } from "vue-i18n";
import lang from "./XSelectList.json";

const { t } = useI18n({ messages: lang });
const datalist = ref([]);
const current = ref(null);
const isOpen = ref(false);
const text = ref("");

const query = () => {
  if (props.data?.is_valid == false) return;
  const dto = { ...props.data, FILTER: text.value };
  $api.post(props.rest, dto, (data) => {
    datalist.value = data;
    if (
      props.modelValue == null &&
      props.autoselect == true &&
      data.length > 0
    ) {
      current.value = data[0];
    }
  });
};

const displayFields = (obj) => {
  let text = "";
  props.fields.split(",").forEach((x) => {
    text += obj[x] + props.separator;
  });
  text = text.slice(0, -props.separator.length);
  return text;
};

const textSelected = computed(() => {
  if (current.value == null) return t("please select");
  return displayFields(current.value);
});

const imageSelected = computed(() => {
  if (current.value == null) return "";
  return current.value[props.image];
});

const clickHandle = () => {
  if (props.disabled) return;
  isOpen.value = !isOpen.value;
};

const selectedClick = (x) => {
  current.value = x;
  isOpen.value = false;
};

const clearClick = () => {
  current.value = null;
  isOpen.value = false;
};

const props = defineProps({
  modelValue: {
    type: Object,
    default: null,
  },
  rest: {
    type: String,
    default: "",
  },
  data: {
    type: Object,
    default: null,
  },
  image: {
    type: String,
    default: "",
  },
  pk: {
    type: String,
    default: "",
  },
  fields: {
    type: String,
    default: "",
  },
  separator: {
    type: String,
    default: " ",
  },
  nullable: {
    type: Boolean,
    default: false,
  },
  autoselect: {
    type: Boolean,
    default: true,
  },
  disabled: {
    type: Boolean,
    default: false,
  },
  pms: {
    type: Object,
    default: null,
  },
});

const emit = defineEmits(["update:modelValue", "change"]);

watch(current, () => {
  emit("update:modelValue", current.value);
  emit("change", current.value);
});

watch(
  () => props.modelValue,
  () => {
    current.value = props.modelValue;
    if (props.modelValue && props.pk) {
      const exist = datalist.value.find(
        (x) => x[props.pk] == props.modelValue[props.pk]
      );
      if (exist) {
        current.value = exist;
      }
    }
  }
);

watch(
  () => props.data,
  () => query()
);

onMounted(() => {
  if (props.modelValue) current.value = props.modelValue;
  query();
});
</script>
