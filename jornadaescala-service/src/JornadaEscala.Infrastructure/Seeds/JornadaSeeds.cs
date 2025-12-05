using JornadaEscala.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JornadaEscala.Infrastructure.Persistence;

public static class JornadaSeeds
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JornadaTrabalho>().HasData(
            new JornadaTrabalho { Id = 1, Nome = "07:00 às 13:15", HoraEntrada = new(7,0,0), HoraSaida = new(13,15,0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = false },
            new JornadaTrabalho { Id = 7, Nome = "20:00 às 02:00", HoraEntrada = new(20,0,0), HoraSaida = new(2,0,0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = true },
            new JornadaTrabalho { Id = 11, Nome = "07:00 às 16:00 (Chefia)", HoraEntrada = new(7,0,0), HoraSaida = new(16,0,0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = false }
            // ... completar conforme documento
        );
    }
}
