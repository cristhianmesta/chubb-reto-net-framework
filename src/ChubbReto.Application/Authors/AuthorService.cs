using ChubbReto.Application.Shared;
using ChubbReto.Domain.Entities;
using ChubbReto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChubbReto.Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;


        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<ListAuthorFullDto>> ListAuthorsFull()
        {
            var authors = await _authorRepository.GetAll();

            return authors.Select(x => new ListAuthorFullDto
            {
                Id = x.AuthorId,
                FullName = x.FullName,
                BithDate = x.BirthDate,
                CityOfOrigin = x.CityOfOrigin,
                Email = x.Email
            });
        }

        public async Task<IEnumerable<ListAurthorDto>> ListAuthors()
        {
            var authors = await _authorRepository.GetAll();

            return authors.Select(x => new ListAurthorDto
            {
                Id = x.AuthorId,
                FullName = x.FullName,
            });
        }

        public async Task<Result<int>> CreateAuthor(CreateAuthorDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.NombreCompleto))
                errors.Add("El nombre completo es requerido.");

            var authorExits = await _authorRepository.Exists(dto.NombreCompleto.Trim());

            if (authorExits)
                errors.Add("Ya existe un autor registrado con ese nombre.");

            if (dto.FechaDeNacimiento == default)
                errors.Add("La fecha de nacimiento es requerida.");

            if (string.IsNullOrWhiteSpace(dto.CorreoElectronico) ||
                !Regex.IsMatch(dto.CorreoElectronico, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errors.Add("El correo electrónico es requerido.");

            if (errors.Any())
                return Result<int>.Fail(errors);

            try
            {
                var entity = new Author
                {
                    FullName = dto.NombreCompleto.Trim(),
                    BirthDate = dto.FechaDeNacimiento,
                    CityOfOrigin = dto.CiudadDeProcedencia,
                    Email = dto.CorreoElectronico
                };

                var id = await _authorRepository.Add(entity);

                return Result<int>.Ok(id, "Autor creado correctamente");
            }
            catch (Exception ex)
            {
                // Aqui podríamos escribir en logs
                return Result<int>.Fail("Ocurrió un error al guardar el autor.");
            }
        }
    }
}
