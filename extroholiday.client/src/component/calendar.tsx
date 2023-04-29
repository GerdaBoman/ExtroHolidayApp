import FullCalendar from "@fullcalendar/react";
import multiMonthPlugin from "@fullcalendar/multimonth";
import { useState } from "react";
import { IDate } from "../interface/IDate";
import styled from "@emotion/styled";
import { title } from "process";

const StyledCalendar = styled(FullCalendar)`
  width: auto;
  margin: 3rem 3rem 4rem 6rem;

  @media screen and (max-width: 768px) {
    margin: 1rem;
  }
`;
export const CalendarComp = ({
  calendar,
  onDateSelect,
}: {
  calendar: IDate[];
  onDateSelect: (date: Date) => void;
}) => {
  const [currentView, setCurrentView] = useState<string>("multiMonthYear");
  const eventContent = (eventInfo: any) => {
    return { domNodes: [] };
  };

  const handleDatesSet = (arg: any) => {
    const date = arg.start;
    if (onDateSelect) {
      onDateSelect(date);
    }
  };

  return (
    <>
      <div style={{ width: "auto", margin: "3rem 3rem 4rem 6rem" }}>
        <StyledCalendar
          plugins={[multiMonthPlugin]}
          handleWindowResize={true}
          defaultAllDay={true}
          events={calendar}
          eventDisplay="background"
          initialView={currentView}
          datesSet={handleDatesSet}
          aspectRatio={1.5}
          contentHeight={700}
          eventContent={eventContent}
        />
      </div>
    </>
  );
};
