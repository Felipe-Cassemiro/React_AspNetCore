import "./App.css";

function App() {
  const atividade = [
    {
      Id: 1,
      Descricao: "Primeira Atividade",
    },
    {
      Id: 2,
      Descricao: "Segunda Atividade",
    },
  ];

  return (
    <>
      <form >
        <input id="descricao" type="text" placeholder="descrição"/>
        <input id="id" type="text" placeholder="Id"/>
        <button>+ Atividades</button>
      </form>


      <div className="mt-3">
        <ul className="list-group">
          {atividade.map((ativ) => (
            <li key={ativ.Id} className="list-group-item">
              {ativ.Descricao}
            </li>
          ))}
        </ul>
      </div>
    </>
  );
}

export default App;
