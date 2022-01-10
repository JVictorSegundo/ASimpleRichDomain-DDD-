using LeagueStore.Domain.Validation;
using LeagueStore.Domain.ValueObjects;

namespace LeagueStore.Domain.Entities
{
    public class Item : CommonAttributes
    {
        public string Description { get; private set; }
        public string Attributes { get; private set; }
        public Attack Attack { get; private set; }
        public Defense Defense { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //---

        public Item (string name, string description, Attack attack, Defense defense)
        {
            Validate(name, description, attack, defense);
            Attributes = $"Este item oferece: {attack.AttackDamage} de dano de ataque, " +
                $"{defense.Armor} de armadura, {attack.MagicDamage} de dano mágico, {defense.MagicArmor} de defesa mágica e {defense.LifeAmount}" +
                $" de quantidade vida adicional. Use-o sabiamente invocador";
        }
        //---

        public void Update (string name, string description, Attack attack, Defense defense, int categoryId)
        {
            Validate(name, description, attack, defense);
            Attributes = $"Este item oferece: {attack.AttackDamage} de dano de ataque, " +
                $"{defense.Armor} de armadura, {attack.MagicDamage} de dano mágico, {defense.MagicArmor} de defesa mágica e {defense.LifeAmount} " +
                $"de quantidade vida adicional. Use-o sabiamente invocador";
            CategoryId = categoryId;
        }
        //---

        //-----------------------------------------------------------[ Validations ]-----------------------------------------------------------\\
        private void Validate (string name, string description, Attack attack, Defense defense)
        {
            //Name
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(name), "Invalid name. Name is required!");
            DomainValidation.DomainExceptions(name.Length > 20, "Invalid name. The item name is too long! [over 20 characters]");
            DomainValidation.DomainExceptions(string.IsNullOrWhiteSpace(name), "Invalid name. The item name can't be left blank!");
            DomainValidation.DomainExceptions(regx.IsMatch(name), "Invalid name. The item name can't contain special characters!");
            Name = name;

            //Description
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(description), "Invalid description. Description is required!");
            DomainValidation.DomainExceptions(name.Length > 800, "Invalid description. The item description is too long! [over 800 characters]");
            DomainValidation.DomainExceptions(string.IsNullOrWhiteSpace(name), "Invalid description. The description can't be left blank!");
            DomainValidation.DomainExceptions(regx.IsMatch(description), "Invalid name. The item name can't contain special characters!");
            Description = description;

            //Attacks [Attack Damage, Magic Damage]
            DomainValidation.ConvertibleToInt(attack.AttackDamage);
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(attack.AttackDamage), "Invalid attack damage amount. The amount of attack damage is needed!");
            DomainValidation.DomainExceptions(int.Parse(attack.AttackDamage) < 0, "Invalid attack damage amount. The amount of attack damage must to be above 0!");
            DomainValidation.DomainExceptions(int.Parse(attack.AttackDamage) > 100, "Invalid attack damage amount. The amount of attack damage must to be bellow 100!");
            DomainValidation.ConvertibleToInt(attack.MagicDamage);
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(attack.MagicDamage), "Invalid magic damage. The amount of magic damage is needed!");
            DomainValidation.DomainExceptions(int.Parse(attack.MagicDamage) <= 0, "Invalid magic damage amount. The amount of magic damage must to be above 0!");
            DomainValidation.DomainExceptions(int.Parse(attack.MagicDamage) > 100, "Invalid magic damage amount. The amount of magic damage must to be bellow 100!");
            Attack = attack;

            //Defenses [Armor, Life Amount, Magic Armor]
            DomainValidation.ConvertibleToInt(defense.Armor);
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(defense.Armor), "Invalid armor. The amount of armor is needed!");
            DomainValidation.DomainExceptions(int.Parse(defense.Armor) < 0, "Invalid armor amount. The amount of armor must to be above 0!");
            DomainValidation.DomainExceptions(int.Parse(defense.Armor) > 50, "Invalid armor amount. The amount of armor must to be bellow 50!");
            DomainValidation.ConvertibleToInt(defense.LifeAmount);
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(defense.LifeAmount), "Invalid life amount. The amount of life is needed!");
            DomainValidation.DomainExceptions(int.Parse(defense.LifeAmount) < 0, "Invalid attack life amount. The amount of life must to be above 0!");
            DomainValidation.DomainExceptions(int.Parse(defense.LifeAmount) > 300, "Invalid attack life amount. The amount of life must to be bellow 300!");
            DomainValidation.ConvertibleToInt(defense.MagicArmor);
            DomainValidation.DomainExceptions(string.IsNullOrEmpty(defense.MagicArmor), "Invalid magic armor. The amount of magic armor is needed!");
            DomainValidation.DomainExceptions(int.Parse(defense.MagicArmor) < 0, "Invalid magic armor amount. The amount of magic armor must to be above 0!");
            DomainValidation.DomainExceptions(int.Parse(defense.MagicArmor) > 50, "Invalid magic armor amount. The amount of magic armor must to be bellow 50!");
            Defense = defense;
        } 
    }
}
