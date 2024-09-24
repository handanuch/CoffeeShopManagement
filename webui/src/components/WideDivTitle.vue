<template>
  <h4 class="card-title mb-4">
{{ title }}
    <span class="badge badge-soft-primary font-size-11 m-1">
      {{ badge }}
    </span>
  </h4>
</template>

<script setup>
const props = defineProps({
  title: {
    type: String,
    default: "",
  },
  badge: {
    type: String,
    default: "",
  },
});
</script>
