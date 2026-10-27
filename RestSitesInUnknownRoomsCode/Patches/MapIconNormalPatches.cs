using HarmonyLib;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Nodes.Screens.Map;
using MegaCrit.Sts2.Core.Rooms;

namespace RestSitesInUnknownRooms.RestSitesInUnknownRoomsCode.Patches;

[HarmonyPatch(typeof(NNormalMapPoint))]
public static class MapIconNormalPatches
{
    [HarmonyPatch(nameof(NNormalMapPoint.UnknownIconPath))]
    [HarmonyPrefix]
    public static void IconPrefix(RoomType pointType, out RoomType __state)
    {
        __state = pointType;
    }
    
    [HarmonyPatch(nameof(NNormalMapPoint.UnknownIconPath))]
    [HarmonyPostfix]
    public static void IconPostfix(ref string __result, RoomType __state)
    {
        if (__state != RoomType.RestSite) return;
        if (__result != ImageHelper.GetImagePath("atlases/ui_atlas.sprites/map/icons/map_unknown.tres")) return;

        __result = ImageHelper.GetImagePath("atlases/ui_atlas.sprites/map/icons/map_unknown_rest_site.tres");
    }
    
    [HarmonyPatch(nameof(NNormalMapPoint.UnknownOutlinePath))]
    [HarmonyPrefix]
    public static void OutlinePrefix(RoomType pointType, out RoomType __state)
    {
        __state = pointType;
    }
    
    [HarmonyPatch(nameof(NNormalMapPoint.UnknownOutlinePath))]
    [HarmonyPostfix]
    public static void OutlinePostfix(ref string __result, RoomType __state)
    {
        if (__state != RoomType.RestSite) return;
        if (__result != NNormalMapPoint.OutlinePath("map_unknown")) return;

        __result = NNormalMapPoint.OutlinePath("map_rest");
    }
}