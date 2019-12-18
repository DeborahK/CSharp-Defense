using System;
using Xunit;

namespace APM.SL.Test
{
  public class EmailTest
  {
    [Fact]
    public void SendEmail_WhenValidValues_ShouldReturnTrue()
    {
      // Arrange
      var expected = true;

      // Act
      bool actual = Utility.SendEmail("Jack Harkness", "Today's Meeting",
                                    "Please confirm our 1PM meeting",
                                    DateTime.Now);

      // Assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void SendEmail_WhenOptionalValues_ShouldReturnTrue()
    {
      // Arrange
      var expected = true;

      // Act
      bool actual = Utility.SendEmail("Jack Harkness", "Today's Meeting",
                                    "Please confirm our 1PM meeting",
                                    DateTime.Now,
                                    saveCopy: true, highPriority:true, 
                                    includeSignature: false);

      // Assert
      Assert.Equal(expected, actual);
    }
  }
}
