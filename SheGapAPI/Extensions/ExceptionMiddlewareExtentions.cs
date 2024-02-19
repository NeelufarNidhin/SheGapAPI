using System;
using System.Net;
using Entities.ErrorModel;
using Interfaces;
using Microsoft.AspNetCore.Diagnostics;

namespace SheGapAPI.Extensions
{
	public static  class ExceptionMiddlewareExtentions
	{
		//Extension for WebApplicaion
		public static void ConfigureExceptionhandler(this WebApplication app,ILoggerManager logger)
		{
			//setup UseExceptionHandler middleware  for handling exceptions
			app.UseExceptionHandler(appError =>
			{
				//setup the steps required while an exception occurs
				appError.Run(async context =>
				{
					//statuscode of response set to 500
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

					//content type is set
					context.Response.ContentType = "application/json";

					//Getting details from the IExceptionHandlerFeature from httpContext
					var contextFeature = context.Features.Get  <IExceptionHandlerFeature>();
					if(contextFeature != null)
					{
						//logging details into log file
						logger.LogError($"Something went wrong: {contextFeature.Error}");


						//setting values to errordetails to display
						await context.Response.WriteAsync(new ErrorDetails()
						{
							StatusCode = context.Response.StatusCode,
							Message = "Internal Server Error",

						}.ToString());
					}
				});
			});
		}
	}
}

