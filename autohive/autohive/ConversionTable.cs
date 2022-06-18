using System.Numerics;

namespace autohive;

public static class ConversionTable
{
    public static ConversionRow[] Table =
    {
        new ConversionRow("ascension_perks/", new []
        {
            new ConversionElement(new[] { "possible", "custom_tooltip", "NOT", "auth_hive_mind" },
                new string[] {"has_authority=auth_hive_mind"},
                new[] { "gestalt_can_ascend=no" },
                new[]{ "ap_mind_over_matter", "ap_transcendence" }),
            new ConversionElement(new[] { "possible", "custom_tooltip", "NOT", "auth_hive_mind" },
                new string[] {"has_authority=auth_hive_mind"},
                new[] { "gestalt_has_bots=no" },
                new[]{ "ap_the_flesh_is_weak", "ap_synthetic_evolution" })
        })
    };
}