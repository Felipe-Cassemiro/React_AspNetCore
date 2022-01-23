import { useState, useEffect } from "react";
import {Button, Modal} from "react-bootstrap";

import AtividadeForm from "./AtividadeForm";
import AtividadesLista from "./AtividadesLista";
import apiAtividade from '../../api/atividade';
import TitlePage from '../../components/TitlePage';


export default function Atividade() {

  const [showModalAtividade, setShowModalAtividade] = useState(false);
  const [smShowModalExcluirAtividade, setSmShowModalExcluirAtividade] = useState(false);
  const [listaAtividades, setListaAtividades] = useState([]);
  const [atividade, setAtividade] = useState({id: 0});

  const handleAbrirOuFecharModalAtividade = () => setShowModalAtividade(!showModalAtividade);

  const toggleModalExcluirAtividade = (id) => {
    if(id !== 0 && id !== undefined){
      const atividade = listaAtividades.filter((p) => p.id === id);
      setAtividade(atividade[0]);
    } else {
      setAtividade({id:0});
    }
    setSmShowModalExcluirAtividade(!smShowModalExcluirAtividade)
  };

  const listarAtividades = async () => {
    const response = await apiAtividade.get('atividade');
    return response.data;
  }
  
  useEffect(() => {
    const getAtividades = async () => {
      const todasAtividades = await listarAtividades();
      if (todasAtividades) setListaAtividades(todasAtividades);
    }
    getAtividades();
  }, [])

  const addAtividade = async (ativ) => {
    const response = await apiAtividade.post('atividade', ativ);
    setListaAtividades([...listaAtividades, response.data]);
    handleAbrirOuFecharModalAtividade();
  }

  const atualizarAtividade = async (ativ) => {
    const response = await apiAtividade.put('atividade/', ativ);
    const { id } = response.data;
    setListaAtividades(listaAtividades.map(p => p.id === id ? response.data : p));
    setAtividade({id: 0});
    handleAbrirOuFecharModalAtividade();
  }

  const cancelarAtividade = () => {
    setAtividade({id: 0});
    handleAbrirOuFecharModalAtividade();
  }

  const deletarAtividade = async (id) => {
    toggleModalExcluirAtividade(0);
    if (await apiAtividade.delete(`atividade/${id}`)) {
      const listaAtividadesFiltradas = listaAtividades.filter((p) => p.id !== id);
      setListaAtividades([...listaAtividadesFiltradas]);
   }
  }

  const editarAtividade = (id) => {
    const atividade = listaAtividades.filter((p) => p.id === id);
    setAtividade(atividade[0]);
    handleAbrirOuFecharModalAtividade();
  }

  const ModalAdicionarAtividade = () => {
    setAtividade({id: 0});
    handleAbrirOuFecharModalAtividade();
  }

  return (
    <>
      <TitlePage titulo={'Atividade ' + (atividade.id !==0 ? atividade.id : '')}>
        
        <Button variant="outline-secondary" onClick={ModalAdicionarAtividade}>
          <i className="fas fa-plus"></i>
        </Button>
        
      </TitlePage>


      <AtividadesLista
        toggleModalExcluirAtividade={toggleModalExcluirAtividade}
        editarAtividade={editarAtividade}
        listaAtividades={listaAtividades}
      />

      

      <Modal 
        show={showModalAtividade} 
        onHide={handleAbrirOuFecharModalAtividade}
        fullscreen='md-down'
      >
        <Modal.Header closeButton>
          <Modal.Title>Atividade {atividade.id !==0 ? atividade.id : ''}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AtividadeForm
          addAtividade={addAtividade}
          listaAtividades={listaAtividades}
          atividadeSelecionada={atividade}
          atualizarAtividade={atualizarAtividade}
          cancelarAtividade={cancelarAtividade}
          />
        </Modal.Body>
      </Modal>

      <Modal
        size='sm'
        show={smShowModalExcluirAtividade} 
        onHide={toggleModalExcluirAtividade}
      >
        <Modal.Header closeButton>
          <Modal.Title>
            Ecluir Atividade {' '} 
            {atividade.id !==0 ? atividade.id : ''}
          </Modal.Title>
        </Modal.Header>

        <Modal.Body>
          Tem certeza que deseja excluir a atividade {atividade.id}
        </Modal.Body>

        <Modal.Footer className="d-flex justify-content-beteween">
          <button className="btn btn-outline-success me-2" onClick={() => deletarAtividade(atividade.id)}>
            <i className="fas fa-check me-2"></i>
            Sim
          </button>

          <button className="btn btn-danger" onClick={() => toggleModalExcluirAtividade(0)}>
            <i className="fas fa-times me-2"></i>
            Não
          </button>
        </Modal.Footer>

      </Modal>
    </>
  );
}
