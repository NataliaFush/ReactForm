
import Form from "./components/Form";
import Home from "./components/Home";


const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/Registration',
    element: <Form />
  },

];

export default AppRoutes;
