@page "/gestaorecebimento"

@using System.ComponentModel.DataAnnotations

<PageTitle>Gestão de Recebimento</PageTitle>


<div class= "container-recebimento" >
    < h1 class= "titulo" > Gestão de Recebimento</h1>

    <table class= "tabela" >
        < thead >
            < tr >
                < th > Id </ th >
                < th > Proprietário </ th >
                < th > Descrição </ th >
                < th > Tipo </ th >
                < th > Obrigatório </ th >
            </ tr >
        </ thead >
        < tbody >
            @foreach(var campo in Campos)
            {
                < tr >
                    < td > @campo.Id </ td >
                    < td > @campo.Proprietario </ td >
                    < td > @campo.Descricao </ td >
                    < td > @campo.Tipo </ td >
                    < td > @campo.Obrigatorio </ td >
                </ tr >
            }
        </ tbody >
    </ table >
</ div >

@code {
    public class CampoRecebimento
{
    public int Id { get; set; }
    public string Proprietario { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Obrigatorio { get; set; } = string.Empty;
}

private List<CampoRecebimento> Campos = new()
    {
        new CampoRecebimento { Id = 1, Proprietario = "id", Descricao = "Código para a identificação do pagamento.", Tipo = "Int(FK)", Obrigatorio = "Sim" },
        new CampoRecebimento { Id = 2, Proprietario = "Pedido", Descricao = "O produto que foi pedido pelo cliente.", Tipo = "VARCHAR", Obrigatorio = "Sim" },
        new CampoRecebimento { Id = 3, Proprietario = "Valor", Descricao = "O valor do produto.", Tipo = "Float", Obrigatorio = "Sim" },
        new CampoRecebimento { Id = 4, Proprietario = "Forma de pagamento", Descricao = "Qual foi a forma de pagamento; exemplo: Pix, Dinheiro ou Cartão.", Tipo = "VARCHAR - Campo de Seleção", Obrigatorio = "Sim" },
        new CampoRecebimento { Id = 5, Proprietario = "Data e Hora", Descricao = "A data e o horário em que o pagamento foi realizado.", Tipo = "DateTime", Obrigatorio = "Sim" },
        new CampoRecebimento { Id = 6, Proprietario = "Comprovante", Descricao = "O comprovante que o pagamento foi realizado.", Tipo = "VARCHAR - Campo de Seleção", Obrigatorio = "Não" },
        new CampoRecebimento { Id = 7, Proprietario = "Cliente", Descricao = "Dados do cliente.", Tipo = "VARCHAR", Obrigatorio = "Sim" }
    };

    
}