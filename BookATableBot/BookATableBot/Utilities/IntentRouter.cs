using BookATableBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableBot.Utilities
{
  public class IntentRouter
  {
    public static BotModel Process(BotModel botModel)
    {
      var intentsList = WebApiConfig.IntentHandlers;
      var intent = intentsList.FirstOrDefault(i => i.Key.ToLower() == botModel.Request.Intent.ToLower());
      if (!string.IsNullOrWhiteSpace(intent.Key))
      {
        return intent.Value(botModel);
      }
      if (string.IsNullOrWhiteSpace(botModel.Response.Text))
      {
        botModel.Response.Text = "Sorry, I do not understand. please try again.";
      }
      return botModel;
    }
  }
}