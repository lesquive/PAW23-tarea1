import Restaurantes from "./components/Restaurantes";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import EditarRestaurante from "./components/EditarRestaurante";
import "./App.css";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Restaurantes />} />
        <Route path="/edit/:id" element={<EditarRestaurante />} />
      </Routes>
    </Router>
  );
}

export default App;
