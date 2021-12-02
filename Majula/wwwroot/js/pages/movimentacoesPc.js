const urlGetSetorAtualPc = `/MovimentacoesPc/GetListaMovimentacaoPc/`
const urlPostMovPc = `/MovimentacoesPc/PostMovimentacao/`
const urlGetSetoresPc = `/Setores/GetSetores/`

var banco_objeto_pc = new Object();

let setores_pc = document.getElementById('pc_setorId');
setores_pc.length = 0;

let banco_setores_dropdown_pc = [];

var pcId = document.getElementById('Id').value;

GetMovimentacaoPc(pcId);
getSetoresPc();

function getSetoresPc() {
    fetch(urlGetSetoresPc).then(responde => responde.json())
        .then(Setores => {
            banco_setores_dropdown_pc = Setores
            let option;
            for (let i = 0; i < Setores.length; i++) {
                option = document.createElement('option');
                option.innerHTML = `
            ${Setores[i].sigla} - ${Setores[i].descricao}
            `
                option.id = Setores[i].id;
                option.className = 'opt';
                setores_pc.add(option);
            }
        })
}

function PostMovimentacaoPc() {
    var dropdown_setor_pc = document.getElementById('pc_setorId');
    var setor_selecionado_pc = dropdown_setor_pc.options[dropdown_setor_pc.selectedIndex].id;

    const pc_Id = document.getElementById('Id');


    const objeto_movimentacao = {
        "SetorId": setor_selecionado_pc,
        "DataAtual": new Date(),
        "Ativo": true,
        "ComputadorId": pc_Id.value.trim()
    };
    console.log(objeto_movimentacao);
    fetch(urlPostMovPc, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(objeto_movimentacao),
    }).then(response => response.json(GetMovimentacaoPc(pcId)))

}

function GetMovimentacaoPc(id) {
    fetch(urlGetSetorAtualPc + id).then(responde => responde.json()).then(ObjetoMovimentacao => {
        banco_objeto_pc = ObjetoMovimentacao
        atualizar();
    })
}

function GerarHtmlPcMov(SetorId, DataAtual) {
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
    document.getElementById('setorAtualPc').appendChild(dl_setor);
    console.log(banco_objeto_pc);
}

function limparSetorPcMov() {
    const setor = document.getElementById('setorAtualPc');
    while (setor.firstChild) {
        setor.removeChild(setor.lastChild);
    }
}

function atualizar() {
    limparSetorPcMov();
    GerarHtmlPcMov(banco_objeto_pc.setor.sigla, banco_objeto_pc.dataAtual);
}