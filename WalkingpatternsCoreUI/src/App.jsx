import React from "react";
import Layout from "./components/Layout.jsx";
import Login from "./components/Login.jsx";
import Dashboard from "./components/Dashboard.jsx";
import ProjectDetails from "./components/ProjectDetails.jsx";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {

  return (
    <BrowserRouter>

      <Routes>

        <Route path="/" element={<Login />} />

        <Route
          path="/dashboard"
          element={
            <Layout>
              <Dashboard />
            </Layout>
          }
        />

        <Route
          path="/project/:clientName"
          element={
            <Layout>
              <ProjectDetails />
            </Layout>
          }
        />

      </Routes>


    </BrowserRouter>
  );


}

export default App;