import { useState, useEffect } from "react";

const atividadeInicial = {
  id: 0,
  titulo: "",
  prioridade: "NaoDefinido",
  descricao: "",
};

export default function AtividadeForm(props) {
  const [atividade, setAtividade] = useState(atividadeAtual());

  useEffect(() => {
    if (props.atividadeSelecionada.id !== 0) setAtividade(props.atividadeSelecionada);
  }, [props.atividadeSelecionada]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setAtividade({ ...atividade, [name]: value });
  };

  function atividadeAtual() {
    if (props.atividadeSelecionada.id !== 0) {
      return props.atividadeSelecionada;
    } else {
      return atividadeInicial;
    }
  }

  const editarOuCriarAtividade = (e) => {
    e.preventDefault();

    if(props.atividadeSelecionada.id !== 0){
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
      <form className="row g-3" onSubmit={editarOuCriarAtividade}>
        <div className="col-md-6 mb-1">
          <label className="form-label">Título</label>
          <input
            className="form-control"
            id="titulo"
            name="titulo"
            onChange={inputTextHandler}
            value={atividade.titulo}
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
            value={atividade.prioridade}
            className="form-select"
          >
            <option value="NaoDefinido">Selecione...</option>
            <option value="Baixa">Baixa</option>
            <option value="Normal">Normal</option>
            <option value="Alta">Alta</option>
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
            value={atividade.descricao}
            placeholder="Descricao"
          />
        </div>
        <div className="col-12">
          
          <button className="btn btn-outline-secondary" type="submit">
              <i className="fas fa-plus me-2"></i>
              Salvar
            </button>
          {props.atividadeSelecionada.id === 0 ? (
            <span></span>
          ) : (
            <>
              <button
                className="ms-2 btn btn-outline-warning"
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
