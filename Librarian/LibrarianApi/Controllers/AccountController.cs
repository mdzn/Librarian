﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Librarian.API.Models;
using Librarian.API.Repositories;
using Librarian.Entities;
using Microsoft.AspNet.Identity;

namespace Librarian.API.Controllers
{
  [RoutePrefix("api/Account")]
  public class AccountController : ApiController
  {
    private IAuthenticationRepository _repo = null;
    public AccountController(IAuthenticationRepository repo)
    {
      _repo = repo;
    }

    // GET api/Account
    public async Task<IHttpActionResult> Get()
    {
      return Ok(_repo.GetAll());
    }

    // POST api/Account/Register
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IHttpActionResult> Register(UserModel userModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IdentityResult result = await _repo.RegisterUser(userModel);

      IHttpActionResult errorResult = GetErrorResult(result);

      if (errorResult != null)
      {
        return errorResult;
      }

      return Ok();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _repo.Dispose();
      }

      base.Dispose(disposing);
    }

    private IHttpActionResult GetErrorResult(IdentityResult result)
    {
      if (result == null)
      {
        return InternalServerError();
      }

      if (!result.Succeeded)
      {
        if (result.Errors != null)
        {
          foreach (string error in result.Errors)
          {
            ModelState.AddModelError("", error);
          }
        }

        if (ModelState.IsValid)
        {
          // No ModelState errors are available to send, so just return an empty BadRequest.
          return BadRequest();
        }

        return BadRequest(ModelState);
      }

      return null;
    }
  }
}