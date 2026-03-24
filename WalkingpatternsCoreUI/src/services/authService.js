import axios from "axios";

const API_URL = "/api/Auth";

export const login = async (username, password) => {

    const response = await axios.post(API_URL + "/login", {
        username: username,
        password: password
    });

    if (response.data.token) {
        localStorage.setItem("token", response.data.token);
        localStorage.setItem("username",response.data.username);
    }

    return response.data;
};

export const logout = () => {
    localStorage.removeItem("token");
};