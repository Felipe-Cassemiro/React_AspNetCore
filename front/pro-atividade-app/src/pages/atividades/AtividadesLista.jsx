import React from 'react'
import AtividadeItem from "./AtividadeItem";

export default function AtividadesLista(props) {
    return (
        <div className="mt-5">
        {props.listaAtividades.map((ativ) => (
          <AtividadeItem
            key={ativ.id}
            ativ={ativ}
            toggleModalExcluirAtividade={props.toggleModalExcluirAtividade}
            editarAtividade={props.editarAtividade}
          />
        ))}
      </div>
    )
}
