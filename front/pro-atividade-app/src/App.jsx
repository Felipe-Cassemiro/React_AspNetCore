import { useState, useEffect } from "react";
import "./App.css";

import AtividadeForm from "./components/AtividadeForm";
import AtividadesLista from "./components/AtividadesLista";
import apiAtividade from './api/atividade'


function App() {
  const [listaAtividades, setListaAtividades] = useState([]);
  const [atividade, setAtividade] = useState({id: 0});

  const listarAtividades = async () => {
    const response = await apiAtividade.get('atividade');
    return response.data;
  }
  
  useEffect(() => {
    const getAtividades = async () => {
      const todasAtividades = await listarAtividades();
      if (todasAtividades) setListaAtividades(todasAtividades);
    }
    getAtividades();
  }, [])

  const addAtividade = async (ativ) => {
    const response = await apiAtividade.post('atividade', ativ);
    setListaAtividades([...listaAtividades, response.data]);
  }

  const atualizarAtividade = async (ativ) => {
    const response = await apiAtividade.put('atividade/', ativ)
    const { id } = response.data
    setListaAtividades(listaAtividades.map(p => p.id === id ? response.data : p))
    setAtividade({id: 0})
  }

  function cancelarAtividade() {
    setAtividade({id: 0})
  }

  const deletarAtividade = async (id) => {
    if (await apiAtividade.delete(`atividade/${id}`)) {
      const listaAtividadesFiltradas = listaAtividades.filter((p) => p.id !== id);
      setListaAtividades([...listaAtividadesFiltradas]);
   }
  }

  function editarAtividade(id) {
    const atividade = listaAtividades.filter((p) => p.id === id);
    
    setAtividade(atividade[0]);
  }

  return (
    <>
      <AtividadeForm
        addAtividade={addAtividade}
        listaAtividades={listaAtividades}
        atividadeSelecionada={atividade}
        atualizarAtividade={atualizarAtividade}
        cancelarAtividade={cancelarAtividade}
      />
      <AtividadesLista
        deletarAtividade={deletarAtividade}
        editarAtividade={editarAtividade}
        listaAtividades={listaAtividades}
      />
    </>
  );
}

export default App;
