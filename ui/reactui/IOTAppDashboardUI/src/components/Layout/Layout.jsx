import "./Layout.css";
import App from "../App/App";
import MyFooter from "./MyFooter";
import MyNav from "./MyNav";
import MyHeader from "./MyHeader";

function Layout() {
  return (
    <>
      <div className="container">
        <MyHeader />
          <MyNav />
          <App />
        <MyFooter />
      </div>
    </>
  );
}

export default Layout;
