import { AppBar, Container, Typography } from '@mui/material';
import ScienceOutlinedIcon from "@mui/icons-material/ScienceOutlined";

export default function Header() {
  return (
    <AppBar>
      <Container>
        <ScienceOutlinedIcon />
        <Typography>
          Nucleic Acid To Polypeptide Converter
        </Typography>
      </Container>
    </AppBar>
  );
};
