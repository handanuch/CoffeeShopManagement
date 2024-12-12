<template>
  <!-- <Spinner v-if="products.isLoading" /> -->
  <p v-if="getItems.length === 0">No products found.</p>
  <Product
    v-else
    v-for="product in getItems"
    :key="product.id"
    :product="product"
  />

  <paginate
    v-if="filter.paginated"
    :page-count="Math.ceil(filtered.length / filter.itemsPerPage)"
    :page-range="3"
    :margin-pages="2"
    :click-handler="clickCallback"
    :prev-text="'Prev'"
    :next-text="'Next'"
    :container-class="'pagination'"
    :page-class="'page-item'"
  />
</template>

<script setup lang="ts">
import { ref, computed, watch, onMounted } from "vue";
// import { useStore } from "vuex";
// import Spinner from "../components/Spinner.vue";
// import Product from "../components/Product.vue";
// import Paginate from "vuejs-paginate-next";

// Define props with TypeScript-style type inference
interface FilterProps {
  limit?: number;
  name?: string;
  type?: string;
  priceMin?: number;
  priceMax?: number;
  paginated?: boolean;
  itemsPerPage?: number;
}

const props = withDefaults(
  defineProps<{
    filter?: FilterProps;
  }>(),
  {
    filter: () => ({
      limit: -1,
      name: "",
      type: "",
      priceMin: 0,
      priceMax: 99,
      paginated: false,
      itemsPerPage: 12,
    }),
  }
);

// Reactive state
// const store = useStore();
const filtered = ref([]);
const currentPage = ref(1);

// Computed properties
// const products = computed(() => store.state.products);
const getItems = computed(() => {
  if (props.filter.paginated) {
    let current = currentPage.value * props.filter.itemsPerPage;
    let start = current - props.filter.itemsPerPage;
    return filtered.value.slice(start, current);
  } else {
    return filtered.value;
  }
});

// Methods
const filterCondition = (product) => {
  if (
    props.filter.name &&
    !product.title.toLowerCase().includes(props.filter.name.toLowerCase())
  ) {
    return false;
  }
  if (props.filter.type && product.category !== props.filter.type) {
    return false;
  }
  if (props.filter.priceMin && product.price < props.filter.priceMin) {
    return false;
  }
  if (props.filter.priceMax && product.price > props.filter.priceMax) {
    return false;
  }
  return true;
};

// const filterProducts = () => {
//   console.log("Filtering products");
//   // Filter products
//   filtered.value = products.value.data.filter((product) => {
//     return filterCondition(product);
//   });
//   if (props.filter.limit !== -1) {
//     filtered.value = filtered.value.slice(0, props.filter.limit);
//   }

//   return filtered.value;
// };

const clickCallback = (pageNum) => {
  currentPage.value = Number(pageNum);
};

// Watchers
// watch(
//   () => props.filter,
//   () => {
//     filterProducts();
//   },
//   { deep: true }
// );

// watch(
//   () => products.value.isLoading,
//   () => {
//     filterProducts();
//   }
// );

// // Initial filter on mount
// onMounted(() => {
//   filterProducts();
// });
</script>

<style scoped>
.pagination {
  margin: 10px;
  justify-content: center;
  cursor: pointer;
  list-style: none;
  padding: 0;
  margin: 0;
}
</style>
