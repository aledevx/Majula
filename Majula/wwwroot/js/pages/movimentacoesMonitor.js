const urlGet = `/MovimentacoesMonitor/GetListaMovimentacao/`
const urlPost = `/MovimentacoesMonitor/PostMovimentacao/`

var banco_objeto = new Object();

var monitorId = document.getElementById('Id').value;

GetMovimentacao(monitorId);

function PostMovimentacaoMonitor() {
    const setor_movimentacao = document.getElementById('setor');
    const monitor_id = document.getElementById('Id');


    const objeto_movimentacao = {
        "Setor": setor_movimentacao.value.trim(),
        "DataAtual": new Date(),
        "Ativo": true,
        "MonitorId": monitor_id.value.trim()
    };

    fetch(urlPost, {
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

function GerarHtml(Setor, DataAtual) {
    const dl_setor = document.createElement('dl');
    dl_setor.classList.add('row');
    dl_setor.innerHTML = `
 <dt class="col-sm-3">Setor atual</dt>
 <dd class="col-sm-2">${Setor}</dd>
 <dt class="col-sm-4">Data movimentação</dt>
 <dd class="col-sm-3">${DataAtual}</dd>
 `
    document.getElementById('setorAtualMonitor').appendChild(dl_setor);
}

function limparSetor() {
    const setor = document.getElementById('setorAtualMonitor');
    while (setor.firstChild) {
        setor.removeChild(setor.lastChild);
    }
}

function atualizar() {
    limparSetor();
    GerarHtml(banco_objeto.setor, banco_objeto.dataAtual);
}