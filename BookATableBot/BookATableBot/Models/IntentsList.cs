using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableBot.Models
{
  public class IntentsList : List<KeyValuePair<string, Func<BotModel, BotModel>>>
  {
    public void Add(string intentName, Func<BotModel,BotModel> function)
    {
      var intent = this.FirstOrDefault(i => i.Key.ToLower() == intentName.ToLower());
      if (string.IsNullOrWhiteSpace(intent.Key))
      {
        Add(new KeyValuePair<string, Func<BotModel, BotModel>>(intentName, function));
      }
    }
  }
}