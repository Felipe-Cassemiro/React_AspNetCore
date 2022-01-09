import { useState, useEffect } from "react";
import "./App.css";

import AtividadeForm from "./components/AtividadeForm";
import AtividadesLista from "./components/AtividadesLista";

let initialStage = [
  {
    Id: 1,
    Descricao: "Primeira Atividade",
    Prioridade: "1",
    Titulo: "Título",
  },
  {
    Id: 2,
    Descricao: "Segunda Atividade",
    Prioridade: "1",
    Titulo: "Título",
  },
]

function App() {
  const [index, setIndex] = useState(0);
  const [listaAtividades, setListaAtividades] = useState(initialStage);
  const [atividade, setAtividade] = useState({Id: 0});

  useEffect(() => {
    listaAtividades.length <= 0 ? setIndex(1) : 
    setIndex(Math.max.apply(Math,listaAtividades.map((p) => p.Id)) + 1)

  }, [listaAtividades])

  function addAtividade(ativ) {
    
    setListaAtividades([...listaAtividades, { ...ativ, Id: index  }]);
  }

  function atualizarAtividade(ativ) {
    setListaAtividades(listaAtividades.map(p => p.Id === ativ.Id ? ativ : p))
    setAtividade({Id: 0})
  }

  function cancelarAtividade() {
    setAtividade({Id: 0})
  }

  function deletarAtividade(id) {
    const listaAtividadesFiltradas = listaAtividades.filter((p) => p.Id !== id);

    setListaAtividades([...listaAtividadesFiltradas]);
  }

  function editarAtividade(id) {
    const atividade = listaAtividades.filter((p) => p.Id === id);
    
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
