using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_Hero_Monster_Classes_Part_2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Character hero = new Character();
            Character monster = new Character();
            Dice dice = new Dice();


            hero.Name = "Aris";
            hero.Health = 100;
            hero.DamageMax = 20;
            hero.AttackBonus = true;

            monster.Name = "myPhone";
            monster.Health = 100;
            monster.DamageMax = 15;
            monster.AttackBonus = false;

            if(hero.AttackBonus)
            {
                monster.Defend(hero.Attack(dice));
            }
            
            if(monster.AttackBonus)
            {
                hero.Defend(monster.Attack(dice));
            }


            while (hero.Health > 0 || monster.Health > 0)
            {
                hero.Defend(monster.Attack(dice));
                monster.Defend(hero.Attack(dice));
                displayResult(hero, monster);
            }

        }

        public void displayResult(Character opponent1, Character opponent2)
        {
            if(opponent1.Health <= 0)
            {
                resultLabel.Text = $"{opponent1.Name} was defeated and has {opponent1.Health} Health left. {opponent2.Name} is the winner.";
            }
            else if(opponent2.Health <= 0)
            {
                resultLabel.Text = $"{opponent2.Name} was defeated and has {opponent2.Health} Health left. {opponent1.Name} is the winner.";
            }
            else if(opponent1.Health <= 0 && opponent2.Health <= 0)
            {
                resultLabel.Text = $"They are both loosers!!!";
            }
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMax { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice attk)
        {
            attk.Sides = 20;
            return attk.Roll();
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }
    }

    public class Dice
    {
        public int Sides { get; set; }

        Random random = new Random();
        public int Roll()
        {
            return random.Next(1, Sides);
        }
    }
}