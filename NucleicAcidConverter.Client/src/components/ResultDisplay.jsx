import { Box, CircularProgress, Container, Typography } from "@mui/material";

const divStyleTemp = {
  display: "inline"
};

export default function ResultDisplay({ translationResult, displayedProperty, loading }) {
  
  return (
    <Container sx={{ marginTop: 2 }}>
      <Typography>Result:</Typography>
      <Box p={2} sx={{ border: "2px solid grey" }}>
        {loading ? (
          <CircularProgress />
        ) : (
          <Typography>
            {translationResult
              .map((aminoAcid) => aminoAcid[displayedProperty])
              .join(" - ")}
          </Typography>
        )}
      </Box>
    </Container>
  );
}
