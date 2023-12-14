import DeviceOps from "../Device/DeviceOps";
import ListofDevices from "../Device/ListofDevices";
import { Views } from "../Layout/data";
import LiveReading from "../LiveReading/LiveReading";
import Login from "../Login/Login";
import "./App.css";

function App(props) {
    // TODO :  Display the Respective component in App [ ListofDevices, Recordings, User Management]
    let layout = props.layout;
    console.log(layout);
    return (
      <>
        {layout == Views[0] ? <ListofDevices /> : null}
        {layout == Views[1] ? <LiveReading /> : null}
        {layout == Views[2] ? <Login /> : null}
        {layout == Views[3] ? <DeviceOps /> : null}
      </>
    );
}

export default App;
