import { useState } from "react";
import "./App.css";

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

  function prioridadeAtividade(param) {
    switch (param) {
      case "1":
        return "Baixa";
      case "2":
        return "Normal";
      case "3":
        return "Alta";

      default:
        return "Não Definido";
    }
  }

  function prioridadeAtividadeStyle(param, icone) {
    switch (param) {
      case "1":
        return icone ? "smile" : "success";
      case "2":
        return icone ? "meh" : "secondary";
      case "3":
        return icone ? "frown" : "danger";

      default:
        return "dark";
    }
  }

  return (
    <>
      <form className="row g-3">
        <div className="col-md-6">
          <label className="form-label">Id da atividade</label>
          <input
            className="form-control"
            id="id"
            type="text"
            readOnly
            placeholder="Id"
            value={Math.max.apply(Math, listaAtividades.map(p => p.Id)) + 1}
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Prioridade</label>
          <select id="prioridade" className="form-select">
            <option defaultValue="0">Selecione...</option>
            <option value="1">Baixa</option>
            <option value="2">Normal</option>
            <option value="3">Alta</option>
          </select>
        </div>

        <div className="col-md-6 mb-1">
          <label className="form-label">Título</label>
          <input
            className="form-control"
            id="titulo"
            type="text"
            placeholder="Título"
          />
        </div>

        <div className="col-md-6 mb-1">
          <label className="form-label">Descrição da atividade</label>
          <input
            className="form-control"
            id="descricao"
            type="text"
            placeholder="Descricao"
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
            <div
              className={
                "card-body border border-" +
                prioridadeAtividadeStyle(ativ.Prioridade, false)
              }
            >
              <div className="d-flex justify-content-between">
                <h5 className="card-title">
                  <span
                    className={
                      "badge rounded-pill me-2 bg-" +
                      prioridadeAtividadeStyle(ativ.Prioridade, false)
                    }
                  >
                    {ativ.Id} - {ativ.Titulo}
                  </span>
                </h5>
                <h6>
                  Prioridade:
                  <span
                    className={
                      "ms-2 text-" + prioridadeAtividadeStyle(ativ.Prioridade, false)
                    }
                  >
                    <i
                      className={
                        "me-1  far fa-" +
                        prioridadeAtividadeStyle(ativ.Prioridade, true)
                      }
                    ></i>
                    {prioridadeAtividade(ativ.Prioridade)}
                  </span>
                </h6>
              </div>
              <p className="card-text">{ativ.Descricao}</p>

              <div className="d-flex justify-content-end border-top pt-2 m-0">
                <button className="btn-sm btn-outline-primary me-2">
                  <i className="fas fa-pen me-2"></i>
                  Editar
                </button>
                <button className="btn-sm btn-outline-danger">
                  <i className="fas fa-trash me-2"></i>
                  Deletar
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </>
  );
}

export default App;
