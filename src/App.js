import { getAllClients, getClientById } from './Api';
import './App.css';
import { useEffect, useState } from 'react';

function App() {
  const [clients, setclients] = useState([])
  const [idClient, setIdClient] = useState("")
  const [CLient, setClient] = useState()

  useEffect((() => {
    getAllClients()//getting all the clients, filling the list
      .then(data => {
        setclients(data)
      })

  }), [])

  const getTheClientById = () => {
    getClientById(idClient)
      .then(data => setClient(data))
      .catch(() => {
        alert("please enter a valid id")
        console.log("none")
      })
}


return (
  <div>
    <h1>Clients</h1>
    <table className="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>Name</th>
          <th>Address</th>
          <th>Date Of Birth</th>
          <th>Email</th>
        </tr>
      </thead>

      {!clients || clients.length === 0 ? <tbody><tr><td>loading data...</td></tr></tbody> :

        <tbody>
          {
            clients.map((p, i) => (
              <tr key={i}>
                <td>{p.id}</td>
                <td>{p.name}</td>
                <td>{p.address}</td>
                <td>{p.dateOfBirth}</td>
                <td>{p.email}</td>
              </tr>))
          }
        </tbody>}
    </table>

    <div>
      <input placeholder="enter client id" value={idClient} onChange={(i) => setIdClient(i.target.value)} />
      <button onClick={() => getTheClientById()}>Submit</button>
      {CLient && <p>{CLient.name}</p>}
    </div>
  </div>
);
}

export default App;
