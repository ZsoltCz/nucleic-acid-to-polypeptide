import { Container, Typography } from "@mui/material";

export default function Instructions() {

  return (
    <Container sx={{ marginTop: "20px" }}>
      <Typography variant="h5" gutterBottom>
        Welcome to Nucleic Acid To Polypeptide Converter!
      </Typography>
      <Typography variant="h6" gutterBottom>
        Input a DNA or RNA sequence below, select a reading frame and press the translate button!
      </Typography>
      <Typography variant="h6">
        You can change the amino acid display format with the "Amino acid display" button.
      </Typography>
    </Container>
  );
};