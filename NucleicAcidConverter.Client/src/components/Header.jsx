import { AppBar, Container, Typography } from "@mui/material";
import ScienceOutlinedIcon from "@mui/icons-material/ScienceOutlined";

export default function Header() {
  return (
    <AppBar position="static">
      <Container>
        <ScienceOutlinedIcon />
        <Typography display="inline">
          Nucleic Acid To Polypeptide Converter
        </Typography>
      </Container>
    </AppBar>
  );
};
