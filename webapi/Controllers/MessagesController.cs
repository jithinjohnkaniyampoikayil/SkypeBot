using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace webapi.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {

        // POST: api/Messages
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
           
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            Activity reply = new Activity();
           
            IMessageActivity newMessage = Activity.CreateMessageActivity();
            if (activity.Type == ActivityTypes.Message)
            {
                if (activity != null)
                {
                    
                    int length = (activity.Text ?? string.Empty).Length;
                    // return our reply to the user
                    activity.Text = activity.Text.ToLower();
                    if ("hi hai ho da heeee hello".Contains(activity.Text))
                    {
                        //reply.Type = "typing";
                        //await connector.Conversations.ReplyToActivityAsync(reply);
                        reply = activity.CreateReply($"**Hi, I am notesvillage Bot, It's Nice talking to you. I will help you in downloading notes and tutorials with the help of few simple commands. Please use '//Help' to see available service provided by me.**");
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else
                    {
                        reply = activity.CreateReply($"Sorry I can't understand you. Please use '//Help' to see available service provided by this bot");
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    
                }
            }
        
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }
    
        
    }
}
