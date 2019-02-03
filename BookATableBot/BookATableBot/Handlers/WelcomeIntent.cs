using BookATableBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableBot.Handlers
{
  public class WelcomeIntent
  {
    internal static BotModel Process(BotModel botModel)
    {
      botModel.Response.Text = "Hi! Would you like to book a table? If yes, simply type 'Book a table'";
      return botModel;
    }
  }
}