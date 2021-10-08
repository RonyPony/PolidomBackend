using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<Account> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<Account> userManager , IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountToRegister accountToRegister)
        {
            try
            {
                var account = _mapper.Map<Account>(accountToRegister);
                var result = await _userManager.CreateAsync(account, accountToRegister.Password);

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
    }
}
