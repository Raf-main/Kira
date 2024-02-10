import instance from "./axiosInstance";

export default class AuthService {
  async login(data) {
    try {
      const response = await instance.post("login", data);
      console.log(response);
      return response.data;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async signup(data) {
    try {
      const response = await instance.post("register", data);
      console.log(response);
      return response.data;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  async refreshToken() {
    try {
      const response = await instance.post("refreshAccessToken");
      console.log(response);
      return response.data;
    } catch (error) {
      console.log(error);
      throw error;
    }
  }
}
