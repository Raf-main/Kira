import { configureStore } from "@reduxjs/toolkit";
import AuthReducer from "../reducers/authReducer";

const store = configureStore({
  reducer: {
    auth: AuthReducer
  }
});

export default store;
