﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polidom.Core.Models;
using Polidom.Data.Data.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolidomApplication.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields

        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        /// <summary>
        /// <paramref name="userManager"/> <see cref="UserManager{Account}"/> class.
        /// <paramref name="mapper"/> <see cref="IMapper"/> class.
        /// </summary>
        public AccountController(UserManager<Account> userManager , IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                IList<AccountModel> users = await _userManager.Users.Select(user => new AccountModel
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role.ToString(),
                    RegisteredDate = user.RegisterDate
                }).ToListAsync();

                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountToRegister accountToRegister)
        {
            try
            {
                Account account = _mapper.Map<Account>(accountToRegister);
                IdentityResult result = await _userManager.CreateAsync(account, accountToRegister.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors) 
                    { 
                        ModelState.TryAddModelError(error.Code, error.Description); 
                    }
                    return BadRequest(ModelState);
                }

                await _userManager.AddToRoleAsync(account, accountToRegister.Role.ToString());

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]AccountToLogin accountToLogin)
        {
            try
            {
                Account account = await _userManager.FindByEmailAsync(accountToLogin.Email);

                if (account is null)
                    throw new Exception("AccountNotFound");

                if (!await _userManager.CheckPasswordAsync(account, accountToLogin.Password))
                    throw new Exception("InvalidPassword");

                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(AccountToUpdate accountToUpdate)
        {
            try
            {
                Account account = await _userManager.FindByEmailAsync(accountToUpdate.Email);
                account.UserName = accountToUpdate.UserName;
                account.BornDate = accountToUpdate.BornDate;
                account.Name = accountToUpdate.Name;
                account.PhoneNumber = accountToUpdate.PhoneNumber;
                account.Role = accountToUpdate.Role;

                await _userManager.UpdateAsync(account);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}