﻿using System;
using ShoppingCart.Models;
using ShoppingCart.Repository.Interfaces;
using ShoppingCart.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Business
{
	public class AccoutBusiness : Controller
	{
		private readonly IAccoutRepository _accoutRepository;

		public AccoutBusiness(IAccoutRepository accoutRepository)
		{
			_accoutRepository = accoutRepository;
		}

		public async Task<UserAuthenticate> Authentication(string user, string pass)
		{
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
			{
                UserAuthenticate result = await _accoutRepository.ViewAuthenticate(user, pass);
                return result;
            }
			else
			{
				return null;
			}
                
        }

		public async Task<TokenBody> GenerateToken(TokenService tokenService, UserAuthenticate user)
		{
            var token = tokenService.GenerateToken(null, user);
            return token;
		}
	}
}

