import React from "react";

export default function Atividade(props) {

    function prioridadeAtividade(param) {
        switch (param) {
          case "Baixa":
          case "Normal":
          case "Alta":
            return param;
    
          default:
            return "Não Definido";
        }
      }
    
      function prioridadeAtividadeStyle(param, icone) {
        switch (param) {
          case "Baixa":
            return icone ? "smile" : "success";
          case "Normal":
            return icone ? "meh" : "secondary";
          case "Alta":
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
          prioridadeAtividadeStyle(props.ativ.prioridade, false)
        }
      >
        <div className="d-flex justify-content-between">
          <h5 className="card-title">
            <span
              className={
                "badge rounded-pill me-2 bg-" +
                prioridadeAtividadeStyle(props.ativ.prioridade, false)
              }
            >
              {props.ativ.id} - {props.ativ.titulo}
            </span>
          </h5>
          <h6>
            Prioridade:
            <span
              className={
                "ms-2 text-" +
                prioridadeAtividadeStyle(props.ativ.prioridade, false)
              }
            >
              <i
                className={
                  "me-1  far fa-" +
                  prioridadeAtividadeStyle(props.ativ.prioridade, true)
                }
              ></i>
              {prioridadeAtividade(props.ativ.prioridade)}
            </span>
          </h6>
        </div>
        <p className="card-text">{props.ativ.descricao}</p>

        <div className="d-flex justify-content-end border-top pt-2 m-0">
          <button className="btn-sm btn-outline-primary me-2"
            onClick={() => props.editarAtividade(props.ativ.id)}
          >
            <i className="fas fa-pen me-2"></i>
            Editar
          </button>
          <button
            className="btn-sm btn-outline-danger"
            onClick={() => props.deletarAtividade(props.ativ.id)}
          >
            <i className="fas fa-trash me-2"></i>
            Deletar
          </button>
        </div>
      </div>
    </div>
  );
}
