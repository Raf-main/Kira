import AuthService from "../services/authService";
import * as AuthTypes from "../types/auth.types";

const authService = new AuthService();

export const loginRequest = () => ({
  type: AuthTypes.LOGIN_REQUEST,
});

export const signupRequest = () => ({
  type: AuthTypes.SIGNUP_REQUEST,
});

export const logoutRequest = () => ({
  type: AuthTypes.LOGOUT_REQUEST,
});

export const loginSuccess = (data) => ({
  type: AuthTypes.LOGIN_SUCCESS,
  payload: data,
});

export const signupSuccess = () => ({
  type: AuthTypes.SIGNUP_SUCCESS,
});

export const loginError = (data) => ({
  type: AuthTypes.LOGIN_ERROR,
  payload: data,
});

export const signupError = (data) => ({
  type: AuthTypes.SIGNUP_ERROR,
  payload: data,
});

export const loginAsync = (data) => {
  return async (dispatch) => {
    try {
      dispatch(loginRequest());
      const loginData = await authService.login(data);
      dispatch(loginSuccess(loginData));
    } catch (error) {
      dispatch(loginError(error));
    }
  };
};

export const signupAsync = (data) => {
  return async (dispatch) => {
    try {
      dispatch(signupRequest());
      await authService.signup(data);
      dispatch(signupSuccess());
    } catch (error) {
      dispatch(signupError(error));
    }
  };
};
