﻿using DotNetCoreAppExample.Domain.Contatos.Entities;
using DotNetCoreAppExample.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace DotNetCoreAppExample.Domain.Contatos.Interfaces
{
    public interface IContatoRepository : IRepositoryBase<Contato>
    {
        Contato ObterPorEmail(string email);
        ICollection<Contato> ObterAtivos();

        Endereco ObterEnderecoPorId(Guid enderecoId);
        Endereco AdicionarEndereco(Endereco endereco);
        Endereco AtualizarEndereco(Endereco endereco);

        Telefone ObterTelefonePorId(Guid telefoneId);
        Telefone AdicionarTelefone(Telefone telefone);
        Telefone AtualizarTelefone(Telefone telefone);
        void RemoverTelefone(Guid telefoneId);

    }
}
