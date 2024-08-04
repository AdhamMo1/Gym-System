namespace Gym.Tests.Controllers
{
    public class SubCategoriesControllerTests
    {
        private readonly Mock<IUnitOfWork> _mockIUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly SubCategoriesController _controller;
        public SubCategoriesControllerTests()
        {
            _mockIUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _controller = new SubCategoriesController(_mockIUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddSubCategory_ReturnsOkResult_WithSubCategory()
        {
            // Arrange
            var subCategoryDto = new AddSubCategoryDto();
            var subCategory = new SubscriptionCategory();
            _mockMapper.Setup(m => m.Map<SubscriptionCategory>(It.IsAny<AddSubCategoryDto>())).Returns(subCategory);
            _mockIUnitOfWork.Setup(u => u.SubCategories.CreateAsync(It.IsAny<SubscriptionCategory>())).ReturnsAsync(subCategory);
            _mockIUnitOfWork.Setup(u => u.Save()).Returns(ValueTask.CompletedTask);
            // Act 
            var actualValue = await _controller.AddSubCategory(subCategoryDto); 
            // Assert
            var okRestult = Assert.IsType<OkObjectResult>(actualValue);
            Assert.Equal(subCategory, okRestult.Value);
        }
        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange 
            var subCategories = new List<SubscriptionCategory>();
            _mockIUnitOfWork.Setup(u => u.SubCategories.ReadAllAsync()).ReturnsAsync(subCategories);
            // Act
            var actualValue = await _controller.GetAll();
            // Assert 
            var okResult = Assert.IsType<OkObjectResult>(actualValue);
            Assert.Equal(subCategories, okResult.Value);
        }
        [Fact]
        public async Task Get_ReturnsOkResult_WithSubscriptionCategoryIEnurmble()
        {
            // Arrange
            var id = "test_id";
            var subCategory = new SubscriptionCategory();
            _mockIUnitOfWork.Setup(u => u.SubCategories.ReadAsync(It.IsAny<string>())).ReturnsAsync(subCategory);
            // Act
            var actualValue = await _controller.Get(id);
            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(actualValue);
            Assert.Equal(subCategory, OkResult.Value);
        }
        [Fact]
        public async Task Update_ReturnsOkResult()
        {
            // Arrange
            var subCategory = new SubscriptionCategory();
            _mockIUnitOfWork.Setup(u => u.SubCategories.Update(It.IsAny<SubscriptionCategory>()));
            _mockIUnitOfWork.Setup(u => u.Save()).Returns(ValueTask.CompletedTask);
            // Act 
            var actualValue = await _controller.Update(subCategory);
            var expected = "Done Successfully!";
            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(actualValue);
            Assert.Equal(expected, OkResult.Value);
        }
        [Fact]
        public async Task Delete_ReturnOkResult()
        {
            // Arrange 
            var id = "test_id";
            _mockIUnitOfWork.Setup(u => u.SubCategories.DeleteAsync(It.IsAny<string>()));
            _mockIUnitOfWork.Setup(u => u.Save()).Returns(ValueTask.CompletedTask);
            // Act
            var actualValue = await _controller.Delete(id);
            var expected = "Done Successfully!";
            // Assert 
            var OkResult = Assert.IsType<OkObjectResult>(actualValue);
            Assert.Equal(expected,OkResult.Value);
        }
    }
}
