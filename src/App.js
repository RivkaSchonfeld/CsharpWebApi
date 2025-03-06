import { getAllClients } from './Api';
import './App.css';
import { useEffect, useState } from 'react';

function App() {
  const [clients, setclients] = useState([])

  useEffect((() => {
    getAllClients()
      .then(data => {
        setclients(data)
        console.log(data)
      })
  }), [])

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
    </div>
  );
}

export default App;
