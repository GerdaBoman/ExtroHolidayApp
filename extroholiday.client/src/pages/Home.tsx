import styled from "@emotion/styled";

import { Button } from "@mui/material";
import { Link } from "react-router-dom";

const Main = styled.div`
  padding: 0;

  top: 0;
  left: 0;

  width: 100%;
  height: 100%;
  background: rgba(255, 255, 255, 0.5);
  display: flex;
  flex-direction: column;
  align-items: center;
`;
const HomeTitle = styled.h1`
  font-size: 6em;
  align-items: center;
  margin-top: 10rem;
`;

const Description = styled.h3`
  width: 30rem;
`;

const StyledButton = styled(Button)`
  background-color: orange;
  margin-top: 3rem;
`;

const Home = () => {
  return (
    <>
      <Main>
        <HomeTitle>Extro Holiday</HomeTitle>
        <Description>
          <h3>Välkommen!</h3> We're here to help you make the most of your
          holiday time by planning your trips around Sweden's public holidays,
          which are work-free days. By doing so, you can stretch your vacation
          days and enjoy more time off without using up all your precious annual
          leave. With our help, you can plan long weekends and extended breaks
          that allow you to recharge your batteries while getting the most of
          your vacation days.
        </Description>
        <Link to="/planner" style={{ textDecoration: "none" }}>
          <StyledButton variant="contained">Planner</StyledButton>
        </Link>
      </Main>
    </>
  );
};

export default Home;
