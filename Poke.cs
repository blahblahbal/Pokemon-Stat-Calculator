using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon_Stat_Calculator
{
    public class Poke
    {
	    public string nature;
	    public int[] IV = new int[6];
	    public int[] EVs = new int[6];
	    public int[] baseStat = new int[6];

	    public Poke(string n, int[] IV, int[] EV, int[] baseStat)
	    {
		    this.nature = n;
		    for (int i = 0; i < 6; i++)
		    {
			    this.IV[i] = IV[i];
			    EVs[i] = EV[i];
                this.baseStat[i] = baseStat[i];
		    }
	    }

	    public bool HasBeneficialNatureForStat(Stat S)
	    {
		    if (S == Stat.ATK && (this.nature.ToLower() == "adamant" || this.nature.ToLower() == "brave" || this.nature.ToLower() == "naughty" || this.nature.ToLower() == "lonely"))
		    {
			    return true;
		    }
		    else if (S == Stat.DEF && (this.nature.ToLower() == "lax" || this.nature.ToLower() == "relaxed" || this.nature.ToLower() == "bold" || this.nature.ToLower() == "impish"))
		    {
			    return true;
		    }
		    else if (S == Stat.SPATK && (this.nature.ToLower() == "modest" || this.nature.ToLower() == "quiet" || this.nature.ToLower() == "mild" || this.nature.ToLower() == "rash"))
		    {
			    return true;
		    }
		    else if (S == Stat.SPDEF && (this.nature.ToLower() == "gentle" || this.nature.ToLower() == "careful" || this.nature.ToLower() == "calm" || this.nature.ToLower() == "sassy"))
		    {
			    return true;
		    }
		    else if (S == Stat.SPEED && (this.nature.ToLower() == "timid" || this.nature.ToLower() == "jolly" || this.nature.ToLower() == "hasty" || this.nature.ToLower() == "naive"))
		    {
			    return true;
		    }
		    return false;
	    }

        public bool HasHinderingNatureForStat(Stat S)
        {
            if (S == Stat.ATK && (this.nature.ToLower() == "modest" || this.nature.ToLower() == "timid" || this.nature.ToLower() == "calm" || this.nature.ToLower() == "bold"))
            {
                return true;
            }
            else if (S == Stat.DEF && (this.nature.ToLower() == "gentle" || this.nature.ToLower() == "hasty" || this.nature.ToLower() == "mild" || this.nature.ToLower() == "lonely"))
            {
                return true;
            }
            else if (S == Stat.SPATK && (this.nature.ToLower() == "adamant" || this.nature.ToLower() == "jolly" || this.nature.ToLower() == "careful" || this.nature.ToLower() == "impish"))
            {
                return true;
            }
            else if (S == Stat.SPDEF && (this.nature.ToLower() == "lax" || this.nature.ToLower() == "naive" || this.nature.ToLower() == "rash" || this.nature.ToLower() == "naughty"))
            {
                return true;
            }
            else if (S == Stat.SPEED && (this.nature.ToLower() == "brave" || this.nature.ToLower() == "relaxed" || this.nature.ToLower() == "quiet" || this.nature.ToLower() == "sassy"))
            {
                return true;
            }
            return false;
        }

	    public bool HasNeutralNature()
	    {
		    return this.nature.ToLower() == "quirky" || this.nature.ToLower() == "hardy" || this.nature.ToLower() == "docile" || this.nature.ToLower() == "bashful" || this.nature.ToLower() == "serious";
	    }

        public enum Stat
        {
            HP = 0,
            ATK = 1,
            DEF = 2,
            SPATK = 3,
            SPDEF = 4,
            SPEED = 5
        };
    }

}
