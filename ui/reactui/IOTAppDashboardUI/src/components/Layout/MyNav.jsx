import { Views } from "./data";

function MyNav(props) {
  //console.log("MyNav Props :" + props.delegateActionFunctions);

  let content = Views.map((item, index) => {
    return (
      <li key={index}>
        <a onClick={() => props.delegateActionFunctions(item)}>{item}</a>
      </li>
    );
  });
  return <nav>{content}</nav>;
}

export default MyNav;
