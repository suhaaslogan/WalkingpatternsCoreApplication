import React, { useEffect, useState } from "react";
import axios from "axios";
import { Modal } from "bootstrap";
import { useNavigate } from "react-router-dom";

function Dashboard() {

  const [clients,setClients] = useState([]);
  const [search,setSearch] = useState("");

  const [clientName,setClientName] = useState("");
  const [phone,setPhone] = useState("");
  const [email,setEmail] = useState("");
  const [address,setAddress] = useState("");

  const token = localStorage.getItem("token");

  const username = localStorage.getItem("username");

  useEffect(()=>{
    loadClients();
  },[]);

  const loadClients = async()=>{

    const res = await axios.get(
      "https://localhost:7107/api/Home",
      {
        headers:{
          Authorization:"Bearer " + token
        }
      }
    );

    setClients(res.data);
  };

  const addClient = async(e)=>{
    e.preventDefault();

    await axios.post(
      "https://localhost:7107/api/Home",
      {
       ClientName: clientName,
       Phone: phone,
       Email: email,
       Address: address
      },
      {
        headers:{
          Authorization:"Bearer " + token
        }
      }
    );

    setClientName("");
    setPhone("");
    setEmail("");
    setAddress("");

    loadClients();

    setClientName("");
    setPhone("");
    setEmail("");
    setAddress("");

  // close modal
  const modalElement = document.getElementById("addClientModal");
  const modal = Modal.getInstance(modalElement);

  if (modal) {
    modal.hide();
  }

  // Fix grey background
  document.body.classList.remove("modal-open");

  const backdrops = document.getElementsByClassName("modal-backdrop");
  while (backdrops.length > 0) {
    backdrops[0].parentNode.removeChild(backdrops[0]);
  }
  };

  const navigate = useNavigate();

  const editClient = (clientName) => {
  navigate(`/project/${clientName}`);
};

  const deleteClient = async(name)=>{

    if(!window.confirm("Delete this client?")) return;

    await axios.delete(
      `https://localhost:7107/api/Home/${name}`,
      {
        headers:{
          Authorization:"Bearer " + token
        }
      }
    );

    loadClients();
  };

  return(

<div className="container mt-4">

<h3 className="text-center mb-5">Welcome, {username} To Your Dashboard</h3>


<div className="d-flex justify-content-between mb-4">

<form
className="d-flex"
onSubmit={(e)=>e.preventDefault()}
>

<input
className="form-control me-2"
placeholder="Search by Client Name"
value={search}
onChange={(e)=>setSearch(e.target.value)}
/>

<button className="btn btn-outline-primary">
Search
</button>

</form>

<button
className="btn btn-primary"
data-bs-toggle="modal"
data-bs-target="#addClientModal"
>
Add New Client
</button>

</div>

<table className="table table-bordered">

<thead>

<tr>
<th>Client Name</th>
<th>Phone</th>
<th>Email</th>
<th>Address</th>
<th>Actions</th>
</tr>

</thead>

<tbody>

{clients.length === 0 ? (

<tr>
<td colSpan="5" className="text-center">
Please add client details
</td>
</tr>

) : (

clients
.filter(c=>c.clientName.toLowerCase().includes(search.toLowerCase()))
.map((c,i)=>(

<tr key={i}>

<td>{c.clientName}</td>
<td>{c.phone}</td>
<td>{c.email}</td>
<td>{c.address}</td>

<td>

<button
className="btn btn-primary me-2"
title="Edit Client"
onClick={()=>editClient(c.clientName)}
>
<i className="fas fa-pen-to-square"></i>
</button>

<button
className="btn btn-danger"
title="Delete Client"
onClick={()=>deleteClient(c.clientName)}
>
<i className="fas fa-trash"></i>
</button>

</td>

</tr>

))

)}

</tbody>

</table>

{/* Modal */}

<div className="modal fade" id="addClientModal" tabIndex="-1">

 <div className="modal-dialog modal-dialog-centered">

<div className="modal-content">

<div className="modal-header">

<h5>Add Client</h5>

<button
className="btn-close"
data-bs-dismiss="modal"
></button>

</div>

<div className="modal-body">

<form onSubmit={addClient}>

<div className="mb-3">
<input
className="form-control"
placeholder="Client Name"
value={clientName}
onChange={(e)=>setClientName(e.target.value)}
required
/>
</div>

<div className="mb-3">
<input
className="form-control"
placeholder="Phone"
value={phone}
onChange={(e)=>setPhone(e.target.value)}
required
/>
</div>

<div className="mb-3">
<input
className="form-control"
placeholder="Email"
value={email}
onChange={(e)=>setEmail(e.target.value)}
required
/>
</div>

<div className="mb-3">
<textarea
className="form-control"
placeholder="Address"
rows="3"
value={address}
onChange={(e)=>setAddress(e.target.value)}
></textarea>
</div>

<button className="btn btn-primary w-100">
Save
</button>

</form>
</div>

</div>

</div>

</div>

</div>

  );
}

export default Dashboard;