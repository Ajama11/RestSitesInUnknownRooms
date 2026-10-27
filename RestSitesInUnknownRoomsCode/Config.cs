using BaseLib.Config;

namespace RestSitesInUnknownRooms.RestSitesInUnknownRoomsCode;

internal class Config : SimpleModConfig
{
    [ConfigSlider(Format = "{0}%")]
    public static float Chance { get; set; } = 5f;
}