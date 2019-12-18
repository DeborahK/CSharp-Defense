using APM.SL;
using System;
using System.Diagnostics;
using System.Drawing;
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
      var price = priceTextBox.Text;
      var cost = costTextBox.Text;

      // Calculate and check the profit margin
      var product = new Product();

      decimal calculatedMargin = 0;
      ep.Clear();
      try
      {
        calculatedMargin = product.CalculateMargin(cost, price);
      }
      catch (ValidationException ex) when (ex.ParamName == "cost")
      {
        ep.SetError(costTextBox, ex.Message);
      }
      catch (ValidationException ex) when (ex.ParamName == "price")
      {
        ep.SetError(priceTextBox, ex.Message);
      }

      var isAcceptable = calculatedMargin >= 40;

      if (isAcceptable)
      {
        marginLabel.ForeColor = Color.ForestGreen;
      }
      else
      {
        marginLabel.ForeColor = Color.Red;
      }

      // Display the results
      marginLabel.Text = calculatedMargin.ToString() + "%";
    }

    //protected void costTextbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    //{
    //  try
    //  {
    //    ep.SetError(costTextBox, "");
    //  }
    //  catch (Exception ex)
    //  {
    //    ep.SetError(costTextBox, ex.Message);
    //  }
    //}
  }
}
