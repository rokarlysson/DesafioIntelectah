using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace ApplicationCore.Services
{
    public class PacientesService : IPacientesService
    {
        private readonly IPacientesRepository _repository;
        public PacientesService(IPacientesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<PacienteDto> ListarPacientes()
        {
            return _repository.GetAll()
                .Select(x => new PacienteDto
                {
                    Id = x.Id,
                    Cpf = x.Cpf,
                    Telefone = x.Telefone,
                    Sexo = x.Sexo,
                    DataNascimento = x.DataNascimento,
                    Email = x.Email,
                    Nome = x.Nome
                });
        }

        public PacienteDto BuscarPaciente(int id)
        {
            var entidade = _repository.GetById(id);
            return new PacienteDto
            {
                Id = entidade.Id,
                Cpf = entidade.Cpf,
                Telefone = entidade.Telefone,
                Sexo = entidade.Sexo,
                DataNascimento = entidade.DataNascimento,
                Email = entidade.Email,
                Nome = entidade.Nome
            };
        }

        public void ManterPaciente(PacienteDto paciente)
        {
            var entidade = new Paciente
            {
                Cpf = paciente.Cpf,
                DataNascimento = paciente.DataNascimento,
                Email = paciente.Email,
                Nome = paciente.Nome,
                Sexo = paciente.Sexo,
                Telefone = paciente.TelefoneNumerico()
            };

            if (paciente.Id.HasValue)
            {
                entidade.Id = paciente.Id.Value;
                _repository.Update(entidade);
                _repository.Commit();

                return;
            }

            _repository.Insert(entidade);
            _repository.Commit();
        }

        public void ExcluirPaciente(int id)
        {
            var entidade = _repository.GetById(id);
            _repository.Delete(entidade);
            _repository.Commit();
        }
    }
}
