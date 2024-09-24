import axios from "axios";
import Swal from "sweetalert2";
import routes from "@/router";
import Page404 from "@/views/Page404.vue";
import i18n from "@/config/i18n";
import router from "@/config/router";
import useLoadingStore from "@/stores/loading";
import moment from "moment";
const { t } = i18n.global;

const $api = {
  post: (url, dto, ok, ld = null, notok = null, pms = null, rt = "json") => {
    const loading = useLoadingStore();
    const uuid = $getUUID();
    const headers = {
      "x-crd": localStorage.getItem("crd") || "",
      "x-token": $session()?.TOKEN || "",
      "x-pms":
        pms || (dto instanceof FormData ? dto.get("X_PMS_ID") : dto.X_PMS_ID),
    };
    if (ld != null) ld.value = true;
    loading.addTask(uuid);
    axios
      .post(url, dto, { headers: headers, responseType: rt })
      .then((res) => {
        loading.removeTask(uuid);
        if (ld != null) ld.value = false;
        ok(res.data);
      })
      .catch((err) => {
        loading.removeTask(uuid);
        if (rt == "arraybuffer") {
          const de = new TextDecoder();
          console.log(de.decode(err.response.data));
          return;
        }
        console.log(err);
        if (ld != null) ld.value = false;
        switch (err.response.status) {
          case 400:
            if (err.response.data.message) {
              $msg.error(err.response.data.message);
            } else if (err.response.data.Errors) {
              for (var k in err.response.data.Errors) {
                if (k == "dto") continue;
                $msg.error(err.response.data.Errors[k]);
                return;
              }
            }
            break;
          case 401:
            $msg.error(t("invalid_session"), () => {
              sessionStorage.removeItem("signed");
              router.push("/login");
            });
            break;
          case 403:
            $msg.error(t("you_dont_have_permission"));
            break;
          case 406:
            break;
          case 418: {
            $msg.error(err.response.data.locale);
            break;
          }
          case 500:
            $msg.error(err.response.data);
            break;
          default:
            $msg.error(err.response.status + " " + err.response.statusText);
            break;
        }
        if (notok != null) {
          notok(
            err.response.status == 400 &&
              !err.response.data.message &&
              !err.response.data.Errors,
            err.response.status,
            err.response.data
          );
        }
      });
  },
};

const $msg = {
  show: (s, c) =>
    Swal.fire({
      text: s,
      icon: "info",
      showConfirmButton: false,
      showCloseButton: true,
      didClose: () => {
        if (typeof c != "undefined") c();
      },
    }),
  warn: (s) =>
    Swal.fire({
      text: s,
      icon: "warning",
      showConfirmButton: false,
      showCloseButton: true,
    }),
  error: (s, c) =>
    Swal.fire({
      text: s,
      icon: "error",
      showConfirmButton: false,
      showCloseButton: true,
    }).then((result) => {
      if (result.isDismissed) {
        if (typeof c != "undefined") c();
      }
    }),

  success: (s, c) =>
    Swal.fire({
      text: s,
      icon: "success",
      showConfirmButton: false,
      showCloseButton: true,
    }).then((result) => {
      if (result.isDismissed) {
        if (typeof c != "undefined") c();
      }
    }),
  confirm: (s, y) =>
    Swal.fire({
      text: s,
      icon: "question",
      showCancelButton: true,
      showConfirmButton: true,
      cancelButtonColor: "#d33",
      cancelButtonText: t("no"),
      confirmButtonText: t("yes"),
      confirmButtonColor: "#3085d6",
      showCloseButton: true,
    }).then((result) => {
      if (result.isConfirmed) y();
    }),
};

const $usr = {
  apply: () => {
    const t = localStorage.getItem("theme") == "dark" ? "dark" : "light";
    $usr.theme(t);
  },
  theme: (s) => {
    const t = s == "dark" ? s : "light";
    localStorage.setItem("theme", t);
    document.documentElement.setAttribute("data-bs-theme", t);
    document.body.setAttribute("data-sidebar", t);
  },
};

const $b64 = {
  enc: (s) => {
    if (s == null) return null;
    return btoa(unescape(encodeURIComponent(s)));
  },
  dec: (s) => {
    if (s == null) return null;
    return decodeURIComponent(escape(atob(s)));
  },
};
const $date = {
  now: () => moment().utc(true).format("YYYY-MM-DD"),
  format: (s, f) => (s == null ? "" : moment(s).format(f)),
};

