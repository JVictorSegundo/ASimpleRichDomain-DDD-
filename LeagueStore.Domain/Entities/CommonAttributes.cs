using System.Text.RegularExpressions;

namespace I_LeagueStore.Domain.Entities
{
    public abstract class CommonAttributes
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        protected Regex regx = new Regex("[-!@#$%¨&*()_+=`´{[ª}º^~?/°:;>.<,|+*/]");
    }
}
