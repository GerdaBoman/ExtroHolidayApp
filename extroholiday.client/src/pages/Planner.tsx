import { useEffect, useState } from "react";
import { CalendarComp } from "../component/calendar";
import styled from "@emotion/styled";
import { IDate } from "../interface/IDate";

const StyledWorkFree = styled.div`
  background-color: #f0948d;
  border-radius: 4px;
  height: auto;
  width: 10rem;
`;

const StyledRecommended = styled.div`
  background-color: #f7e477;
  border-radius: 4px;
  height: auto;
  width: 10rem;
`;

const Separator = styled.div`
  margin-left: 1rem;
`;

const Legend = styled.div`
  display: fixed;
  flex-direction: row;
  width: 100%;
  justify-content: center;
`;

const Container = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-gap: 20px;
  max-width: 500rem;
  margin: 4rem;
  @media only screen and (min-width: 768px) {
    grid-template-columns: 1fr 1fr;
  }
`;

const Column = styled.div`
  padding: 20px;
`;

const DatesPrinted = styled.div`
  padding: 10px;
  background-color: #fff;
  border-radius: 4px;
  font-size: 0.8em;
`;

const DatesContainer = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
`;
const Planner = () => {
  const [chosenYear, setChosenYear] = useState<number>(
    new Date().getFullYear()
  );

  const [calendar, setCalendar] = useState<IDate[]>([]);

  //Change link to match the new azure api!
  const getCalendar = async (year: number) => {
    const res = await fetch(
      `https://extroholidayapp.azurewebsites.net/api/Caledar?year=${year}`
    );
    const data = await res.json();
    setCalendar(data);
  };

  useEffect(() => {
    getCalendar(chosenYear);
  }, [chosenYear]);

  const handleCalendarDateSelect = (date: Date) => {
    setChosenYear(date.getFullYear());
  };

  const totalDaysOff = () => {
    var total: number = 0;
    calendar.map((day) => {
      total++;
    });
    return (
      <>
        <h2>Total days off : {total}</h2>
      </>
    );
  };

  const totalVacationDays = () => {
    var total: number = 0;
    calendar.map((day) => {
      if (day.dayOfWeek === "Lördag" || day.dayOfWeek === "Söndag") {
        console.log("Weekend");
      } else if (day.title.length > 0) {
        console.log(day.title);
      } else total++;
    });
    return (
      <>
        <h2>Total vacations days needed : {total}</h2>
      </>
    );
  };

  const renderCalendarDays = () => {
    const dateGroups: IDate[][] = [];
    let currentGroup: IDate[] = [];
    calendar.forEach((day, index) => {
      if (
        index === 0 ||
        new Date(calendar[index - 1].date).getTime() !==
          new Date(day.date).getTime() - 86400000
      ) {
        if (currentGroup.length > 0) {
          dateGroups.push(currentGroup);
        }
        currentGroup = [day];
      } else {
        currentGroup.push(day);
      }
    });
    if (currentGroup.length > 0) {
      dateGroups.push(currentGroup);
    }

    return (
      <>
        <DatesContainer>
          {dateGroups.map((group, index) => (
            <DatesPrinted key={index}>
              {group.map((day, index) => (
                <p key={index}>
                  <strong>{day.date.toString()}</strong> :{" "}
                  {day.dayOfWeek === "Lördag" || day.dayOfWeek === "Söndag"
                    ? day.title || day.dayOfWeek
                    : day.title || <u>"Take a day off!"</u>}
                </p>
              ))}
            </DatesPrinted>
          ))}
        </DatesContainer>
      </>
    );
  };

  return (
    <>
      <Container className="container">
        <Column className="leftSide">
          <h3>Calendar</h3>
          <CalendarComp
            calendar={calendar}
            onDateSelect={handleCalendarDateSelect}
          />
          <Legend>
            <Separator>
              <StyledWorkFree>Arbetsfri dag</StyledWorkFree>
            </Separator>
            <Separator>
              <StyledRecommended>Rekommenderad ledighetsdag</StyledRecommended>
            </Separator>
          </Legend>
        </Column>
        <Column className="rightSide">
          <h3>Recommended days to take:</h3>
          {renderCalendarDays()}
          <>
            <div>
              {totalDaysOff()}
              {totalVacationDays()}
            </div>
          </>
        </Column>
      </Container>
    </>
  );
};

export default Planner;
