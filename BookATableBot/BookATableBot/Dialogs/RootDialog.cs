using System;
using System.Threading.Tasks;
using Google.Apis.Dialogflow.v2.Data;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BookATableBot.Dialogs
{
  [Serializable]
  public class RootDialog : IDialog<object>
  {
    //private const string clientAccessToken = "";
    //private static AIConfiguration config = new AIConfiguration(clientAccessToken, SupportedLanguage.English);
    //private static ApiAi apiAi = new ApiAi(config);
    public Task StartAsync(IDialogContext context)
    {
      context.Wait(MessageReceivedAsync);

      return Task.CompletedTask;
    }

    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
      var activity = await result as Activity;

      // calculate something for us to return
      int length = (activity.Text ?? string.Empty).Length;

      // return our reply to the user
      await context.PostAsync($"You sent {activity.Text} which was {length} characters");

      context.Wait(MessageReceivedAsync);
    }
  }
}