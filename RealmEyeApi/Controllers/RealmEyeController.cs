﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealmEyeNET.Constants;
using RealmEyeNET.Error;
using RealmEyeNET.Scraper;

namespace RealmEyeApi.Controllers
{
	[ApiController]
	[Route("api/realmeye")]
	public class RealmEyeController : Controller
	{
		private readonly ILogger<RealmEyeController> _logger;

		public RealmEyeController(ILogger<RealmEyeController> logger)
		{
			_logger = logger;
		}

		[HttpGet("basics/{name}")]
		public JsonResult GetBasicData(string name)
		{
			try
			{
				var profile = new PlayerScraper(name)
					.ScrapePlayerProfile();
				return profile.Status == ApiStatusCode.Success
					? new JsonResult(profile)
					: new JsonResult(new ApiResponse(profile.Status).GetMessage());
			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetBasicData (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}

		[HttpGet("char/{name}")]
		public JsonResult GetCharacterData(string name)
		{
			try
			{
				var characterData = new PlayerScraper(name)
					.ScrapCharacterInformation();
				return characterData.Status == ApiStatusCode.Success
					? new JsonResult(characterData)
					: new JsonResult(new ApiResponse(characterData.Status).GetMessage());
			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetCharacterData (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}

		[HttpGet("pets/{name}")]
		public JsonResult GetPetYard(string name)
		{
			try
			{
				var pets = new PlayerScraper(name)
					.ScrapPetYard();
				return pets.Status == ApiStatusCode.Success
					? new JsonResult(pets)
					: new JsonResult(new ApiResponse(pets.Status).GetMessage());

			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetPetYard (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}

		[HttpGet("graveyard/{name}/{amount?}")]
		public JsonResult GetGraveyard(string name, int amount = -1)
		{
			try
			{
				var gy = new PlayerScraper(name)
					.ScrapGraveyard(amount);
				return gy.Status == ApiStatusCode.Success
					? new JsonResult(gy)
					: new JsonResult(new ApiResponse(gy.Status).GetMessage());
			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetGraveyard (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}

		[HttpGet("graveyardsummary/{name}")]
		public JsonResult GetGraveyardSummary(string name)
		{
			try
			{
				var gys = new PlayerScraper(name)
					.ScrapeGraveyardSummary();
				return gys.Status == ApiStatusCode.Success
					? new JsonResult(gys)
					: new JsonResult(new ApiResponse(gys.Status).GetMessage());
			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetGraveyardSummary (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}

		[HttpGet("namehistory/{name}")]
		public JsonResult GetNameHistory(string name)
		{
			try
			{
				var nh = new PlayerScraper(name)
					.ScrapeNameHistory();
				return nh.Status == ApiStatusCode.Success
					? new JsonResult(nh)
					: new JsonResult(new ApiResponse(nh.Status).GetMessage());
			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetNameHistory (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}

		[HttpGet("guildhistory/{name}")]
		public JsonResult GetGuildHistory(string name)
		{
			try
			{
				var gh = new PlayerScraper(name)
					.ScrapGuildHistory();
				return gh.Status == ApiStatusCode.Success
					? new JsonResult(gh)
					: new JsonResult(new ApiResponse(gh.Status).GetMessage());
			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetNameHistory (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}

		[HttpGet("rankhistory/{name}")]
		public JsonResult GetRankHistory(string name)
		{
			try
			{
				var rh = new PlayerScraper(name)
					.ScrapeRankHistory();
				return rh.Status == ApiStatusCode.Success
					? new JsonResult(rh)
					: new JsonResult(new ApiResponse(rh.Status).GetMessage());
			}
			catch (Exception e)
			{
				_logger.Log(LogLevel.Error, e, $"Error Occurred @ GetNameHistory (Name: {name})");
				return new JsonResult(new ApiResponse(ApiStatusCode.UnspecifiedError).GetMessage());
			}
		}
	}
}
