const urlGet = `/MovimentacoesMonitor/GetListaMovimentacaoMonitor/`
const urlPostMovMonitor = `/MovimentacoesMonitor/PostMovimentacaoMonitor/`
const urlGetSetores = `/Setores/GetSetores/`

var banco_objeto = new Object();

let setores = document.getElementById('monitor_setorId');
setores.length = 0;

let banco_setores_dropdown = [];

var monitorId = document.getElementById('Id').value;

GetMovimentacao(monitorId);

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


function PostMovimentacaoMonitor() {
    var dropdown_setor_monitor = document.getElementById('monitor_setorId');
    var setor_selecionado = dropdown_setor_monitor.options[dropdown_setor_monitor.selectedIndex].id;

    const monitor_id = document.getElementById('Id');


    const objeto_movimentacao = {
        "SetorId": setor_selecionado,
        "DataAtual": new Date(),
        "Ativo": true,
        "MonitorId": monitor_id.value.trim()
    };
    console.log(objeto_movimentacao);
    fetch(urlPostMovMonitor, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(objeto_movimentacao),
    }).then(response => response.json(GetMovimentacao(monitorId)))

}

function GetMovimentacao(id) {
    fetch(urlGet + id).then(responde => responde.json()).then(ObjetoMovimentacao => {
        banco_objeto = ObjetoMovimentacao
        atualizar();

    })
}

function GerarHtml(SetorId, DataAtual) {
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
    document.getElementById('setorAtualMonitor').appendChild(dl_setor);
    console.log(banco_objeto);
}

function limparSetor() {
    const setor = document.getElementById('setorAtualMonitor');
    while (setor.firstChild) {
        setor.removeChild(setor.lastChild);
    }
}

function atualizar() {
    limparSetor();
    GerarHtml(banco_objeto.setor.sigla, banco_objeto.dataAtual);
}