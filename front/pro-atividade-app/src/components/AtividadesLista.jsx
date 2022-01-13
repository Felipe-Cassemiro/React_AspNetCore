import React from 'react'
import Atividade from "./Atividade";

export default function AtividadesLista(props) {
    return (
        <div className="mt-5">
        {props.listaAtividades.map((ativ) => (
          <Atividade
            key={ativ.id}
            ativ={ativ}
            deletarAtividade={props.deletarAtividade}
            editarAtividade={props.editarAtividade}
          />
        ))}
      </div>
    )
}
