using OOPReview1;
namespace NhlSystemTest1
{
    [TestClass]
    public class RosterTest
    {
        [TestMethod]
        [DataRow(97,"Connor McDavid",NhlPosition.C)]
        [DataRow(18, "Zach Hyman", NhlPosition.LW)]
        [DataRow(25, "Darnell Nurse", NhlPosition.D)]
        public void Constructor_ValidValues_SetsNoNamePosition(
            int playerNo,
            string playerName,
            NhlPosition playerPosition)
        {
            //perform these 3 task
            //arrange
                NhlRoster validPlayer1 = new NhlRoster(playerNo,playerName,playerPosition);

            //act//assert//for testing cosntructor you can combine act and assert
            Assert.AreEqual(playerNo, validPlayer1.Number);
            Assert.AreEqual(playerName, validPlayer1.Name);
            Assert.AreEqual(playerPosition,validPlayer1.playerPosition);

        }
        [TestMethod]
        [DataRow(-1)]
        [DataRow(99)]
        public void Number_InvalidNumber_ThrowsArgumentOutOfRangeException(int playerNumber)
        {
          


            //act and assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>( () => 
            {
                //arrange
                NhlRoster invalidPlayer1 = new NhlRoster(playerNumber, "Connor McDavid", NhlPosition.C);
            }
            );
            Assert.AreEqual("Invalid Jersey Number. Must choose between 0 and 98", exception.ParamName);
        }
        public void Name_InvalidName_ThrowsNulArgumentException()
        {

        }
    }
}