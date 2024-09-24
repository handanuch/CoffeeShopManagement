<template>
  <div class="d-flex gap-3">
    <a @click="(e) => emit('view', e)" href="javascript:;" class="text-primary">
      <i class="mdi mdi-eye font-size-18"></i>
    </a>
    <a @click="(e) => emit('edit', e)" href="javascript:;" class="text-success">
      <i class="mdi mdi-pencil font-size-18"></i>
    </a>
    <a
      @click="(e) => emit('delete', e)"
      href="javascript:;"
      class="text-danger"
    >
      <i class="mdi mdi-delete font-size-18"></i>
    </a>
  </div>
</template>

<script setup>
const props = defineProps({
  view: {
    type: Boolean,
    default: true,
  },
  edit: {
    type: Boolean,
    default: true,
  },
  delete: {
    type: Boolean,
    default: true,
  },
});

const emit = defineEmits(["view", "edit", "delete"]);
</script>
