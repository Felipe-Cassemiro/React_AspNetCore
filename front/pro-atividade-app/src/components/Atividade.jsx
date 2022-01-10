import React from "react";

export default function Atividade(props) {

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
    <div className="card mb-2 shadow-sm">
      <div
        className={
          "card-body border border-" +
          prioridadeAtividadeStyle(props.ativ.Prioridade, false)
        }
      >
        <div className="d-flex justify-content-between">
          <h5 className="card-title">
            <span
              className={
                "badge rounded-pill me-2 bg-" +
                prioridadeAtividadeStyle(props.ativ.Prioridade, false)
              }
            >
              {props.ativ.Id} - {props.ativ.Titulo}
            </span>
          </h5>
          <h6>
            Prioridade:
            <span
              className={
                "ms-2 text-" +
                prioridadeAtividadeStyle(props.ativ.Prioridade, false)
              }
            >
              <i
                className={
                  "me-1  far fa-" +
                  prioridadeAtividadeStyle(props.ativ.Prioridade, true)
                }
              ></i>
              {prioridadeAtividade(props.ativ.Prioridade)}
            </span>
          </h6>
        </div>
        <p className="card-text">{props.ativ.Descricao}</p>

        <div className="d-flex justify-content-end border-top pt-2 m-0">
          <button className="btn-sm btn-outline-primary me-2"
            onClick={() => props.editarAtividade(props.ativ.Id)}
          >
            <i className="fas fa-pen me-2"></i>
            Editar
          </button>
          <button
            className="btn-sm btn-outline-danger"
            onClick={() => props.deletarAtividade(props.ativ.Id)}
          >
            <i className="fas fa-trash me-2"></i>
            Deletar
          </button>
        </div>
      </div>
    </div>
  );
}
