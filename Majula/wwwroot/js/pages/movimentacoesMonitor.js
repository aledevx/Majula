const urlGetLista = `/MovimentacoesMonitor/GetListaMovimentacaoMonitor/`
const urlPost = `/MovimentacoesMonitor/PostMovimentacao/`

let banco_movimentacoes = []

function PostMovimentacao() {
    const setor_movimentacao = document.getElementById('setor');
    const monitor_id = document.getElementById('Id');


    const objeto_movimentacao = {
        "Setor": setor_movimentacao.value.trim(),
        "DataAtual": new Date(),
        "Ativo": true,
        "MonitorId": obj_id.value.trim()
    };

    fetch(urlPost, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(objeto_movimentacao),
    }).then(response => response.json)

}