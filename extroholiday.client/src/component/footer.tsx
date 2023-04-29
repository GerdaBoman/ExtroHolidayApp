import styled from "@emotion/styled";
import React from "react";

const StyledFooter = styled.div`
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  height: 2rem;
  text-align: center;
  color: black;
`;

const Footer = () => {
  return <StyledFooter> © Gerda Boman 2023 </StyledFooter>;
};

export default Footer;
