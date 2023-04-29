
using ExtroHoliday.Api.Controllers;
using ExtroHoliday.Core.Logic.Interface;
using ExtroHoliday.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ExtroHoliday_Test
{
    public class CalendarControllerTest
    {
        [Fact]
        public async Task GetCalendar_Returns_OK_With_Expected_Result()
        {
            // Arrange
            int year = 2023;
            var expected = new List<CalendarForFrontEnd> { new CalendarForFrontEnd() };

            var calendarMock = new Mock<ICalendar>();
            calendarMock.Setup(c => c.DatesToTakeOff(year)).ReturnsAsync(expected);

            var controller = new CalendarController(calendarMock.Object);

            // Act
            var result = await controller.GetCalendar(year);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);

        }

        [Fact]
        public async Task GetCalendar_Returns_NotFound_When_Result_Is_Empty()
        {
            // Arrange
            int year = 2023;
            var expected = new List<CalendarForFrontEnd>();

            var calendarMock = new Mock<ICalendar>();
            calendarMock.Setup(c => c.DatesToTakeOff(year)).ReturnsAsync(expected);

            var controller = new CalendarController(calendarMock.Object);

            // Act
            var result = controller.GetCalendar(year).Result;
            var notFoundResult = result as NotFoundResult;

            // Assert
            Assert.Equal(404, notFoundResult!.StatusCode);
        }
    }
}