import "./Layout.css";
import App from "../App/App";
import MyFooter from "./MyFooter";
import MyNav from "./MyNav";
import MyHeader from "./MyHeader";
import { useState } from "react";
import { Views } from "./data";

function Layout() {
  const [currentView, setCurrentView] = useState(Views[3]);  // default View

  //console.log(currentView);

  return (
    <>
      <div className="container">
          <MyHeader />
        <MyNav delegateActionFunctions={setCurrentView} />
        <App layout={currentView} />
        <MyFooter />
      </div>
    </>
  );
}

export default Layout;
