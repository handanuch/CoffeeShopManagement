<template>
  <button @click="(e) => emit('click', e)" :class="class" type="button">
    <i :class="iconCls"></i> {{ " " }}
    <slot></slot>
  </button>
</template>

<script setup>
import { computed } from "vue";

const props = defineProps({
  icon: {
    type: String,
    default: "",
  },
  class: {
    type: String,
    default: "",
  },
  spin: {
    type: Boolean,
    default: false,
  },
});
const emit = defineEmits(["click"]);

const iconCls = computed(
  () => props.icon + " " + (props.spin ? "fas fa-spinner fa-spin" : "")
);
</script>
