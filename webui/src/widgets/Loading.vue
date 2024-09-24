<template>
  <div class="loader-container" v-if="store.loading">
    <div class="loader"></div>
  </div>
</template>

<script setup>
import useLoadingStore from "@/stores/loading";
const store = useLoadingStore();
</script>
