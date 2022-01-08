import { useState } from "react";
import "./App.css";

function App() {
  const [listaAtividades, setListaAtividades] = useState([
    {
      Id: 1,
      Descricao: "Primeira Atividade",
    },
    {
      Id: 2,
      Descricao: "Segunda Atividade",
    },
  ]);

  function addAtividade(e) {
    e.preventDefault();
    const atividade = {
      Id: document.getElementById("id").value,
      Descricao: document.getElementById("descricao").value,
    };
    setListaAtividades([...listaAtividades, { ...atividade }]);
  }

  return (
    <>
      <form className="row g-3">
        <div className="colmd-6">
          <label className="form-label" htmlFor="id">
            Id da atividade
          </label>
          <input
            className="form-control"
            id="id"
            type="text"
            placeholder="Id"
          />
        </div>
        <div className="colmd-6 mb-1">
          <label className="form-label" htmlFor="descricao">
            Descrição da atividade
          </label>
          <input
            className="form-control"
            id="descricao"
            type="text"
            placeholder="descricao"
          />
        </div>
        <div className="col-12">
          <button className="btn btn-outline-secondary" onClick={addAtividade}>
            + Atividades
          </button>
        </div>
      </form>

      <div className="mt-5">
        {listaAtividades.map((ativ) => (
          <div key={ativ.Id} className="card mb-2 shadow-sm">
            <div className="card-body">
              <div className="d-flex justify-content-between">
                <h5 className="card-title">
                  <span className="badge rounded-pill bg-secondary me-2">
                    {ativ.Id} - título
                  </span>
                </h5>
                <h6>Prioridade: Normal</h6>
              </div>
              <p className="card-text">{ativ.Descricao}</p>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default App;
