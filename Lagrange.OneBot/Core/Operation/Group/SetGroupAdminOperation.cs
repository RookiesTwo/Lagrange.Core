using System.Text.Json;
using System.Text.Json.Nodes;
using Lagrange.Core;
using Lagrange.Core.Common.Interface.Api;
using Lagrange.OneBot.Core.Entity.Action;

namespace Lagrange.OneBot.Core.Operation.Group;

[Operation("set_group_admin")]
public class SetGroupAdminOperation : IOperation
{
    public async Task<OneBotResult> HandleOperation(BotContext context, JsonNode? payload)
    {
        var message = payload.Deserialize<OneBotSetGroupAdmin>();

        if (message != null)
        {
            bool _ = await context.SetGroupAdmin(message.GroupId, message.UserId, message.Enable);
            return new OneBotResult(null, 0, "ok");
        }

        throw new Exception();
    }
}