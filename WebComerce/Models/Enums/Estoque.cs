using System.ComponentModel;

namespace WebComerce.Models.Enums;

public enum Estoque
{
    [Description("Possui")]
    Possui = 1,
    [Description("Vazio")]
    Vazio = 2
}