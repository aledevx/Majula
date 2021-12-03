const urlGetSetorAtualEquipamento = `/MovimentacoesEquipamento/GetMovimentacaoAtualEquipamento/`
const urlGetSetoresEquipamento = `/Setores/GetSetores`
const urlPostMovEquipamento = `/MovimentacoesEquipamento/PostMovimentacao/`

var banco_objeto_equipamento = new Object();

let setores_equipamento = document.getElementById('equipamento_setorId');
setores_equipamento.length = 0;

let banco_setores_dropdown_equipamento = [];

var equipamentoId = document.getElementById('Id').value;

GetMovimentacaoEquipamento(equipamentoId);
GetSetoresEquipamento();

function GetSetoresEquipamento() {
    fetch(urlGetSetoresEquipamento).then(response => response.json())
        .then(Setores => {
            banco_setores_dropdown_equipamento = Setores
            let option;
            for (let i = 0; i < Setores.length; i++) {
                option = document.createElement('option');
                option.innerHTML = `
                ${Setores[i].sigla} - ${Setores[i].descricao}
                `
                option.id = Setores[i].id;
                option.className = 'opt';
                setores_equipamento.add(option);
            }
            console.log(banco_setores_dropdown_equipamento);
        })
}

function GetMovimentacaoEquipamento(id) {
    fetch(urlGetSetorAtualEquipamento + id).then(responde => responde.json()).then(ObjetoMovimentacao => {
        banco_objeto_equipamento = ObjetoMovimentacao
        atualizarTelaEquipamento();
    })
}

function limparSetorEquipamentoMov() {
    const setor = document.getElementById('setorAtualEquipamento');
    while (setor.firstChild) {
        setor.removeChild(setor.lastChild);
    }
}

function atualizarTelaEquipamento() {
    limparSetorEquipamentoMov();
    GerarHtmlEquipamentoMov(banco_objeto_equipamento.setor.sigla, banco_objeto_equipamento.dataAtual);
}

function GerarHtmlEquipamentoMov(SetorId, DataAtual) {
    const dl_setor = document.createElement('dl');
    var date = new Date(DataAtual);
    var dataFormatada = (String(date.getHours()).padStart(2, '0')) + ":" + (String(date.getMinutes()).padStart(2, '0')) + " - " + (String(date.getDate()).padStart(2, '0')) + "/" + String((date.getMonth() + 1)).padStart(2, '0') + "/" + date.getFullYear();

    dl_setor.classList.add('row');
    dl_setor.innerHTML = `
 <dt class="col-sm-3">Setor atual</dt>
 <dd class="col-sm-2">${SetorId}</dd>
 <dt class="col-sm-4">Data movimentação</dt>
 <dd class="col-sm-3">${dataFormatada}</dd>
 `
    document.getElementById('setorAtualEquipamento').appendChild(dl_setor);
    console.log(banco_objeto_equipamento);
}

function PostMovimentacaoEquipamento(){
    //Variavel para pegar o drop e conseguir pegar o valor da option selecionada
    var dropdown_setor_Equipamento = document.getElementById('equipamento_setorId');
    var setor_selecionado_equipamento = dropdown_setor_Equipamento.options[dropdown_setor_Equipamento.selectedIndex].id;

    const equipamento_Id = document.getElementById('Id');

    //Cria o objeto da movimentação do equipamento
    const objeto_movimentacao = {
        "SetorId": setor_selecionado_equipamento,
        "DataAtual": new Date(),
        "Ativo": true,
        "EquipamentoId": equipamento_Id.value.trim()
    };
    //Post da movimentação do equipamento
    fetch(urlPostMovEquipamento, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(objeto_movimentacao),
    }).then(response => response.json(GetMovimentacaoEquipamento(equipamentoId)))
}