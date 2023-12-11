import { useState } from "react";
import "./Devices.css";
import Device from "./Device";

function ListofDevices() {
  const [ListofDevices, setListofDevices] = useState([]);

  async function getDevicesList(url = "https://localhost:7125/api/Device") {
    const response = await fetch(url);
    var deviceList = await response.json();
    // console.log(deviceList);
    setListofDevices(deviceList);
  }

  async function addRandomDevices(
    url = "https://localhost:7125/api/Device/ManualSeedData"
  ) {
    const response = await fetch(url);
    var deviceList = await response.json();
    console.log(deviceList);
    // setListofDevices(deviceList);
  }

  return (
    <>
      <button onClick={() => getDevicesList()}>Show All Devices</button>
      <button>Add New Device</button>
      <button>Manage Devices</button>

      <div className="cardcontainer">
        {ListofDevices.map((device, index) => (
          <Device key={index} {...device} />
        ))}
      </div>
      <button onClick={() => addRandomDevices()}>Bulk Add Random Device</button>
    </>
  );
}

export default ListofDevices;
