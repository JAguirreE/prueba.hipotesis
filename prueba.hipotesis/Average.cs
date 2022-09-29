using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.Distributions;

namespace prueba.hipotesis
{
  public partial class Average : Form
  {
    MainMenu mainMenu;

    public Average(MainMenu mainMenu)
    {
      InitializeComponent();
      this.mainMenu = mainMenu;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      mainMenu.Show();
      Close();
    }

    private void textBox1_Leave(object sender, EventArgs e)
    {
      float stdDev = float.Parse(textBox1.Text);
      textBox2.Text = (stdDev * stdDev).ToString();
    }

    private void textBox2_Leave(object sender, EventArgs e)
    {
      float variance = float.Parse(textBox2.Text);
      textBox1.Text = Math.Sqrt(variance).ToString();
    }

    private void textBox3_Leave(object sender, EventArgs e)
    {
      textBox4.Text = (100 - float.Parse(textBox3.Text)).ToString();
    }

    private void textBox4_Leave(object sender, EventArgs e)
    {
      textBox3.Text = (100 - float.Parse(textBox4.Text)).ToString();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        if (textBox1.Value > 0 || textBox2.Value > 0)
        {
          PathOne();
          return;
        }

        if (textBox7.Value >= 30)
        {
          PathTwo();
        }
        else
        {
          PathThree();
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      
    }

    private void PathOne()
    {
      var zc = (textBox5.Value - textBox7.Value) / (textBox1.Value / (decimal)Math.Sqrt(double.Parse(numericUpDown1.Value.ToString())));
      label8.Text = $"Zc = {zc}";
    }

    private void PathTwo()
    {
      var zc = (textBox5.Value - textBox7.Value) / (textBox6.Value / (decimal)Math.Sqrt(double.Parse(numericUpDown1.Value.ToString())));
      label8.Text = $"Zc = {zc}";
      label10.Text = $"gl = {numericUpDown1.Value - 1}";
      double tx4 = (double)textBox4.Value / 100;
      int txx = (int)(numericUpDown1.Value - 1);
      var zag = ExcelFunctions.TInv(tx4, txx);
      label11.Text = $"Z(∝, gl) = {zag}";
      var x = -StudentT.InvCDF(0d, 1d, 8, 0.005);
    }

    private void PathThree()
    {
      var zc = (textBox5.Value - textBox7.Value) / (textBox6.Value / (decimal)Math.Sqrt(double.Parse(numericUpDown1.Value.ToString())));
      label8.Text = $"Zc = {zc}";
    }
  }
}
