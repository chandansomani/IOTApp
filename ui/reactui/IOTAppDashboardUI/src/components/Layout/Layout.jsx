import "./Layout.css";
import App from "../App/App";
import MyFooter from "./MyFooter";
import MyNav from "./MyNav";
import MyHeader from "./MyHeader";

function Layout() {
  return (
    <>
      <div>
        <MyHeader />
        <section>
          <MyNav />
          <article>
            <App />
            <App />
            <App />
          </article>
        </section>
        <MyFooter />
      </div>
    </>
  );
}

export default Layout;
