import { Container, Typography } from "@mui/material";

export default function Instructions() {

  return (
    <Container>
      <Typography>
        Welcome to Nucleic Acid To Polypeptide Converter!
        Input a DNA or RNA sequence below, select a reading frame and press the translate button!
        You can change the amino acid display format with the "Amino acid display" button.
      </Typography>
    </Container>
  );
};