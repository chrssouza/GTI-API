﻿using GTI.Shared.Commands.Interfaces;

namespace GTI.Domain.Commands.Clientes
{
    public class CreateClienteCommand : ICommand
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public DateTime DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public string Uf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
