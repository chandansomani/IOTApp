
import getFormValues from "./getFormValues";
function Login() {

    const onSubmit = (e) => {
      e.preventDefault();
      const { isEmpty, data } = getFormValues(e.currentTarget);

      if (isEmpty) {
        console.log("please provide all values");
        return;
      }

      // fetch User Token from
      // https://localhost:7125/api/Login
      // save token if valid
      // else
      //
      //
      console.log(data);

      // clear inputs
      e.currentTarget.reset();
    };

  return (
    <>
      <form onSubmit={onSubmit}>
        <input id="UserName" type="text" name="UserName" />
        <input id="password" type="password" name="Password" />
        <input type="submit" name="Submit" value=">" />
      </form>
    </>
  );
}
export default Login;


//Src :  https://github.com/john-smilga/youtube-react-formdata-api/blob/main/src/App.jsx
// Yt : https://www.youtube.com/watch?v=WrX5RndZIzw