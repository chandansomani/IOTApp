import "./Layout.css";
import App from "../App/App";
import MyFooter from "./MyFooter";
import MyNav from "./MyNav";
import MyHeader from "./MyHeader";
import { useState } from "react";

const Views = ["Devices", "LiveReading", "Login"]

function Layout() {

  const [currentView, setCurrentView] = useState(Views[0]);

  //console.log(currentView);

  return (
    <>
      <div className="container">
        <MyHeader />
          <MyNav delegateActionFunctions={setCurrentView}/>
          <App layout={currentView} />
        <MyFooter />
      </div>
    </>
  );
}

export default Layout;
