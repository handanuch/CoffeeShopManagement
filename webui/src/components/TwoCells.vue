<template>
  <p class="mb-1">{{ first }}</p>
  <p class="mb-0">
    <span class="badge badge-pill badge-soft-primary font-size-11">
      {{ second }}
    </span>
  </p>
</template>

<script setup>
const props = defineProps({
  first: {
    type: String,
    default: "",
  },
  second: {
    type: String,
    default: "",
  },
});
</script>
