const urlGetLista = `/MovimentacoesPc/GetListaMovimentacao/`
const urlPost = `/MovimentacoesPc/PostMovimentacao/`

var banco_objeto = new Object();

var pcId = document.getElementById().value;


GetMovimentacao(pcId);


function PostMovimentacao() {
    const setor_movimentacao = document.getElementById('setor');
    const computador_id = document.getElementById('Id');


    const objeto_movimentacao = {
        "Setor": setor_movimentacao.value.trim(),
        "DataAtual": new Date(),
        "Ativo": true,
        "ComputadorId": computador_id.value.trim()
    };

    fetch(urlPost, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(objeto_movimentacao),
    }).then(response => response.json)

}


function GetMovimentacao(id) {
    fetch(urlGetLista + id).then(responde => responde.json()).then(ObjetoMovimentacao => {
        banco_objeto = ObjetoMovimentacao
        console.log(banco_objeto);
    })
}