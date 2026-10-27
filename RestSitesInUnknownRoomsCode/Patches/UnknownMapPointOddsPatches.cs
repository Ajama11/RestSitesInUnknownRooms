using HarmonyLib;
using MegaCrit.Sts2.Core.Odds;
using MegaCrit.Sts2.Core.Rooms;

namespace RestSitesInUnknownRooms.RestSitesInUnknownRoomsCode.Patches;

[HarmonyPatch(typeof(UnknownMapPointOdds))]
public static class UnknownMapPointOddsPatches
{
    public const float RestSiteChance = 0.05f;
    
    [HarmonyPatch(typeof(RunOddsSet), nameof(RunOddsSet.UnknownMapPoint), MethodType.Getter)]
    [HarmonyPostfix]
    public static UnknownMapPointOdds RunOddsSetPostfix(UnknownMapPointOdds __result)
    {
        __result._baseOdds.TryAdd(RoomType.RestSite, RestSiteChance);
        __result._nonEventOdds.TryAdd(RoomType.RestSite, RestSiteChance);
        return __result;
    }
}