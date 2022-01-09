import { useState } from "react";
import "./App.css";

import AtividadeForm from "./components/AtividadeForm";
import AtividadesLista from "./components/AtividadesLista";

function App() {
  const [listaAtividades, setListaAtividades] = useState([
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
  ]);

  const [atividade, setAtividade] = useState({});

  function addAtividade(e) {
    e.preventDefault();
    const atividade = {
      Id: document.getElementById("id").value,
      Descricao: document.getElementById("descricao").value,
      Titulo: document.getElementById("titulo").value,
      Prioridade: document.getElementById("prioridade").value,
    };
    setListaAtividades([...listaAtividades, { ...atividade }]);
  }

  function deletarAtividade(id) {
    const atividadesFiltradas = listaAtividades.filter((p) => p.Id !== id);

    setListaAtividades([...atividadesFiltradas]);
  }

  function editarAtividade(id) {
    const atividade = listaAtividades.filter((p) => p.Id === id);


    setAtividade([atividade(0)]);
  }

  return (
    <>
      <AtividadeForm
        addAtividade={addAtividade}
        listaAtividades={listaAtividades}
        AtivSelecionada={atividade}
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
