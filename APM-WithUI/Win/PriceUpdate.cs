using APM.SL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win
{
  public partial class PriceUpdate : Form
  {
    public PriceUpdate()
    {
      InitializeComponent();
    }

    private void Calculate_Click(object sender, EventArgs e)
    {
      // Calculate and check the profit margin
      var price = priceTextBox.Text;
      var cost = costTextBox.Text;

      var product = new Product();
      var calculatedMargin = product.CalculateMargin(cost, price);

      var isAcceptable = calculatedMargin >= 40;

      if (isAcceptable)
      {
        marginLabel.ForeColor = Color.ForestGreen;
      } else
      {
        marginLabel.ForeColor = Color.Red;
      }

      // Display the results
      marginLabel.Text = calculatedMargin.ToString() + "%";
    }
  }
}
