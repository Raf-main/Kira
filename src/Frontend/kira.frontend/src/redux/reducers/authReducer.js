import * as AuthTypes from "../types/auth.types";

const initialState = {
  user: {},
  isLoggedIn: false,
  isLoading: false,
  errorMessage: ""
};

const AuthReducer = (state = initialState, action) => {
  console.log(action);
  switch (action.type) {
    case AuthTypes.LOGIN_REQUEST:
      return {
        ...state,
        user: {},
        isLoading: true,
        errorMessage: "",
        isLoggedIn: false
      };
    case AuthTypes.SIGNUP_REQUEST:
      return {
        ...state,
        user: {},
        isLoading: true,
        errorMessage: "",
        isLoggedIn: false
      };
    case AuthTypes.LOGIN_SUCCESS:
      return {
        ...state,
        user: action.payload,
        isLoading: false,
        errorMessage: "",
        isLoggedIn: true
      };
    case AuthTypes.SIGNUP_SUCCESS:
      return {
        ...state,
        user: {},
        isLoading: false,
        errorMessage: "",
        isLoggedIn: false
      };
    case AuthTypes.LOGIN_ERROR:
      return {
        ...state,
        user: {},
        isLoading: false,
        errorMessage: action.payload.message,
        isLoggedIn: false
      };
    case AuthTypes.SIGNUP_ERROR:
      return {
        ...state,
        user: {},
        isLoading: false,
        errorMessage: action.payload.message,
        isLoggedIn: false
      };
    case AuthTypes.LOGOUT_REQUEST:
      return {
        ...state,
        user: {},
        isLoading: false,
        errorMessage: ""
      };
    default:
      return state;
  }
};

export default AuthReducer;
