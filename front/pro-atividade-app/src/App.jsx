import "./App.css";
import Atividade from "./pages/atividades/Atividade";
import {Routes, Route} from 'react-router-dom'
import Cliente from "./pages/clientes/Cliente";
import DashBoard from './pages/dashboard/Dashboard';

export default function App() {

  return (
    <Routes>
      <Route path="/atividades" element={<Atividade/>}></Route>
      <Route path="/clientes" element={<Cliente />}></Route>
      <Route path="/" element={<DashBoard/>}></Route>
    </Routes>
  );
}

