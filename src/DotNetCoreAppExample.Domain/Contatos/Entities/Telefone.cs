﻿using DotNetCoreAppExample.Domain.Core;
using FluentValidation;
using System;

namespace DotNetCoreAppExample.Domain.Contatos.Entities
{
    public class Telefone : EntityBase<Telefone>
    {
        public Telefone(Guid id, int ddd, string numero, Guid contatoId)
        {
            Id = Guid.NewGuid();
            DDD = ddd;
            Numero = numero;
            ContatoId = contatoId;
        }

        // Construtor para o EF
        protected Telefone() { }

        public int DDD { get; private set; }
        public string Numero { get; private set; }
        public Guid ContatoId { get; private set; }

        // EF propriedades de navegacao
        public virtual Contato Contato { get; private set; }

        public override bool EstaValido()
        {
            ValidarNumero();

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        #region  [ Validações ]

        private void ValidarNumero()
        {
            RuleFor(c => c.DDD)
                .NotEmpty().WithMessage("O DDD precisa ser fornecido")
                .Must(d => d.ToString().Length == 2).WithMessage("DDD deve ter 2 caracteres");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O Numero precisa ser fornecido")
                .Length(1, 10).WithMessage("O Numero precisa ter entre 1 e 10 caracteres");
        }

        #endregion  [ Validações ]
    }
}
