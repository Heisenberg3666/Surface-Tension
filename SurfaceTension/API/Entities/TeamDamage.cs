using System.ComponentModel;

namespace Surface_Tension.API.Entities
{
    public class TeamDamage
    {
        [Description("The team that this config applies to.")]
        public Team Team { get; set; }

        [Description("The amount of time before damage will occur.")]
        public float Delay { get; set; }

        [Description("The amount of damage that will be dealt.")]
        public int Damage { get; set; }

        [Description("The time between the damage dealt.")]
        public float Interval { get; set; }

        [Description("Whether or not the damage number is a percentage of the players original health.")]
        public bool IsPercent { get; set; }
    }
}
