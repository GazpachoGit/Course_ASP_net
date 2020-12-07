import axios from "axios";
import qs from "qs";

const instance = axios.create({
    baseURL: "/api/v1/",
    paramsSerializer: function (params) {
      return qs.stringify(params, { arrayFormat: "repeat" });
    },
  });

  export const loadProducts = async (filters) => {
    const response = await instance.get("Products", {
      params: filters,
    });
  
    return response.data;
  };
  
  export const loadListings = async () => {
      const resp = await instance.get('Listing', {params: {}});
  }