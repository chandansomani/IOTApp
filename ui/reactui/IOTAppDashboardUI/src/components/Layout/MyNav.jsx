
function MyNav(props) {

  //console.log("MyNav Props :" + props.delegateActionFunctions);

  return (
    <nav>
      <li>
        <a onClick={() => props.delegateActionFunctions("Devices")}>Devices</a>
      </li>
      <li>
        <a onClick={() => props.delegateActionFunctions("LiveReading")}>
          Live Readings
        </a>
      </li>
      <li>
        <a onClick={() => props.delegateActionFunctions("Login")}>Login</a>
      </li>
    </nav>
  );
}

export default MyNav