import './App.css';
import { Component } from "react";

class Wishes extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaWishes: [],
      idUsuario: '',
      descricao: ''
    }
  };

  buscarDesejos = () => {

    fetch('http://localhost:5000/api/Desejos')

    .then(retorno => retorno.json())
    .then(dados => this.setState({listaWishes : dados}))

  .catch (erro => console.log(erro))

  }

  updateEstadoDesc = async (event) => {
    await this.setState({
      descricao : event.target.value

    })

    console.log(this.state.descricao)
  }
  
  updateEstadoUser = async (event) => {
    await this.setState({
      idUsuario : event.target.value

    })
    console.log(this.state.idUsuario)
  }
  cadastrarWish = (event) =>{
    event.preventDefault();

    fetch('http://localhost:5000/api/Desejos', {

      method:'POST',

      body: JSON.stringify({idUsuario : this.state.idUsuario, 
                            descricao : this.state.descricao}),

      headers:{
        "Content-Type" : "application/json"
      }

    })
    .then( console.log("Cadastrado!"))

    .catch(erro => console.log(erro))
    
    .then(this.buscarDesejos)

  }

  componentDidMount() {

    this.buscarDesejos()

  
  }

  render() {
    return (
      <div>
        <main>
          <section id = "tela">
            <h2 id="titulo">Wishlist!</h2>
            <div id = "organizacao">
              <div id="divCadastro">
            <h3>Cadastro</h3>
            <form id= "formCadastro" onSubmit={this.cadastrarWish}>
              <label>Seu ID</label>
              <input type="text" value={this.idUsuario} placeholder="Quem é você? (ID)" onChange ={this.updateEstadoUser} />
              <label>Seu desejo!</label>
              <input type="text" value={this.descricao} placeholder="Qual seu desejo?" onChange ={this.updateEstadoDesc}/>
              <button type = "submit"> Cadastrar </button>
            </form>
            </div>
            <table id="tabelaWishes">
                <thead>
                  <tr>
                    <th>Id usuário</th>
                    <th>Desejo</th>
                  </tr>
                </thead>

                <tbody>
                  {
                    this.state.listaWishes.map((Wish) =>{
                      return(
                        <tr key ={Wish.idDesejo}>
                          <td>{Wish.idUsuario}</td>
                          <td>{Wish.descricao}</td>
                        </tr>
                      )

                    })
                  }
                </tbody>
              </table>
            </div>
          </section>
        </main>
      </div>

    )
  }
}

export default Wishes