using BookATableBot.Models;
using Google.Apis.Dialogflow.v2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BookATableBot.Utilities
{
  public class ModelMapper
  {
    internal static BotModel DialogFlowToModel(GoogleCloudDialogflowV2WebhookRequest dFlowResponse)
    {
      var botModel = new BotModel()
      {
        Id = dFlowResponse.ResponseId
      };
      botModel.Session.Id = dFlowResponse.Session;
      botModel.Request.Intent = dFlowResponse.QueryResult.Intent.DisplayName;
      botModel.Request.Parameters = dFlowResponse.QueryResult.Parameters.ToList()
        .ConvertAll(p => new KeyValuePair<string, string>(p.Key, p.Value.ToString()));
      return botModel;
    }

    internal static GoogleCloudDialogflowV2WebhookResponse ModelToDialogFlow(BotModel botModel)
    {
      var response = new GoogleCloudDialogflowV2WebhookResponse()
      {
        FulfillmentText = botModel.Response.Text,
        Source = "BookAtableBot",
      };
      return response;
    }
  }
}