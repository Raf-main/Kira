import axios from "axios";
import * as apiConfig from "../../config/serverApiConfig";
import tokenService from "./tokenService";

const instance = axios.create({
  baseURL: apiConfig.API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
    Authorization: `Bearer ${tokenService.getToken()}`,
  },
});

export default instance;
