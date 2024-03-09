import { AppBar, Toolbar, Typography } from "@mui/material";
import ScienceOutlinedIcon from "@mui/icons-material/ScienceOutlined";

export default function Header() {
  return (
    <AppBar position="static">
      <Toolbar>
        <ScienceOutlinedIcon fontSize="large" sx={{ mr: 3 }} />
        <Typography variant="h5">
          Nucleic Acid To Polypeptide Converter
        </Typography>
      </Toolbar>
    </AppBar>
  );
};
