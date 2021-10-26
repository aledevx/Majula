const urlGetLista = `/MovimentacoesPc/GetListaMovimentacao/`
const urlPost = `/MovimentacoesPc/PostMovimentacao/`
const urlGetSetores = `/Setores/GetSetores/`

var banco_objeto = new Object();

let setores = document.getElementById('pc_setorId');
setores.length = 0;

let banco_setores_dropdown = [];

var pcId = document.getElementById('Id').value;
 
getSetores();
 
function getSetores(){
    fetch(urlGetSetores).then(responde => responde.json())
    .then(Setores => {
        banco_setores_dropdown = Setores
        let option;
        for (let i =0; i< Setores.length; i++){
            option = document.createElement('option');
            option.innerHTML = `
            ${Setores[i].sigla} - ${Setores[i].descricao}
            `
            option.id = Setores[i].id;
            option.className = 'opt';
            setores.add(option);
        }
    })
}

function PostMovimentacao() {
    var dropdown_setor = document.getElementById('pc_setorId');
    var setor_selecionado = dropdown_setor.options[dropdown_setor.selectedIndex].id;

    const pc_Id = document.getElementById('Id');


    const objeto_movimentacao = {
        "SetorId": setor_selecionado,
        "DataAtual": new Date(),
        "Ativo": true,
        "PcId": pc_Id.value.trim()
    };
    console.log(objeto_movimentacao);
    fetch(urlPost, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(objeto_movimentacao),
    }).then(response => response.json(GetMovimentacao(pcId)))

}

function GetMovimentacao(id) {
    fetch(urlGet + id).then(responde => responde.json()).then(ObjetoMovimentacao => {
        banco_objeto = ObjetoMovimentacao
        atualizar();
    })
}

function GerarHtml(SetorId, DataAtual) {
    const dl_setor = document.createElement('dl');
    dl_setor.classList.add('row');
    dl_setor.innerHTML = `
 <dt class="col-sm-3">Setor atual</dt>
 <dd class="col-sm-2">${SetorId}</dd>
 <dt class="col-sm-4">Data movimentação</dt>
 <dd class="col-sm-3">${DataAtual}</dd>
 `
    document.getElementById('setorAtual').appendChild(dl_setor);
}

function limparSetor() {
    const setor = document.getElementById('setorAtual');
    while (setor.firstChild) {
        setor.removeChild(setor.lastChild);
    }
}

function atualizar() {
    limparSetor();
    GerarHtml(banco_objeto.setor, banco_objeto.dataAtual);
}