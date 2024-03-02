import { Box, CircularProgress, Container, Grid, Typography } from "@mui/material";

const divStyleTemp = {
  display: "inline"
};

export default function ResultDisplay({ translationResult, displayedProperty, loading }) {
  
  return (
    <Container sx={{ marginTop: 2 }}>
      <Grid container spacing={2}>
        <Grid item xs={10}>
          <Typography>Result:</Typography>
        </Grid>
        <Grid item xs={10}>
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
        </Grid>
      </Grid>
    </Container>
  );
}
