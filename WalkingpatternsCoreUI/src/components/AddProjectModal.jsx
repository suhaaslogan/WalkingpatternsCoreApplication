import { useState } from "react";
import axios from "axios";

function AddProjectModal({ show, onClose, clientName, refreshProjects }) {

  const [projectName, setProjectName] = useState("");
  const [projectDate, setProjectDate] = useState("");

  const saveProject = async (e) => {
    e.preventDefault();

    try {

      const response = await axios.post(
        "https://localhost:7107/api/client/addProject",
        {
          projectName: projectName,
          projectDate: projectDate,
          clientName: clientName,
          versionNumber: "Version 1A"
        }
      );

      if (response.data.success) {

        refreshProjects();   // reload table
        onClose();           // close popup

        setProjectName("");
        setProjectDate("");
      }
      else {
        alert(response.data.message);
      }

    } catch (error) {
      console.error(error);
      alert("Error saving project");
    }
  };

  if (!show) return null;

  return (
    <>
      <div className="modal-backdrop fade show"></div>

      <div className="modal fade show d-block">
        <div className="modal-dialog modal-dialog-centered">
          <div className="modal-content">

            <div className="modal-header">
              <h5>Add New Project</h5>

              <button
                className="btn-close"
                onClick={onClose}
              ></button>
            </div>

            <div className="modal-body">

              {/* IMPORTANT */}
              <form onSubmit={saveProject}>

                <div className="mb-3">
                  <label>Project Name</label>

                  <input
                    type="text"
                    className="form-control"
                    value={projectName}
                    onChange={(e) => setProjectName(e.target.value)}
                    required
                  />
                </div>

                <div className="mb-3">
                  <label>Project Date</label>

                  <input
                    type="date"
                    className="form-control"
                    value={projectDate}
                    onChange={(e) => setProjectDate(e.target.value)}
                    required
                  />
                </div>

                <div className="text-center">
                  {/* IMPORTANT */}
                  <button type="submit" className="btn btn-primary">
                    Save
                  </button>
                </div>

              </form>

            </div>

          </div>
        </div>
      </div>
    </>
  );
}

export default AddProjectModal;