// Exemplo de steps com SpecFlow (pseudocódigo reduzido)
using TechTalk.SpecFlow;
using FluentAssertions;

[Binding]
public class CadastroFuncionarioSteps
{
    private int _statusCode;
    private bool _eventoPublicado;

    [Given(@"um funcionário com nome ""(.*)"" e CPF ""(.*)""")]
    public void DadoUmFuncionario(string nome, string cpf)
    {
        // preparar DTO...
    }

    [When(@"eu envio a requisição de cadastro")]
    public void QuandoEnvioRequisicao()
    {
        _statusCode = 201;
        _eventoPublicado = true;
    }

    [Then(@"o sistema responde com (.*) Created")]
    public void EntaoStatus(int code) => _statusCode.Should().Be(code);

    [Then(@"publica um evento ""(.*)""")]
    public void EntaoEvento(string evt) => _eventoPublicado.Should().BeTrue();
}
