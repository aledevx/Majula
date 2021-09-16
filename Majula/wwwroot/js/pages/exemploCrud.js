const urlGetRecuperacao = '/ObraRecuperacoes/GetObraRecuperacao/'
const urlGetRecuperacaoList = '/ObraRecuperacoes/GetListObraRecuperacao/'
const urlPostRecuperacao = '/ObraRecuperacoes/PostObraRecuperacao/'
const urlDeleteRecuperacao = '/ObraRecuperacoes/DeleteObraRecuperacao/'
const urlServRecuperacao = '/Servicos/GetServicosRecuperacao'

let dropdown_recuperacao = document.getElementById('dropdown_list_recuperacao');
dropdown_recuperacao.length = 0;

let banco_drop_recuperacao = []

let banco_objetos_recuperacao = []



// Metodo GET para chamar os itens do banco
GetObrasRecuperacao();


// preenche o dropdown com os serviços do tipo Recuperação

function buscar_servicos_recuperacao() {
    fetch(urlServRecuperacao).then(response => response.json())
        .then(Servicos => {
            banco_drop_recuperacao = Servicos
            limparCamposModalRecuperacao();
            let option_recuperacao;
            for (let i = 0; i < Servicos.length; i++) {
                option_recuperacao = document.createElement('option');
                option_recuperacao.text = Servicos[i].descricao;
                option_recuperacao.id = Servicos[i].id;
                option_recuperacao.className = 'opt-recuperacao';
                dropdown_recuperacao.add(option_recuperacao);
            }
        })
}

// Limpa o dropdown impedindo que as informações fiquem duplicadas

function limparCamposModalRecuperacao() {
    document.getElementById('quant_recuperacao').value = '';
    document.getElementById('valor_unit_recuperacao').value = '';
    document.getElementById('data_execucao_recuperacao').value = '';
    const option_recuperacao = document.getElementsByClassName('opt-recuperacao');
    for (let i = 0; i < option_recuperacao.length; i++) {
        option_recuperacao.removeChild(option_recuperacao);
    }
}

// Método POST

function PostRecuperacao() {
    var lista_drop_recuperacao = document.getElementById('dropdown_list_recuperacao');
    var option_selecionada_drop_recuperacao = lista_drop_recuperacao.options[lista_drop_recuperacao.selectedIndex].id;

    const obraId_recuperacao = document.getElementById('Id');
    const quantidade_recuperacao = document.getElementById('quant_recuperacao');
    const valorunitario_recuperacao = document.getElementById('valor_unit_recuperacao');
    const dataexecucao_recuperacao = document.getElementById('data_execucao_recuperacao');


    const objeto_recuperacao = {
        "ObraId": obraId_recuperacao.value.trim(),
        "ServicoId": option_selecionada_drop_recuperacao,
        "Quantidade": parseFloat(quantidade_recuperacao.value.trim()),
        "ValorUnitario": parseFloat(valorunitario_recuperacao.value.trim()),
        "DataExecucao": new Date(dataexecucao_recuperacao.value.trim().replace(/(\d+[/])(\d+[/])/, '$2$1')),
    };
    fetch(urlPostRecuperacao, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(objeto_recuperacao),
    }).then(response => response.json(GetObrasRecuperacao()),).then(() => { })
}

// Método GET

function GetObrasRecuperacao() {
    fetch(urlGetRecuperacaoList).then(response => response.json()).then(ObjetoRecuperacao => {
        banco_objetos_recuperacao = ObjetoRecuperacao
        atualizarTelaRecuperacao();
    })
}


// Popula a tabela com a lista de artes especiais

function criarHtmlRecuperacao(Id, ServicoId, Quantidade, ValorUnitario, DataExecucao) {
    const tr_recuperacao = document.createElement('tr');
    tr_recuperacao.classList.add('tr_recuperacao');
    tr_recuperacao.innerHTML = `
    <td>${ServicoId}</td>
    <td>${Quantidade}</td>
    <td>${ValorUnitario}</td>
    <td>${DataExecucao}</td>
   <td> <button type="button" class="btn btn-danger" onclick="DeleteRecuperacao('${Id}')"> Deletar </button> </td>
    `
    document.getElementById('corpoTabelaRecuperacao').appendChild(tr_recuperacao);
}

// Atualiza a tela buscando os objetos e populando a tabela novamente

function atualizarTelaRecuperacao() {
    limparCorpoTabelaRecuperacao();
    banco_objetos_recuperacao.forEach(obj => criarHtmlRecuperacao(obj.id, obj.servico.descricao, obj.quantidade, obj.valorUnitario, obj.dataExecucao));
}

// limpa a tabela toda vez que for inserido um obj novo
function limparCorpoTabelaRecuperacao() {
    const tabelaRecuperacao = document.getElementById('corpoTabelaRecuperacao');
    while (tabelaRecuperacao.firstChild) {
        tabelaRecuperacao.removeChild(tabelaRecuperacao.lastChild);
    }
}


// Método DELETE
function DeleteRecuperacao(id){
    fetch(urlDeleteRecuperacao + id, {
        method: 'DELETE',
    }).then(res => res.text(GetObrasRecuperacao()));
}