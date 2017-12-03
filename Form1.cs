using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_Stat_Calculator
{
    public partial class frmStatCalc : Form
    {
        public frmStatCalc()
        {
            InitializeComponent();
        }
        public int level100_statcalc(Poke P, Poke.Stat S)
        {
            int baseStat = P.baseStat[(int)S];
            int level100_Stat = baseStat * 2;

            if (S == Poke.Stat.HP)
            {
                level100_Stat += 41;
            }
            else
            {
                level100_Stat += 36;
            }

            level100_Stat -= (31 - P.IV[(int)S]);
            level100_Stat += (int)(P.EVs[(int)S] / 4);

            

            if (S == Poke.Stat.HP)
            {
                level100_Stat += 100;
            }
            else
            {
                if (P.HasNeutralNature()) return level100_Stat;
                if (P.HasBeneficialNatureForStat(S))
                {
                    level100_Stat += (int)((baseStat * 2 + 36 - (31 - P.IV[(int)S]) + (int)(P.EVs[(int)S] / 4)) * 0.1);
                }
                else if (P.HasHinderingNatureForStat(S))
                {
                    level100_Stat -= (int)((baseStat * 2 + 36 - (31 - P.IV[(int)S]) + (int)(P.EVs[(int)S] / 4)) * 0.1);
                }
                else if (P.HasNeutralNature())
                {
                    level100_Stat += 0;
                }
            }

            if (S == Poke.Stat.HP)
            {
                level100_Stat = ((level100_Stat - 10) * (Convert.ToInt32(txtLevel.Text)) / 100) + 10;
            }
            else
            {
                level100_Stat = ((level100_Stat - 5) * (Convert.ToInt32(txtLevel.Text)) / 100) + 5;
            }
            return level100_Stat;
        }

        private void frmStatCalc_Load(object sender, EventArgs e)
        {
            lblLEVEL100ATK.Text = lblLEVEL100DEF.Text = lblLEVEL100HP.Text = lblLEVEL100SPATK.Text = lblLEVEL100SPDEF.Text = lblLEVEL100SPEED.Text = string.Empty;
        }
        private bool IsNumeric(string text)
        {
            int n;
            bool numeric = int.TryParse(text, out n);
            return numeric;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
	        {
		        if (c is TextBox)
		        {
                    if (c.Text == string.Empty) // && (IsNumeric(c.Text) && c != txtNature))
                    {
                        MessageBox.Show("Error; please fill out all fields.", "Error");
                        return;
                    }
		        }
	        }
            //int level = Convert.ToInt32(txtLevel.Text);

	        string nature = txtNature.Text;
	        int[] IVs = new int[6];
	        int[] EVs = new int[6];
	        int[] baseStat = new int[6];

	        baseStat[0] = Convert.ToInt32(txtHPbaseStat.Text);
	        baseStat[1] = Convert.ToInt32(txtATKbaseStat.Text);
	        baseStat[2] = Convert.ToInt32(txtDEFbaseStat.Text);
	        baseStat[3] = Convert.ToInt32(txtSPATKbaseStat.Text);
            baseStat[4] = Convert.ToInt32(txtSPDEFbaseStat.Text);
            baseStat[5] = Convert.ToInt32(txtSPEEDbaseStat.Text);

	        IVs[0] = Convert.ToInt32(txtHPIV.Text);
	        IVs[1] = Convert.ToInt32(txtATKIV.Text);
	        IVs[2] = Convert.ToInt32(txtDEFIV.Text);
	        IVs[3] = Convert.ToInt32(txtSPATKIV.Text);
	        IVs[4] = Convert.ToInt32(txtSPDEFIV.Text);
	        IVs[5] = Convert.ToInt32(txtSPEEDIV.Text);

	        EVs[0] = Convert.ToInt32(txtHPEV.Text);
	        EVs[1] = Convert.ToInt32(txtATKEV.Text);
	        EVs[2] = Convert.ToInt32(txtDEFEV.Text);
	        EVs[3] = Convert.ToInt32(txtSPATKEV.Text);
	        EVs[4] = Convert.ToInt32(txtSPDEFEV.Text);
	        EVs[5] = Convert.ToInt32(txtSPEEDEV.Text);

	        Poke P = new Poke(nature, IVs, EVs, baseStat);

	        lblLEVEL100HP.Text = level100_statcalc(P, Poke.Stat.HP).ToString();
	        lblLEVEL100ATK.Text = level100_statcalc(P, Poke.Stat.ATK).ToString();
	        lblLEVEL100DEF.Text = level100_statcalc(P, Poke.Stat.DEF).ToString();
	        lblLEVEL100SPATK.Text = level100_statcalc(P, Poke.Stat.SPATK).ToString();
	        lblLEVEL100SPDEF.Text = level100_statcalc(P, Poke.Stat.SPDEF).ToString();
	        lblLEVEL100SPEED.Text = level100_statcalc(P, Poke.Stat.SPEED).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }
            lblLEVEL100ATK.Text = lblLEVEL100DEF.Text = lblLEVEL100HP.Text = lblLEVEL100SPATK.Text = lblLEVEL100SPDEF.Text = lblLEVEL100SPEED.Text = string.Empty;
        }
    }
}
