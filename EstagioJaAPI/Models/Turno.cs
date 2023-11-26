using System.ComponentModel;

namespace EstagioJaAPI.Models;
public enum Turno 
{
    [Description("MATUTINO")]
    MATUTINO,
    
    [Description("VESPERTINO")]
    VESPERTINO,

    [Description("NOTURNO")]
    NOTURNO,

    [Description("INTEGRAL")]
    INTEGRAL
}