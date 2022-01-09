import React from "react";

export default function AtividadeForm(props) {
  
  const inputTextHandler = (e) => {
    const {name, value} = e.target;
  }
  
  return (
    <form className="row g-3">
      <div className="col-md-6">
        <label className="form-label">Id da atividade</label>
        <input
          name="id"
          className="form-control"
          id="id"
          type="text"
          onChange={inputTextHandler}
          placeholder="Id"
          value={
            Math.max.apply(
              Math,
              props.listaAtividades.map((p) => p.Id)
            ) + 1
          }
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
        <button className="btn btn-outline-secondary" onClick={props.addAtividade}>
          + Atividades
        </button>
      </div>
    </form>
  );
}
