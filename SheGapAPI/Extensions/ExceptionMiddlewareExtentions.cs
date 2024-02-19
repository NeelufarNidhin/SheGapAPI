using System;
using System.Net;
using Entities.ErrorModel;
using Interfaces;
using Microsoft.AspNetCore.Diagnostics;

namespace SheGapAPI.Extensions
{
	public static  class ExceptionMiddlewareExtentions
	{
		//Extention on WebApplicaion
		public static void ConfigureExceptionhandler(this WebApplication app,ILoggerManager logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get  <IExceptionHandlerFeature>();
					if(contextFeature != null)
					{
						logger.LogError($"Something went wrong: {contextFeature.Error}");

						await context.Response.WriteAsync(new ErrorDetails()
						{
							StatusCode = context.Response.StatusCode,
							Message = "Interna;l Server Error",

						}.ToString());
					}
				});
			});
		}
	}
}

