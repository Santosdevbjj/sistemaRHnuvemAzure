namespace SharedKernel.Events;

public record FuncionarioCreated(int FuncionarioId, string NomeCompleto, string CPF);
public record FuncionarioUpdated(int FuncionarioId, string NomeCompleto, string CPF);
public record FuncionarioDeleted(int FuncionarioId);
