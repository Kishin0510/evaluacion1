using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using evaluacion1.Src.DTOs;
using evaluacion1.Src.Models;
using evaluacion1.Src.Interfaces;


namespace evaluacion1.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("")]
        public async Task<IResult> CreateUser(CreateUserDTO userDTO)
        {
            var exist = await _userRepository.ExistByRut(userDTO.RUT);

            if (exist)
            {
                return TypedResults.Conflict("El RUT ya existe.");
            } else {
                var user = new User
                {
                RUT = userDTO.RUT,
                Name = userDTO.Name,
                Gender = userDTO.Gender,
                Email = userDTO.Email,
                Birthdate = userDTO.Birthdate
                };
                await _userRepository.CreateUser(user);
                return TypedResults.Created("Usuario creado exitosamente.");
            }

        }
    }
}