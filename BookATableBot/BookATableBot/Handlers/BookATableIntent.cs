using BookATableBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableBot.Handlers
{
  public class BookATableIntent
  {
    internal static BotModel Process(BotModel botModel)
    {
      var time = botModel.Request.Parameters.FirstOrDefault(p => p.Key == "time");
      var date = botModel.Request.Parameters.FirstOrDefault(p => p.Key == "date");
      var number = botModel.Request.Parameters.FirstOrDefault(p => p.Key == "number");

      botModel.Response.Text = "Awesome! Your table for " + number + " is booked for " + date + " at " + time + "Have a nice day!";
      return botModel;
    }
  }
}