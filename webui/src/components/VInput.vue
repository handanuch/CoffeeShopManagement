<template>
  <div class="mb-2 col-sm-12 col-md-8 col-lg-6 col-xl-4" :class="class">
    <label v-if="label" class="form-label" :class="rq ? 'rq' : ''">
      {{ label }}
    </label>
    <slot></slot>
  </div>
</template>

<script setup>
const props = defineProps({
  label: {
    type: String,
    default: "",
  },
  rq: {
    type: Boolean,
    default: false,
  },
  class: {
    type: String,
    default: "",
  },
});
</script>
