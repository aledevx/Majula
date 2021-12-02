const urlGetSetorAtualEquipamento = `/MovimentacoesEquipamento/GetListaMovimentacao/`

var banco_objeto_equipamento = new Object();

var equipamentoId = document.getElementById('Id').value;

GetMovimentacaoEquipamento(equipamentoId);

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