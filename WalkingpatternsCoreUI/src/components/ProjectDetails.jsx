import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import AddProjectModal from "./AddProjectModal";

function ProjectVersions() {
  const { clientName } = useParams();
  const [projects, setProjects] = useState([]);

    const [showModal, setShowModal] = useState(false);

  useEffect(() => {
    loadProjects();
  }, []);

  const loadProjects = async () => {
    const res = await axios.get(
      `https://localhost:7107/api/client/project/${clientName}`
    );
    setProjects(res.data);
  };

  return (
    <div className="container mt-4">

      <h4 className="text-end">
        Client Name : {clientName}
      </h4>

      <div className="d-flex justify-content-between mt-4">

        <input
          type="text"
          placeholder="Search projects"
          className="form-control w-25"
        />

       <button
          className="btn btn-primary"
          onClick={()=>setShowModal(true)}
        >
          + Add New Project
        </button>


        <AddProjectModal
        show={showModal}
        onClose={()=>setShowModal(false)}
        clientName={clientName}
        refreshProjects={loadProjects}
      />

      </div>

      <table className="table table-bordered mt-5">
        <thead>
          <tr>
            <th>Project Name</th>
            <th>Project Date</th>
            <th>Version Number</th>
            <th>Edit</th>
          </tr>
        </thead>

        <tbody>

          {projects.length === 0 ? (
            <tr>
              <td colSpan="4" className="text-center">
                No Projects Found
              </td>
            </tr>
          ) : (
            projects.map((p, index) => (
              <tr key={index}>
                <td>{p.projectName}</td>
                <td>{p.projectDate}</td>
                <td>{p.versionNumber}</td>

                <td>

                  <button className="btn btn-primary me-2">
                    ✏️
                  </button>

                  <button className="btn btn-danger">
                    🗑
                  </button>

                </td>
              </tr>
            ))
          )}

        </tbody>
      </table>

    </div>
  );
}

export default ProjectVersions;