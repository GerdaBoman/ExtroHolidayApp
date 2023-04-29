import { Route, Routes } from "react-router-dom";
import "./App.css";
import Home from "./pages/Home";
import Planner from "./pages/Planner";
import NotFound from "./pages/NotFound";
import Footer from "./component/footer";
import { Navbar } from "./component/navbar";

function App() {
  return (
    <div className="App">
      <Navbar />
      <Routes>
        <Route path="/" Component={Home} />
        <Route path="/planner" Component={Planner} />
        <Route path="*" Component={NotFound} />
      </Routes>
      <Footer />
    </div>
  );
}

export default App;
