import React from "react";
import { useState } from "react";
import { connect, useDispatch } from "react-redux";
import { loginAsync } from "../../redux/actions/authAction";

export const LoginForm = () => {
  const defaultForm = {
    email: "",
    password: "",
    hidePassword: true
  };

  const [formData, setFormData] = useState(defaultForm);
  const [hidePassword, setHidePassword] = useState(true);
  const dispatch = useDispatch();

  const handleInputChange = (e) => {
    const { name, value } = e.target;

    setFormData({ ...formData, [name]: value });
  };

  const handleClickHidePassword = () => {
    setHidePassword(!hidePassword);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(loginAsync(formData));
  };

  return (
    <div>
      <div>LoginForm</div>
      <form onSubmit={handleSubmit}>
        <input name="email" onChange={handleInputChange} />
        <input
          name="password"
          onChange={handleInputChange}
          type={hidePassword ? "password" : "text"}
        />
        <button type="button" onClick={handleClickHidePassword}>
          Change password visibillity
        </button>
        <button type="button" onClick={handleSubmit}>
          Submit
        </button>
      </form>
    </div>
  );
};

const mapStateToProps = (state) => {
  return {
    error: state.auth.errorMessage,
    isLoading: state.auth.isLoading,
    isLoggedIn: state.auth.isLoggedIn
  };
};

export default connect(mapStateToProps)(LoginForm);
