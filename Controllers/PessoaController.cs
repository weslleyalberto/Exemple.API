﻿using Exemple.API.Application.Command;
using Exemple.API.Application.Models;
using Exemple.API.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exemple.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public PessoaController(IMediator mediator, IRepository<Pessoa> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastraPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ExcluiPessoaCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}
