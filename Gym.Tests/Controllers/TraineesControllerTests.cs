namespace Gym.Tests.Controllers
{
    public class TraineesControllerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TraineesController _controller;

        public TraineesControllerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _controller = new TraineesController(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddTrainee_ReturnsOkResult_WithTrainee()
        {
            // Arrange
            var traineeInDto = new TraineeInDto();
            var trainee = new Trainee();
            _mockMapper.Setup(m => m.Map<Trainee>(It.IsAny<TraineeInDto>())).Returns(trainee);
            _mockUnitOfWork.Setup(u => u.Trainees.CreateAsync(It.IsAny<Trainee>())).ReturnsAsync(trainee);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(ValueTask.CompletedTask);

            // Act
            var result = await _controller.AddTrainee(traineeInDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(trainee, okResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithTraineeDetailsOutDto()
        {
            // Arrange
            var traineeId = "test_id";
            var trainee = new Trainee();
            var traineeDetailsOutDto = new TraineeDetailsOutDto();
            _mockUnitOfWork.Setup(u => u.Trainees.ReadAsync(It.IsAny<string>())).ReturnsAsync(trainee);
            _mockMapper.Setup(m => m.Map<TraineeDetailsOutDto>(It.IsAny<Trainee>())).Returns(traineeDetailsOutDto);

            // Act
            var result = await _controller.Get(traineeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(traineeDetailsOutDto, okResult.Value);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithTraineeOutDtoEnumerable()
        {
            // Arrange
            var trainees = new List<Trainee> { new Trainee(), new Trainee() };
            var traineeOutDtos = new List<TraineeOutDto> { new TraineeOutDto(), new TraineeOutDto() };
            _mockUnitOfWork.Setup(u => u.Trainees.ReadAllAsync()).ReturnsAsync(trainees);
            _mockMapper.Setup(m => m.Map<IEnumerable<TraineeOutDto>>(It.IsAny<IEnumerable<Trainee>>())).Returns(traineeOutDtos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(traineeOutDtos, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsOkResult()
        {
            // Arrange
            var updateTraineeDto = new UpdateTraineeDto { Id = Guid.NewGuid() };
            var trainee = new Trainee();
            _mockMapper.Setup(m => m.Map<Trainee>(It.IsAny<UpdateTraineeDto>())).Returns(trainee);
            _mockUnitOfWork.Setup(u => u.Trainees.Update(It.IsAny<Trainee>()));
            _mockUnitOfWork.Setup(u => u.Save()).Returns(ValueTask.CompletedTask);

            // Act
            var result = await _controller.Update(updateTraineeDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Done Successfully.", okResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            // Arrange
            var traineeId = "test_id";
            var trainee = new Trainee();
            _mockUnitOfWork.Setup(u => u.Trainees.ReadAsync(It.IsAny<string>())).ReturnsAsync(trainee);
            _mockUnitOfWork.Setup(u => u.Trainees.DeleteAsync(It.IsAny<string>())).Returns(ValueTask.CompletedTask);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(ValueTask.CompletedTask);

            // Act
            var result = await _controller.Delete(traineeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Done Successfully.", okResult.Value);
        }
    }
}
