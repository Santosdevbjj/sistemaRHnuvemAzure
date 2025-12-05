using JornadaEscala.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JornadaEscala.Infrastructure.Persistence
{
    /// <summary>
    /// Classe responsável por popular a tabela JornadaTrabalho com os horários pré-definidos.
    /// Inclui jornadas diurnas e noturnas, tanto para funcionários operacionais quanto para chefia.
    /// </summary>
    public static class JornadaSeeds
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JornadaTrabalho>().HasData(
                // Funcionários sem cargo de chefia (intervalo de 15 minutos)
                new JornadaTrabalho { Id = 1, Nome = "07:00 às 13:15", HoraEntrada = new(7, 0, 0), HoraSaida = new(13, 15, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 2, Nome = "08:00 às 14:15", HoraEntrada = new(8, 0, 0), HoraSaida = new(14, 15, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 3, Nome = "09:00 às 15:15", HoraEntrada = new(9, 0, 0), HoraSaida = new(15, 15, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 4, Nome = "12:00 às 18:15", HoraEntrada = new(12, 0, 0), HoraSaida = new(18, 15, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 5, Nome = "13:00 às 19:15", HoraEntrada = new(13, 0, 0), HoraSaida = new(19, 15, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 6, Nome = "14:00 às 20:15", HoraEntrada = new(14, 0, 0), HoraSaida = new(20, 15, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = false },

                // Jornadas noturnas (operacionais)
                new JornadaTrabalho { Id = 7, Nome = "20:00 às 02:00", HoraEntrada = new(20, 0, 0), HoraSaida = new(2, 0, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = true },
                new JornadaTrabalho { Id = 8, Nome = "21:00 às 03:00", HoraEntrada = new(21, 0, 0), HoraSaida = new(3, 0, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = true },
                new JornadaTrabalho { Id = 9, Nome = "23:00 às 05:00", HoraEntrada = new(23, 0, 0), HoraSaida = new(5, 0, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = true },
                new JornadaTrabalho { Id = 10, Nome = "00:00 às 06:00", HoraEntrada = new(0, 0, 0), HoraSaida = new(6, 0, 0), DuracaoIntervaloMin = 15, PermiteHorarioNoturno = true },

                // Funcionários com cargo de chefia (intervalo de 1 hora)
                new JornadaTrabalho { Id = 11, Nome = "07:00 às 16:00 (Chefia)", HoraEntrada = new(7, 0, 0), HoraSaida = new(16, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 12, Nome = "08:00 às 17:00 (Chefia)", HoraEntrada = new(8, 0, 0), HoraSaida = new(17, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 13, Nome = "09:00 às 18:00 (Chefia)", HoraEntrada = new(9, 0, 0), HoraSaida = new(18, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = false },
                new JornadaTrabalho { Id = 14, Nome = "10:00 às 19:00 (Chefia)", HoraEntrada = new(10, 0, 0), HoraSaida = new(19, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = false },

                // Jornadas noturnas (chefia)
                new JornadaTrabalho { Id = 15, Nome = "17:00 às 01:00 (Chefia)", HoraEntrada = new(17, 0, 0), HoraSaida = new(1, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = true },
                new JornadaTrabalho { Id = 16, Nome = "18:00 às 02:00 (Chefia)", HoraEntrada = new(18, 0, 0), HoraSaida = new(2, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = true },
                new JornadaTrabalho { Id = 17, Nome = "19:00 às 03:00 (Chefia)", HoraEntrada = new(19, 0, 0), HoraSaida = new(3, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = true },
                new JornadaTrabalho { Id = 18, Nome = "23:00 às 07:00 (Chefia)", HoraEntrada = new(23, 0, 0), HoraSaida = new(7, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = true },
                new JornadaTrabalho { Id = 19, Nome = "00:00 às 08:00 (Chefia)", HoraEntrada = new(0, 0, 0), HoraSaida = new(8, 0, 0), DuracaoIntervaloMin = 60, PermiteHorarioNoturno = true }
            );
        }
    }
}
