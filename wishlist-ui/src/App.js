import './App.css';
import { Component } from "react";

class Wishes extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaWishes: [{idwish:1, idUser : 1, desejo : 'Uma lamborghini'}],
      desejo: ''
    }
  };

  componentDidMount() {
    //
  }

  render() {
    return (
      <div>
        <main>
          <section id = "tela">
            <h2 id="titulo">Wishlist!</h2>
            <div id = "organizacao">
            <h3>Cadastro</h3>
              <table>
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
                        <tr key ={Wish.idwish}>
                          <td>{Wish.idUser}</td>
                          <td>{Wish.desejo}</td>
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