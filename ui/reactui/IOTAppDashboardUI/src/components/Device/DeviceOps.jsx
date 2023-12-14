import { useState } from "react";
import ListofDevices from "./ListofDevices";
import AddDevice from "./AddDevice";



function DeviceOps() {
  const Views = ["Device Summary", "Add New Device", "Manage Devices", " Testing Bulk Add Random Device"]
  const [currentView, setCurrentView] = useState(Views[0]); // default View

  async function addRandomDevices(
    url = "https://localhost:7125/api/Device/ManualSeedData"
  ) {
    const response = await fetch(url);
    var deviceList = await response.json();
    console.log(deviceList);
    // setListofDevices(deviceList);
  }
    // console.log(currentView);
  return (
    <div>
      {/* DeviceOps */}
      <nav>
        <button onClick={() => setCurrentView(Views[0])}>{Views[0]}</button>
        <button onClick={() => setCurrentView(Views[1])}>{Views[1]}</button>
        <button onClick={() => setCurrentView(Views[2])}>{Views[2]}</button>
      </nav>
      <>
        {currentView == Views[0] ? <ListofDevices /> : null}
        {currentView == Views[1] ? <AddDevice /> : null}

      </>
        <button onClick={() => addRandomDevices()}>{Views[3]}</button>
    </div>
  );
}

export default DeviceOps