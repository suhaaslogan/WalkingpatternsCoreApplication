import React from "react";
import { Link, useNavigate } from "react-router-dom";

function Layout({ children }) {

  const navigate = useNavigate();
  const token = localStorage.getItem("token");

  const logout = () => {
    localStorage.removeItem("token");
    navigate("/");
  };

  return (

    <div className="d-flex flex-column min-vh-100">

      <nav className="navbar navbar-expand-sm navbar-light" style={{backgroundColor:"#e3f2fd"}}>

        <div className="container-fluid">

          <Link className="navbar-brand" to="/dashboard">
            Walking Patterns
          </Link>

          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNav"
          >
            <span className="navbar-toggler-icon"></span>
          </button>

          <div className="collapse navbar-collapse" id="navbarNav">

            <ul className="navbar-nav ms-auto">

              {token ? (

                <li className="nav-item">
                  <button
                    className="nav-link btn btn-link"
                    onClick={logout}
                  >
                    Logout
                  </button>
                </li>

              ) : (

                <li className="nav-item">
                  <Link className="nav-link" to="/">
                    Login
                  </Link>
                </li>

              )}

            </ul>

          </div>

        </div>

      </nav>

      <div className="container body-content flex-grow-1 mt-3">

        {children}

      </div>

      <footer className="text-center mt-auto mb-3">
        © {new Date().getFullYear()}
      </footer>

    </div>
  );
}

export default Layout;