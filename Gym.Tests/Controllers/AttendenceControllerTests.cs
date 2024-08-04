namespace Gym.Tests.Controllers
{
    public class AttendenceControllerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AttendenceController _controller;

        public AttendenceControllerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AttendenceController(_mockUnitOfWork.Object, _mockMapper.Object);
        }
        [Fact]
        public async Task AddAttendence_ReturnOkResult_WithAttendence()
        {
            // Arrange
            var id = Guid.NewGuid();
            var attendence = new Attendence();
            _mockUnitOfWork.Setup(u => u.Attendences.CreateAsync(It.IsAny<Attendence>())).ReturnsAsync(attendence);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(ValueTask.CompletedTask);
            // Act
            var actualValue = await _controller.AddAttendence(id);
            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(actualValue);
            Assert.Equal(attendence, OkResult.Value);
        }
        [Fact]
        public async Task GetAll_ReturnOkResult_WithAttendenceIEnumerable()
        {
            // Arrange
            var Attendences = new List<Attendence>();
            _mockUnitOfWork.Setup(u => u.Attendences.ReadAllAsync()).ReturnsAsync(Attendences);
            // Act 
            var actualValue = await _controller.GetAll();
            // Assert 
            var OkResult = Assert.IsType<OkObjectResult>(actualValue);
            Assert.Equal(Attendences, OkResult.Value);
        }
    }
}
