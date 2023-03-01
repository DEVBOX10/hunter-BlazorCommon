using System.Collections.Immutable;

namespace BlazorCommon.RazorLib.Menu;

public record MenuRecord(ImmutableArray<MenuOptionRecord> MenuOptions)
{
    public static readonly MenuRecord Empty = new(
        new[]
        {
            new MenuOptionRecord(
                "No menu options exist for this item.",
                MenuOptionKind.Other)
        }.ToImmutableArray());
}// test if locked branch is still available to myself