const $exr = {
  exchange: (arr, fccy, tccy, amt) => {
    if (arr.length <= 0) return 0;
    if (fccy == tccy) return amt;
    const f_avg_rate = arr.find((x) => x.CCY == fccy)?.ERV_AVG || 1;
    const t_avg_rate = arr.find((x) => x.CCY == tccy)?.ERV_AVG || 1;
    return amt * (f_avg_rate / t_avg_rate);
  },
  crossrate: (arr, fccy, tccy) => {
    if (arr.length <= 0) return 0;
    if (fccy == tccy) return 1;
    const f_avg_rate = arr.find((x) => x.CCY == fccy)?.ERV_AVG || 1;
    const t_avg_rate = arr.find((x) => x.CCY == tccy)?.ERV_AVG || 1;
    return f_avg_rate / t_avg_rate;
  },
};

const $session = () => {
  if (!localStorage.getItem("usr")) return null;
  return JSON.parse($b64.dec(localStorage.getItem("usr")));
};

const $page = (id) => routes[id] || Page404;

const $rptType = (type) => {
  switch (type) {
    case "html":
      return ["HTML5", "text/html", "html"];
    case "docx":
      return [
        "WORDOPENXML",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "docx",
      ];
    case "xlsx":
      return [
        "EXCELOPENXML",
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        "xlsx",
      ];
    default:
      return ["PDF", "application/pdf", "pdf"];
  }
};

const $getUUID = () => {
  if (
    typeof window.crypto !== "undefined" &&
    typeof window.crypto.randomUUID === "function"
  ) {
    return window.crypto.randomUUID();
  } else {
    return Date.now().toString(36) + Math.random().toString(36).substring(2);
  }
};
const neverNull = (number) => {
  return isNaN(number) ? 0 : number;
};
const setCommas = (number) => {
  return number.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
};
const setDecimal = (number) => {
  return number.toString().replace(/\B(?<!\.\d*)(?=(\d{3})+(?!\d))/g, ",");
};
const clearCommas = (number) => {
  return number.toString().replace(/,/g, "");
};

const getNumber = (number) => {
  return neverNull(parseFloat(clearCommas(number)));
};

const getDate = (date) => {
  date = new Date(date);
  return new Date(
    date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate()
  );
};

const formatNumber = (number, ext = 0, pm = false) => {
  number = getNumber(number);
  return number == 0 && pm == number.toStringue
    ? "-"
    : setCommas(number.toFixed(ext));
};

const clearZero = (sel) => {
  // return '' instead 0
  if (sel.value == "0") {
    sel.value = "";
  }
};

const addZero = (sel) => {
  // return 0 instead ''
  if (sel.value == "") {
    sel.value = "0";
  }
};
const clearZeroD = (sel) => {
  // return '' instead 0
  if (sel.value == "0.00") {
    sel.value = "";
  } else {
    sel.value = clearCommas(sel.value);
  }
};
function focusNumber(el, ext = 0) {
  if ($(el).val() == (0).toFixed(ext)) {
    $(el).val("");
  } else {
    $(el).val(clearCommas($(el).val()));
  }
}
function focusoutNumber(el, ext = 0) {
  $(el).val(formatNumber($(el).val(), ext));
}

const addZeroD = (sel) => {
  // return 0 instead ''
  if (sel.value == "") {
    sel.value = "0.00";
  } else {
    sel.value = setDecimal(sel.value);
  }
};
const inputInteger = (el) => {
  // Allow input [0-9] only
  el.value = el.value.replace(/[^0-9]/g, "");
};

const inputDecimal = (el) => {
  // Allow input [0-9] & [.] only
  el.value = el.value.replace(/[^0-9.]/g, "").replace(/(\..*)\./g, "$1");
};

const $id = () => Math.random().toString(36).substring(2, 15);

export {
  $api,
  $msg,
  $usr,
  $b64,
  $date,
  $page,
  $rptType,
  $exr,
  $session,
  $getUUID,
  setCommas,
  clearCommas,
  getNumber,
  getDate,
  formatNumber,
  clearZero,
  addZero,
  addZeroD,
  clearZeroD,
  inputDecimal,
  inputInteger,
  $id,
};
