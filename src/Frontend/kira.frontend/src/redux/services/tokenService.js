class TokenService {
  constructor() {
    this.accessTokenKey = "accessToken";
  }
  getToken() {
    return localStorage.getItem(this.accessTokenKey);
  }

  setToken(token) {
    localStorage.setItem(this.accessTokenKey, token);
  }

  removeToken() {
    localStorage.removeItem(this.accessTokenKey);
  }
}

const tokenService = new TokenService();

export default tokenService;
