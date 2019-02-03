using BookATableBot.Utilities;
using Google.Apis.Dialogflow.v2.Data;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookATableBot.Controllers
{
  public class DialogFlowController : ApiController
  {
    public GoogleCloudDialogflowV2WebhookResponse Post(GoogleCloudDialogflowV2WebhookRequest obj)
    {
      var botModel = ModelMapper.DialogFlowToModel(obj);
      if(botModel == null)
      {
        return null;
      }
      botModel = IntentRouter.Process(botModel);
      return ModelMapper.ModelToDialogFlow(botModel);
    }

    public string Get()
    {
      return "Hello DialogFlow!";
    }
  }
}
