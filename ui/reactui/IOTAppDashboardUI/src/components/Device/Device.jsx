function Device({name, parameter1, parameter2, parameter3 }) {
  return (
    <div className="card" >
      {/* <div>{device.id}</div> */}
      <div>{name}</div>
      <div>{parameter1}</div>
      <div>{parameter2}</div>
      <div>{parameter3}</div>
    </div>
  );
}

export default Device