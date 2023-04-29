using ExtroHoliday.Core.Logic.Interface;
using ExtroHoliday.Domain.DTO;
using Moq;

namespace ExtroHoliday_Test;

public class CalendarTests
{

    private Mock<ICalendar> Calendar { get; set; }

    private readonly ICalendar _sut;

    int year = 2023;

    public CalendarTests()
    {

        Calendar = new Mock<ICalendar>();
        _sut = Calendar.Object;
    }

    [Fact]
    public async Task GetCalendarWithValues_Returns_A_List()
    {
        // Arrange


        var expectedResults = new List<GetRedDaysDTO>()
            {
             new GetRedDaysDTO() { Date = new DateOnly(2023, 5, 1) },
             new GetRedDaysDTO() { Date = new DateOnly(2023, 5, 17) },
             new GetRedDaysDTO() { Date = new DateOnly(2023, 12, 25) }
             };
        Calendar.Setup(c => c.GetCalendarWithValues(year)).ReturnsAsync(expectedResults);

        // Act
        var result = await _sut.GetCalendarWithValues(year);

        // Assert
        Assert.NotEmpty(result);
        Assert.IsType<List<GetRedDaysDTO>>(result);

    }

    [Fact]
    public async Task DatesToTakeOff_Returns_List_Containing_2023_12_24_As_Red_Date()
    {
        // Arrange
        var expectedResults = new List<CalendarForFrontEnd>()
            {
                new CalendarForFrontEnd() { Date = new DateOnly(2023,12,23),DayOfWeek="Lördag", Title="", BackgroundColor="red"},
                new CalendarForFrontEnd() { Date = new DateOnly(2023,12,24),DayOfWeek="Söndag", Title="Julafton", BackgroundColor="red"},
                new CalendarForFrontEnd() { Date =new DateOnly(2023,12,25), DayOfWeek = "Måndag", Title = "Juldagen", BackgroundColor = "red"},
            };
        Calendar.Setup(x => x.DatesToTakeOff(year)).ReturnsAsync(expectedResults);


        var expectedRedDate = new DateOnly(2023, 12, 24);
        // Act
        var result = await _sut.DatesToTakeOff(year);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(result.Any(x => x.Date == expectedRedDate && x.BackgroundColor == "red"));
    }
}



