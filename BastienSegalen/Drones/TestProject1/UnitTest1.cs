using Drones;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_that_drone_is_taking_orders(){
            // Arrange
            Drone drone = new Drone();
            // Act
            EvacuationState state = drone.GetEvacuationState();
            // Assert
            Assert.AreEqual(EvacuationState.Free, state);
            // Arrange a no-fly zone around the drone
            bool response = drone.Evacuate(new System.Drawing.Rectangle(400,400,200,200));
            // Assert
            Assert.IsFalse(response);
            // because the zone is around the drone
            Assert.AreEqual(EvacuationState.Evacuating, drone.GetEvacuationState());
            // Arrange: remove no-fly zone
            drone.FreeFlight();
            // Assert
            Assert.AreEqual(EvacuationState.Free, drone.GetEvacuationState());}
    }
}