import { useState, useEffect } from "react";

const atividadeInicial = {
  Id: 0,
  Titulo: "",
  Prioridade: 0,
  Descricao: "",
};

export default function AtividadeForm(props) {
  const [atividade, setAtividade] = useState(atividadeAtual());

  useEffect(() => {
    if (props.atividadeSelecionada.Id !== 0) setAtividade(props.atividadeSelecionada);
  }, [props.atividadeSelecionada]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setAtividade({ ...atividade, [name]: value });
  };

  function atividadeAtual() {
    if (props.atividadeSelecionada.Id !== 0) {
      return props.atividadeSelecionada;
    } else {
      return atividadeInicial;
    }
  }

  const editarOuCriarAtividade = (e) => {
    e.preventDefault();

    if(props.atividadeSelecionada.Id !== 0){
      props.atualizarAtividade(atividade)
    } else {
      props.addAtividade(atividade);
    }

    setAtividade(atividadeInicial)
  }

  const cancelarEdicao = (e) => {
    e.preventDefault();

    props.cancelarAtividade();

    setAtividade(atividadeInicial);
  };


  return (
    <>
      <h1>Atividade {atividade.Id !==0 ? atividade.Id : ''}</h1>
      <form className="row g-3" onSubmit={editarOuCriarAtividade}>
        <div className="col-md-6 mb-1">
          <label className="form-label">Título</label>
          <input
            className="form-control"
            id="titulo"
            name="Titulo"
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
            name="Prioridade"
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
            name="Descricao"
            onChange={inputTextHandler}
            value={atividade.Descricao}
            placeholder="Descricao"
          />
        </div>
        <div className="col-12">
          {props.atividadeSelecionada.Id === 0 ? (
            <button className="btn btn-outline-secondary" type="submit">
              <i className="fas fa-plus me-2"></i>
              Atividade
            </button>
          ) : (
            <>
              <button className="btn btn-outline-success me-2" type="submit">
                <i className="fas fa-plus me-2"></i>
                Salvar
              </button>

              <button
                className="btn btn-outline-warning"
                onClick={cancelarEdicao}
              >
                <i className="fas fa-plus me-2"></i>
                Cancelar
              </button>
            </>
          )}
        </div>
      </form>
    </>
  );
}
