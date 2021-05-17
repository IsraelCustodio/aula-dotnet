using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Models
{
    public enum TipoNotificacao
    {
        danger, info, light, success, warning
    }

    public class Notificacao
    {
        public string Mensagem { get; set; }
        public TipoNotificacao Tipo { get; set; }
    }

    public static class Notification
    {
        public static void Set(ITempDataDictionary temp, Notificacao notificacao)
        {
            temp["notify"] = JsonSerializer.Serialize(notificacao);
        }

        public static IHtmlContent Get(ITempDataDictionary temp)
        {
            if (temp["notify"] != null)
            {
                var obj = JsonSerializer.Deserialize<Notificacao>((string)temp["notify"]);

                string html = $"<div class=\"alert alert-{obj.Tipo}\">{obj.Mensagem}</div>";
                return new HtmlContentBuilder().AppendHtml(html);
            }
            else
            {
                return new HtmlContentBuilder().AppendHtml("");
            }
        }
    }
}
