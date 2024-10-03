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

        [HttpGet("")]
        public async Task<IResult> GetUsers(string? sort, string? gender)
        {
            if (!string.IsNullOrEmpty(sort) && sort != "asc" && sort != "desc")
            {
                return TypedResults.BadRequest("El parámetro 'sort' debe ser 'asc' o 'desc'.");
            }

            if (!string.IsNullOrEmpty(gender) && gender != "masculino" && gender != "femenino" && gender != "otro" && gender != "prefiero no decirlo")
            {
                return TypedResults.BadRequest("El parámetro 'gender' debe ser 'masculino', 'femenino', 'otro' o 'prefiero no decirlo'.");
            }

            var users = new List<User>();
            if(!string.IsNullOrEmpty(gender) && string.IsNullOrEmpty(sort)) 
            {
                users = await _userRepository.GetUsersByGender(gender);
            }
            if (!string.IsNullOrEmpty(sort) && string.IsNullOrEmpty(gender))
            {
                users = await _userRepository.GetUserDesOrAsc(sort);
            }
            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(gender))
            {
                users = await _userRepository.GetUserDesOrAscByGender(sort, gender);
            } else {
                users = await _userRepository.GetUsers();
            }
            return TypedResults.Ok(users);
    
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                return TypedResults.NotFound("Usuario no encontrado.");
            }
            await _userRepository.DeleteUser(id);
            return TypedResults.Ok("Usuario eliminado exitosamente.");
        }
        
    }
}