import { useState } from "react";
import getFormValues from "../Layout/getFormValues"


function AddDevice() {

  const sampleJson = {
    "id": 9,
    "name": "Device 28",
    "parameter1": 74,
    "parameter2": "Low",
    "parameter3": 27
  };

  async function addDevices(url = "https://localhost:7125/api/Device") {
    const response = await fetch(url);
    var deviceList = await response.json();
    // console.log(deviceList);
    // setListofDevices(deviceList);
  }

  const onSubmit = (e) => {
    e.preventDefault();
    const { isEmpty, data } = getFormValues(e.currentTarget);

    if (isEmpty) {
      console.log("please provide all values");
      return;
    }

    //TODO Submit form data to api & test its working

    console.log(data);

    // clear inputs
    e.currentTarget.reset();
  };

  const [inInputName, setInputName] = useState("Device 28");
  const [inParameter1, setParameter1 ] = useState("74");
  const [inParameter2, setParameter2 ] = useState("High");
  const [inParameter3, setParameter3 ] = useState("18");

  return (
    <div>
      <h2>AddDevice</h2>
      <form onSubmit={onSubmit}>
        <input
          id="Name"
          type="text"
          name="name"
          value={inInputName}
          onChange={(e) => setInputName(e.target.value)}
        />
        <input
          id="parameter1"
          type="text"
          name="parameter1"
          value={inParameter1}
          onChange={(e) => setParameter1(e.target.value)}
        />
        <input
          id="parameter2"
          type="text"
          name="parameter2"
          value={inParameter2}
          onChange={(e) => setParameter2(e.target.value)}
        />
        <input
          id="parameter3"
          type="text"
          name="parameter3"
          value={inParameter3}
          onChange={(e) => setParameter3(e.target.value)}
        />
        <input type="submit" name="Submit" value=">" />
      </form>
    </div>
  );
}

export default AddDevice;
