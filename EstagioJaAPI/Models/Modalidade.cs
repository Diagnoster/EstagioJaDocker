using System.ComponentModel;

namespace EstagioJaAPI.Models;

public enum Modalidade
{
    [Description("PRESENCIAL")]
    PRESENCIAL,

    [Description("SEMIPRESENCIAL")]
    SEMIPRESENCIAL,

    [Description("REMOTO")]
    REMOTO
}