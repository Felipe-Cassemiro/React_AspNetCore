import { useState, useEffect } from "react";

const atividadeInicial = {
  Id: 0,
  Titulo: '',
  Prioridade: 0,
  Descricao: ''
}

export default function AtividadeForm(props) {
  const [atividade, setAtividade] = useState(atividadeAtual());

  useEffect(() => {
    if (props.atividadeSelecionada.Id !== 0)
      setAtividade(props.atividadeSelecionada);
  }, [props.atividadeSelecionada])


  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setAtividade({ ...atividade, [name]: value });
  };


  function atividadeAtual () {
    if(props.atividadeSelecionada.Id !== 0){
      return props.atividadeSelecionada
    } else {
      return atividadeInicial
    }
  }

  return (
    <form className="row g-3">
      <div className="col-md-6 mb-1">
        <label className="form-label">Título</label>
        <input
          className="form-control"
          id="titulo"
          name="titulo"
          onChange={inputTextHandler}
          value={atividade.Titulo}
          type="text"
          placeholder="Título"
        />
      </div>

      <div className="col-md-6">
        <label className="form-label">Prioridade</label>
        <select
          id="prioridade"
          name="prioridade"
          onChange={inputTextHandler}
          value={atividade.Prioridade}
          className="form-select"
        >
          <option defaultValue="0">Selecione...</option>
          <option value="1">Baixa</option>
          <option value="2">Normal</option>
          <option value="3">Alta</option>
        </select>
      </div>

      <div className="col-md-12 mb-1">
        <label className="form-label">Descrição da atividade</label>
        <textarea
          className="form-control"
          id="descricao"
          type="text"
          name="descricao"
          onChange={inputTextHandler}
          value={atividade.Descricao}
          placeholder="Descricao"
        />
      </div>
      <div className="col-12">
        <button
          className="btn btn-outline-secondary"
          onClick={props.addAtividade}
        >
          + Atividades
        </button>
      </div>
    </form>
  );
}
